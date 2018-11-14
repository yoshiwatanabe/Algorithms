

# Sort

## Insertion sort

```
public int[] Sort(int[] array)
{
    // [a]
    for (int i = 1; i < array.Length; i++)
    {         
        // [b]
        int current = array[i]; 
        
        // [c]
        for (int j = 0; j < i; j++) // Scan from 0 to i-1 
        {
            // [d]
            if (current < array[j])
            {
                // [e]
                for (int k = i; k > j; k--)
                {
                    array[k] = array[k - 1]; // k receives k-1 value
                }

                // [f]
                array[j] = current; // This is the actual insertion

                // [g]
                break; // Terminate the innner loop since we already process the 'i'. Move on to the next one.
            }
        }
    }

    return array;
}

```

[a] The outer loop iterates n-1 elements using the index 'i' starting from index 1, which is the 2nd element. The subarray left of 'i' is always sorted. 

[b] The element at 'i' is saved as 'current' in the body of the outer loop. Not only this makes it easier to read the algorithm, it saves the value aside so that when we do "shiftig" at [e], we will not loose the value.

[c] The inner loop is to iterate the sorted subarray to the left of 'i'. For the very first iteration of the outerloop, the inner loop will iterate over a single-element subarray. The inner loop will choose an 'insertion point' in the subarray, which would be one of 'front of' or 'behind of' an element, or 'between' two elements.

[d] Scanning from the front, looking for an element that is larger than 'current'. If found, we will have to insert 'current' item 'in front of' the element. It may never find one if 'current' is the largest.

[e] We need to shift values in the subarray. Use a new index 'k' and walk backward, starting from where 'current' was, ending at the 'insertion point' just found, which is at j. 

[f] Copy the value of 'current' to the insertion point. This completes 'insert' operation of 'Insertion Sort'

[g] We can terminate the inner loop. It will pick up from the next 'i'.

## Quicksort

Quicksort is actually slow if the input array is nearly sorted.
Partition function would partitions an input subarray into two partitions:
- Those smaller or equal to the pivot
- Those greater than the pivot.

Why slow? Because this implementation uses the Length-1 element as a strategy for selecting a pivot, and the array is already sorted, all of the other elements will be on the left of the pivot, and nothing on the right of the pivot. This means the new pivot index (where the element divides it into two partitions) will be at Length-2. It merely partitioned the input subarray into one large partition and an empty partition. This would not result in O(log n) time complexity.

