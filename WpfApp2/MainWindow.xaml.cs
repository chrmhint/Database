/* 
 * Author : Christina Hinton
 * Date : 9/24/18
 * File : MainWindow.xaml.cs
 * Description : Prints data from access database
 */

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        OleDbConnection cn;

        public MainWindow()
        {

            InitializeComponent();
            
           cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\smats\\source\\repos\\WpfApp2\\WpfApp2\\Database1.accdb");
        }

        //print assets in appropriate boxes
        private void AssetsButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

            string data = "";
            string assetID = "";
            string assetName = "";
            while(read.Read())
            {
                data += read[0].ToString() + "\n";
                assetID += read[1].ToString() + "\n";
                assetName += read[2].ToString() + "\n";
            }
            cn.Close();

            InfoBox.Text = data;
            AssetID.Text = assetID;
            AssetDescription.Text = assetName;
        }

        //print employee info
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

            string id = "";
            string firstName = "";
            string lastName = "";
            while (read.Read())
            {
                id += read[0].ToString() + "\n";
                firstName += read[1].ToString() + "\n";
                lastName += read[2].ToString() + "\n";
            }
            cn.Close();

            EmployeeID.Text = id;
            FirstName.Text = firstName;
            LastName.Text = lastName;
        }

      
    }
}
