using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{ 
//{
//    // Read and Write BLOB to/from Filesystem and Database
//    public class BlobSample : System.Windows.Forms.Form
//    {
//        private System.Windows.Forms.PictureBox pbxPhoto;
//        private System.ComponentModel.Container components = null;
//        private System.Windows.Forms.Button btnLoadPhoto;
//        private System.Windows.Forms.Button btnAddEmp;
//        private System.Windows.Forms.Button btnGetEmp;
//        private System.Windows.Forms.StatusBar statusBar;

//        // My own private Variables
//        private String _fname = null;
//        private SqlConnection _conn;

//        // Constructor
//        public BlobSample()
//        {
//            // Initialize GUI
//            InitializeComponent();

//            // Get Database Connection
//            _conn = new SqlConnection("data source=XEON;" +
//                "initial catalog=Northwind;" +
//                "user id=sa;password=manager;");
//        }

//        // **** Read Image from Filesystem and add it to the Database.
//        public void AddEmployee(
//            string plastName,
//            string pfirstName,
//            string ptitle,
//            DateTime phireDate,
//            int preportsTo,
//            string photoFilePath)
//        {

//            // Read Image into Byte Array from Filesystem
//            byte[] photo = GetPhoto(photoFilePath);

//            // Construct INSERT Command
//            SqlCommand addEmp = new SqlCommand(
//                "INSERT INTO Employees (" +
//                "LastName,FirstName,Title,HireDate,ReportsTo,Photo) " +
//                "VALUES(@LastName,@FirstName,@Title,@HireDate,@ReportsTo,@Photo)", _conn);

//            addEmp.Parameters.Add("@LastName", SqlDbType.NVarChar, 20).Value = plastName;
//            addEmp.Parameters.Add("@FirstName", SqlDbType.NVarChar, 10).Value = pfirstName;
//            addEmp.Parameters.Add("@Title", SqlDbType.NVarChar, 30).Value = ptitle;
//            addEmp.Parameters.Add("@HireDate", SqlDbType.DateTime).Value = phireDate;
//            addEmp.Parameters.Add("@ReportsTo", SqlDbType.Int).Value = preportsTo;
//            addEmp.Parameters.Add("@Photo", SqlDbType.Image, photo.Length).Value = photo;

//            // Open the Connection and INSERT the BLOB into the Database
//            _conn.Open();
//            addEmp.ExecuteNonQuery();
//            _conn.Close();
//        }

//        // **** Read Image into Byte Array from Filesystem
//        public static byte[] GetPhoto(string filePath)
//        {
//            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
//            BinaryReader br = new BinaryReader(fs);

//            byte[] photo = br.ReadBytes((int)fs.Length);

//            br.Close();
//            fs.Close();

//            return photo;
//        }

//        // **** Read BLOB from the Database and save it on the Filesystem
//        public void GetEmployee(string plastName, string pfirstName)
//        {
//            SqlCommand getEmp = new SqlCommand(
//                "SELECT EmployeeID, Photo " +
//                "FROM Employees " +
//                "WHERE LastName = @lastName " +
//                "AND FirstName = @firstName", _conn);

//            getEmp.Parameters.Add("@LastName", SqlDbType.NVarChar, 20).Value = plastName;
//            getEmp.Parameters.Add("@FirstName", SqlDbType.NVarChar, 10).Value = pfirstName;

//            FileStream fs;                          // Writes the BLOB to a file (*.bmp).
//            BinaryWriter bw;                        // Streams the BLOB to the FileStream object.
//            int bufferSize = 100;                   // Size of the BLOB buffer.
//            byte[] outbyte = new byte[bufferSize];  // The BLOB byte[] buffer to be filled by GetBytes.
//            long retval;                            // The bytes returned from GetBytes.
//            long startIndex = 0;                    // The starting position in the BLOB output.
//            string emp_id = "";                     // The employee id to use in the file name.

//            // Open the connection and read data into the DataReader.
//            _conn.Open();
//            SqlDataReader myReader = getEmp.ExecuteReader(CommandBehavior.SequentialAccess);

//            while (myReader.Read())
//            {
//                // Get the employee id, which must occur before getting the employee.
//                emp_id = myReader.GetInt32(0).ToString();

//                // Create a file to hold the output.
//                fs = new FileStream("employee" + emp_id + ".bmp",
//                                    FileMode.OpenOrCreate, FileAccess.Write);
//                bw = new BinaryWriter(fs);

//                // Reset the starting byte for the new BLOB.
//                startIndex = 0;

//                // Read the bytes into outbyte[] and retain the number of bytes returned.
//                retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);

//                // Continue reading and writing while there are bytes beyond the size of the buffer.
//                while (retval == bufferSize)
//                {
//                    bw.Write(outbyte);
//                    bw.Flush();

//                    // Reposition the start index to the end of the last buffer and fill the buffer.
//                    startIndex += bufferSize;
//                    retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
//                }

//                // Write the remaining buffer.
//                bw.Write(outbyte, 0, (int)retval);
//                bw.Flush();

//                // Close the output file.
//                bw.Close();
//                fs.Close();
//            }

//            // Close the reader and the connection.
//            myReader.Close();
//            _conn.Close();
//        }

//        private void btnAddEmp_Click(object sender, System.EventArgs e)
//        {
//            DateTime hireDate = DateTime.Parse("2003.05.03");
//            AddEmployee("Mary", "Jones", "Software Engineer", hireDate, 5, _fname);
//            statusBar.Text = "Employee added to the Database";
//        }

//        private void btnGetEmp_Click(object sender, System.EventArgs e)
//        {
//            GetEmployee("Mary", "Jones");
//            statusBar.Text = "Employee saved to Filesystem";
//        }

//        private void btnLoadPhoto_Click(object sender, System.EventArgs e)
//        {
//            OpenFileDialog dlg = new OpenFileDialog();

//            dlg.Title = "Open Photo";
//            dlg.Filter = "Windows Bitmap Files (*.bmp)|*.bmp"
//                + "|All files (*.*)|*.*";

//            if (dlg.ShowDialog() == DialogResult.OK)
//            {
//                try
//                {
//                    pbxPhoto.Image = new Bitmap(dlg.OpenFile());
//                    _fname = dlg.FileName;
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("Unable to load file: " + ex.Message);
//                }
//            }

//            dlg.Dispose();
//        }

//        // The main entry point for the application.
//        [STAThread]
//        static void Main()
//        {
//            Application.Run(new BlobSample());
//        }
//    }
}
