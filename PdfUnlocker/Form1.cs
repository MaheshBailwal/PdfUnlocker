using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Pdf.Security;

namespace PdfUnlocker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void brnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "pdf file |*.pdf";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
            }
        }

        private string  Unlock(string filenameSource, string password)
        {
            string filenameDest = filenameSource.Replace(".pdf", "_unlock.pdf", StringComparison.OrdinalIgnoreCase);
            File.Copy(filenameSource,
             filenameDest, true);
            var document = PdfReader.Open(filenameDest, password, PdfDocumentOpenMode.Modify);
            PdfDocumentSecurityLevel level = document.SecuritySettings.DocumentSecurityLevel;
            document.Save(filenameDest);

            return filenameDest;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
             var newfile =  Unlock(txtFile.Text, txtPassword.Text);
                MessageBox.Show($"Unlocked File Created ({newfile})");
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
           
        }
    }
}