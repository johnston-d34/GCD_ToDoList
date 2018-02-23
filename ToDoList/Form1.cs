using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToDoList
{
    public partial class frmToDoList : Form
    {
        private ToDoManager TDL;
        public frmToDoList()
        {
            InitializeComponent();
            TDL = new ToDoManager();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstToDoList.Items.Add(txtItems.Text);
            ToDos t = new ToDos() { TDL = txtItems.Text };
            TDL.Add(t);
            if (txtItems.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please Type an Item to Do");
            }
            txtItems.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstToDoList.Items.RemoveAt(lstToDoList.SelectedIndex);
            lstToDoList.Refresh();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtItems.Clear();
            lstToDoList.Items.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog()
            {
                Filter = "txt files|*.txt",
                Title = "Enter Name of File You Wish To Save"
            };
            if (Convert.ToBoolean(dialog.ShowDialog()) == true) 
            {
                var file = dialog.FileName;
                TDL.SaveToCSV(file);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "txt files|*.txt",
                Title = "Enter Name of File You Wish to Load"
            };

            if (Convert.ToBoolean(dialog.ShowDialog()) == true) 
            {
                TDL.LoadFromCSV(dialog.FileName);
            }
            foreach(ToDos t in TDL.GetList())
            {
                lstToDoList.Items.Add(t);
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To use the to do list, please type in your " +
                "item to do in the text box provided and then click on the 'Add' " +
                "button. \nTo Delete an item, simply click on the item" +
                "in the list box below and click on 'Delete'");
        }
    }
}
