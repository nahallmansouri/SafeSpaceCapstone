using Microsoft.Win32;
using SafeSpaceCapstone.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SafeSpaceCapstone.View
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Window
    {
        #region Fields
        StudentInfoViewModel viewModel;
        private CollectionView masterListView;
        #endregion

        #region Constructors
        public TeacherView()
        {
            InitializeComponent();
            ConfigureViewModel();
        }
        #endregion

        #region Methods
        private void ConfigureViewModel()
        {
            viewModel = new StudentInfoViewModel();
            DataContext = viewModel;
        }
        #endregion
        #region Event Handlers
        private void StudentNamesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Student Names CSV...",
                Filter = "CSV files(*.csv) | *.csv",
                Multiselect = false
            };
            Mouse.OverrideCursor = Cursors.Wait;
            if (openFileDialog.ShowDialog() == true)
            {
                viewModel.StudentNamesFilePath = openFileDialog.FileName;
            }
            Mouse.OverrideCursor = null;

        }

        private void StudentDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Student Names CSV...",
                Filter = "CSV files(*.csv) | *.csv",
                Multiselect = false
            };
            Mouse.OverrideCursor = Cursors.Wait;
            if (openFileDialog.ShowDialog() == true)
            {
                viewModel.StudentDataFilePath = openFileDialog.FileName;
            }
            Mouse.OverrideCursor = null;
        }
        #endregion
    }
}
