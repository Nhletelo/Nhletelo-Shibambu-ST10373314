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

namespace ClassLibraryWithMultipleWindows
{
    /// <summary>
    /// Interaction logic for AddInfo.xaml
    /// </summary>
    public partial class AddInfo : Window
    {
        public List<Student> student = new List<Student>();
        public AddInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtAge.Text = string.Empty;
            txtCampus.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtFirstName.Focus();
            radMale.Focus();
            lstShow.Items.Clear();
            lstShowAll.Items.Clear();
        }

        private void radFemale_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string theGender;
            if (radMale.IsChecked == true)
            {
                theGender = "Male";
            }
            else if (radFemale.IsChecked == true)
            {
                theGender = "Female";
            }
            student.Add(new Student(txtFirstName.Text, txtLastName.Text, int.Parse(txtAge.Text), txtCampus.Text, theGender));

            foreach (Student student in students)
            {
                lstShow.Items.Add($"student.FirstName} : {student.LastName}");
            }
        }
    }
}
