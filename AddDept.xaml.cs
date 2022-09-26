using HrSystem.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HrSystem
{
    /// <summary>
    /// Interaction logic for AddDept.xaml
    /// </summary>
    public partial class AddDept : Window
    {

        private hrContext db = new hrContext();



        List<Department> departments
        {
            get { return db.Departments.ToList(); }
        }
        public AddDept()
        {
            InitializeComponent();
            cbLoc.ItemsSource = db.Locations.ToList();
        }
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            var dept = new Department();
            long depart;

            if (long.TryParse(tbDptID.Text, out depart) == false)
            {
                MessageBox.Show("The Reference entered for the new section is incorrect ! ");
                return;

            }

            //EmployeeService employeeService = new EmployeeService();
            //employeeService.Insert(tbDptID.Text);

            var CheckIdNumber = departments.Where(e => e.DepartmentId == long.Parse(tbDptID.Text)).FirstOrDefault() != null;
            switch (CheckIdNumber)
            {
                case true:
                    MessageBox.Show("Department ID is Exsist");
                    break;
                case false:
                    dept.DepartmentId = long.Parse(tbDptID.Text);
                    dept.DepartmentName = tbDptName.Text;
                    dept.Location = cbLoc.SelectedItem as Location;
                    db.Departments.Add(dept);
                    db.SaveChanges();
                    MessageBox.Show($" The {tbDptName.Text} has added");
                    this.Close();
                    break;
            }




        }

        
    }
}
