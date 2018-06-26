using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Sort
{
    
    /// <summary>
    /// 
    /// </summary>
    public class ParentChildSort
    {
        public class Item
        {
            public int Id { get; set; }
            public int OrderBy { get; set; }

            public int? ParentId { get; set; }
        }

        public static Item[] Partition(Item[] items)
        {
            int i = 0;
            int j = items.Length;

            // Partition

            while (i < j)
            {
                if (items[i].ParentId.HasValue)
                {
                    while (j == items.Length || items[j].ParentId.HasValue)
                    {
                        j--;
                    }

                    if (i < j)
                    {
                        var temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                        j--;
                    }
                }

                i++;
            }

            // i at this point will be pointing to an element just passed the last parent. 
            // i is pointing to outside of the array if the input array is all parents only

            return items;
        }

        static ParentChildSort()
        {
            Item[] sorted = null;
            
            sorted = ParentChildSort.Partition(new Item[]
            {
                new Item { Id = 10, OrderBy = 200 },
                new Item { Id = 12, ParentId = 10 },
                new Item { Id = 14, ParentId = 10 },
                new Item { Id = 16, OrderBy = 300 }
            });

            sorted = ParentChildSort.Partition(new Item[]
            {
                new Item { Id = 10, OrderBy = 200 },
                new Item { Id = 12, OrderBy = 300 },
                new Item { Id = 14, OrderBy = 400 },
                new Item { Id = 16, OrderBy = 500 }
            });

            sorted = ParentChildSort.Partition(new Item[]
            {
                new Item { Id = 10, ParentId = 16 },
                new Item { Id = 12, ParentId = 16 },
                new Item { Id = 14, ParentId = 16 },
                new Item { Id = 16, OrderBy = 500 }
            });
        }
    }
}
