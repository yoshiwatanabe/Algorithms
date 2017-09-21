# Sort
## Quicksort

Quicksort is actually slow if the input array is nearly sorted.
Partition function would partitions an input subarray into two partitions:
- Those smaller or equal to the pivot
- Those greater than the pivot.

Why slow? Because this implementation uses the Length-1 element as a strategy for selecting a pivot, and the array is already sorted, all of the other elements will be on the left of the pivot, and nothing on the right of the pivot. This means the new pivot index (where the element divides it into two partitions) will be at Length-2. It merely partitioned the input subarray into one large partition and an empty partition. This would not result in O(log n) time complexity.

