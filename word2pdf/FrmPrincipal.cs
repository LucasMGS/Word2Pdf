using System;
using System.IO;
using System.Windows.Forms;
using SautinSoft.Document;

namespace word2pdf
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void BtnConverter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFileName.Text)) return;

                var docPath = txtFileName.Text;
                var pdfPath = docPath.Replace(".docx", ".pdf");

                var dc = DocumentCore.Load(docPath);
                dc.Save(pdfPath);

                txtFileName.Text = string.Empty;
                btnSelecionar.Enabled = true;
                btnConverter.Enabled = false;

                MessageBox.Show(this, "Arquivo convertido com sucesso!", @"Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:", ex.Message);

                txtFileName.Text = string.Empty;
                btnSelecionar.Enabled = true;
                btnConverter.Enabled = false;
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                var arquivo = new OpenFileDialog
                {
                    Filter = @"Todos os arquivos (*.doc, *.docx) | *.doc; *.docx",
                    Title = @"Escolha o arquivo para conversão",
                    RestoreDirectory = true
                };

                if (arquivo.ShowDialog() != DialogResult.OK) return;

                txtFileName.Text = arquivo.FileName;

                btnConverter.Enabled = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:", ex.Message);
            }
        }
    }
}
