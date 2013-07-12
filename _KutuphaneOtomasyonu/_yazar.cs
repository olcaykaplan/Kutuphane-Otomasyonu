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
    public partial class _yazar : Form
    {
        public static _yazar pointer = null;
        public _yazar()
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
            SqlDataAdapter adptr = new SqlDataAdapter("select yazar_adi, yazar_soyadi from Author",con);
            adptr.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void _yazar_Load(object sender, EventArgs e)
        {
            guncel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AuthorInsert";
            cmd.Parameters.AddWithValue("@yazar_id",ParameterDirection.Output);
            cmd.Parameters.AddWithValue("@yazar_adi",textBox1.Text);
            cmd.Parameters.AddWithValue("@yazar_soyadi",textBox2.Text);
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
