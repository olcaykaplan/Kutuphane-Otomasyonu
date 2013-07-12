using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _KutuphaneOtomasyonu
{
    public partial class _AnaMonu : Form
    {
            public static _AnaMonu pointer = null;


        public _AnaMonu()
        {
            pointer = this;
            InitializeComponent();
           
        }

        private void btnUyeler_Click(object sender, EventArgs e)
        {
            this.Hide();
            _Uye uyeler = new _Uye();
            uyeler.ShowDialog();
            
        }

        private void btnKitaplar_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (_Kitap.pointer == null)
            {
                _Kitap kitaplar = new _Kitap();
                kitaplar.Show();
            }
            else
            {
                _Kitap.pointer.Show();
            }
        }

        private void _AnaMonu_Load(object sender, EventArgs e)
        {
   
        }

        private void btnKitapAra_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (_KitapAra.pointer==null)
	        {
                _KitapAra kitapara = new _KitapAra();
                kitapara.Show();
	        }
            else
            {
                _KitapAra.pointer.Show();
            }
          
        }
    }
}
