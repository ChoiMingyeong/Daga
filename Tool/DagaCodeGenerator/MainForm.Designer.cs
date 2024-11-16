

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
            tabControl = new TabControl();
            constantPage = new TabPage();
            enumPage = new TabPage();
            dataTablePage = new TabPage();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(constantPage);
            tabControl.Controls.Add(enumPage);
            tabControl.Controls.Add(dataTablePage);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(10, 10);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(527, 364);
            tabControl.TabIndex = 0;
            // 
            // constantPage
            // 
            constantPage.Location = new Point(4, 24);
            constantPage.Name = "constantPage";
            constantPage.Padding = new Padding(3);
            constantPage.Size = new Size(519, 336);
            constantPage.TabIndex = 0;
            constantPage.Text = "Constant";
            constantPage.UseVisualStyleBackColor = true;
            constantPage.Controls.Add(new MainViewPanel()
            {
                Dock = DockStyle.Fill,
            });
            // 
            // enumPage
            // 
            enumPage.Location = new Point(4, 24);
            enumPage.Name = "enumPage";
            enumPage.Padding = new Padding(3);
            enumPage.Size = new Size(519, 336);
            enumPage.TabIndex = 1;
            enumPage.Text = "Enum";
            enumPage.UseVisualStyleBackColor = true;
            enumPage.Controls.Add(new MainViewPanel()
            {
                Dock = DockStyle.Fill,
            });
            // 
            // enumPage
            // 
            dataTablePage.Location = new Point(4, 24);
            dataTablePage.Name = "dataTablePage";
            dataTablePage.Padding = new Padding(3);
            dataTablePage.Size = new Size(519, 336);
            dataTablePage.TabIndex = 2;
            dataTablePage.Text = "DataTable";
            dataTablePage.UseVisualStyleBackColor = true;
            dataTablePage.Controls.Add(new MainViewPanel()
            {
                Dock = DockStyle.Fill,
            });
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(547, 384);
            Controls.Add(tabControl);
            MaximizeBox = false;
            Name = "MainForm";
            Padding = new Padding(10);
            Text = "DagaCodeGenerator";
            Load += MainForm_Load;
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage constantPage;
        private TabPage enumPage;
        private TabPage dataTablePage;
    }
}
