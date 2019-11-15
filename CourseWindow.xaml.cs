using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HW3
{
    /// <summary>
    /// Interaction logic for CourseWindow.xaml
    /// </summary>
    public partial class CourseWindow : Window
    {
        public CourseWindow()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
           Course course = new Course();
            course.CourseCode = txtCourseCode.Text;
            course.CourseQuota = Int32.Parse(txtCourseQuota.Text);
            course.CourseCredit = Int32.Parse(txtCourseCredit.Text);
           
            CetDb db = new CetDb();
            db.Courses.Add(course);

            db.SaveChanges();
            MessageBox.Show("Ders eklendi.");
           
            txtCourseCode.Text = "";
            txtCourseQuota.Text = "";
            txtCourseCredit.Text = "";
            LoadCourses();
        }
        private void Course_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            CetDb db = new CetDb();
            List<Course> courses = db.Courses.ToList();
            dgCourse.ItemsSource = courses;
        }



        private void btndelete_Click(object sender, RoutedEventArgs e)
        {


            Course course = dgCourse.SelectedItem as Course;
            if (course != null)
            {
                CetDb db = new CetDb();
                db.Courses.Remove(course);
                db.SaveChanges();
                MessageBox.Show("Ders silindi!");
                LoadCourses();

            }
            else
            {
                MessageBox.Show("Silmek için dersi seçmelisin!");
            }





        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            Course course = dgCourse.SelectedItem as Course;
            if (course != null)
            {
                CetDb db = new CetDb();
                var coursenew = db.Courses.Find(course.Id);

                coursenew.CourseCode = txtCourseCode.Text;
                coursenew.CourseQuota = Int32.Parse(txtCourseQuota.Text);
                coursenew.CourseCredit =Int32.Parse( txtCourseCredit.Text);
               
                db.SaveChanges();
                LoadCourses();
                MessageBox.Show("Güncellendi.");
            }
            else
            {
                MessageBox.Show("güncellemek için ders seçmelisin!");
            }






        }

        private void dgCourse_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            Course course = dgCourse.SelectedItem as Course;
            if (course != null)
            {
                txtCourseCode.Text = course.CourseCode;
                txtCourseQuota.Text = course.CourseQuota.ToString();
                txtCourseCredit.Text = course.CourseCredit.ToString();
              



            }




        }

       
    }
}
