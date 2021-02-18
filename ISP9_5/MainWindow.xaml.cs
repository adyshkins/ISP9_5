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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISP9_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities context = new Entities();

        public MainWindow()
        {
            InitializeComponent();
            dgPerson.ItemsSource = context.Person.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWin addEditWin = new AddEditWin();
            this.Hide();
            addEditWin.ShowDialog();
            dgPerson.ItemsSource = context.Person.ToList();
            this.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var resultMess = MessageBox.Show("ВЫ УВЕРЕНЫ?", "Удаление пользователя", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultMess == MessageBoxResult.Yes)
            {
                if (dgPerson.SelectedItem is Person person)
                {
                    context.Person.Remove(person);
                    context.SaveChanges();
                    MessageBox.Show("Запись удалена");
                    dgPerson.ItemsSource = context.Person.ToList();
                }
                else
                {
                    MessageBox.Show("Запись не выбрана");
                }
            }
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgPerson.SelectedItem is Person person)
            {
                AddEditWin addEditWin = new AddEditWin(person);
                this.Hide();
                addEditWin.ShowDialog();
                dgPerson.ItemsSource = context.Person.ToList();
                this.Show();
            }
            else
            {
                MessageBox.Show("Запись не выбрана");
            }


        }
    }
}
