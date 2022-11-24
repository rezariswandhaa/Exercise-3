using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    internal class Program
    {
        class Node
        {
            public int rollNumber;
            public string name;
            public Node next;
        }
        class CircularList
        {
            Node LAST;

            public CircularList()
            {
                LAST = null;
            }

            public bool Search(int rollNO, ref Node previous, ref Node current)
            {
                for(previous = current = LAST.next; current != LAST; previous = current, current = current.next)
                {
                    if(rollNO == current.rollNumber)
                        return (true);
                }
                if (rollNO == LAST.rollNumber)
                    return true;
                else
                    return (false);
            }
            public bool listEmpty()
            {
                if (LAST == null)
                    return true;
                else
                    return false;
            }

            public void traverse()
            {
                
            }
        }
        



        static void Main(string[] args)
        {
        }
    }
}
