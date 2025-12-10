using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IpcimWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class Domain
    {
        public string DomainName { get; set; }
        public string IpAddress { get; set; }

        public Domain(string domainName, string ipAddress)
        {
            DomainName = domainName;
            IpAddress = ipAddress;
        }

    }
    public partial class MainWindow : Window
    {
        public List<Domain> domainList = new List<Domain>();
        public MainWindow()
        {
            InitializeComponent();
            var sorok = File.ReadAllLines("csudh.txt").Skip(1);
            foreach(string s in sorok)
            {
                string[] darabok = s.Split(";");
                string domainName = darabok[0];
                string ipAdress = darabok[1];
                domainList.Add(new Domain(domainName, ipAdress));
            }
            dataGrid.ItemsSource = domainList;
        }
    }
}