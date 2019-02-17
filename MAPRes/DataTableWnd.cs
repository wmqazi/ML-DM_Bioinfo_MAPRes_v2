using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class DataTableWnd : Form
    {
        //<Members>
        private DataTable table;
        //</Members>

        public DataTableWnd(DataTable table, string caption)
        {
            InitializeComponent();
            this.table = table;
            this.Text = "Data Table [" + table.TableName + "]";
            this.toolStripStatusLabel1.Text = "Total Records: " + table.Rows.Count;
            this.grid.DataSource = table.DefaultView;
        }

        public DataTableWnd(DataSet dataset)
        {
            InitializeComponent();
            DataTableSelectorWnd dtsw = new DataTableSelectorWnd("", dataset);
            dtsw.ShowDialog(this);
            if (dtsw.TableName == "")
                return;
            this.table = dataset.Tables[dtsw.TableName];
            this.Text = "Data Table [" + table.TableName + "]";
            this.toolStripStatusLabel1.Text = "Total Records: " + table.Rows.Count;
            this.grid.DataSource = table.DefaultView;
            dtsw.Dispose();
        }

        public void ShowAsMDIChild(Form mdiParent)
        {
            this.MdiParent = mdiParent;
            this.Show();
        }

        public void ShowAsChild(Form owner)
        {
            this.Owner = owner;
            this.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDlg.ShowDialog(this);
            string filename = saveDlg.FileName;
            if (filename == "")
                return;

            table.WriteXml(filename);
        }


        public bool MenuBarVisible
        {
            set {
                this.menuStrip1.Visible = true;
            }
            get {
                return menuStrip1.Visible;
            }
        }


    }
}