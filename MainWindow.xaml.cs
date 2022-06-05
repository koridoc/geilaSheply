using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace geilaSheply
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainModelView mainModelView;


        public MainWindow()
        {
            InitializeComponent();
            mainModelView = new MainModelView();

            this.DataContext = mainModelView;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainModelView.CreateListAbiturients();
            ViewListAbiturient.ItemsSource = mainModelView.AbiturientsCollection;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SettingsUniversity settingsUniversity = new SettingsUniversity();
            settingsUniversity.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (mainModelView.AbiturientsCollection.Count() == 0) 
            {
                MessageBox.Show("Список абитуриентов пуст");
            }
            else
            {
                mainModelView.RunAlgGeilaSheply();
                AdmittedList admittedList = new AdmittedList(mainModelView.UniversitiesCollection);
                admittedList.Show();
            }
            
        }
    }
}
