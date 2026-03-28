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

            txtFinished.Text = "Finished!";
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

            txtFinished.Text = "Finished!";
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

            txtFinished.Text = "Finished!";
        }
    }

}