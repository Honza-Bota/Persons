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
using Persons.Model;

namespace Persons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Test databáze
            //test funkčního návrhu Singltonu
            //
            //PersonDatabase p1 = PersonDatabase.Instance;
            //PersonDatabase p2 = PersonDatabase.Instance;
            //MessageBox.Show(ReferenceEquals(p1, p2).ToString());
            //
            //test funkcí databáze
            //
            //Person per1 = new Person("Jan", "Boťa", DateTime.Now, "012345/0123");
            //per2 = new Person("Jan", "Boťa", DateTime.Now, "012345/0124");
            //
            //p1.Add(per1);
            //p1.Add(per2);
            //p1.Remove(per1);
            //
            //MessageBox.Show(p1.Count.ToString());
            #endregion
        }
    }
}
