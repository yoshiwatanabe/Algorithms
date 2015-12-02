using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }

        public static void Print(Node node)
        {
            Node n = node;
            while (n != null)
            {
                Console.WriteLine(n.Value);
                n = n.NextNode;
            }
        }
    }

    class MergeLinkedLists
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

            Node B = new Node // {2, 3, 6}
            {
                Value = 2,
                NextNode =
                new Node
                {
                    Value = 3,
                    NextNode =
                    new Node { Value = 6, NextNode = null }
                }
            };

            Node result = Merge(A, B);
            Node.Print(result); // {1, 2, 3, 4, 5, 6}
        }

        public static Node Merge(Node a, Node b)
        {
            Node result = null; // [x]

            if (a == null)
                return b;

            if (b == null)
                return a;

            if (a.Value <= b.Value)
            {
                result = a; // [1]
                result.NextNode = Merge(a.NextNode, b); // [2]
            }
            else
            {
                result = b; // [3]
                result.NextNode = Merge(b.NextNode, a); // [4]
            }

            // NOTE:
            // At [2] we recurse into a new context with two candidates, the two heads of the
            // lists, one being the "next" node of the one that was just promoted as "result"
            // [2] also passes, b "as is" (it was defeated by the less-than-equal test)
            // Also [2]'s recursed call determines what should be the following NextNode.
            // [3] and [4] are to take the *other* list as the winner.
            //
            // Mentally visualize this each invocation is suspending returning the node that was
            // selected as 'result', proceeding to the next invocation. Only when we reach the 
            // termination condition, which is one of the two input list exhaust, then unwinding
            // cause the final list to be built, from the tail to the head!

            return result;
        }
    }
}
