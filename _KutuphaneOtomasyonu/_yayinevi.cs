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
    public partial class _yayinevi : Form
    {
        public static _yayinevi pointer = null;
        public _yayinevi()
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
            SqlDataAdapter adptr = new SqlDataAdapter("select Yayievi_adi, yayinevi_adres, yayinevi_tel,yayinevi_eposta from PublishingHouse", con);
            adptr.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _yayinevi_Load(object sender, EventArgs e)
        {
            guncel();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PublishingHouseInsert";
            cmd.Parameters.AddWithValue("@yayinevi_id", ParameterDirection.Output);
            cmd.Parameters.AddWithValue("@Yayinevi_adi", txtAD.Text);
            cmd.Parameters.AddWithValue("@yayinevi_adres", txtAdres.Text);
            cmd.Parameters.AddWithValue("@yayinevi_tel", txtTel.Text);
            cmd.Parameters.AddWithValue("@yayinevi_eposta", txtE_posta.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            guncel();
        }
    }
}
