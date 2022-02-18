namespace StudentPhoneBook.Entities
{
    public class Student
    {
        private int studentID;

        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        private string studentName;

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }
        private string studentContactNumber;

        public string StudentContactNumber
        {
            get { return studentContactNumber; }
            set { studentContactNumber = value; }
        }

        public Student()
        {
            studentID = 0;
            studentName = string.Empty;
            studentContactNumber = string.Empty;
        }
        static void Main()
        {
        }
    }
}