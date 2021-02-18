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

namespace ISP9_5
{
    /// <summary>
    /// Логика взаимодействия для AddEditWin.xaml
    /// </summary>
    public partial class AddEditWin : Window
    {
        Entities context = new Entities();

        public AddEditWin()
        {
            InitializeComponent();
            tbTitle.Text = "Добавление";
            tbID.Text = string.Empty;
        }

        public AddEditWin(Person person)
        {
            InitializeComponent();
            tbTitle.Text = "Изменение";
            btnAddPerson.Content = "Сохранить";
            tbID.Text += person.ID;

            txtFname.Text = person.FirstName;
            txtLname.Text = person.LastName;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.Person.Add(new Person
                {
                    LastName = txtLname.Text,
                    FirstName = txtFname.Text
                });
                context.SaveChanges();

                MessageBox.Show("Запись успешно добавлена");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
           
        }
    }
}
