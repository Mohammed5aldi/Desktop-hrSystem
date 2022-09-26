using HrSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HrSystem
{
    /// <summary>
    /// Interaction logic for AddEMP.xaml
    /// </summary>
    public partial class AddEMP : Window
    {
         hrContext db = new hrContext();
        //List<Employee> employees
        //{
        //    get
        //    {
        //        return db.Employees.ToList();
        //    }
        //} 
        
        public AddEMP()
        {
            InitializeComponent();
            cbdepts.ItemsSource = db.Departments.ToList();
            cbJobs.ItemsSource = db.Jobs.ToList();  
        }
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            var emp = new Employee();

            double salary;
            if (double.TryParse(tbSalary.Text, out salary) == false)
            {
                MessageBox.Show("Salary format is not correct !");
                return;
            }

            //try
            //{
            //    emp.EmployeeId = long.Parse(tbEmpID.Text);
            //    emp.Salary = double.Parse(tbSalary.Text);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return;
            //}

            //var data = employees.Exists(e => e.EmployeeId == long.Parse(tbEmpID.Text));
            //var x = tbEmpID.Text;

            bool referenceIdExists = db.Employees.Where(e => e.EmployeeId == long.Parse(tbEmpID.Text)).FirstOrDefault() != null;

            switch (referenceIdExists)
                {
                    case true:
                        MessageBox.Show("ID is Exist !");
                        break;

                    case false:
                        emp.EmployeeId = long.Parse(tbEmpID.Text);
                        emp.FirstName = tbFname.Text;
                        emp.LastName = tbLname.Text;
                        emp.Email = tbEmail.Text;
                        emp.HireDate = dpHireDate.Text;
                        emp.Job = cbJobs.SelectedItem as Job;
                        emp.Department = cbdepts.SelectedItem as Department;
                        emp.Salary = double.Parse(tbSalary.Text);
                        db.Employees.Add(emp);
                        db.SaveChanges();
                        this.Close();
                        MessageBox.Show($"The Employee {tbFname.Text} {tbLname.Text} ID {tbEmpID.Text} has been added");
                        break;
                }
            }
        }
    }

