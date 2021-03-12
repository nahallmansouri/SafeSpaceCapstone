using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeSpaceCapstone.Model
{
    class StudentInfoModel :INotifyPropertyChanged
    {
        #region Variables
        private string studentName;
        private string studentSerialNum;
        private string studentNumEncounters;
        #endregion

        #region Constructor
        //Constructor used when parsing the Student Name CSV
        //There is no NumEncounters in this CSV there for we fill with an empty string
        public StudentInfoModel(string rowData)
        {
            //splits the row of data from the CSV into seperate fields stored in an array
            string[] data = rowData.Split(',');
            StudentName = data[0];
            StudentSerialNum = data[1];
            StudentNumEncounters = "";
        }
        #endregion

        #region INotifyProperyChange
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        
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
        /*
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
        */
        #endregion
    }
}
