using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DataBindingTable
{
    public partial class App : Application
    {
        // Базовое поле для свойства
        private static StoreNorthwindDB storeNorthwindDB =
            new StoreNorthwindDB();
        // Свойство для базового поля со ссылкой на экземпляр класса
        public static StoreNorthwindDB StoreNorthwindDB
        {
            get { return storeNorthwindDB; }
        }
    }
}