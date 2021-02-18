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

        bool isEdit;
        Person editPerson;

        public AddEditWin()
        {
            isEdit = false;
            InitializeComponent();
            tbTitle.Text = "Добавление";
            tbID.Text = string.Empty;
        }

        public AddEditWin(Person person)
        {
            editPerson = person;
            isEdit = true;
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
            if(isEdit == false)
            {
                // Добавлене пользователя
                try
                {
                    if (string.IsNullOrWhiteSpace(txtFname.Text))
                    {
                        MessageBox.Show("Поля не должны быть пустыми");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtLname.Text))
                    {
                        MessageBox.Show("Поля не должны быть пустыми");
                        return;
                    }



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
            else
            {
                try
                {
                    editPerson.FirstName = txtFname.Text;
                    editPerson.LastName = txtLname.Text;
                    context.SaveChanges();
                    MessageBox.Show("Запись успешно изменена");
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }


        }

        private void txtFname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int num;
            if (Int32.TryParse(e.Text, out num))
            {
                e.Handled = true;
            }
           
        }

        private void txtLname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int num;
            if (Int32.TryParse(e.Text, out num))
            {
                e.Handled = true;
            }
        }
    }
}
