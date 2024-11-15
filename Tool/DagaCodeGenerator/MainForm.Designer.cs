

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
            srcCheckedListBox = new CheckedListBox();
            outputSearchBtn = new Button();
            outputPathTextBox = new TextBox();
            button3 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            label1 = new Label();
            label2 = new Label();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 337);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 366);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 4;
            label2.Text = "Output";
            // 
            // srcPathTextBox
            // 
            srcPathTextBox.Location = new Point(62, 334);
            srcPathTextBox.Name = "srcPathTextBox";
            srcPathTextBox.Size = new Size(314, 23);
            srcPathTextBox.TabIndex = 1;
            // 
            // srcSearchBtn
            // 
            srcSearchBtn.Location = new Point(382, 334);
            srcSearchBtn.Name = "srcSearchBtn";
            srcSearchBtn.Size = new Size(27, 23);
            srcSearchBtn.TabIndex = 2;
            srcSearchBtn.Text = "..";
            srcSearchBtn.UseVisualStyleBackColor = true;
            srcSearchBtn.Click += srcSearchBtn_Click;
            // 
            // srcCheckedListBox
            // 
            srcCheckedListBox.CheckOnClick = true;
            srcCheckedListBox.FormattingEnabled = true;
            srcCheckedListBox.Location = new Point(12, 12);
            srcCheckedListBox.Name = "srcCheckedListBox";
            srcCheckedListBox.Size = new Size(503, 310);
            srcCheckedListBox.TabIndex = 3;
            // 
            // outputSearchBtn
            // 
            outputSearchBtn.Location = new Point(382, 363);
            outputSearchBtn.Name = "outputSearchBtn";
            outputSearchBtn.Size = new Size(27, 23);
            outputSearchBtn.TabIndex = 6;
            outputSearchBtn.Text = "..";
            outputSearchBtn.UseVisualStyleBackColor = true;
            outputSearchBtn.Click += outputSearchBtn_Click;
            // 
            // outputPathTextBox
            // 
            outputPathTextBox.Location = new Point(62, 363);
            outputPathTextBox.Name = "outputPathTextBox";
            outputPathTextBox.Size = new Size(314, 23);
            outputPathTextBox.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(415, 334);
            button3.Name = "button3";
            button3.Size = new Size(100, 52);
            button3.TabIndex = 8;
            button3.Text = "Generate";
            button3.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 397);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(529, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(529, 419);
            Controls.Add(statusStrip1);
            Controls.Add(button3);
            Controls.Add(outputSearchBtn);
            Controls.Add(outputPathTextBox);
            Controls.Add(label2);
            Controls.Add(srcCheckedListBox);
            Controls.Add(srcSearchBtn);
            Controls.Add(srcPathTextBox);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "DagaCodeGenerator";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox srcPathTextBox;
        private Button srcSearchBtn;
        private CheckedListBox srcCheckedListBox;
        private Button outputSearchBtn;
        private TextBox outputPathTextBox;
        private Button button3;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
    }
}
