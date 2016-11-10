using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MysqlEDMXDocumentation
{
    public partial class MainForm : Form
    {
        public static string connectionString = "";
        public static MySqlHelper sqlHelper; 

        public MainForm()
        {
            InitializeComponent();
        }

        public string edmxFileName { get; set; }

        public XDocument edmxDocument { get; set; }

        private void CreateDocumentation()
        {
            var doc = XDocument.Load(edmxFileName);
            var entityTypeElements = doc.Descendants("{http://schemas.microsoft.com/ado/2009/11/edm}EntityType");
            var i = 0;
            foreach (var entityTypeElement in entityTypeElements)
            {
                var tableName = entityTypeElement.Attribute("Name").Value;
                var propertyElements =
                    entityTypeElement.Descendants("{http://schemas.microsoft.com/ado/2009/11/edm}Property");
                AddNodeDocumentation(entityTypeElement, GetTableDocumentation(tableName).Replace("\r", string.Empty).Replace("\n", string.Empty));
                foreach (var propertyElement in propertyElements)
                {
                    var columnName = propertyElement.Attribute("Name").Value;
                    AddNodeDocumentation(propertyElement, GetColumnDocumentation(tableName, columnName).Replace("\r",string.Empty).Replace("\n", string.Empty));
                }
            }
            edmxDocument = doc;
        }

        private void AddNodeDocumentation(XElement element, string documentation)
        {
            if (string.IsNullOrEmpty(documentation))
                return;
            element.Descendants("{http://schemas.microsoft.com/ado/2009/11/edm}Documentation").Remove();
                element.AddFirst(new XElement(
                    "{http://schemas.microsoft.com/ado/2009/11/edm}Documentation",
                    new XElement("{http://schemas.microsoft.com/ado/2009/11/edm}Summary", documentation)));
        }

        private string GetTableDocumentation(string tableName)
        {
            return
                sqlHelper.ExecuteScalar(
                    "select TABLE_COMMENT from INFORMATION_SCHEMA.TABLES where table_schema = 'swms' and TABLE_NAME='" +
                    tableName + "'") as string;
        }

        private string GetColumnDocumentation(string tableName, string columnName)
        {
            return
                sqlHelper.ExecuteScalar(
                        "select COLUMN_COMMENT from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'swms' AND TABLE_NAME='" +
                        tableName + "' AND COLUMN_NAME='" + columnName + "'")
                    as string;
        }

        private void btn_SelectEdmxFilename_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "EDMX File(*.edmx)|*.edmx",
                RestoreDirectory = true
            };
            fileDialog.ShowDialog();
            txt_edmxFileName.Text = fileDialog.FileName;
            edmxFileName = fileDialog.FileName;
        }

        private void btn_Proc_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = txt_connectionString.Text.Trim();
                sqlHelper = new MySqlHelper(connectionString);

                edmxFileName = txt_edmxFileName.Text.Trim();
                CreateDocumentation();

                txt_Result.Text = edmxDocument.ToString();
                MessageBox.Show("Documenation add Completed!!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Documentaion add Filed, Reason:" + ex.Message);
               
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Writing result to {0}", edmxFileName);
                if (File.Exists(edmxFileName))
                {
                    var targetFile = edmxFileName + DateTime.Now.ToString("MM-dd-hh-mm-ss") + ".bak";
                    File.Move(edmxFileName, targetFile);
                }
                edmxDocument.Save(edmxFileName);

                MessageBox.Show("File Saved, Now Back to Visual Studio using T4 to generate entity");
            }
            catch (Exception ex)
            {
                MessageBox.Show("File Save Failed , Reason:" + ex.Message);
            }
        }
    }
}