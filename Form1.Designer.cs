namespace DataStructureAssignment
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxDataStructure;
        private System.Windows.Forms.RadioButton radioButtonHeap;
        private System.Windows.Forms.RadioButton radioButtonBinarySearchTree;
        private System.Windows.Forms.RadioButton radioButtonLinkedList;
        private System.Windows.Forms.GroupBox groupBoxSortAlgorithm;
        private System.Windows.Forms.RadioButton radioButtonMergeSort;
        private System.Windows.Forms.RadioButton radioButtonQuickSort;
        private System.Windows.Forms.GroupBox groupBoxSearchAlgorithm;
        private System.Windows.Forms.RadioButton radioButtonDFS;
        private System.Windows.Forms.RadioButton radioButtonBinarySearch;
        private System.Windows.Forms.ComboBox comboBoxSortBy;
        private System.Windows.Forms.TextBox textBoxSearchTerm;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.RichTextBox richTextBoxImportedData;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            importToolStripMenuItem = new ToolStripMenuItem();
            groupBoxDataStructure = new GroupBox();
            radioButtonHeap = new RadioButton();
            radioButtonBinarySearchTree = new RadioButton();
            radioButtonLinkedList = new RadioButton();
            groupBoxSortAlgorithm = new GroupBox();
            radioButtonMergeSort = new RadioButton();
            radioButtonQuickSort = new RadioButton();
            groupBoxSearchAlgorithm = new GroupBox();
            radioButtonDFS = new RadioButton();
            radioButtonBinarySearch = new RadioButton();
            comboBoxSortBy = new ComboBox();
            textBoxSearchTerm = new TextBox();
            buttonSort = new Button();
            buttonSearch = new Button();
            richTextBoxImportedData = new RichTextBox();
            richTextBoxOutput = new RichTextBox();
            menuStrip1.SuspendLayout();
            groupBoxDataStructure.SuspendLayout();
            groupBoxSortAlgorithm.SuspendLayout();
            groupBoxSearchAlgorithm.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { importToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1258, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(83, 29);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // groupBoxDataStructure
            // 
            groupBoxDataStructure.Controls.Add(radioButtonHeap);
            groupBoxDataStructure.Controls.Add(radioButtonBinarySearchTree);
            groupBoxDataStructure.Controls.Add(radioButtonLinkedList);
            groupBoxDataStructure.Location = new Point(12, 31);
            groupBoxDataStructure.Name = "groupBoxDataStructure";
            groupBoxDataStructure.Size = new Size(200, 100);
            groupBoxDataStructure.TabIndex = 1;
            groupBoxDataStructure.TabStop = false;
            groupBoxDataStructure.Text = "Data Structure";
            // 
            // radioButtonHeap
            // 
            radioButtonHeap.AutoSize = true;
            radioButtonHeap.Location = new Point(6, 75);
            radioButtonHeap.Name = "radioButtonHeap";
            radioButtonHeap.Size = new Size(79, 29);
            radioButtonHeap.TabIndex = 2;
            radioButtonHeap.TabStop = true;
            radioButtonHeap.Text = "Heap";
            radioButtonHeap.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinarySearchTree
            // 
            radioButtonBinarySearchTree.AutoSize = true;
            radioButtonBinarySearchTree.Location = new Point(6, 48);
            radioButtonBinarySearchTree.Name = "radioButtonBinarySearchTree";
            radioButtonBinarySearchTree.Size = new Size(178, 29);
            radioButtonBinarySearchTree.TabIndex = 1;
            radioButtonBinarySearchTree.TabStop = true;
            radioButtonBinarySearchTree.Text = "Binary Search Tree";
            radioButtonBinarySearchTree.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinkedList
            // 
            radioButtonLinkedList.AutoSize = true;
            radioButtonLinkedList.Location = new Point(6, 21);
            radioButtonLinkedList.Name = "radioButtonLinkedList";
            radioButtonLinkedList.Size = new Size(119, 29);
            radioButtonLinkedList.TabIndex = 0;
            radioButtonLinkedList.TabStop = true;
            radioButtonLinkedList.Text = "Linked List";
            radioButtonLinkedList.UseVisualStyleBackColor = true;
            // 
            // groupBoxSortAlgorithm
            // 
            groupBoxSortAlgorithm.Controls.Add(radioButtonMergeSort);
            groupBoxSortAlgorithm.Controls.Add(radioButtonQuickSort);
            groupBoxSortAlgorithm.Location = new Point(218, 31);
            groupBoxSortAlgorithm.Name = "groupBoxSortAlgorithm";
            groupBoxSortAlgorithm.Size = new Size(200, 100);
            groupBoxSortAlgorithm.TabIndex = 2;
            groupBoxSortAlgorithm.TabStop = false;
            groupBoxSortAlgorithm.Text = "Sort Algorithm";
            // 
            // radioButtonMergeSort
            // 
            radioButtonMergeSort.AutoSize = true;
            radioButtonMergeSort.Location = new Point(6, 48);
            radioButtonMergeSort.Name = "radioButtonMergeSort";
            radioButtonMergeSort.Size = new Size(126, 29);
            radioButtonMergeSort.TabIndex = 1;
            radioButtonMergeSort.TabStop = true;
            radioButtonMergeSort.Text = "Merge Sort";
            radioButtonMergeSort.UseVisualStyleBackColor = true;
            // 
            // radioButtonQuickSort
            // 
            radioButtonQuickSort.AutoSize = true;
            radioButtonQuickSort.Location = new Point(6, 21);
            radioButtonQuickSort.Name = "radioButtonQuickSort";
            radioButtonQuickSort.Size = new Size(120, 29);
            radioButtonQuickSort.TabIndex = 0;
            radioButtonQuickSort.TabStop = true;
            radioButtonQuickSort.Text = "Quick Sort";
            radioButtonQuickSort.UseVisualStyleBackColor = true;
            // 
            // groupBoxSearchAlgorithm
            // 
            groupBoxSearchAlgorithm.Controls.Add(radioButtonDFS);
            groupBoxSearchAlgorithm.Controls.Add(radioButtonBinarySearch);
            groupBoxSearchAlgorithm.Location = new Point(424, 31);
            groupBoxSearchAlgorithm.Name = "groupBoxSearchAlgorithm";
            groupBoxSearchAlgorithm.Size = new Size(200, 100);
            groupBoxSearchAlgorithm.TabIndex = 3;
            groupBoxSearchAlgorithm.TabStop = false;
            groupBoxSearchAlgorithm.Text = "Search Algorithm";
            // 
            // radioButtonDFS
            // 
            radioButtonDFS.AutoSize = true;
            radioButtonDFS.Location = new Point(6, 48);
            radioButtonDFS.Name = "radioButtonDFS";
            radioButtonDFS.Size = new Size(183, 29);
            radioButtonDFS.TabIndex = 1;
            radioButtonDFS.TabStop = true;
            radioButtonDFS.Text = "Depth-First Search";
            radioButtonDFS.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinarySearch
            // 
            radioButtonBinarySearch.AutoSize = true;
            radioButtonBinarySearch.Location = new Point(6, 21);
            radioButtonBinarySearch.Name = "radioButtonBinarySearch";
            radioButtonBinarySearch.Size = new Size(142, 29);
            radioButtonBinarySearch.TabIndex = 0;
            radioButtonBinarySearch.TabStop = true;
            radioButtonBinarySearch.Text = "Binary Search";
            radioButtonBinarySearch.UseVisualStyleBackColor = true;
            // 
            // comboBoxSortBy
            // 
            comboBoxSortBy.FormattingEnabled = true;
            comboBoxSortBy.Location = new Point(630, 48);
            comboBoxSortBy.Name = "comboBoxSortBy";
            comboBoxSortBy.Size = new Size(75, 33);
            comboBoxSortBy.TabIndex = 4;
            // 
            // textBoxSearchTerm
            // 
            textBoxSearchTerm.Location = new Point(776, 50);
            textBoxSearchTerm.Name = "textBoxSearchTerm";
            textBoxSearchTerm.Size = new Size(77, 31);
            textBoxSearchTerm.TabIndex = 5;
            // 
            // buttonSort
            // 
            buttonSort.Location = new Point(630, 98);
            buttonSort.Name = "buttonSort";
            buttonSort.Size = new Size(75, 33);
            buttonSort.TabIndex = 6;
            buttonSort.Text = "Sort";
            buttonSort.UseVisualStyleBackColor = true;
            buttonSort.Click += buttonSort_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(776, 98);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(77, 33);
            buttonSearch.TabIndex = 7;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // richTextBoxImportedData
            // 
            richTextBoxImportedData.Location = new Point(12, 137);
            richTextBoxImportedData.Name = "richTextBoxImportedData";
            richTextBoxImportedData.Size = new Size(1246, 259);
            richTextBoxImportedData.TabIndex = 8;
            richTextBoxImportedData.Text = "";
            // 
            // richTextBoxOutput
            // 
            richTextBoxOutput.Location = new Point(0, 402);
            richTextBoxOutput.Name = "richTextBoxOutput";
            richTextBoxOutput.Size = new Size(1258, 273);
            richTextBoxOutput.TabIndex = 9;
            richTextBoxOutput.Text = "";
            // 
            // Form1
            // 
            ClientSize = new Size(1258, 675);
            Controls.Add(richTextBoxOutput);
            Controls.Add(richTextBoxImportedData);
            Controls.Add(buttonSearch);
            Controls.Add(buttonSort);
            Controls.Add(textBoxSearchTerm);
            Controls.Add(comboBoxSortBy);
            Controls.Add(groupBoxSearchAlgorithm);
            Controls.Add(groupBoxSortAlgorithm);
            Controls.Add(groupBoxDataStructure);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Data Structure Assignment";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBoxDataStructure.ResumeLayout(false);
            groupBoxDataStructure.PerformLayout();
            groupBoxSortAlgorithm.ResumeLayout(false);
            groupBoxSortAlgorithm.PerformLayout();
            groupBoxSearchAlgorithm.ResumeLayout(false);
            groupBoxSearchAlgorithm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

