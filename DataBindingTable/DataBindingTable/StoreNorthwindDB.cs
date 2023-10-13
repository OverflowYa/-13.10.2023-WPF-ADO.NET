using System;
using System.Collections.Generic;
using System.Text;

// Подключение пространств имен инфраструктуры ADO.NET
using System.Data;
using System.Data.OleDb;
using System.Windows;// Для MessageBox

namespace DataBindingTable
{
    // Класс для доступа к БД
    public class StoreNorthwindDB
    {
        // Извлекаем в поле строку соединения из файла App.config
        String connectionString = System.Configuration.
            ConfigurationManager.ConnectionStrings["MyNorthwind"].ConnectionString;

        //*********************************************************
        // Метод извлечения данных из таблицы Employees
        // хранилища базы данных в ADO.NET-объект DataTable
        //*********************************************************
        DataTable dtEmployees = null;// Ссылка на объект DataTable
        public DataTable LoadTableEmployees()
        {
            // Загрузим таблицу Employees только один раз
            if (dtEmployees != null)
                return dtEmployees;

            // Заполняем объект таблицы Employees данными из БД
            dtEmployees = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand selectCommand = conn.CreateCommand();
                OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand);

                // Загружает данные и схему таблицы Employees
                selectCommand.CommandText = "SELECT EmployeeID, " +
                    "(LastName + ', ' + FirstName) AS FullName, " +
                    "Address, BirthDate, Region FROM Employees";

                try
                {
                    // Метод сам открывает БД и сам же ее закрывает
                    adapter.Fill(dtEmployees);
                }
                catch
                {
                    MessageBox.Show("Ошибка подключения к БД");
                }
                finally
                {
                    conn.Close(); // На всякий случай!
                }
            }

            return dtEmployees;
        }
    }
}