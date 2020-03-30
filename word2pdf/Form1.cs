using System;
using System.IO;
using System.Windows.Forms;
using SautinSoft.Document;

namespace word2pdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void BtnConverter_Click(object sender, EventArgs e)
        {
            try
            {
                var fileName = txtBox_fileName.Text;
                var path = @"C:\Users\Lucas Moreira\Desktop";
                var pathFile = path + "\\" + fileName + ".docx";
                var pdfFile = pathFile.Replace(".docx",".pdf");
                
                var dc = DocumentCore.Load(pathFile);
                dc.Save(pdfFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:", ex.Message);
            }
        }
    }
}
