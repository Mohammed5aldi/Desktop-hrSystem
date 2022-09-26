//using HrSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;

//namespace HrSystem.Services
//{
//    public class EmployeeService
//    {
//        hrContext db = new hrContext();
//        public List<Employee> GetAll()
//        {
//            return db.Employees.ToList();
//        }

//        public void Insert(string x)
//        {

//            long depart;

//            if (long.TryParse(x, out depart) == false)
//            {
//                MessageBox.Show("Enter Number Only ");
//                return;

//            }

//            var emp = new Employee();

//            bool referenceIdExists = db.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault() != null;

//            var data = employees.Exists(e => e.EmployeeId == long.Parse(tbEmpID.Text));
//            var x = tbEmpID.Text;




//            switch (referenceIdExists)
//            {
//                case true:
//                    MessageBox.Show("ID is Exist !");
//                    break;

//                case false:
//                    emp.EmployeeId = long.Parse(tbEmpID.Text);
//                    emp.FirstName = tbFname.Text;
//                    emp.LastName = tbLname.Text;
//                    emp.Email = tbEmail.Text;
//                    emp.HireDate = dpHireDate.Text;
//                    emp.Job = cbJobs.SelectedItem as Job;
//                    emp.Department = cbdepts.SelectedItem as Department;
//                    emp.Salary = double.Parse(tbSalary.Text);
//                    db.Employees.Add(emp);
//                    db.SaveChanges();
//                    this.Close();
//                    MessageBox.Show($"The Employee {tbFname.Text} {tbLname.Text} ID {tbEmpID.Text} has been added");
//                    break;





//            }
//        }
//    }



