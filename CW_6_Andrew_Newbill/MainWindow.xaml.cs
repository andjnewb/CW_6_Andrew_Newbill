using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Numerics;
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

namespace CW_6_Andrew_Newbill
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        OleDbConnection cn2;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CW6_Database.accdb");
            cn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CW6_Database.accdb");

        }

        private void GetDataButton_Click(object sender, RoutedEventArgs e)
        {
            //Getting Asset IDs
            string query = "select AssetID from Assets";

            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();

            string data = "";

            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }

            AssetIDS.Text = data;

            //Getting Asset descriptions

            query = "select Description from Assets";

            cmd = new OleDbCommand(query, cn);

            read = cmd.ExecuteReader();

            data = "";

            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }

            AssetDescriptions.Text = data;

            query = "select EmployeeID from Assets";

            cmd = new OleDbCommand(query, cn);

            read = cmd.ExecuteReader();

            data = "";

            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }

            AssignedToBox.Text = data;

            cn.Close();

        }

        private void Get_Employees_Button_Click(object sender, RoutedEventArgs e)
        {
            //Getting Asset IDs
            string query = "select Employee_ID from Employees";

            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();

            string data = "";

            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }

            Employee_IDs_2.Text = data;

            query = "select FirstName from Employees";

            cmd = new OleDbCommand(query, cn);

            read = cmd.ExecuteReader();

            data = "";

            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }

            Employee_Names_First.Text = data;

            query = "select LastName from Employees";

            cmd = new OleDbCommand(query, cn);

            read = cmd.ExecuteReader();

            data = "";

            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }

            Employee_Names_Last.Text = data;

            cn2.Close();
        }
    }
}
