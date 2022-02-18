using System;
using System.Collections.Generic;
using StudentPhoneBook.Entities;
using StudentPhoneBook.Exceptions;

namespace StudentPhoneBook.DataAccessLayer
{
    public class StudentDAL
    {
        public static List<Student> studentList = new List<Student>();

        public bool AddStudentDAL(Student newStudent)
        {
            bool studentAdded = false;
            try
            {
                studentList.Add(newStudent);
                studentAdded = true;
            }
            catch (SystemException ex)
            {
                throw new StudentPhoneBookException(ex.Message);
            }
            return studentAdded;

        }

        public List<Student> GetAllStudentsDAL()
        {
            return studentList;
        }

        public Student SearchStudentDAL(int searchStudentID)
        {
            Student searchStudent = null;
            try
            {
                searchStudent = studentList.Find(student => student.StudentID == searchStudentID);
            }
            catch (SystemException ex)
            {
                throw new StudentPhoneBookException(ex.Message);
            }
            return searchStudent;
        }

        public bool UpdateStudentDAL(Student updateStudent)
        {
            bool studentUpdated = false;
            try
            {
                for (int i = 0; i < studentList.Count; i++)
                {
                    if (studentList[i].StudentID == updateStudent.StudentID)
                    {
                        studentList[i].StudentName = updateStudent.StudentName;
                        studentList[i].StudentContactNumber = updateStudent.StudentContactNumber;
                        studentUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new StudentPhoneBookException(ex.Message);
            }
            return studentUpdated;

        }

        public bool DeleteStudentDAL(int deleteStudentID)
        {
            bool studentDeleted = false;
            try
            {
                Student deleteStudent = studentList.Find(student => student.StudentID == deleteStudentID);

                if (deleteStudent != null)
                {
                    studentList.Remove(deleteStudent);
                    studentDeleted = true;
                }
            }
            catch (SystemException ex)
            {
                throw new StudentPhoneBookException(ex.Message);
            }
            return studentDeleted;

        }
        static void Main()
        {
        }

    }
}