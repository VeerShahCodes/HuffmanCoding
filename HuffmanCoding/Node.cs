using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
    public class Node
    {
        public int frequency;
        public char character;
        public Node? left;
        public Node? right;
        public Node(int frequency, char character)
        {
            this.frequency = frequency;
            this.character = character;
            this.left = null;
            this.right = null;
          
        }

        public Node(int frequency)
        {
            this.frequency = frequency;
        }
    }
}
