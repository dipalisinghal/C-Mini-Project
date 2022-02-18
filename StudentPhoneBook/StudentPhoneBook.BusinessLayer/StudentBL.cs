using System;
using System.Collections.Generic;
using System.Text;
using StudentPhoneBook.Entities;
using StudentPhoneBook.Exceptions;
using StudentPhoneBook.DataAccessLayer;

namespace StudentPhoneBook.BusinessLayer
{
    public class StudentBL
    {
        private static bool ValidateStudent(Student student)
        {
            StringBuilder sb = new StringBuilder();
            bool validStudent = true;
            if (student.StudentID <= 0)
            {
                validStudent = false;
                sb.Append(Environment.NewLine + "Invalid Student ID");

            }
            if (student.StudentName == string.Empty)
            {
                validStudent = false;
                sb.Append(Environment.NewLine + "Student Name Required");

            }
            if (student.StudentContactNumber.Length < 10)
            {
                validStudent = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            if (validStudent == false)
                throw new StudentPhoneBookException(sb.ToString());
            return validStudent;
        }

        public static bool AddStudentBL(Student newStudent)
        {
            bool studentAdded = false;
            try
            {
                if (ValidateStudent(newStudent))
                {
                    StudentDAL studentDAL = new StudentDAL();
                    studentAdded = studentDAL.AddStudentDAL(newStudent);
                }
            }
            catch (StudentPhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studentAdded;
        }

        public static List<Student> GetAllStudentsBL()
        {
            List<Student> studentList = null;
            try
            {
                StudentDAL studentDAL = new StudentDAL();
                studentList = studentDAL.GetAllStudentsDAL();
            }
            catch (StudentPhoneBookException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return studentList;
        }

        public static Student SearchStudentBL(int searchStudentID)
        {
            Student searchStudent = null;
            try
            {
                StudentDAL studentDAL = new StudentDAL();
                searchStudent = studentDAL.SearchStudentDAL(searchStudentID);
            }
            catch (StudentPhoneBookException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchStudent;

        }

        public static bool UpdateStudentBL(Student updateStudent)
        {
            bool studentUpdated = false;
            try
            {
                if (ValidateStudent(updateStudent))
                {
                    StudentDAL studentDAL = new StudentDAL();
                    studentUpdated = studentDAL.UpdateStudentDAL(updateStudent);
                }
            }
            catch (StudentPhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studentUpdated;
        }

        public static bool DeleteStudentBL(int deleteStudentID)
        {
            bool studentDeleted = false;
            try
            {
                if (deleteStudentID > 0)
                {
                    StudentDAL studentDAL = new StudentDAL();
                    studentDeleted = studentDAL.DeleteStudentDAL(deleteStudentID);
                }
                else
                {
                    throw new StudentPhoneBookException("Invalid Student ID");
                }
            }
            catch (StudentPhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studentDeleted;
        }
        static void Main()
        {
        }

    }
}