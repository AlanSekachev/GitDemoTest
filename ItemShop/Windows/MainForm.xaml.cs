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
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
            //dgrid.ItemsSource = EntityDB.db.Пользователи.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgrid.ItemsSource = EntityDB.db.Продукция.ToList(); //Вывод данных о продукции в элемент DataGrid при загрузке главного окна
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)//Обработчик нажатия на кнопку. Переход на окно добавления продукции
        {
            AddEditWindow editwindow = new AddEditWindow(null); 
            editwindow.Show();
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)//Обработчик нажатия на кнопку.
        {
            var itemsdelete = dgrid.SelectedItems.Cast<Продукция>().ToList();//Просмотр выбранных элементов DataGrid
            if (MessageBox.Show($"Вы точно хотите удалить следующие {itemsdelete.Count()} элементы из всей базы данных?",
                "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) // Всплывающее окно с подтверждением
            {
                try //Удаление выбранных элементов таблицы Продукция, сохранение данных в базе данных, вывод обновленных элементов в DataGrid
                {
                    EntityDB.db.Продукция.RemoveRange(itemsdelete); 
                    EntityDB.db.SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    dgrid.ItemsSource = EntityDB.db.Продукция.ToList();
                }
                catch (Exception ex) //Проверка на ошибки
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void searchtb_TextChanged(object sender, TextChangedEventArgs e) 
        {
           dgrid.ItemsSource = EntityDB.db.Продукция.Where(q => q.Наименование_товара.Contains(searchtb.Text)).ToList(); //Поиск продукции по наименованию
        }

       
    }
}
