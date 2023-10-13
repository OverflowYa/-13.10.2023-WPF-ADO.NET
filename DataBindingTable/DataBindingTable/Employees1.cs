using System;
using System.Collections.Generic;
using System.Text;

// Подключение пространства имен для DataTable
using System.Data;

namespace DataBindingTable
{
    // Класс свойств доступа к данным таблицы Employees
    class Employees1
    {
        //********************************************************
        // Cвойства доступа для привязки и базовые поля  
        //********************************************************
        // Для списка надо массив
        string[] listFullName = null;
        public string[] ListFullName
        {
            get
            {
                if (listFullName == null)
                {
                    listFullName = new string[dt.Rows.Count];
                    int i = 0;
                    // Перебираем записи и заполняем массив для списка
                    foreach (DataRow row in dt.Rows)
                    {
                        listFullName[i] = (string)dt.Rows[i]["FullName"];
                        i++;
                    }
                }
                return listFullName;
            }
        }
        int employeeID;
        public int EmployeeID
        {
            get { return employeeID; }
        }
        string fullName;
        public string FullName
        {
            get { return fullName; }
        }
        string address;
        public string Address
        {
            get { return address; }
        }
        string birthDate;
        public string BirthDate
        {
            get { return birthDate; }
        }
        string region;
        public string Region
        {
            get { return region; }
        }

        // Навигация по таблице ADO.NET
        public Employees1 GetEmployee(int ID)
        {
            // Проверяем границы массива
            if (ID < 0 || ID >= dt.Rows.Count)
                return null;

            // Наполняем свойства полями записи ID
            // для последующего их извлечения свойствами
            // в привязанные элементы интерфейса.
            // Входные параметры приводятся явно 
            // к тому типу, который ожидает метод
            return new Employees1(
                (int)dt.Rows[ID]["EmployeeID"],
                (string)dt.Rows[ID]["FullName"],
                (string)dt.Rows[ID]["Address"],
                dt.Rows[ID]["BirthDate"].ToString(),
                dt.Rows[ID]["Region"].ToString()
                );
        }

        // Конструктор с параметрами
        public Employees1(int employeeID,
            string fullName, string address,
            string birthDate, string region)
        {
            this.employeeID = employeeID;
            this.fullName = fullName;
            this.address = address;
            this.birthDate = birthDate;
            this.region = region;
        }

        // Конструктор по умолчанию 
        public Employees1() { }

        // Ссылка на исходную таблицу-объект ADO.NET
        DataTable dt = App.StoreNorthwindDB.LoadTableEmployees();
    }
}