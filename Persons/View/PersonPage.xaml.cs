using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Persons.ViewModel;

namespace Persons.View
{
    /// <summary>
    /// Interakční logika pro PersonPage.xaml
    /// </summary>
    public partial class PersonPage : Window
    {
        public PersonPage()
        {
            InitializeComponent();

            DataContext = new PersonViewModel();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show((DataContext as PersonViewModel).ShowPersons(),"Vytvořené osoby",MessageBoxButton.OK);
        }
    }
}
