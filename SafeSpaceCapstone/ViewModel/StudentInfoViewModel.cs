using SafeSpaceCapstone.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SafeSpaceCapstone.ViewModel
{
    class StudentInfoViewModel: INotifyPropertyChanged
    {
        public IList<StudentInfoModel> Students { get; set; }

        private string studentNamesFilePath;
        private string studentDataFilePath;

        public StudentInfoViewModel()
        {
            Students = new List<StudentInfoModel>();
        }

        public string StudentNamesFilePath
        {
            get
            {
                return studentNamesFilePath;
            }
            set
            {
                studentNamesFilePath = value;
                OnPropertyChanged("StudentNamesFilePath");
            }
        }

        public string StudentDataFilePath
        {
            get
            {
                return studentDataFilePath;
            }
            set
            {
                studentDataFilePath = value;
                OnPropertyChanged("StudentDataFilePath");
            }
        }

        //private ICommand mUpdater;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            //if property changed is not null it will set the new property name
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /*
        public ICommand UpdateCommand
        {
            get
            {
                if(mUpdater == null)
                {
                    mUpdater = new Updater();
                }
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        private class Updater: ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;
            public void Execute (object parameter)
            {

            }
        }
        */

    }
}
