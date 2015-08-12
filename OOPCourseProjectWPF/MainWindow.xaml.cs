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

namespace OOPCourseProjectWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ContractController contractManager;

        private string filename = "data.xml";

        public MainWindow()
        {
            InitializeComponent();
            contractManager = new ContractController(this);
            contractManager.Load(filename);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contractManager.Save(filename);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            contractManager.StartStorage();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            contractManager.StopStorage();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            contractManager.AddContract();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            contractManager.RemoveSelectedContract();
        }

        private void DisplayItemsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView displayItemsTreeView = sender as TreeView;
            if (displayItemsTreeView.SelectedItem is DisplayItem)
                contractManager.SelectedItem = displayItemsTreeView.SelectedItem as DisplayItem;
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            contractManager.Undo();
        }
    }
}
