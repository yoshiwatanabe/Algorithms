using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = Sample.GetSmallBalancedBST();

            Node node = null;
            node = FindExact(root, 7);
            Debug.Assert(node != null);
            node = FindExact(root, 2);
            Debug.Assert(node == null);

            node = FindNearst(root, 5, root);
            Debug.Assert(node.Value == 5);

            node = FindNearst(root, 8, root);
            Debug.Assert(node.Value == 7);

            node = FindNearst(root, 9, root);
            Debug.Assert(node.Value == 10);

            node = FindNearst(root, 11, root);
            Debug.Assert(node.Value == 12);
        }

        /// <summary>
        /// Recursively look for a node that is nearest to the target value.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="target"></param>
        /// <param name="nearestSoFar"></param>
        /// <returns></returns>
        private static Node FindNearst(Node node, int target, Node nearestSoFar)
        {
            if (node.Value == target)
            {
                // if exact match is found, its is nearest (same), so return the current node.
                return node;
            }

            if (node.Value < target)
            {
                // If we can't proceed, the current node maybe the nearest. Compare with the nearest so far and return the nearest
                if (node.Right == null)
                {
                    return ChooseNeaestNode(target, node, nearestSoFar);
                }
                else
                {
                    return FindNearst(node.Right, target, ChooseNeaestNode(target, node.Right, nearestSoFar));
                }
            }
            else
            {
                if (node.Left == null)
                {
                    return ChooseNeaestNode(target, node, nearestSoFar);
                }
                else
                {
                    return FindNearst(node.Left, target, ChooseNeaestNode(target, node.Left, nearestSoFar));
                }
            }
        }

        public static Node ChooseNeaestNode(int target, Node a, Node b)
        {
            if (a.Value == b.Value)
            {
                return a;
            }
            else if (Math.Abs(target - a.Value) <= Math.Abs(target - b.Value))
            {
                return a;
            }
            else
            {
                return b;
            }            
        }

        public static Node FindExact(Node node, int target)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value == target)
            {
                return node;
            }

            if (node.Value < target)
            {
                return FindExact(node.Right, target);
            }
            else
            {
                return FindExact(node.Left, target);
            }
        }
    }
}
