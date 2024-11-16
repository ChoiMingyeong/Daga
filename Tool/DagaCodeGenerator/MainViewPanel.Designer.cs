namespace DagaCodeGenerator
{
    partial class MainViewPanel
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            Label label1;
            Label label2;
            splitContainer1 = new SplitContainer();
            checkedListView1 = new CheckedListView();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            srcPathTextBox = new TextBox();
            srcPathSelectBtn = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            outputPathTextBox = new TextBox();
            outputPathSelectBtn = new Button();
            genBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 36);
            label1.TabIndex = 2;
            label1.Text = "Open";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 35);
            label2.TabIndex = 2;
            label2.Text = "Output";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(checkedListView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(468, 396);
            splitContainer1.SplitterDistance = 317;
            splitContainer1.TabIndex = 0;
            // 
            // checkedListView1
            // 
            checkedListView1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            checkedListView1.Dock = DockStyle.Fill;
            checkedListView1.Location = new Point(0, 0);
            checkedListView1.Name = "checkedListView1";
            checkedListView1.Size = new Size(468, 317);
            checkedListView1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(genBtn);
            splitContainer2.Panel2.Padding = new Padding(5);
            splitContainer2.Size = new Size(468, 75);
            splitContainer2.SplitterDistance = 373;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer3.Size = new Size(373, 75);
            splitContainer3.SplitterDistance = 36;
            splitContainer3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.3972282F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.04558F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.6005363F));
            tableLayoutPanel1.Controls.Add(srcPathTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(srcPathSelectBtn, 2, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(373, 36);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // srcPathTextBox
            // 
            srcPathTextBox.Dock = DockStyle.Fill;
            srcPathTextBox.Location = new Point(64, 3);
            srcPathTextBox.Name = "srcPathTextBox";
            srcPathTextBox.Size = new Size(258, 23);
            srcPathTextBox.TabIndex = 0;
            // 
            // srcPathSelectBtn
            // 
            srcPathSelectBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            srcPathSelectBtn.Dock = DockStyle.Fill;
            srcPathSelectBtn.Location = new Point(328, 3);
            srcPathSelectBtn.Name = "srcPathSelectBtn";
            srcPathSelectBtn.Size = new Size(42, 30);
            srcPathSelectBtn.TabIndex = 1;
            srcPathSelectBtn.Text = "..";
            srcPathSelectBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.3972282F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.77748F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.8686323F));
            tableLayoutPanel2.Controls.Add(outputPathTextBox, 1, 0);
            tableLayoutPanel2.Controls.Add(outputPathSelectBtn, 2, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(373, 35);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // outputPathTextBox
            // 
            outputPathTextBox.Dock = DockStyle.Fill;
            outputPathTextBox.Location = new Point(64, 3);
            outputPathTextBox.Name = "outputPathTextBox";
            outputPathTextBox.Size = new Size(257, 23);
            outputPathTextBox.TabIndex = 0;
            // 
            // outputPathSelectBtn
            // 
            outputPathSelectBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            outputPathSelectBtn.Dock = DockStyle.Fill;
            outputPathSelectBtn.Location = new Point(327, 3);
            outputPathSelectBtn.Name = "outputPathSelectBtn";
            outputPathSelectBtn.Size = new Size(43, 29);
            outputPathSelectBtn.TabIndex = 1;
            outputPathSelectBtn.Text = "..";
            outputPathSelectBtn.UseVisualStyleBackColor = true;
            // 
            // genBtn
            // 
            genBtn.AutoSize = true;
            genBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            genBtn.Dock = DockStyle.Fill;
            genBtn.Location = new Point(5, 5);
            genBtn.Name = "genBtn";
            genBtn.Size = new Size(81, 65);
            genBtn.TabIndex = 0;
            genBtn.Text = "Generate";
            genBtn.UseVisualStyleBackColor = true;
            // 
            // MainViewPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "MainViewPanel";
            Size = new Size(468, 396);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private CheckedListView checkedListView1;
        private SplitContainer splitContainer2;
        private Button genBtn;
        private SplitContainer splitContainer3;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox srcPathTextBox;
        private Button srcPathSelectBtn;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox outputPathTextBox;
        private Button outputPathSelectBtn;
    }
}
