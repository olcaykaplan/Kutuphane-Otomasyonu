using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _KutuphaneOtomasyonu
{
    public partial class _KitapAra : Form
    {
        public static _KitapAra pointer = null;
        public _KitapAra()
        {
            pointer = this;
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        DataTable table = new DataTable();
        private void btnGeridon_Click(object sender, EventArgs e)
        {
            this.Hide();
            _AnaMonu.pointer.Show();
        }
        private void guncelle() 
        {
            table.Clear();
            SqlDataAdapter adptr = new SqlDataAdapter("select ");
            adptr.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void _KitapAra_Load(object sender, EventArgs e)
        {

        }

        private void btnKitapAra_Click(object sender, EventArgs e)
        {

        }
    }
}
