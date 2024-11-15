namespace DagaCodeGenerator
{
    partial class CheckedListView
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
            CheckedListViewBox = new ListView();
            SuspendLayout();
            // 
            // CheckedListViewBox
            // 
            CheckedListViewBox.Dock = DockStyle.Fill;
            CheckedListViewBox.Location = new Point(0, 0);
            CheckedListViewBox.Name = "CheckedListViewBox";
            CheckedListViewBox.Size = new Size(300, 300);
            CheckedListViewBox.TabIndex = 0;
            CheckedListViewBox.UseCompatibleStateImageBehavior = false;
            CheckedListViewBox.CheckBoxes = true;
            CheckedListViewBox.FullRowSelect = true;
            // 
            // CheckedListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(CheckedListViewBox);
            Name = "CheckedListView";
            Size = new Size(300, 300);
            ResumeLayout(false);
        }

        #endregion

        private ListView CheckedListViewBox;
    }
}
