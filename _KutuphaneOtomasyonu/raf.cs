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
    public partial class raf : Form
    {
        public static raf pointer = null;
        public raf()
        {
            pointer = this;
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        DataTable table = new DataTable();

        private void guncel()
        {
            table.Clear();
            SqlDataAdapter adptr = new SqlDataAdapter("select RafSutun, RafSatir from Shelves", con);
            adptr.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ShelvesInsert";
            cmd.Parameters.AddWithValue("@raf_id", ParameterDirection.Output);
            cmd.Parameters.AddWithValue("@RafSutun", txtSutun.Text);
            cmd.Parameters.AddWithValue("@RafSatir", txtSatir.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            guncel();
        }

        private void raf_Load(object sender, EventArgs e)
        {
            guncel();
        }
    }
}
