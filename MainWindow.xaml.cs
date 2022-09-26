using HrSystem.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HrSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        hrContext db = new hrContext();
        List<Employee> employee
        {


            get { return db.Employees.ToList(); }

        }
        List<Department> Departments
        {
            
            get { 
                var list = db.Departments.ToList();
                var dept = new Department();
                dept.DepartmentName = "";
                list.Insert(0,dept);
                return list;

                 }
        }
        
        

        public MainWindow()
        {
            InitializeComponent();
            dg_data.ItemsSource = employee;
            cb_dpts.ItemsSource = Departments;

            
        }

        private void cb_dpts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dpts = cb_dpts.SelectedItem as Department;
            if (dpts == null || dpts.DepartmentName == "")
            {

                dg_data.ItemsSource = employee;
                
            }
            else
            {
                  dg_data.ItemsSource = dpts.Employees.ToList();
            }
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = tb_search.Text.ToLower();

            if (text.Equals(""))
            {
                dg_data.ItemsSource = employee;

            }
            else
            {
                var data = employee.Where(e => e.FirstName.ToLower().StartsWith(text)
                                                          || e.LastName.ToLower().StartsWith(text));
                dg_data.ItemsSource = data;
            }
        }

        private void btaddDapt_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddDept();
            dialog.ShowDialog();
            cb_dpts.ItemsSource = Departments;
        }

        private void btDeleteDpts_Click(object sender, RoutedEventArgs e)
        {
            var dept = cb_dpts.SelectedItem as Department;

            if (dept != null || dept.DepartmentName.Equals(""))
            {
                var choise = MessageBox.Show($"Delete Department {dept.DepartmentName} ?",
                                                         "Delete Woring",MessageBoxButton.YesNo);
                if (choise == MessageBoxResult.Yes)
                {

                    db.Departments.Remove(dept);
                    db.SaveChanges();
                    cb_dpts.ItemsSource = Departments;
                    MessageBox.Show($"{dept} section has been removed");

                }

            }
        }

        private void btAddEmp_Click(object sender, RoutedEventArgs e)
        {
            var dailog = new AddEMP();
            dailog.ShowDialog();
            dg_data.ItemsSource = employee;
        }

        private void btDeleteEmp_Click(object sender, RoutedEventArgs e)
        {
            var emp = dg_data.SelectedItem as Employee;

            if (emp != null)
            {
                var choise = MessageBox.Show($"Delete Employee {emp.FirstName} {emp.LastName} ID {emp.EmployeeId} ?",
                                                         "Delete Woring", MessageBoxButton.YesNo);
                if (choise == MessageBoxResult.Yes)
                {

                    db.Employees.Remove(emp);
                    db.SaveChanges();
                    dg_data.ItemsSource = employee;
                    MessageBox.Show($"{emp}  has been removed");

                }
            }
        }

        private void brExoprt_Click(object sender, RoutedEventArgs e)
        {
            var dailog = new SaveFileDialog();
            dailog.Filter = "CSF File |*.csv";
            var save = dailog.ShowDialog();
            if (save == true)
            {
                using (var sw = new StreamWriter(dailog.FileName))
                {
                    foreach (var col in dg_data.Columns)
                    {
                        sw.Write(col.Header.ToString() + ",");
                    }
                    sw.WriteLine();
                    foreach (var row in dg_data.Items)
                    {
                        if (row is Employee)
                        {
                            switch (row)
                            {
                                case Employee emp:
                                    sw.WriteLine(
                                        $"{emp.EmployeeId} ," +
                                        $"{emp.FirstName} ," +
                                        $"{emp.LastName}," +
                                        $"{emp.Email} ," +
                                        $"{emp.PhoneNumber}," +
                                        $"{emp.HireDate}," +
                                        $"{emp.JobId}," +
                                        $"{emp.Salary} ," +
                                        $"{emp.ManagerId}," +
                                        $"{emp.DepartmentId}," +
                                        $"{emp.Department}," +
                                        $"{emp.Job}," +
                                        $"{emp.Manager}," +
                                        $"{emp.Dependents}," +
                                        $"{emp.InverseManager}" );
                                    break;
                            }

                        }
                    }
                }
            }
           
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
