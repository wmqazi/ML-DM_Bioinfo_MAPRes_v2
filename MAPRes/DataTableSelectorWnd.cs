using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class DataTableSelectorWnd : Form
    {
        public DataTableSelectorWnd(string title, DataSet dataset)
        {
            InitializeComponent();
            this.lblDataTableFor.Text = title;
            foreach (DataTable t in dataset.Tables)
            {
                lstOfTableName.Items.Add(t.TableName);                
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string TableName
        {
            get {
                return this.lstOfTableName.SelectedItem.ToString();
            }
        }
    }
}