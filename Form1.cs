using Newtonsoft.Json;
using Python.Runtime;

namespace PythonTestRunner
{
    public partial class Form1 : Form
    {
        private string jsonFilePath = "";
        private TestListItem? testList;
        private bool runningTests = false;

        private void FillTreeView()
        {
            string json = File.ReadAllText(jsonFilePath);

            testList = JsonConvert.DeserializeObject<TestListItem>(json);
            testTreeView.Nodes.Clear();

            if (testList != null)
            {
                testTreeView.Nodes.Add(testList.name, testList.name, 4);
                testList.node = testTreeView.Nodes[0];

                foreach (var group in testList.subgroups)
                {
                    AddTestTreeItem(testTreeView.Nodes[0], group);
                }

                testList.node.ExpandAll();
            }
        }

        private void AddTestTreeItem(TreeNode root, TestListItem item)
        {
            root.Nodes.Add(item.name, item.name, 4);
            var groupNode = root.Nodes[root.Nodes.Count - 1];
            item.node = groupNode;

            if (item.tests != null)
            {
                foreach (var test in item.tests)
                {
                    AddTestTreeItem(groupNode, test);
                }
            }

            if (item.subgroups != null)
            {
                foreach (var subgroup in item.subgroups)
                {
                    AddTestTreeItem(groupNode, subgroup);
                }
            }
        }

        private async void RunSelectedTests()
        {
            if (testList == null) { return; }

            runningTests = true;
            testTreeView.Enabled = false;
            runTestsButton.Enabled = false;
            stopTestsButton.Enabled = true;

            var selectedTests = new List<TestListItem>();
            AddSelectedTests(testList, selectedTests);

            displayTextBox.Clear();
            displayTextBox.Update();

            foreach (var test in selectedTests)
            {
                if (!runningTests)
                {
                    displayTextBox.AppendText("Testing stopped");
                    break;
                }

                displayTextBox.AppendText("Running " + test.name + "... ");
                displayTextBox.Update();
                test.node.ImageIndex = 3;

                await Task.Run(test.Run);

                displayTextBox.AppendText(test.testResult.GetValueOrDefault() ? "PASS\n" : "FAIL\n");
                displayTextBox.Update();
                test.node.ImageIndex = test.testResult.GetValueOrDefault() ? 1 : 2;
            }

            runningTests = false;
            testTreeView.Enabled = true;
            runTestsButton.Enabled = true;
            stopTestsButton.Enabled = false;
        }

        private void AddSelectedTests(TestListItem item, List<TestListItem> selected)
        {
            if (item.node.Checked && item.isTest.GetValueOrDefault())
            {
                selected.Add(item);
            }

            if (item.subgroups != null)
            {
                foreach (TestListItem subgroup in item.subgroups)
                {
                    AddSelectedTests(subgroup, selected);
                }
            }

            if (item.tests != null)
            {
                foreach (TestListItem test in item.tests)
                {
                    AddSelectedTests(test, selected);
                }
            }
        }

        private TestListItem? FindMatchingTest(TestListItem? root, TreeNode node)
        {
            if (root == null || node == null || node.Text.Equals(root.name))
            {
                return root;
            }

            if (root.subgroups != null)
            {
                foreach (var group in root.subgroups)
                {
                    var result = FindMatchingTest(group, node);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            if (root.tests != null)
            {
                foreach (var test in root.tests)
                {
                    var result = FindMatchingTest(test, node);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        public Form1()
        {
            InitializeComponent();

            Runtime.PythonDLL = "C:\\Users\\Muhammad\\AppData\\Local\\Programs\\Python\\Python311\\python311.dll";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(jsonFilePath))
            {
                jsonFileLabel.Text = jsonFilePath;
            }
        }

        private void jsonFileButton_Click(object sender, EventArgs e)
        {
            jsonFileDialog.ShowDialog();
        }

        private void jsonFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            jsonFilePath = jsonFileDialog.FileName;
            jsonFileLabel.Text = jsonFilePath;

            FillTreeView();
        }

        private void testTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                foreach (TreeNode child in e.Node.Nodes)
                {
                    child.Checked = e.Node.Checked;
                }
            }
        }

        private void runTestsButton_Click(object sender, EventArgs e)
        {
            RunSelectedTests();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void testTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            displayTextBox.Clear();
            var item = FindMatchingTest(testList, e.Node);
            if (item != null && item.isTest.GetValueOrDefault() && item.logPath != null)
            {
                displayTextBox.Text = File.ReadAllText(item.logPath);
            }
            displayTextBox.Update();
        }

        private void stopTestsButton_Click(object sender, EventArgs e)
        {
            runningTests = false;
        }
    }
}
