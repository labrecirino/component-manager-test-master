using ReadDataApplication.Proxies;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;

namespace ReadDataApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Comments about the exercise: A predefined WPF app with a Button and a ListView is provided.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Comments about the exercise: Use async/await if possible
        private async void  ReadData_Click(object sender, RoutedEventArgs e)
        {
            ShowData.ItemsSource = null;

            IComponentManager cm = new ComponentManagerClient();

            // Comments about the exercise: Dot not block GUI while communicating to the service, it should be responsive all the time.
            // Use async/await if possible
            IEnumerable<PersonalData> list =  await Task.Run<IEnumerable<PersonalData>>(() => cm.ReadDataAsync());
            this.UpdateLayout();

            //perform a synchronous, rather than asynchronous. Tip: remove async modifier 
            //IEnumerable<PersonalData> list = cm.ReadData();

            // Comments about the exercise: Show LastName and FirstName on ListView, ordered by LastName and only persons older than 16 years old.
            // Use LINQ when possible.
            var itemList = (from item in list
                           where item.Age > 16
                           orderby item.LastName, item.FirstName
                           select item);

            ShowData.ItemsSource = itemList;


        }




    }
}
