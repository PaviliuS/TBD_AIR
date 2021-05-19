using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TBD_AIR
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommand command = null;
        private void view(string str)
        {
            dataAdapter = new SqlDataAdapter(str, sqlConnection);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            dataAdapter.Dispose();
            dataSet.Dispose();
        }
        private void procedure(string str)
        {
            command = new SqlCommand(str, sqlConnection);
            if (command.ExecuteNonQuery().ToString() == "-1")
            {
                MessageBox.Show("Ошибка!");
            }
            else
            {
                MessageBox.Show("Успешно!");
            }
            command.Dispose();
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AIRDB"].ConnectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение к БД установлено");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            view("select * from v_passengers");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            view("select * from v_planes");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            view("select * from v_cities");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            view("select * from v_employees");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            view("select * from v_terminals");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            view("select * from v_classes");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            view("select * from v_sales");
        }
        private void buttonSale_Click(object sender, EventArgs e)
        {
            procedure($"INSERT INTO t_sales(f_passenger, f_plane, f_city, f_employee, f_terminal, f_class, f_ticket_volume, f_price, f_data)VALUES(N'{textBox1.Text}', N'{textBox2.Text}', N'{textBox3.Text}', N'{textBox4.Text}', N'{textBox5.Text}', N'{textBox6.Text}',N'{textBox7.Text}', N'{textBox8.Text}', SYSDATETIME());");
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            procedure($"INSERT INTO t_passengers(f_name_1, f_name_2, f_name_3, f_passport) VALUES(N'{textBox9.Text}', N'{textBox10.Text}', N'{textBox11.Text}', N'{textBox12.Text}');");
        }
    }
}
