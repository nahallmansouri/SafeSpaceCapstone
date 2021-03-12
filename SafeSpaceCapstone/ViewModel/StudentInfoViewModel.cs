using SafeSpaceCapstone.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace SafeSpaceCapstone.ViewModel
{
    class StudentInfoViewModel: INotifyPropertyChanged
    {
        public List<StudentInfoModel> Students { get; set; }
        private string studentNamesFilePath;
        private string studentDataFilePath;

        #region Constructors
        public StudentInfoViewModel()
        {
            Students = new List<StudentInfoModel>();
        }
        #endregion

        #region Get/Set
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
        #endregion

        #region Methods
        public void ParseStudentNameCSV(string filepath)
        {
            
            //Reads the contents of the CSV files as individual lines
            string[] lines = System.IO.File.ReadAllLines(filepath);
            //Split each row into column data
            bool isFirst = true;
            foreach (var line in lines)
            {
                //creates a new Student
                if (isFirst)//handles a header for the file so it is not added to the data
                {
                    isFirst = false;
                    continue;
                }
                StudentInfoModel st = new StudentInfoModel(line);
                //adds our newly created student to our Students List
                Students.Add(st);
            }
        }

        public void ParseStudentDataCSV(string filepath)
        {
            //Reads the contents of the CSV files as individual lines
            string[] lines = System.IO.File.ReadAllLines(filepath);
            //Split each row into column data
            bool isFirst = true;
            foreach (var line in lines)
            {
                //creates a new Student
                if (isFirst)//handles a header for the file so it is not added to the data
                {
                    isFirst = false;
                    continue;
                }
                string [] lineSplit = line.Split(',');
               foreach(var student in Students)
               {
                    if(lineSplit[0] == student.StudentSerialNum)
                    {
                        student.StudentNumEncounters = lineSplit[1]; //sets numencounters to 2nd col of that line
                        break; //if we found a match we want to move to next line
                    }
               }
            }
        }
        #endregion

        #region PropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            //if property changed is not null it will set the new property name
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
