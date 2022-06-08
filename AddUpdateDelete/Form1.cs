using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddUpdateDelete
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emre\OneDrive\Belgeler\ekleSil.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into anaEkran values('" + txtUrunAdi.Text + "','" + txtFiyat.Text + "','" + txtAdet.Text + "')";
            sqlCommand.ExecuteNonQuery();
            con.Close();
            txtUrunAdi.Text = "";
            txtAdet.Text = "";
            txtFiyat.Text = "";
            
            dataGoster();

            MessageBox.Show("Kayıt başarı ile yapıldı.");
        }
        public void dataGoster()
        {
            con.Open();
            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from anaEkran";
            sqlCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter(sqlCommand);
            da.Fill(dataTable);
            dataGridView1.DataSource= dataTable;

            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGoster();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from anaEkran where productName='" + txtSilinecekUrun.Text + "'"; 
            sqlCommand.ExecuteNonQuery();
            con.Close();
            txtSilinecekUrun.Text = "";
            dataGoster();

            MessageBox.Show("Kayıt başarı ile silindi.");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from anaEkran where productName='"+txtAra.Text+"'";
            sqlCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            con.Close();
            txtUrunAdi.Text = "";
        }
    }
}
