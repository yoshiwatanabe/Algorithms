using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    class ReverseLinkedList
    {
        public static void Run()
        {
            Node A = new Node // {1, 4, 5}
            {
                Value = 1,
                NextNode =
                new Node
                {
                    Value = 4,
                    NextNode =
                    new Node { Value = 5, NextNode = null }
                }
            };

            Node r = Reverse(A);
            Node.Print(r);
        }

        private static Node Reverse(Node head)
        {
            Node temp = null; // This makes the last Node of the reversed list to have null.
            Node next = null; // next saver. must evacuate next to help traverse from left to right
            while (head != null) // head may be named as 'i' or 'current' as it just iterates
            {
                next = head.NextNode; // evacuate the next iteration step
                head.NextNode = temp; // temp is "new follower" or "new next". at very 1st iteration, this is null, which is correct
                temp = head; // updatte 'new next' to be pointed by the next iteration context.
                head = next; // moves to the next node.
            }

            return temp; // ends with the last iteration node, which is the new head of the reversed list.
        }
    }
}
