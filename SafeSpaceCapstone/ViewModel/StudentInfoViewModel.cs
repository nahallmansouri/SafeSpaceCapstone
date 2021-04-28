using SafeSpaceCapstone.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

        public void ParseStudentDataCSV()
        {
            //gets the directory for the user
            string userPath = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                userPath = Directory.GetParent(userPath).ToString();
            }
            //Change directory to the User's Path
            string cdCmd = "cd " + userPath;
            //Pull file and places it into our directory (User Folder)
            string pullFileCmd = "ufs get \"test.csv\" ";
            //Sets up process to use comand prompt
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.UseShellExecute = false;
            //Starts Command Prompt
            process.Start();
            //Calls comands from above to pull the file
            process.StandardInput.WriteLine(cdCmd);
            process.StandardInput.WriteLine(pullFileCmd);
            //Reads the contents of the CSV files as individual lines
            string fullFilePath = userPath + "\\test.csv";
            StudentDataFilePath = fullFilePath;
            string[] lines = System.IO.File.ReadAllLines(fullFilePath);
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
        
        public void ExportMasterTable(string folderPath)
        {
            //DateTime dateTime = DateTime.UtcNow.Date;
            string dateOfExport = DateTime.Now.ToShortDateString();
            //must replae the '/' becuase it throws errors when producing file paths
            dateOfExport = dateOfExport.Replace('/', '-');
            //create file name. have to add .csv to specify file type
            string fileName = "Student Encounters " + dateOfExport + ".csv";
            string delimeter = ",";
            using (StreamWriter file = new StreamWriter(Path.Combine(folderPath, fileName)))
            {
                //sets the header for the CSV
                file.Write("Student Names, Student Serial Numbers, Student Number of Encounters");
                file.WriteLine();
                foreach (StudentInfoModel student in Students)
                {
                    //writes the date for one student to the file
                    file.Write(student.StudentName + delimeter + student.StudentSerialNum + delimeter + student.StudentNumEncounters);
                    file.WriteLine();
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
