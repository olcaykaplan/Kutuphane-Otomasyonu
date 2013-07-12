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
    public partial class Tur : Form
    {
        public static Tur pointer = null;
        public Tur()
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
            SqlDataAdapter adptr = new SqlDataAdapter("select Tur from BooksType", con);
            adptr.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Tur_Load(object sender, EventArgs e)
        {
            guncel();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BooksTypeInsert";
            cmd.Parameters.AddWithValue("@tur_id",ParameterDirection.Output);
            cmd.Parameters.AddWithValue("@Tur",textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            guncel();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
