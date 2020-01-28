using System;
using System.Windows.Forms;
using System.IO;

namespace NotePad3
{
    public partial class FormMainWindow : Form
    {

        public FormMainWindow()
        {
            InitializeComponent();
            toolStripStatusLabelFileName.Text = tabPage1.Text;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _about = new AboutBox1();
            _about.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.Title = "Save file as...";
            saveFile.DefaultExt = ".txt";
            DialogResult result = saveFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFile.FileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(fs);
                writer.Write(textBoxDocument.Text);
                writer.Close();
            }

        }

        private void updateStatusIndicators(object sender, EventArgs e)
        {
            toolStripStatusLabelLength.Text = "Length: " + textBoxDocument.TextLength;
            toolStripStatusLabelCursorPosition.Text = "Pos: (" + textBoxDocument.SelectionStart + ")";
        }

        private void insertTimestampToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var caretPosition = textBoxDocument.SelectionStart;
            var dateAndTime = System.DateTime.Now.ToString();
            textBoxDocument.Text = textBoxDocument.Text.Insert(caretPosition, dateAndTime);
            textBoxDocument.SelectionStart = caretPosition + dateAndTime.Length;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxDocument.WordWrap)
            {
                textBoxDocument.WordWrap = false;
                wordWrapToolStripMenuItem.Checked = false;
            }
            else
            {
                textBoxDocument.WordWrap = true;
                wordWrapToolStripMenuItem.Checked = true;
            }
        }
    }
}
