using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SafeSpaceCapstone.Model
{
    public class StudentInfo : INotifyPropertyChanged
    {
        #region Variables
        private string studentName;
        private string studentSerialNum;
        private string studentNumEncounters;
        private string studentNamesFilePath;
        private string studentDataFilePath;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    #region Get/Set
        public string StudentName
        {
            get { return studentName; }
            set
            {
                studentName = value;
                OnPropertyChanged("StudentName");
            }
        }
        public string StudentSerialNum
        {
            get { return studentSerialNum; }
            set
            {
                studentSerialNum = value;
                OnPropertyChanged("StudentSerialNum");
            }
        }
        public string StudentNumEncounters
        {
            get { return studentNumEncounters; }
            set
            {
                studentNumEncounters = value;
                OnPropertyChanged("StudentNumEncounters");
            }
        }
        public string StudentNamesFilePath
        {
            get { return studentNamesFilePath; }
            set
            {
                studentNamesFilePath = value;
                OnPropertyChanged("StudentNamesFilePath");
            }
        }
        public string StudentDataFilePath
        {
            get { return studentDataFilePath; }
            set
            {
                studentDataFilePath = value;
                OnPropertyChanged("StudentDataFilePath");
            }
        }
        #endregion
    }
}
