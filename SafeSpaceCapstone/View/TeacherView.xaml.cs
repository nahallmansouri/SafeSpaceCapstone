using Microsoft.Win32;
using SafeSpaceCapstone.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace SafeSpaceCapstone.View
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Window
    {
        #region Fields
        StudentInfoViewModel viewModel;
        //private CollectionView masterListView;
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
                //sets the Students Name File Path in viewmodel
                viewModel.StudentNamesFilePath = openFileDialog.FileName;
                //parses that file
                viewModel.ParseStudentNameCSV(openFileDialog.FileName);
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
                //parses that file
                viewModel.ParseStudentDataCSV(openFileDialog.FileName);
            }
            Mouse.OverrideCursor = null;
        }
        #endregion
    }
}
