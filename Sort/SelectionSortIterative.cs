namespace Sort
{
    public class SelectionSortIterative
    {
        public int[] Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }

            return array;
        }
    }
}
