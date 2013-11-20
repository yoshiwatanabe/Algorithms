using System;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    class Sample
    {
        public static Node GetSmallBalancedBST()
        {
            //       5
            //      /  \
            //     3    10
            //    / \   / \
            //   1  4  7  12
            //

            Node root = new Node { Value = 5,
                 Left = new Node { Value = 3,
                     Left = new Node { Value = 1 },
                     Right = new Node { Value = 4 } },
                 Right = new Node { Value = 10,
                     Left = new Node { Value = 7 },
                     Right = new Node { Value = 12 } }
            };

            return root;
        }
    }
}

// 8 passed always
// (5), null
// (10), 5
// (7), 10
