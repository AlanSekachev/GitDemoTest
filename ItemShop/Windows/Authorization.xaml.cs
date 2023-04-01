using ItemShop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ItemShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();

        }

        private void autobtn_Click(object sender, RoutedEventArgs e)
        {
            var autho = EntityDB.db.Пользователи.FirstOrDefault(u => u.Логин == logintb.Text && u.Пароль == passbox.Password); // Проверка ввода данных с данными из Базы данных

            if (autho == null) // Проверка на пустые поля
            {
                MessageBox.Show("Вы ничего не ввели");
            }

            if (autho != null) // Вход при условии правильных данных
            {
                MessageBox.Show(autho.ФИО_Пользователя);
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Close();
            }
            
            else MessageBox.Show("Неверно введен логин или пароль"); // Вывод сообщения при несоответствии введенных данных
            
            
        }
    }
}
