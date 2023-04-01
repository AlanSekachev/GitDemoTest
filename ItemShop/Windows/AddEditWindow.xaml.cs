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
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private Продукция _currentItem = new Продукция(); //элемент Таблицы продукция
        public AddEditWindow(Продукция selectetItem)
        {
            InitializeComponent();
            if(selectetItem != null) //Приравнивание выбранных элементов в DataGrid к _currentItem
              _currentItem = selectetItem;

            DataContext = _currentItem;


        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();//Проверка на ввод данных о продукции
            if (string.IsNullOrWhiteSpace(_currentItem.Наименование_товара))
                errors.AppendLine("Укажите название товара");
            if (string.IsNullOrWhiteSpace(_currentItem.Артикул))
                errors.AppendLine("Укажите артикул товара");
            if (string.IsNullOrWhiteSpace(_currentItem.Описание))
                errors.AppendLine("Укажите описание товара");
            if (string.IsNullOrWhiteSpace(_currentItem.Производитель))
                errors.AppendLine("Укажите производителя товара");
           
            if (_currentItem.id_Товара == 0)
                ItemShopDateBaseEntities.GetContext().Продукция.Add(_currentItem); //Добавление id_товара

            try
                {
                ItemShopDateBaseEntities.GetContext().SaveChanges(); // добавление продукции в базу данных
                MessageBox.Show("Информация сохранена!");
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); // проверка на ошибки
            }
               
            
        }
    }
}
