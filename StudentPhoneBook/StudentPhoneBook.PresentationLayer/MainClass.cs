using System;
using System.Collections.Generic;
using StudentPhoneBook.Entities;
using StudentPhoneBook.BusinessLayer;
using StudentPhoneBook.Exceptions;

namespace GuestPhoneBook.PresentationLayer
{
    class MainClass
    {
        static void Main()
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ListAllStudents();
                        break;
                    case 3:
                        SearchStudentByID();
                        break;
                    case 4:
                        UpdateStudent();
                        break;
                    case 5:
                        DeleteStudent();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void DeleteStudent()
        {
            try
            {
                int deleteStudentID;
                Console.WriteLine("Enter StudentID to Delete:");
                deleteStudentID = Convert.ToInt32(Console.ReadLine());
                Student deleteGuest = StudentBL.SearchStudentBL(deleteStudentID);
                if (deleteGuest != null)
                {
                    bool studentdeleted = StudentBL.DeleteStudentBL(deleteStudentID);
                    if (studentdeleted)
                        Console.WriteLine("Student Deleted");
                    else
                        Console.WriteLine("Student not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Student Details Available");
                }


            }
            catch (StudentPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateStudent()
        {
            try
            {
                int updateStudentID;
                Console.WriteLine("Enter StudentID to Update Details:");
                updateStudentID = Convert.ToInt32(Console.ReadLine());
                Student updatedStudent = StudentBL.SearchStudentBL(updateStudentID);
                if (updatedStudent != null)
                {
                    Console.WriteLine("Update Student Name :");
                    updatedStudent.StudentName = Console.ReadLine();
                    Console.WriteLine("Update PhoneNumber :");
                    updatedStudent.StudentContactNumber = Console.ReadLine();
                    bool studentUpdated = StudentBL.UpdateStudentBL(updatedStudent);
                    if (studentUpdated)
                        Console.WriteLine("Student Details Updated");
                    else
                        Console.WriteLine("Student Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Student Details Available");
                }


            }
            catch (StudentPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchStudentByID()
        {
            try
            {
                int searchStudentID;
                Console.WriteLine("Enter StudentID to Search:");
                searchStudentID = Convert.ToInt32(Console.ReadLine());
                Student searchStudent = StudentBL.SearchStudentBL(searchStudentID);
                if (searchStudent != null)
                {
                    Console.WriteLine("**************************");
                    Console.WriteLine("StudentID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("**************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchStudent.StudentID, searchStudent.StudentName, searchStudent.StudentContactNumber);
                    Console.WriteLine("**************************");
                }
                else
                {
                    Console.WriteLine("No Student Details Available");
                }

            }
            catch (StudentPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListAllStudents()
        {
            try
            {
                List<Student> studentList = StudentBL.GetAllStudentsBL();
                if (studentList != null)
                {
                    Console.WriteLine("**************************");
                    Console.WriteLine("StudentID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("**************************");
                    foreach (Student student in studentList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", student.StudentID, student.StudentName, student.StudentContactNumber);
                    }
                    Console.WriteLine("**************************");

                }
                else
                {
                    Console.WriteLine("No Student Details Available");
                }
            }
            catch (StudentPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddStudent()
        {
            try
            {
                Student newStudent = new Student();
                Console.WriteLine("Enter StudentID :");
                newStudent.StudentID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name :");
                newStudent.StudentName = Console.ReadLine();
                Console.WriteLine("Enter PhoneNumber :");
                newStudent.StudentContactNumber = Console.ReadLine();
                bool studentAdded = StudentBL.AddStudentBL(newStudent);
                if (studentAdded)
                    Console.WriteLine("Student Added");
                else
                    Console.WriteLine("Student not Added");
            }
            catch (StudentPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("\n****Student PhoneBook Menu****");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. List All Students");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.WriteLine("**************\n");
        }
    }
}