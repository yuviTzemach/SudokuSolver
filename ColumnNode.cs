using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    public class ColumnNode : DancingNode
    {
        public int numOfNodes;
        public int value;

        //constructor of the ColumnNode class
        public ColumnNode(int value)
        {
            this.InitLinksToItself();
            this.numOfNodes = 0;
            this.value = value;
            this.columnNode = this;
        }

        //This function unlink this ColumnNode and all the rows that it holds
        //This function should get called when this column was chosen in HeuristicColumnSelection().
        public void cover()
        {
            // unlink the column node from the header column node list.
            this.UnlinkLeftRight();

            // go over all the nodes that belong to this column node.
            for (DancingNode node1 = this.down; node1 != this; node1 = node1.down)
            {
                // go over all the nodes that belong to 'node1' row.
                for (DancingNode node2 = node1.right; node2 != node1; node2 = node2.right)
                {
                    // unlink the node from above and below rows
                    node2.UnlinkUpDown();

                    // decrease the relevant column counter as we just unlink a node from this column.
                    node2.columnNode.numOfNodes--;
                }
            }
        }

        /*This function restore the links of this ColumnNode and all the rows that it holds, to the column header list
        It also does the opposite of cover()
        This function should get called after the "bet" on 
        this column, turns out to be a mistake and we need to go back to the previuos state */
        public void uncover()
        {
            //go over all the nodes that belong to this column node
            for (DancingNode node1 = this.up; node1 != this; node1 = node1.up)
            {
                //go over all the nodes that belong to 'node1' row
                for (DancingNode node2 = node1.left; node2 != node1; node2 = node2.left)
                {
                    //decrease the relevant column counter as we just unlink a node from this column
                    node2.columnNode.numOfNodes++;
                    //restore the node's links to be between its former up and down node
                    node2.RelinkUpDown();

                }
            }
            //restore the links for this column node to the header column node list
            this.RelinkLeftRight();
        }
    }
}