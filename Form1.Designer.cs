namespace PythonTestRunner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            jsonFileButton = new Button();
            jsonFileLabel = new Label();
            jsonFileDialog = new OpenFileDialog();
            testTreeView = new TreeView();
            testIconList = new ImageList(components);
            displayTextBox = new RichTextBox();
            runTestsButton = new Button();
            stopTestsButton = new Button();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // jsonFileButton
            // 
            jsonFileButton.Location = new Point(12, 12);
            jsonFileButton.Name = "jsonFileButton";
            jsonFileButton.Size = new Size(127, 35);
            jsonFileButton.TabIndex = 0;
            jsonFileButton.Text = "Load Test List";
            jsonFileButton.UseVisualStyleBackColor = true;
            jsonFileButton.Click += jsonFileButton_Click;
            // 
            // jsonFileLabel
            // 
            jsonFileLabel.AutoSize = true;
            jsonFileLabel.Location = new Point(145, 17);
            jsonFileLabel.Name = "jsonFileLabel";
            jsonFileLabel.Size = new Size(160, 25);
            jsonFileLabel.TabIndex = 1;
            jsonFileLabel.Text = "(no JSON selected)";
            // 
            // jsonFileDialog
            // 
            jsonFileDialog.FileName = "openFileDialog1";
            jsonFileDialog.FileOk += jsonFileDialog_FileOk;
            // 
            // testTreeView
            // 
            testTreeView.CheckBoxes = true;
            testTreeView.Dock = DockStyle.Fill;
            testTreeView.ImageIndex = 0;
            testTreeView.ImageList = testIconList;
            testTreeView.Location = new Point(0, 0);
            testTreeView.Name = "testTreeView";
            testTreeView.SelectedImageIndex = 0;
            testTreeView.Size = new Size(199, 385);
            testTreeView.TabIndex = 2;
            testTreeView.AfterCheck += testTreeView_AfterCheck;
            testTreeView.NodeMouseClick += testTreeView_NodeMouseClick;
            // 
            // testIconList
            // 
            testIconList.ColorDepth = ColorDepth.Depth32Bit;
            testIconList.ImageStream = (ImageListStreamer)resources.GetObject("testIconList.ImageStream");
            testIconList.TransparentColor = Color.Transparent;
            testIconList.Images.SetKeyName(0, "icons8-minus-96.png");
            testIconList.Images.SetKeyName(1, "icons8-check-mark-button-96.png");
            testIconList.Images.SetKeyName(2, "icons8-cross-mark-button-96.png");
            testIconList.Images.SetKeyName(3, "icons8-counterclockwise-arrows-96.png");
            // 
            // displayTextBox
            // 
            displayTextBox.Dock = DockStyle.Fill;
            displayTextBox.Location = new Point(0, 0);
            displayTextBox.Name = "displayTextBox";
            displayTextBox.ReadOnly = true;
            displayTextBox.Size = new Size(573, 385);
            displayTextBox.TabIndex = 3;
            displayTextBox.Text = "";
            displayTextBox.WordWrap = false;
            // 
            // runTestsButton
            // 
            runTestsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            runTestsButton.Location = new Point(584, 12);
            runTestsButton.Name = "runTestsButton";
            runTestsButton.Size = new Size(96, 35);
            runTestsButton.TabIndex = 4;
            runTestsButton.Text = "Run Tests";
            runTestsButton.UseVisualStyleBackColor = true;
            runTestsButton.Click += runTestsButton_Click;
            // 
            // stopTestsButton
            // 
            stopTestsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stopTestsButton.Enabled = false;
            stopTestsButton.Location = new Point(686, 12);
            stopTestsButton.Name = "stopTestsButton";
            stopTestsButton.Size = new Size(102, 35);
            stopTestsButton.TabIndex = 5;
            stopTestsButton.Text = "Stop Tests";
            stopTestsButton.UseVisualStyleBackColor = true;
            stopTestsButton.Click += stopTestsButton_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 53);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(testTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(displayTextBox);
            splitContainer1.Size = new Size(776, 385);
            splitContainer1.SplitterDistance = 199;
            splitContainer1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(stopTestsButton);
            Controls.Add(runTestsButton);
            Controls.Add(jsonFileLabel);
            Controls.Add(jsonFileButton);
            Name = "Form1";
            Text = "Python Test Runner";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button jsonFileButton;
        private Label jsonFileLabel;
        private OpenFileDialog jsonFileDialog;
        private TreeView testTreeView;
        private RichTextBox displayTextBox;
        private Button runTestsButton;
        private Button stopTestsButton;
        private ImageList testIconList;
        private SplitContainer splitContainer1;
    }
}
