using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    class Program
    {
        /// <summary>
        ///  https://www.tutorialspoint.com/design_pattern/mvc_pattern.htm
        /// </summary>
        /// <param name="args"></param>
        /// 
        static void Main(string[] args)
        {
            //fetch student record based on his roll no from the database
            Student model = RetrieveStudentFromDatabase();

            //Create a view : to write student details on console
            StudentView view = new StudentView();

            StudentController controller = new StudentController(model, view);

            controller.UpdateView();

            //update model data
            controller.SetStudentName("John");

            controller.UpdateView();
        }

        private static Student RetrieveStudentFromDatabase()
        {
            Student student = new Student();
            student.SetName("Urban");
            student.SetRollNo("3");
            return student;
        }
    }

    //MODEL
    public class Student
    {
        private string _rollNo;
        private string _name;

        public string GetRollNo()
        {
            return _rollNo;
        }

        public void SetRollNo(string rollNo)
        {
            this._rollNo = rollNo;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            this._name = name;
        }
    }

    // VIEW
    public class StudentView
    {
        public void PrintStudentDetails(string studentName, string studentRollNo)
        {
            Console.WriteLine("Student: ");
            Console.WriteLine("Name: " + studentName);
            Console.WriteLine("Roll No: " + studentRollNo);
        }
    }

    //CONTROLLER
    public class StudentController
    {
        private Student model;
        private StudentView view;

        public StudentController(Student model, StudentView view)
        {
            this.model = model;
            this.view = view;
        }

        public void SetStudentName(string name)
        {
            model.SetName(name);
        }

        public String GetStudentName()
        {
            return model.GetName();
        }

        public void SetStudentRollNo(string rollNo)
        {
            model.SetRollNo(rollNo);
        }

        public String GetStudentRollNo()
        {
            return model.GetRollNo();
        }

        public void UpdateView()
        {
            view.PrintStudentDetails(model.GetName(), model.GetRollNo());
        }
    }



}
