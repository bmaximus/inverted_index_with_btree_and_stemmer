using BTree;
using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        private InvertedIndex invertedIndex;

        public Form1()
        {
            InitializeComponent();
            invertedIndex = new InvertedIndex();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!txtSearchText.Text.Any())
            {
                resultListBox.DataBindings.Clear();
            }
            var searchResults = invertedIndex.GetResults(txtSearchText.Text);

            var res = searchResults;
            resultListBox.DataSource = res;

        }

        private void resultListBox_DoubleClick(object sender, EventArgs e)
        {
            Document selectedDocument = resultListBox.SelectedItem as Document;
            Process.Start(string.Format("{0}\\{1}.txt", invertedIndex.Path, selectedDocument.DocumentId));
        }
    }
}
