using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    public class DancingLinks
    {
        //root node of the doubly-circular linked list
        private ColumnNode root;
        //will hold the possible solution for the sudoku
        private List<DancingNode> solutionNodes;
        private int[,] solutionBoard;
        private int sudokuSize;
        //an indication that the solution was found
        public bool isSolved;

        public DancingLinks(bool[,] cover, int[,] sudoku)
        {
            this.solutionBoard = sudoku;
            this.sudokuSize = sudoku.GetLength(0);
            this.root = this.CreateDLXBoard(cover);
            this.isSolved = false;
            this.solutionNodes = new List<DancingNode>();
        }

        //The dancing links algorithm
        public void DLX()
        {
            //if a solution is already found - "fold" the recursion.
            if (this.isSolved)
            {
                return;
            }
            //the root is the last column node - means that we found a solution
            if (this.root.right == this.root)
            {
                this.ConvertDancingLinksToBoard();
                this.isSolved = true;
                return;
            }
            //choose the next column node to cover
            ColumnNode columnNode = this.HeuristicColumnSelection();
            columnNode.cover();

            //for all nodes in the row the column node holds
            for (DancingNode rowNode = columnNode.down; rowNode != columnNode; rowNode = rowNode.down)
            {
                //add this node to the possible solution list
                this.solutionNodes.Add(rowNode);
                //cover all the nodes that in the rowNode's row 
                for (DancingNode node = rowNode.right; node != rowNode; node = node.right)
                {
                    node.columnNode.cover();
                }
                //go and cover the next column until we finish
                this.DLX();
                // revert the above cover because it turned out as a wrong choice
                int lastIdx = this.solutionNodes.Count - 1;
                rowNode = this.solutionNodes[lastIdx];
                this.solutionNodes.RemoveAt(lastIdx);
                columnNode = rowNode.columnNode;
                for (DancingNode j = rowNode.left; j != rowNode; j = j.left)
                {
                    j.columnNode.uncover();
                }
            }
            // continue the reverting of the wrong column choice - restore it to the dlx linked list
            columnNode.uncover();
        }

        //According to Dancing Links algorithm, the best column choice is the one that has the fewest rows
        //This function go over the column list and search for the minimum one
        private ColumnNode HeuristicColumnSelection()
        {
            int minRowsAmount = Int32.MaxValue;
            ColumnNode minColumnNode = null;

            //go over all column node lists and search for the ColumnNode with the fewest rows
            ColumnNode columnNode = (ColumnNode)this.root.right;
            while (columnNode != this.root)
            {
                if (columnNode.numOfNodes < minRowsAmount)
                {
                    //new min value and min node
                    minRowsAmount = columnNode.numOfNodes;
                    minColumnNode = columnNode;
                }
                //advance to the next column node
                columnNode = (ColumnNode)columnNode.right;
            }
            return minColumnNode;
        }
        //create the doubly-circular linked lists that matches the cover board
        //return the root column node
        private ColumnNode CreateDLXBoard(bool[,] coverBoard)
        {
            //create the "root" column node
            ColumnNode headerNode = new ColumnNode(-1);
            //create the columns list - header nodes that each one will hold a row of DancingNode.
            List<ColumnNode> columnNodes = new List<ColumnNode>();
            //total columns in cover board (sudoku size * sudoku size * constraints)
            int totalColumns = coverBoard.GetLength(1);
            for (int col = 0; col < totalColumns; col++)
            {
                //create ColumnNode for every column in cover board
                ColumnNode n = new ColumnNode(col);
                //add it to the header list and to the header doubly link list
                columnNodes.Add(n);
                headerNode = (ColumnNode)headerNode.InsertAsRightNode(n);
            }
            //get back the root header node (it is circular so the root will be the right node of the last node)
            headerNode = headerNode.right.columnNode;

            for (int idx = 0; idx < coverBoard.GetLength(0); idx++)
            {
                DancingNode prev = null;
                for (int j = 0; j < totalColumns; j++)
                {
                    //if the constraint is ON
                    if (coverBoard[idx, j])
                    {
                        //create new dancing node for the given column node
                        ColumnNode columnNode = columnNodes[j];
                        DancingNode newNode = new DancingNode(columnNode);
                        if (prev == null)
                        {
                            prev = newNode;
                        }
                        //add this new node to the column node lists and connect it to the DLX board
                        columnNode.up.InsertAsDownNode(newNode);
                        prev = prev.InsertAsRightNode(newNode);
                        columnNode.numOfNodes++;

                    }
                }
            }
            headerNode.numOfNodes = totalColumns;
            return headerNode;
        }

        //This function convert the solution's dancing links list to the actual sudoku solution
        private void ConvertDancingLinksToBoard()
        {
            foreach (DancingNode node in this.solutionNodes)
            {
                DancingNode minNode = this.GetMinNodeInRow(node);
                this.DancingNodeToCell(minNode);
            }
        }

        //This function convert the given dancing node to the actual cell, row, column and value in the sudoku
        private void DancingNodeToCell(DancingNode node)
        {
            int ans1 = node.columnNode.value;
            int ans2 = node.right.columnNode.value;
            int row = ans1 / this.sudokuSize;
            int col = ans1 % this.sudokuSize;
            int value = (ans2 % this.sudokuSize) + 1;
            this.solutionBoard[row, col] = value;
        }

        //This function is go over all nodes in the row of the given node and return the one that holds the minimum value.
        private DancingNode GetMinNodeInRow(DancingNode node)
        {
            DancingNode minNode = node;
            int min = minNode.columnNode.value;
            for (DancingNode tmp = node.right; tmp != node; tmp = tmp.right)
            {
                if (tmp.columnNode.value < min)
                {
                    min = tmp.columnNode.value;
                    minNode = tmp;
                }
            }
            return minNode;
        }
    }
}