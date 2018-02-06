using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ksu.Cis300.Sort;

namespace Ksu.Cis300.TextAnalyzer
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the file name of the first text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText1_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText1.Text = uxOpenDialog.FileName.ToString();
                if (uxText2.Text != "")
                {
                    uxAnalyze.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Sets the file name of the second text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText2_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText2.Text = uxOpenDialog.FileName.ToString();
                if(uxText1.Text != "")
                {
                    uxAnalyze.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Shows the Difference value in a message box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, WordCount> dictionary = new Dictionary<string, WordCount>();
                int[] wordCounts = new int[2];
                wordCounts[0] = TestAnalyzer.ProcessFile(uxText1.Text, 0, dictionary);
                wordCounts[1] = TestAnalyzer.ProcessFile(uxText2.Text, 1, dictionary);
                MinPriorityQueue<float, WordFrequency> queue = TestAnalyzer.GetMostCommonWords(dictionary, wordCounts, Convert.ToInt32(uxNumber.Value));
                MessageBox.Show("Difference measure: " + TestAnalyzer.GetDifference(queue).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
