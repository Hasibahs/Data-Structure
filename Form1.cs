using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DataStructureAssignment
{
    public partial class Form1 : Form
    {
        private Heap<Student> studentHeap;
        private BinarySearchTree<Student> studentTree;
        private LinkedList<Student> studentList;
        private SortBy selectedSortBy;

        public Form1()
        {
            InitializeComponent();
            comboBoxSortBy.DataSource = Enum.GetValues(typeof(SortBy));
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                Title = "Select a JSON file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string jsonFilePath = openFileDialog.FileName;
                    string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
                    var settings = new JsonSerializerSettings();
                    settings.Converters.Add(new HeapConverter<Student>());
                    settings.Converters.Add(new BinarySearchTreeConverter<Student>());
                    settings.Converters.Add(new LinkedListConverter<Student>());

                    studentHeap = JsonConvert.DeserializeObject<Heap<Student>>(jsonContent, settings);
                    studentTree = JsonConvert.DeserializeObject<BinarySearchTree<Student>>(jsonContent, settings);
                    studentList = JsonConvert.DeserializeObject<LinkedList<Student>>(jsonContent, settings);

                    richTextBoxImportedData.Text = jsonContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            selectedSortBy = (SortBy)comboBoxSortBy.SelectedItem;

            if (radioButtonHeap.Checked && studentHeap != null)
            {
                SortAndDisplayResults<Student>(studentHeap, "Heap");
            }
            else if (radioButtonBinarySearchTree.Checked && studentTree != null)
            {
                SortAndDisplayResults<Student>(studentTree, "Binary Search Tree");
            }
            else if (radioButtonLinkedList.Checked && studentList != null)
            {
                SortAndDisplayResults<Student>(studentList, "Linked List");
            }
            else
            {
                MessageBox.Show("Please import data and select a data structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            selectedSortBy = (SortBy)comboBoxSortBy.SelectedItem;
            string searchTerm = textBoxSearchTerm.Text;

            if (radioButtonBinarySearchTree.Checked && studentTree != null)
            {
                SearchAndDisplayResults<Student>(studentTree, "Binary Search Tree", searchTerm);
            }
            else if (radioButtonHeap.Checked && studentHeap != null)
            {
                SearchAndDisplayResults<Student>(studentHeap, "Heap", searchTerm);
            }
            else if (radioButtonLinkedList.Checked && studentList != null)
            {
                SearchAndDisplayResults<Student>(studentList, "Linked List", searchTerm);
            }
            else
            {
                MessageBox.Show("Please import data and select a data structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SortAndDisplayResults<T>(dynamic dataStructure, string structureName) where T : Student
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (radioButtonQuickSort.Checked)
            {
                dataStructure.QuickSort(selectedSortBy);
            }
            else if (radioButtonMergeSort.Checked)
            {
                dataStructure.MergeSort(selectedSortBy);
            }

            stopwatch.Stop();
            double elapsedSeconds = Math.Round(stopwatch.Elapsed.TotalSeconds, 1);

            richTextBoxOutput.AppendText($"{structureName} {selectedSortBy} sorted in {elapsedSeconds} seconds.\n");
            DisplayStudents(dataStructure);
            richTextBoxOutput.AppendText($"\nExecution Time: {elapsedSeconds} seconds\n");
        }

        private void SearchAndDisplayResults<T>(dynamic dataStructure, string structureName, string searchTerm) where T : Student
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IEnumerable<Student> result = null;
            if (radioButtonBinarySearch.Checked)
            {
                result = dataStructure.BinarySearch(selectedSortBy, searchTerm);
            }
            else if (radioButtonDFS.Checked)
            {
                result = dataStructure.DepthFirstSearch(selectedSortBy, searchTerm);
            }

            stopwatch.Stop();
            double elapsedSeconds = Math.Round(stopwatch.Elapsed.TotalSeconds, 1);

            richTextBoxOutput.AppendText($"{structureName} {selectedSortBy} search completed in {elapsedSeconds} seconds.\n");
            DisplayStudents(result);
            richTextBoxOutput.AppendText($"\nExecution Time: {elapsedSeconds} seconds\n");
        }

        private void DisplayStudents(IEnumerable<Student> students)
        {
            richTextBoxOutput.Clear();
            foreach (var student in students)
            {
                richTextBoxOutput.AppendText($"Name: {student.Name}\n");
                richTextBoxOutput.AppendText($"ID: {student.ID}\n");
                richTextBoxOutput.AppendText($"Age: {student.Age}\n");
                richTextBoxOutput.AppendText($"GPA: {student.GPA}\n");
                richTextBoxOutput.AppendText($"Major: {student.Major}\n");
                richTextBoxOutput.AppendText($"University: {student.University}\n");
                richTextBoxOutput.AppendText("------------\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
