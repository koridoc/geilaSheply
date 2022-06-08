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
using System.Windows.Shapes;

namespace geilaSheply
{
    /// <summary>
    /// Логика взаимодействия для InfoAbiturient.xaml
    /// </summary>
    public partial class InfoAbiturient : Window
    {
        public InfoAbiturient(AbiturientViewModel abiturientViewModel)
        {
            InitializeComponent();
            this.DataContext = abiturientViewModel;

            addColumnsToDatagrid("ID", "Id");
            addColumnsToDatagrid("Название", "Name");
        }

        private void addColumnsToDatagrid(string header, string binding)
        {
            DataGridTextColumn c = new DataGridTextColumn();
            c.Binding = new Binding(binding);
            c.Header = header;

            ListUniversitiesGrid.Columns.Add(c);
        }
    }
}
