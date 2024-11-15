

namespace DagaCodeGenerator
{
    partial class MainForm
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
            Label label1;
            Label label2;
            srcPathTextBox = new TextBox();
            srcSearchBtn = new Button();
            outputSearchBtn = new Button();
            outputPathTextBox = new TextBox();
            button3 = new Button();
            splitContainer1 = new SplitContainer();
            checkedListView1 = new CheckedListView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 18);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 47);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 4;
            label2.Text = "Output";
            // 
            // srcPathTextBox
            // 
            srcPathTextBox.Location = new Point(53, 15);
            srcPathTextBox.Name = "srcPathTextBox";
            srcPathTextBox.Size = new Size(314, 23);
            srcPathTextBox.TabIndex = 1;
            // 
            // srcSearchBtn
            // 
            srcSearchBtn.Location = new Point(373, 15);
            srcSearchBtn.Name = "srcSearchBtn";
            srcSearchBtn.Size = new Size(27, 23);
            srcSearchBtn.TabIndex = 2;
            srcSearchBtn.Text = "..";
            srcSearchBtn.UseVisualStyleBackColor = true;
            srcSearchBtn.Click += srcSearchBtn_Click;
            // 
            // outputSearchBtn
            // 
            outputSearchBtn.Location = new Point(373, 44);
            outputSearchBtn.Name = "outputSearchBtn";
            outputSearchBtn.Size = new Size(27, 23);
            outputSearchBtn.TabIndex = 6;
            outputSearchBtn.Text = "..";
            outputSearchBtn.UseVisualStyleBackColor = true;
            outputSearchBtn.Click += outputSearchBtn_Click;
            // 
            // outputPathTextBox
            // 
            outputPathTextBox.Location = new Point(53, 44);
            outputPathTextBox.Name = "outputPathTextBox";
            outputPathTextBox.Size = new Size(314, 23);
            outputPathTextBox.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(406, 15);
            button3.Name = "button3";
            button3.Size = new Size(100, 52);
            button3.TabIndex = 8;
            button3.Text = "Generate";
            button3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(10, 10);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(checkedListView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(srcPathTextBox);
            splitContainer1.Panel2.Controls.Add(outputSearchBtn);
            splitContainer1.Panel2.Controls.Add(srcSearchBtn);
            splitContainer1.Panel2.Controls.Add(outputPathTextBox);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Size = new Size(509, 399);
            splitContainer1.SplitterDistance = 314;
            splitContainer1.TabIndex = 9;
            // 
            // checkedListView1
            // 
            checkedListView1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            checkedListView1.Dock = DockStyle.Fill;
            checkedListView1.Location = new Point(0, 0);
            checkedListView1.Name = "checkedListView1";
            checkedListView1.Size = new Size(509, 314);
            checkedListView1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(529, 419);
            Controls.Add(splitContainer1);
            MaximizeBox = false;
            Name = "MainForm";
            Padding = new Padding(10);
            Text = "DagaCodeGenerator";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox srcPathTextBox;
        private Button srcSearchBtn;
        private Button outputSearchBtn;
        private TextBox outputPathTextBox;
        private Button button3;
        private SplitContainer splitContainer1;
        private CheckedListView checkedListView1;
    }
}
