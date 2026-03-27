using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SortingAlgorithms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] sortArray = new int[4];
        int arraySize;
        public MainWindow()
        {
            InitializeComponent();
            //cbSortOptions = new System.Windows.Controls.ComboBox();
            //txtDisplay = new System.Windows.Controls.TextBox();
            cbSortOptions.Items.Add("Bubble Sort");
            cbSortOptions.Items.Add("Insertion Sort");
            cbSortOptions.Items.Add("Selection Sort (Highest)");
            cbSortOptions.Items.Add("Selection Sort (Lowest)");
            cbSortOptions.Items.Add("Quick Sort");
            cbSortOptions.Items.Add("Random Quick Sort");
            cbSortOptions.Items.Add("Heap Sort");
            cbSortOptions.Items.Add("Shell Sort");
            cbSortOptions.Items.Add("Merge Sort");
            cbSortOptions.Items.Add("Radix Sort");
            cbSortOptions.Items.Add("Counting Sort");
            arraySize = 0;
        }

        private void ButtonStartSort_Click(object sender, RoutedEventArgs e)
        {
            CreateArray();
            string sortOption = cbSortOptions.SelectedItem.ToString();
            if (sortOption == "Bubble Sort")
            {
                BubbleSort bubbleSort = new BubbleSort();
                bubbleSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Insertion Sort")
            {
                InsertionSort insertionSort = new InsertionSort();
                insertionSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Selection Sort (Highest)")
            {
                SelectionHighSort selectionhighSort = new SelectionHighSort();
                selectionhighSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Selection Sort (Lowest)")
            {
                SelectionLowSort selectionlowSort = new SelectionLowSort();
                selectionlowSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Quick Sort")
            {
                QuickSort quickSort = new QuickSort();
                quickSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Random Quick Sort")
            {
                RandomQuickSort randomquickSort = new RandomQuickSort();
                randomquickSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Heap Sort")
            {
                HeapSort heapSort = new HeapSort();
                heapSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Shell Sort")
            {
                ShellSort shellSort = new ShellSort();
                shellSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Merge Sort")
            {
                MergeSort mergeSort = new MergeSort();
                mergeSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Radix Sort")
            {
                RandomQuickSort randomquickSort = new RandomQuickSort();
                randomquickSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Counting Sort")
            {
                CountingSort countingSort = new CountingSort();
                countingSort.Sort(sortArray, txtDisplay, txtFinished);
            }
        }
        private void CreateArray()
        {
            arraySize = 0;
            for (int i = 0; i < txtInput.Text.Length; i++)
            {
                if (txtInput.Text[i] == ',')
                {
                    arraySize++;
                }
                if (txtInput.Text[i] == ' ')
                {
                    txtInput.Text = txtInput.Text.Remove(i, 1);
                    i--;
                }
            }
            arraySize++;
            sortArray = new int[arraySize];
            string[] inputArray = txtInput.Text.Split(',');
            for (int i = 0; i < arraySize; i++)
            {
                sortArray[i] = int.Parse(inputArray[i]);
            }
        }
    }
}