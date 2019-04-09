using System.Windows;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace P_Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string conn = @"Data Source=LENOVOYOGA;Initial Catalog=POWER;Integrated Security=True";
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=LENOVOYOGA;Initial Catalog=POWER;Integrated Security=True");
        //POWERPatientEntity dataEntities = new POWERPatientEntity();
        POWERPatientEntity context = new POWERPatientEntity();
        CollectionViewSource clientVisitViewSource;


        public MainWindow()
        {
            InitializeComponent(); 
            clientVisitViewSource = ((CollectionViewSource)(FindResource("clientVisit_OPDViewSource")));
        }
        private void WinDashboard_Loaded(object sender, RoutedEventArgs e)
        {
            // Load is an extension method on IQueryable,    
            // defined in the System.Data.Entity namespace.   
            // This method enumerates the results of the query,    
            // similar to ToList but without creating a list.   
            // When used with Linq to Entities, this method    
            // creates entity objects and adds them to the context.   
            context.ClientVisit_OPD.Load();

            // After the data is loaded, call the DbSet<T>.Local property    
            // to use the DbSet<T> as a binding source.   
            clientVisitViewSource.Source = context.ClientVisit_OPD.Local;
        }


    }
}

