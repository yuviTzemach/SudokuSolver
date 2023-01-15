using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    public class DancingNode
    {
        //pointers to other 'DancingNode' in order to create double-circular linked list
        public DancingNode left;
        public DancingNode right;
        public DancingNode up;
        public DancingNode down;
        public ColumnNode columnNode;

        //constructor of the DancingNode
        public DancingNode()
        {
            this.InitLinksToItself();
        }

        public DancingNode(ColumnNode c)
        {
            this.InitLinksToItself();
            this.columnNode = c;
        }

        // initialize all 'this' pointers to point itself
        protected void InitLinksToItself()
        {
            this.right = this;
            this.left = this;
            this.up = this;
            this.down = this;
        }

        /* This function turns the given node to be the new down node of 'this', and takes care of
        the original down node's pointers
        For example, if the original situation was-
        this 
         | (means this's down pointer and node1's up pointer)
        node1
        When running InsertAsDownNode(node2) the result will be:
        this
         |
        node2
         |
        node1 */
        public DancingNode InsertAsDownNode(DancingNode node)
        {
            node.down = this.down;
            node.down.up = node;
            node.up = this;
            this.down = node;
            return node;
        }

        /* This function turns the given node to be the new right node of 'this', and takes care of 
        the original right node's pointers
        For example, if the original situation was:
        this <-> node1
        When running InsertAsRightNode(node2) the result will be:
        this <-> node2 <-> node1 */
        public DancingNode InsertAsRightNode(DancingNode node)
        {
            node.right = this.right;
            node.right.left = node;
            node.left = this;
            this.right = node;
            return node;
        }

        /* This function detach 'this' node from its right and left nodes and connect between them
        For example, if the original situation was:
        node1 <-> this <-> node2
        When running UnlinkLeftRight() the result will be:
        node1 <-> node2 */
        public void UnlinkLeftRight()
        {
            this.left.right = this.right;
            this.right.left = this.left;
        }

        /* This function restores the links between 'this' node and its former right and left nodes
        The function does the opposite of UnlinkLeftRight() - it relinks 'this' pointers to place it 
        back between node1 and node2 */
        public void RelinkLeftRight()
        {
            this.left.right = this;
            this.right.left = this;
        }

        /* This function detach 'this' node from its up and down nodes and connect between them.
        For example, if the original situation was:
        node1
          |
        this
          |
        node2
        When running UnlinkUpDown() the result will be:
        node1
          |
        node2 */
        public void UnlinkUpDown()
        {
            this.up.down = this.down;
            this.down.up = this.up;
        }

        /* This function restores the links between 'this' node and its former up and down nodes
        The function does the opposite of UnlinkUpDown() - it relinks 'this' pointers to place it 
        back between node1 and node2 */
        public void RelinkUpDown()
        {
            this.up.down = this;
            this.down.up = this;
        }
    }
}