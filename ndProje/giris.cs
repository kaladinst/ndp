using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ndProje
{
    public partial class giris : Form
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public giris()
        {
            InitializeComponent();
        }

        private void girisButton_Click(object sender, EventArgs e)
        {
            KullaniciAdi = kullaniciText.Text;
            Sifre = sifreText.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
