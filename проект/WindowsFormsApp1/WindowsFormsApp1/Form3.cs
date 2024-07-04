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
using System.Text.RegularExpressions;


namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {

        private string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb; ";
        private bool hasLetter = false;
        private bool hasDigit = false;

        public void InsertPerson(string login, string password, string name)
        {
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();

                string query = "INSERT INTO Table1 (Login, [Password], [имя]) VALUES (@Login, @Password, @имя)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@имя", name);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Запись успешно добавлена в таблицу Persons.");
                }
            }
        }
        public bool IsLoginExists(string login)
        {
            bool loginExists = false;

            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Table1 WHERE Login = @Login";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        loginExists = true;
                    }
                }
            }

            return loginExists;
        }
        public bool IsLoginPasswordMatch(string login, string password, string name)
        {
            bool match = false;

            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Table1 WHERE Login = @Login AND [Password] = @Password AND [имя] = @имя";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@имя", name);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        match = true;
                    }
                }
            }

            return match;
        }

        public Form3()
        {
            InitializeComponent();
            textBox2.KeyPress += TextBox_KeyPress;
            textBox3.KeyPress += TextBox_KeyPress;
            textBox4.KeyPress += TextBox4_KeyPress;
            textBox2.TextChanged += TextBox2_TextChanged;
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            hasLetter = false;
            hasDigit = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            // Показываем Form2 и скрываем текущую форму (Form1)
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;
            string name = textBox4.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
            else if (login.Length != 13 || !login.StartsWith("+375"))
            {
                MessageBox.Show("Номер телефона должен начинаться с '+375' и содержать только 13 символов.");
            }
            else if (!string.Equals(password, confirmPassword))
            {
                MessageBox.Show("Пароль и подтверждение пароля не совпадают.");
            }
            else if (!IsAlphaNumeric(password))
            {
                MessageBox.Show("Пароль должен содержать только английские буквы и цифры и быть от 4 до 16 символов.");
            }
            else if (!IsAlphaNumericWithLetterAndDigit(password))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну букву и хотя бы одну цифру.");
            }
            else if (!IsRussianLetters(name))
            {
                MessageBox.Show("Имя должно содержать только буквы на русском.");
            }
            else if (IsLoginExists(login))
            {
                MessageBox.Show("Такой номер телефона уже зарегистрирован.");
            }
            else
            {
                try
                {
                    InsertPerson(login, password, name);
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Такой номер телефона уже зарегистрирован.");
                }
            }
        }

        private bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsAlphaNumeric(string str)
        {
            return Regex.IsMatch(str, "^[a-zA-Z0-9]{4,16}$");
        }

        private bool IsAlphaNumericWithLetterAndDigit(string str)
        {
            return Regex.IsMatch(str, "(?=.*[a-zA-Z])(?=.*[0-9])");
        }

        private bool IsRussianLetters(string str)
        {
            return Regex.IsMatch(str, "^[А-Яа-я]+$");
        }


        private void button3_Click(object sender, EventArgs e)
            {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        // Метод для проверки, что строка содержит хотя бы одну букву и хотя бы одну цифру
  

        private void textBox1_ImeModeChanged(object sender, EventArgs e)
            {

            }

        private void textBox3_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }


        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

