using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace winFormElenaa
{
    public partial class Form1 : Form
    {
        private string connString = "Server=localhost; Port=5432; User Id=postgres; Password=elenong; Database=postgres";
        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        string jenisKelaminPick;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connString);
            Select();

        }
        private void Select()
        {
            conn.Open();
            sql = @"select * from datamuridsma";
            cmd = new NpgsqlCommand(sql, conn);
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            dataGridView1.DataSource = dt;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                jenisKelaminPick = "Laki-laki";
            }
            else
            {
                jenisKelaminPick = "Perempuan";
            }

            conn.Open();
            string q = @"insert into datamuridsma (noInduk, namaMurid, kelasMurid, jenisKelamin) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + jenisKelaminPick+ "')";
            cmd = new NpgsqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data berhasil ditambahkan");
            conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string edit = @"update datamuridsma set namaMurid='" + textBox3.Text + "' where namaMurid='" + textBox2.Text + "'";
            cmd = new NpgsqlCommand(edit, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data berhasil di update");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            string delete = @"delete from datamuridsma where namaMurid = '" + textBox2.Text + "'";
            cmd = new NpgsqlCommand(delete, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data berhasil dihapus");
        }

    }
}