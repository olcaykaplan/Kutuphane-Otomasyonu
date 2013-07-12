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
    public partial class _Uye : Form
    {
        public _Uye()
        {
            InitializeComponent();
        }

        private void _Uye_Load(object sender, EventArgs e)
        {
            cmbSehir.SelectedIndex = 0;
        }

        private void btnGeridon_Click(object sender, EventArgs e)
        {
            this.Hide();
            _AnaMonu anamenu = new _AnaMonu();
            anamenu.ShowDialog();
            
        }
    }
}
