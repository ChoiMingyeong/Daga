namespace DagaCodeGenerator
{
    public partial class CheckedListView : ListView
    {
        // 열 너비 비율 (체크박스 열: 10%, 파일 경로 열: 90%)
        private readonly float[] columnWidthRatios = { 0.1f, 0.9f };

        public CheckedListView()
        {
            // 초기 설정
            View = View.Details;
            CheckBoxes = true;
            FullRowSelect = true;
            GridLines = true;

            // 컬럼 추가
            Columns.Add(new ColumnHeader { Text = "" });
            Columns.Add(new ColumnHeader { Text = "Path" });

            Resize += (sender, e) => AdjustColumnWidths();
            ColumnClick += CustomListView_ColumnClick;
        }

        private void AdjustColumnWidths()
        {
            if (Columns.Count != columnWidthRatios.Length)
                return;

            int totalWidth = ClientSize.Width;
            for (int i = 0; i < Columns.Count; i++)
            {
                Columns[i].Width = (int)(totalWidth * columnWidthRatios[i]);
            }
        }

        private void CustomListView_ColumnClick(object? sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0) // 첫 번째 컬럼(체크박스) 클릭 시
            {
                // 현재 상태 확인
                bool allChecked = Items.Cast<ListViewItem>().All(item => item.Checked);

                // 전체 선택/해제 토글
                foreach (ListViewItem item in Items)
                {
                    item.Checked = !allChecked;
                }
            }
            else
            {
                foreach (ListViewItem item in SelectedItems)
                {
                    item.Checked = true;
                }
            }
        }

        public void AddFilePaths(bool check, params string[] filePaths)
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                var item = new ListViewItem { Checked = check };
                item.SubItems.Add(filePaths[i]);
                Items.Add(item);
            }
        }
    }
}
