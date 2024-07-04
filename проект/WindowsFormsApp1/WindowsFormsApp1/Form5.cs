using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        string login;
        private OleDbConnection connection; // Подключение к базе данных Access
        private OleDbConnection loginConnection; // Подключение к другой базе данных Access

        private DateTime selectedDate;
        private string selectedTime;


        public Form5(string login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose(); // Добавьте эту строку для освобождения ресурсов
            }

            if (loginConnection != null)
            {
                if (loginConnection.State == ConnectionState.Open)
                {
                    loginConnection.Close();
                }
                loginConnection.Dispose(); // Добавьте эту строку для освобождения ресурсов
            }
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            // Инициализация подключения к базе данных Access
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=table1.mdb; ";
            connection = new OleDbConnection(connectionString);
            connection.Open();

            // Инициализация подключения к базе данных Access (Database1) с таблицей Login
            string loginConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb; ";
            loginConnection = new OleDbConnection(loginConnectionString);
            loginConnection.Open();

            // Очистить comboBox1 перед заполнением новых значений
            comboBox1.Items.Clear();

            // Добавить временные значения от 8:00 до 22:00 с интервалом в 1 час
            for (int hour = 10; hour <= 21; hour++)
            {
                // Форматировать строку в формате HH:mm
                string time = string.Format("{0:D2}:00", hour);

                // Добавить строку в comboBox1
                comboBox1.Items.Add(time);
            }

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTime = comboBox1.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedTime))
            {
                selectedDate = monthCalendar1.SelectionStart.Date;
                Console.WriteLine("Выбранное время: " + selectedDate.ToString("dd.MM.yyyy") + " " + selectedTime);
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            DateTime today = DateTime.Today;

            if (selectedDate < today)
            {
                monthCalendar1.SetDate(today);
                MessageBox.Show("Выбор прошлой даты недоступен для бронирования.");
            }
            else if (selectedDate == today)
            {
                MessageBox.Show("Выбор сегодняшней даты недоступен для бронирования.");
            }
            else
            {
                // Здесь можно добавить вашу логику для разрешения бронирования на выбранной дате.
            }
        }
        private bool IsBookingAvailable(DateTime date, string time, int requestedPeople)
        {
            string query = "SELECT SUM([количество людей]) FROM Table1 WHERE [дата] = ? AND [время] = ?";

            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("дата", date.ToShortDateString());  // Ensure the date is in a suitable format
                command.Parameters.AddWithValue("время", time);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // If there are no existing bookings for the specified date and time, or the sum is less than 100, then it's available
                int sumPeople = 0;
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    sumPeople = Convert.ToInt32(result);
                }

                return sumPeople + requestedPeople <= 100;
            }
        }
        // ... (Your existing code)

        private bool IsCorporateBooking(DateTime date, string time)
        {
            string query = "SELECT COUNT(*) FROM Table1 WHERE [дата] = ? AND [время] = ? AND [количество людей] = 'корпорация'";

            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("дата", date);
                command.Parameters.AddWithValue("время", time);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            string selectedTime = comboBox1.SelectedItem as string;
            string textBoxText = textBox1.Text;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Логин не найден в базе данных.");
                return;
            }

            string name = GetNameFromDatabase1(login);

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Имя не найдено в базе данных.");
                return;
            }

            if (!int.TryParse(textBoxText, out int numberOfPeople))
            {
                MessageBox.Show("Введите корректное количество людей.");
                return;
            }

            // Check if the selected time is available
            if (IsBookingExists(selectedDate, selectedTime, textBoxText))
            {
                MessageBox.Show("Время уже забронировано. Выберите другое время.");
                return;
            }

            // Check if the selected time is available for corporate bookings
            if (IsCorporateBooking(selectedDate, selectedTime))
            {
                MessageBox.Show("На это время уже забронирован корпоратив. Выберите другое время.");
                return;
            }

            // Check if the total number of people exceeds the limit
            if (!IsBookingAvailable(selectedDate, selectedTime, numberOfPeople))
            {
                MessageBox.Show("Все места на это время уже забронированы.");
                return;
            }

         
            // Rest of your code for inserting into the database
            // ...

            // Подключение к базе данных, в которую вы хотите вставить данные
            string connectionStringDestination = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=table1.mdb; ";
            using (OleDbConnection connectionDestination = new OleDbConnection(connectionStringDestination))
            {
                connectionDestination.Open();

                string insertQuery = "INSERT INTO Table1 ([дата], [время], [количество людей], [логин], [имя]) VALUES (?, ?, ?, ?, ?)";

                using (OleDbCommand command = new OleDbCommand(insertQuery, connectionDestination))
                {
                    command.Parameters.AddWithValue("дата", selectedDate);
                    command.Parameters.AddWithValue("время", selectedTime);
                    command.Parameters.AddWithValue("количество людей", textBoxText);
                    command.Parameters.AddWithValue("логин", login);
                    command.Parameters.AddWithValue("имя", name);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Заказ успешно оформлен.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить данные в базу данных.");
                        }
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Ошибка при выполнении команды SQL: " + ex.Message);
                    }
                }
            }
        }

        private string GetNameFromDatabase1(string login)
        {
            string name = null;

            string loginConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb; ";
            using (OleDbConnection loginConnection = new OleDbConnection(loginConnectionString))
            {
                loginConnection.Open();

                string query = "SELECT [имя] FROM Table1 WHERE [Login] = ?";
                using (OleDbCommand command = new OleDbCommand(query, loginConnection))
                {
                    command.Parameters.AddWithValue("Login", login);

                    name = command.ExecuteScalar() as string;
                }
            }

            return name;
        }

        private string GetLoginFromDatabase1(string Login)
        {
            string query = "SELECT [логин] FROM Table1 WHERE [логин] = ?";
            using (OleDbCommand command = new OleDbCommand(query, loginConnection))
            {
                command.Parameters.AddWithValue("логин", Login);

                if (loginConnection.State == ConnectionState.Closed)
                {
                    loginConnection.Open();
                }

                string result = command.ExecuteScalar() as string;
                return result;
            }

        }
        private bool IsBookingExists(DateTime date, string time, string human)
        {
            string query = "SELECT COUNT(*) FROM Table1 WHERE [дата] = ? AND [время] = ? AND [количество людей] = ?";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("дата", date);
                command.Parameters.AddWithValue("время", time);
                command.Parameters.AddWithValue("количество людей", human);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime? selectedDate = null;
            string selectedTime = comboBox1.SelectedItem as string;
            string textBoxText = textBox1.Text;

            // Проверка выбора даты
            if (monthCalendar1.SelectionStart != DateTime.MinValue)
            {
                selectedDate = monthCalendar1.SelectionStart.Date;
            }
            else
            {
                MessageBox.Show("Выберите дату.");
                return;
            }

            // Проверка выбора времени
            if (string.IsNullOrEmpty(selectedTime))
            {
                MessageBox.Show("Выберите время.");
                return;
            }

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Логин не найден в базе данных.");
                return;
            }

            string name = GetNameFromDatabase1(login);

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Имя не найдено в базе данных.");
                return;
            }

            if (IsBookingExists(selectedDate.Value, selectedTime, textBoxText))
            {
                MessageBox.Show("Время уже забронировано. Выберите другое время.");
                return;
            }

            // Добавьте ваш код для вставки в базу данных
            // ...

            // Подключение к базе данных, в которую вы хотите вставить данные
            string connectionStringDestination = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=table1.mdb; ";
            using (OleDbConnection connectionDestination = new OleDbConnection(connectionStringDestination))
            {
                connectionDestination.Open();

                string insertQuery = "INSERT INTO Table1 ([дата], [время], [количество людей], [логин], [имя]) VALUES (?, ?, ?, ?, ?)";

                using (OleDbCommand command = new OleDbCommand(insertQuery, connectionDestination))
                {
                    command.Parameters.AddWithValue("дата", selectedDate.Value);
                    command.Parameters.AddWithValue("время", selectedTime);
                    command.Parameters.AddWithValue("количество людей", "корпорация");
                    command.Parameters.AddWithValue("логин", login);
                    command.Parameters.AddWithValue("имя", name);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Заказ успешно оформлен.");

                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить данные в базу данных.");
                        }
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Ошибка при выполнении команды SQL: " + ex.Message);
                    }
                }
            }
        }
    }
}
