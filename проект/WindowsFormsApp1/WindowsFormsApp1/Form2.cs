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
    public partial class Form2 : Form
    {
        bool hide_password = true;
        private string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb; ";
        private void Connect()
        {
            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных:" + ex.Message);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }
            public Form2()
        {     
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            // Показываем Form2 и скрываем текущую форму (Form1)
            form1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            textBox1.KeyPress += textBox1_KeyPress; // Добавляем обработчик события для textBox1
            textBox2.KeyPress += textBox2_KeyPress; // Добавляем обработчик события для textBox2
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                    string query = "SELECT COUNT(*) FROM Table1 WHERE Login = @Login AND Password = @Password";
                    using (OleDbCommand command = new OleDbCommand(query, dbConnection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", password);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0 || (login == "12" && password == "12"))
                        {
                            if (login == "12" && password == "12")
                            {
                                Form7 form7 = new Form7();
                                form7.Show();
                            }
                            else
                            {
                                Form4 form4 = new Form4(login);
                                form4.Show();
                                this.Hide();
                            }

                            // Скрываем текущую форму (Form1)
                            this.Hide();
                            MessageBox.Show("Успешный вход в аккаунт: " + textBox1.Text);
                        }
                        else
                        {
                            MessageBox.Show("Неверное номер телефона пользователя или пароль");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при авторизации:" + ex.Message);
                }
                finally
                {
                    dbConnection.Close();
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр и знаков "+"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только букв и цифр
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private bool IsAlphaNumeric(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, "^[a-zA-Z0-9]{4,16}$");
        }
        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(hide_password)
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\Женя\Desktop\програмы\проект\unnamed.png");
                textBox2.UseSystemPasswordChar = false;
                hide_password = false;
            }
            else
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\Женя\Desktop\програмы\проект\closed_eye.png");
                textBox2.UseSystemPasswordChar = true;
                hide_password = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
