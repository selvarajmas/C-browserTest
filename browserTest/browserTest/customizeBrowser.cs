using System;
using System.Windows.Forms;

namespace browserTest
{
    public partial class customizeBrowser : Form
    {
        String Url = string.Empty;
        public customizeBrowser()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.ScrollBarsEnabled = true;
            webBrowser1.Dock = DockStyle.Fill;
            Url = "http://jpclass.sathisys.com/sjla/controller/loginController.php";
            myBrowser();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            backToolStripMenuItem.Enabled = false;
            forwardToolStripMenuItem.Enabled = false;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.co.in/");
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void myBrowser()
        {
            webBrowser1.Navigate(Url);
            webBrowser1.ProgressChanged +=
            new WebBrowserProgressChangedEventHandler(webpage_ProgressChanged);
            webBrowser1.DocumentTitleChanged +=
            new EventHandler(webpage_DocumentTitleChanged);
            webBrowser1.StatusTextChanged += new EventHandler(webpage_StatusTextChanged);
            webBrowser1.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(webpage_DocumentCompleted);
        }

        private void webpage_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.CanGoBack) backToolStripMenuItem.Enabled = true;
            else backToolStripMenuItem.Enabled = false;

            if (webBrowser1.CanGoForward) forwardToolStripMenuItem.Enabled = true;
            else forwardToolStripMenuItem.Enabled = false;
            toolStripStatusLabel1.Text = "完了";
        }

        private void webpage_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle.ToString();
        }

        private void webpage_StatusTextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = webBrowser1.StatusText;
        }

        private void webpage_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Maximum = (int)e.MaximumProgress;
            toolStripProgressBar1.Value = ((int)e.CurrentProgress < 0 ||
            (int)e.MaximumProgress < (int)e.CurrentProgress) ?
            (int)e.MaximumProgress : (int)e.CurrentProgress;
        }

        private void uRLToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void goToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myBrowser();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}