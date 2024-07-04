using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        private string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Table1.mdb; ";
        DataTable dataTable = new DataTable();

        public delegate void BookingDeletedEventHandler(string login, string valueToDelete);
        


        public Form7()
        {
            InitializeComponent();
            LoadDataToDataGridView(dataGridView2);
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "table1DataSet3.Table1". При необходимости она может быть перемещена или удалена.
            this.table1TableAdapter2.Fill(this.table1DataSet3.Table1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "table1DataSet1.Table1". При необходимости она может быть перемещена или удалена.
            this.table1TableAdapter1.Fill(this.table1DataSet1.Table1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            //// TODO: данная строка кода позволяет загрузить данные в таблицу "table1DataSet.Table1". При необходимости она может быть перемещена или удалена.
            //this.table1TableAdapter.Fill(this.table1DataSet.Table1);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            // Показываем Form2 и скрываем текущую форму (Form1)
            form2.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadDataIntoDataGridView()
        {
            using (OleDbConnection dbConnection = new OleDbConnection(connectString))
            {
                dbConnection.Open();
                string selectQuery = "SELECT * FROM Table1";
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectQuery, dbConnection))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //  доделать уведомление 
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                    // Получаем значение в первом столбце выбранной строки
                    string valueToDelete = selectedRow.Cells[0].Value.ToString();
                    string valueToDelete1 = selectedRow.Cells[1].Value.ToString();
                    string deleteQuery = "DELETE FROM Table1 WHERE [логин] = ? AND [дата]=?";

                    using (OleDbConnection dbConnection = new OleDbConnection(connectString))
                    {
                        dbConnection.Open();
                        using (OleDbCommand command = new OleDbCommand(deleteQuery, dbConnection))
                        {
                            command.Parameters.AddWithValue("логин", valueToDelete);
                            command.Parameters.AddWithValue("дата", valueToDelete1);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Запись успешно удалена.");
                                LoadDataIntoDataGridView(); // Обновляем DataGridView после удаления
                            }
                            else
                            {
                                MessageBox.Show("Запись с указанным не найдена.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при удалении записи: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.");
            }
        }
        public void LoadDataToDataGridView(DataGridView dataGridView2)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
