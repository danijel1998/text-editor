using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace text_editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newCtrlNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            this.Text = "New Document";
        }

        private void openCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Rich Text File(*.rtf)|*.rtf";
            if (DialogResult.OK == ofd.ShowDialog())
            {
                string text = File.ReadAllText(ofd.FileName);
                this.Text = ofd.FileName;
                richTextBox1.Text = text;
            }
        }

        private void saveAsCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rich Text File(*.rtf)|*.rtf";
            if (DialogResult.OK == sfd.ShowDialog())
            {   
                File.WriteAllText(sfd.FileName, richTextBox1.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = Clipboard.GetText();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void cutOnClick(object sender, EventArgs e)
        {
            
            if (richTextBox1.SelectedText != "")
            {
                string text = richTextBox1.SelectedText;
                Clipboard.SetText(text);
                richTextBox1.SelectedText = "";
            }
        }

        private void copyOnClick(object sender, EventArgs e)
        {
            
            if (richTextBox1.SelectedText != "")
            {
                string text = richTextBox1.SelectedText;
                Clipboard.SetText(text);
            }
        }

        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuStripCopy.Enabled = contextMenuCopy.Enabled = !String.IsNullOrEmpty(richTextBox1.SelectedText);
            menuStripCut.Enabled = contextMenuCut.Enabled = !String.IsNullOrEmpty(richTextBox1.SelectedText);
            menuStripPaste.Enabled = contextMenuPaste.Enabled = !String.IsNullOrEmpty(Clipboard.GetText());
        }

        private void menuStripClick(object sender, EventArgs e)
        {
            menuStripCopy.Enabled = contextMenuCopy.Enabled = !String.IsNullOrEmpty(richTextBox1.SelectedText);
            menuStripCut.Enabled = contextMenuCut.Enabled = !String.IsNullOrEmpty(richTextBox1.SelectedText);
            menuStripPaste.Enabled = contextMenuPaste.Enabled = !String.IsNullOrEmpty(Clipboard.GetText());
        }

        private void colorSelect(object sender, EventArgs e)
        {
            ToolStripMenuItem miColor = (ToolStripMenuItem)sender;
            richTextBox1.SelectionColor = Color.FromName(miColor.Text);
        }

        private void allColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void allFontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
        }
        private void changeFontType(object sender, EventArgs e)
        {
            ToolStripMenuItem fontType = (ToolStripMenuItem)sender;
            switch (fontType.Text)
            {
                case "Bold":
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                    break;
                case "Italic":
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic);
                    break;
                case "Underline":
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
                    break;

            }

        }
    }
}
