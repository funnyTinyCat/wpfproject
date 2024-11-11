using System.Windows;
using WpfDataGridToSql02.Data;
using WpfDataGridToSql02.Interfaces;
using Somes.Domain.Models;
using WpfDataGridToSql02.ViewModel;

namespace WpfDataGridToSql02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //        public List<Employee> MyEmployees { get; set; }   
  /*      private readonly IUserRepository _userRepo;
        private List<User> MyUsers { get; set; }
  */
        //        private User createdBy { get; set; }    
        // IUserRepository userRepo
        public MainWindow()
        {
            InitializeComponent();

            MainWindowViewModel vm = new MainWindowViewModel();

            DataContext = vm;

            //using (_userRepo = new IUserRepository()) { 
            
            //}

            //using (AppdataContext _context = new AppdataContext()) {

            //    MyEmployees = _context.Employees.ToList();
            //}

/*
            using (ApplicationDbContext _context02 = new ApplicationDbContext())
            {

                MyUsers = _context02.User.ToList();
            }
*/

         //   var createdBy = _userRepo.GetById(1);

            /*
            if (createdBy == null)
            {
                //CreatedBy.Text = "Nema ništa";
            }
            */

            //var modifiedBy = _userRepo.GetById(1);

            //EmployeesList.ItemsSource = MyEmployees;

            // new - good ones
            //EmployeesList.AutoGeneratingColumn += myDataGrid_AutoGeneratingColumn;

            //EmployeesList.ItemsSource = MyUsers;
            //CreatedBy.Text = createdBy.Username;
        }

        //void myDataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        //{



            /*            if (e.PropertyName == "ID")
                            e.Cancel = true;
            */
            /*
                        if (e.PropertyName == "UserId")
                        {
                            e.Column.Header = "Korisničko ime";
                            e.Column.Visibility = System.Windows.Visibility.Collapsed;
                        } else if (e.PropertyName == "Username")
                        {
                            e.Column.Header = "Korisničko ime";
                        } else if (e.PropertyName == "CreatedDate")
                        {
                            e.Column.Header = "Datum kreiranja";
                        } else if (e.PropertyName == "CreatedBy" )
                        {
                            e.Column.Header = "Kreirao";
                        } else if (e.PropertyName == "ModifiedDate")
                        {
                            e.Column.Header = "Datum izmjene";
                        } else if (e.PropertyName == "ModifiedBy" )
                        {
                            e.Column.Header = "Izmjenio";
                        }
            */


        //    if (e.PropertyName == "Username")
        //    {
        //        e.Column.Header = "Korisničko ime";
        //    }
        //    else if (e.PropertyName == "CreatedDate")
        //    {
        //        e.Column.Header = "Datum kreiranja";
        //        e.Column.Visibility = System.Windows.Visibility.Collapsed;
        //    }

        //}


    }
}