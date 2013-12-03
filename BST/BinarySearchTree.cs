using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BST
{
    partial class Program
    {
        /// <summary>
        /// Recursively look for a node that is nearest to the target value.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="target"></param>
        /// <param name="nearestSoFar"></param>
        /// <returns></returns>
        private static Node FindNearestValueNode(Node node, int target, Node nearestSoFar)
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
                    return ChooseNearestNode(target, node, nearestSoFar);
                }
                else
                {
                    return FindNearestValueNode(node.Right, target, ChooseNearestNode(target, node.Right, nearestSoFar));
                }
            }
            else
            {
                if (node.Left == null)
                {
                    return ChooseNearestNode(target, node, nearestSoFar);
                }
                else
                {
                    return FindNearestValueNode(node.Left, target, ChooseNearestNode(target, node.Left, nearestSoFar));
                }
            }
        }

        public static Node ChooseNearestNode(int target, Node a, Node b)
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

        public static Node FindExactValueMatch(Node node, int target)
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
                return FindExactValueMatch(node.Right, target);
            }
            else
            {
                return FindExactValueMatch(node.Left, target);
            }
        }

        public static void TestBinarySearchTree()
        {
            Node root = Sample.GetSmallBalancedBST();

            Node node = null;
            node = FindExactValueMatch(root, 7);
            Debug.Assert(node != null);
            node = FindExactValueMatch(root, 2);
            Debug.Assert(node == null);

            node = FindNearestValueNode(root, 5, root);
            Debug.Assert(node.Value == 5);

            node = FindNearestValueNode(root, 8, root);
            Debug.Assert(node.Value == 7);

            node = FindNearestValueNode(root, 9, root);
            Debug.Assert(node.Value == 10);

            node = FindNearestValueNode(root, 11, root);
            Debug.Assert(node.Value == 12);
        }
    }
}
