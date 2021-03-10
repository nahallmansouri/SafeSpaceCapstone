using Microsoft.Win32;
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

namespace SafeSpaceCapstone.View
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Window
    {
        public TeacherView()
        {
            InitializeComponent();
        }
        #region Variables
        public string studentNamesFilePath;
        public string studentDataFilePath;
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
                studentNamesFilePath = openFileDialog.FileName;
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
                studentDataFilePath = openFileDialog.FileName;
            }
            Mouse.OverrideCursor = null;
        }
        #endregion
    }
}
