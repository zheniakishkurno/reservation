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
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        string login;
        private string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=table1.mdb; ";
        DataTable dataTable = new DataTable();

      


        public Form6(string login)
        {
            InitializeComponent();
            this.login = login; // Сохраняем логин пользователя


        }

        private void Form6_Load(object sender, EventArgs e)
        {

            this.table1TableAdapter2.Fill(this.table1DataSet2.Table1);
            this.table1TableAdapter1.Fill(this.table1DataSet1.Table1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            LoadDataToDataGridView(); // Загрузка данных в DataGridView

            Form7 form7 = new Form7();
            SetForm7Instance(form7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(login);
            form4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                    // Получаем значение в первом столбце выбранной строки
                    string valueToDelete = selectedRow.Cells[0].Value.ToString();
                    string valueToDelete1 = selectedRow.Cells[1].Value.ToString();
                    string valueToDelete2 = selectedRow.Cells[2].Value.ToString();
                    string deleteQuery = "DELETE FROM Table1 WHERE [дата] = ? AND [время]=? AND [количество людей]=?";

                    using (OleDbConnection dbConnection = new OleDbConnection(connectString))
                    {
                        dbConnection.Open();
                        using (OleDbCommand command = new OleDbCommand(deleteQuery, dbConnection))
                        {
                            command.Parameters.AddWithValue("дата", valueToDelete);
                            command.Parameters.AddWithValue("время", valueToDelete1);
                            command.Parameters.AddWithValue("количество людей", valueToDelete2);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Запись успешно удалена.");
                                LoadDataToDataGridView(); // Обновляем DataGridView после удаления
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


        private void label1_Click(object sender, EventArgs e)
        {
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadDataToDataGridView(DataGridView dataGridView2)
        {
           
        }
        public void LoadDataToDataGridView()
        {
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();
                string query = "SELECT * FROM Table1 WHERE [логин] = @логин";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@логин", login);

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        dataTable.Clear();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
        }

            private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void SetForm7Instance(Form7 form7)
        {
           
        }
        private void HandleBookingDeletedByAdmin(string login, string deletedDate)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
          
        }
        private void AddNotificationToRichTextBox(string notification)
        {
        }
    }
}
