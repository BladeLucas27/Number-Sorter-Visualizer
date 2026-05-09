using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SortingAlgorithms
{
    internal class VisualizationHelper
    {
        public static void DrawBars(int[] array, Canvas canvas, int arraySize)
        {
            canvas.Children.Clear();
            
            double canvasWidth = canvas.ActualWidth > 0 ? canvas.ActualWidth : 691;
            double canvasHeight = canvas.ActualHeight > 0 ? canvas.ActualHeight : 150;
            
            double barWidth = canvasWidth / arraySize;
            int maxValue = array.Max();
            
            if (maxValue == 0) return;

            for (int i = 0; i < arraySize; i++)
            {
                double barHeight = (array[i] / (double)maxValue) * canvasHeight;
                Rectangle bar = new Rectangle
                {
                    Width = barWidth - 2,
                    Height = barHeight,
                    Fill = new SolidColorBrush(Colors.SteelBlue),
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1
                };
                Canvas.SetLeft(bar, i * barWidth);
                Canvas.SetTop(bar, canvasHeight - barHeight);
                canvas.Children.Add(bar);
            }
        }
    }

    internal class BubbleSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            int temp;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        txtDisplay.Text = string.Join(" | ", array);
                        VisualizationHelper.DrawBars(array, canvas, arraySize);
                        await Task.Delay(TimeSpan.FromSeconds(1.5));
                    }
                }
            }
            txtFinished.Text = "Finished!";
        }
    }

    internal class InsertionSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            for (int i = 1; i < size; ++i)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                    txtDisplay.Text = string.Join(" | ", array);
                    VisualizationHelper.DrawBars(array, canvas, arraySize);
                    await Task.Delay(TimeSpan.FromSeconds(0.75));
                }
                array[j + 1] = key;
                txtDisplay.Text = string.Join(" | ", array);
                VisualizationHelper.DrawBars(array, canvas, arraySize);
                await Task.Delay(TimeSpan.FromSeconds(1.5));
            }
            txtFinished.Text = "Finished!";
        }
    }

    internal class SelectionHighSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            for (int i = 0; i < size - 1; i++)
            {
                int max_idx = i;

                for (int j = i + 1; j < size; j++)
                {
                    if (array[j] > array[max_idx])
                    {
                        max_idx = j;
                    }
                }
                int temp = array[i];
                array[i] = array[max_idx];
                array[max_idx] = temp;
                txtDisplay.Text = string.Join(" | ", array);
                VisualizationHelper.DrawBars(array, canvas, arraySize);
                await Task.Delay(TimeSpan.FromSeconds(1.5));
            }
            txtFinished.Text = "Finished!";
        }
    }

    internal class SelectionLowSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            for (int i = 0; i < size - 1; i++)
            {
                int min_idx = i;

                for (int j = i + 1; j < size; j++)
                {
                    if (array[j] < array[min_idx])
                    {
                        min_idx = j;
                    }
                }
                int temp = array[i];
                array[i] = array[min_idx];
                array[min_idx] = temp;
                txtDisplay.Text = string.Join(" | ", array);
                VisualizationHelper.DrawBars(array, canvas, arraySize);
                await Task.Delay(TimeSpan.FromSeconds(1.5));
            }
            txtFinished.Text = "Finished!";
        }
    }

    internal class QuickSort
    {
        int pi;
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            await quickSort(array, 0, size - 1, txtDisplay, canvas, arraySize);
            txtFinished.Text = "Finished!";
        }

        async Task partition(int[] arr, int low, int high, TextBox txtDisplay, Canvas canvas, int arraySize)
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
                    VisualizationHelper.DrawBars(arr, canvas, arraySize);
                    await Task.Delay(TimeSpan.FromSeconds(1.5));
                }
            }
            swap(arr, i + 1, high);
            txtDisplay.Text = string.Join(" | ", arr);
            VisualizationHelper.DrawBars(arr, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            pi = i + 1;
        }

        static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        async Task quickSort(int[] array, int low, int high, TextBox txtDisplay, Canvas canvas, int arraySize)
        {
            if (low < high)
            {
                await partition(array, low, high, txtDisplay, canvas, arraySize);
                await quickSort(array, low, pi - 1, txtDisplay, canvas, arraySize);
                await quickSort(array, pi + 1, high, txtDisplay, canvas, arraySize);
            }
        }
    }

    internal class RandomQuickSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            txtFinished.Text = "Finished!";
        }
    }

    internal class HeapSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            txtFinished.Text = "Finished!";
        }
    }

    internal class ShellSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            for (int gap = size / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < size; i++)
                {
                    int temp = array[i];
                    int j = i;

                    while (j >= gap && array[j - gap] > temp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = temp;
                    txtDisplay.Text = string.Join(" | ", array);
                    VisualizationHelper.DrawBars(array, canvas, arraySize);
                    await Task.Delay(TimeSpan.FromSeconds(1.5));
                }
            }
            txtFinished.Text = "Finished!";
        }
    }

    internal class MergeSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            int left = 0, right = size - 1, middle = left + (right - left) / 2;

            await SortHalf(array, left, middle, txtDisplay, txtFinished, canvas, arraySize);
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            await SortHalf(array, middle + 1, right, txtDisplay, txtFinished, canvas, arraySize);
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            merge(array, left, middle, right);

            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            txtFinished.Text = "Finished!";
        }

        public async Task SortHalf(int[] array, int left, int right, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                await SortHalf(array, left, middle, txtDisplay, txtFinished, canvas, arraySize);
                txtDisplay.Text = string.Join(" | ", array);
                VisualizationHelper.DrawBars(array, canvas, arraySize);
                await Task.Delay(TimeSpan.FromSeconds(0.5));
                await SortHalf(array, middle + 1, right, txtDisplay, txtFinished, canvas, arraySize);
                txtDisplay.Text = string.Join(" | ", array);
                VisualizationHelper.DrawBars(array, canvas, arraySize);
                await Task.Delay(TimeSpan.FromSeconds(0.5));

                merge(array, left, middle, right);
                txtDisplay.Text = string.Join(" | ", array);
                VisualizationHelper.DrawBars(array, canvas, arraySize);
                await Task.Delay(TimeSpan.FromSeconds(0.5));
            }
        }

        static void merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[left + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[middle + 1 + j];

            i = 0;
            j = 0;

            int k = left;
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

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }

    internal class RadixSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            int m = getMax(array, size);

            for (int exp = 1; m / exp > 0; exp *= 10)
            {
                await digitSort(array, size, exp, txtDisplay, canvas, arraySize);
                txtDisplay.Text = string.Join(" | ", array);
                VisualizationHelper.DrawBars(array, canvas, arraySize);
                await Task.Delay(TimeSpan.FromSeconds(1.5));
            }
            txtDisplay.Text = string.Join(" | ", array);
            txtFinished.Text = "Finished!";
        }

        public async Task digitSort(int[] array, int size, int exp, TextBox txtDisplay, Canvas canvas, int arraySize)
        {
            int[] output = new int[size];
            int i;
            int[] count = new int[10];

            for (i = 0; i < 10; i++)
                count[i] = 0;

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
                VisualizationHelper.DrawBars(array, canvas, arraySize);
                await Task.Delay(TimeSpan.FromSeconds(0.5));
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
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished, Canvas canvas, int arraySize)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            VisualizationHelper.DrawBars(array, canvas, arraySize);
            await Task.Delay(TimeSpan.FromSeconds(1.5));

            int maxVal = array[0];
            foreach (int v in array)
            {
                if (v > maxVal)
                    maxVal = v;
            }

            int[] cntArray = new int[maxVal + 1];
            for (int i = 0; i <= maxVal; i++)
            {
                cntArray[i] = 0;
            }

            foreach (int v in array)
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
                VisualizationHelper.DrawBars(sorted, canvas, arraySize);
                await Task.Delay(TimeSpan.FromSeconds(0.5));
            }
            txtDisplay.Text = string.Join(" | ", sorted);
            VisualizationHelper.DrawBars(sorted, canvas, arraySize);
            txtFinished.Text = "Finished!";
        }
    }
}