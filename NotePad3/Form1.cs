using System;
using System.Windows.Forms;
using System.IO;

namespace NotePad3
{
    public partial class FormMainWindow : Form
    {

        private const string Version = "0.01";
        private const string BuildDate = "2020-01-24";

        public FormMainWindow()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msgText = "Notepad3 version " + Version + ". Built on " + BuildDate;
            MessageBox.Show(msgText);
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
    }
}
