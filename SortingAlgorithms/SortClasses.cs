using System.Windows.Controls;

namespace SortingAlgorithms
{
    internal class BubbleSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            int temp;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (array[j] > array[j + 1])                //if current value is greater than next value, swap
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        txtDisplay.Text = string.Join(" | ", array);
                        await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
                    }
                }
            }
            txtFinished.Text = "Finished!";
        }
    }
    internal class InsertionSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            for (int i = 1; i < size; ++i)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)                //if current value is greater than key value, swap
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                    txtDisplay.Text = string.Join(" | ", array);
                    await Task.Delay(TimeSpan.FromSeconds(0.75));        //pauses for 0.75 seconds to show mid-swap state
                }
                array[j + 1] = key;
                txtDisplay.Text = string.Join(" | ", array);
                await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            }
            txtFinished.Text = "Finished!";
        }
    }
    internal class SelectionHighSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            for (int i = 0; i < size - 1; i++)
            {
                int max_idx = i;                                //sets index of maximum value to current index

                for (int j = i + 1; j < size; j++)              //starts looping through array from index after current index to end of array
                {
                    if (array[j] > array[max_idx])              //if value at current index is greater than value at maximum index, changes maximum index to current index
                    {
                        max_idx = j;
                    }
                }
                int temp = array[i];                                //swaps value at current index with value at maximum index
                array[i] = array[max_idx];
                array[max_idx] = temp;
                txtDisplay.Text = string.Join(" | ", array);
                await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            }
            txtFinished.Text = "Finished!";
        }
    }
    internal class SelectionLowSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            for (int i = 0; i < size - 1; i++)
            {
                int min_idx = i;                                //sets index of minimum value to current index

                for (int j = i + 1; j < size; j++)              //starts looping through array from index after current index to end of array
                {
                    if (array[j] < array[min_idx])              //if value at current index is less than value at minimum index, changes minimum index to current index
                    {
                        min_idx = j;
                    }
                }
                int temp = array[i];                            //swaps value at current index with value at minimum index
                array[i] = array[min_idx];
                array[min_idx] = temp;
                txtDisplay.Text = string.Join(" | ", array);
                await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            }
            txtFinished.Text = "Finished!";
        }
    }
    internal class QuickSort
    {
        int pi;
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            await quickSort(array, 0, size-1, txtDisplay);
            txtFinished.Text = "Finished!";
        }
        async Task partition(int[] arr, int low, int high, TextBox txtDisplay)
        {
            int pivot = arr[high];

            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    swap(arr, i, j);
                    txtDisplay.Text = string.Join(" | ", arr);
                    await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
                }
            }
            swap(arr, i + 1, high);
            txtDisplay.Text = string.Join(" | ", arr);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            pi = i + 1;
        }
        static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        async Task quickSort(int[] array, int low, int high, TextBox txtDisplay)
        {
            if (low < high)
            {
                await partition(array, low, high, txtDisplay);
                await quickSort(array, low, pi - 1, txtDisplay);
                await quickSort(array, pi + 1, high, txtDisplay);
            }
        }
    }
    internal class RandomQuickSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state

            txtFinished.Text = "Finished!";
        }
    }
    internal class HeapSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            
            txtFinished.Text = "Finished!";
        }
    }
    internal class ShellSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state

            // Start with a large gap, then reduce it step by step
            for (int gap = size / 2; gap > 0; gap /= 2)
            {
                // Perform a "gapped" insertion sort for this gap size
                for (int i = gap; i < size; i++)
                {
                    // Current element to be placed correctly
                    int temp = array[i];
                    int j = i;

                    // Shift earlier elements that are greater than temp
                    while (j >= gap && array[j - gap] > temp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    // Place temp in its correct position
                    array[j] = temp;
                    txtDisplay.Text = string.Join(" | ", array);
                    await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
                }
            }
            txtFinished.Text = "Finished!";
        }
    }
    internal class MergeSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state

            int left = 0, right = size - 1, middle = left + (right - left) / 2;

            await SortHalf(array, left, middle, txtDisplay, txtFinished);       // Sort first and second halves
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state

            await SortHalf(array, middle + 1, right, txtDisplay, txtFinished);
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            
            merge(array, left, middle, right);                  // Merge the sorted halves

            txtDisplay.Text = string.Join(" | ", array);
            txtFinished.Text = "Finished!";
        }
        public async Task SortHalf(int[] array, int left, int right, TextBox txtDisplay, TextBox txtFinished)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;                             // Find the middle point

                await SortHalf(array, left, middle, txtDisplay, txtFinished);       // Sorts first and second halves
                txtDisplay.Text = string.Join(" | ", array);
                await Task.Delay(TimeSpan.FromSeconds(0.5));        //pauses for .5 seconds to show current state
                await SortHalf(array, middle + 1, right, txtDisplay, txtFinished);
                txtDisplay.Text = string.Join(" | ", array);
                await Task.Delay(TimeSpan.FromSeconds(0.5));        //pauses for .5 seconds to show current state

                merge(array, left, middle, right);                  // Merges the sorted halves
                txtDisplay.Text = string.Join(" | ", array);
                await Task.Delay(TimeSpan.FromSeconds(0.5));        //pauses for .5 seconds to show current state
            }
        }
        static void merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];                  // Temp arrays for sorting
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)                // Copy data to temp arrays
                L[i] = arr[left + i];   
            for (j = 0; j < n2; ++j)
                R[j] = arr[middle + 1 + j];

            i = 0;
            j = 0;
            
            int k = left;                           // Initial index of merged subarray array
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            
            while (i < n1)                          // Copy remaining elements of L[] if any
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            
            while (j < n2)                          // Copy remaining elements of R[] if any
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }
    internal class RadixSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state

            int m = getMax(array, size);

            for (int exp = 1; m / exp > 0; exp *= 10) {
                await digitSort(array, size, exp, txtDisplay);                    //sorts by each digit, starting with least significant digit
                txtDisplay.Text = string.Join(" | ", array);
                await Task.Delay(TimeSpan.FromSeconds(1.5));
            }
            txtDisplay.Text = string.Join(" | ", array);
            txtFinished.Text = "Finished!";
        }
        public async Task digitSort(int[] array, int size, int exp, TextBox txtDisplay)
        {
            int[] output = new int[size]; // output array
            int i;
            int[] count = new int[10];

            // initializing all elements of count to 0
            for (i = 0; i < 10; i++)
                count[i] = 0;

            // Store count of occurrences in count[]
            for (i = 0; i < size; i++)
            {
                count[(array[i] / exp) % 10]++;
            }

            // Change count[i] so that count[i] now contains actual position of this digit in output[]
            for (i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }
                

            // Build the output array
            for (i = size - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now contains sorted numbers according to current digit
            for (i = 0; i < size; i++)
            {
                array[i] = output[i];
                txtDisplay.Text = string.Join(" | ", array);
                await Task.Delay(TimeSpan.FromSeconds(0.5));        //pauses for .5 seconds to show current state
            }
            
        }
        public static int getMax(int[] array, int n)
        {
            int mx = array[0];
            for (int i = 1; i < n; i++)
                if (array[i] > mx)
                    mx = array[i];
            return mx;
        }
    }
    internal class CountingSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state

            int maxVal = array[0];
            foreach (int v in array)                            //finds highest value in array to determine size of counting array
            {
                if (v > maxVal)
                    maxVal = v;
            }

            int[] cntArray = new int[maxVal + 1];                 //cntArray used to count frequency of each value in array, size is maxVal + 1 to account for 0 index
            for (int i = 0; i <= maxVal; i++)
            {
                cntArray[i] = 0;
            }

            foreach (int v in array)                            // count frequency for each element in array
            {
                cntArray[v]++;
            }

            // prefix sums
            for (int i = 1; i <= maxVal; i++)
            {
                cntArray[i] += cntArray[i - 1];
            }

            // build output
            int[] sorted = new int[size];
            for (int i = size - 1; i >= 0; i--)
            {
                int v = array[i];
                sorted[cntArray[v] - 1] = v;
                cntArray[v]--;
                txtDisplay.Text = string.Join(" | ", sorted);
                await Task.Delay(TimeSpan.FromSeconds(0.5));        //pauses for 0.5 seconds to show current state
            }
            txtDisplay.Text = string.Join(" | ", sorted);
            txtFinished.Text = "Finished!";
        }
    }

}