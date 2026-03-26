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
        char sortType;
        int[] sortArray = new int[4];
        int arraySize;
        public MainWindow()
        {
            InitializeComponent();
            //cbSortOptions = new System.Windows.Controls.ComboBox();
            //txtDisplay = new System.Windows.Controls.TextBox();
            cbSortOptions.Items.Add("Bubble Sort");
            cbSortOptions.Items.Add("Selection Sort");
            cbSortOptions.Items.Add("Insertion Sort");
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
            else if (sortOption == "Selection Sort")
            {
                SelectionSort selectionSort = new SelectionSort();
                selectionSort.Sort(sortArray, txtDisplay, txtFinished);
            }
            else if (sortOption == "Insertion Sort")
            {
                InsertionSort insertionSort = new InsertionSort();
                insertionSort.Sort(sortArray, txtDisplay, txtFinished);
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
    class BubbleSort
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
                    if (array[j] > array[j + 1])
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
    class SelectionSort
    {
        public async Task Sort(int[] array, TextBox txtDisplay, TextBox txtFinished)
        {
            txtFinished.Text = "";
            int size = array.Length;
            txtDisplay.Text = string.Join(" | ", array);
            await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
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
                await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            }
            txtFinished.Text = "Finished!";
        }
    }
    class InsertionSort
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

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                    txtDisplay.Text = string.Join(" | ", array);
                    await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
                }
                array[j + 1] = key;
                txtDisplay.Text = string.Join(" | ", array);
                await Task.Delay(TimeSpan.FromSeconds(1.5));        //pauses for 1.5 seconds to show current state
            }
            txtFinished.Text = "Finished!";
        }
    }
}