using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BarCodePrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpn.Text!="" ||txtpo.Text!="")
            {
                this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", 600, 800);           
                this.printDocument1.PrintPage += new PrintPageEventHandler(this.MyPrintDocument_PrintPage);
                PrintController printController = new StandardPrintController();
                printDocument1.PrintController = printController;
                this.printDocument1.Print();
                this.printDocument1.PrintPage -= new PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            }
            else
            {               
                MessageBox.Show("请输入PN或PO！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       


                    }        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)        {           
            e.Graphics.TranslateTransform(200, 30);
            e.Graphics.RotateTransform(90.0F);
            if (txtpn.Text!="")
            {
                e.Graphics.DrawString($"PN:{txtpn.Text}", new Font(new FontFamily("黑体"), 15), System.Drawing.Brushes.Black, 0, 0);
                e.Graphics.DrawString($"*{txtpn.Text}*", fn, System.Drawing.Brushes.Black, 0, 30);
            }
            if (txtpo.Text!="")
            {
                e.Graphics.DrawString($"PO:{txtpo.Text}", new Font(new FontFamily("黑体"), 15), System.Drawing.Brushes.Black, 0, 80);
                e.Graphics.DrawString($"*{txtpo.Text}*", fn, System.Drawing.Brushes.Black, 0, 110);
            
            }
                    
        }
        System.Drawing.Font fn;
        private void Form1_Load(object sender, EventArgs e)
        {
            string fontspath = $"{Application.StartupPath.ToString()}\\Fonts\\FRE3OF9X.TTF";
            if (File.Exists(fontspath))
            {
                PrivateFontCollection privateFonts = new PrivateFontCollection();
                privateFonts.AddFontFile(fontspath);
                fn = new Font(privateFonts.Families[0], 28);


            }
            else
            {
                MessageBox.Show("条码字体不存在！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
     



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }
    }
}
