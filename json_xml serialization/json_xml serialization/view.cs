using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace json_xml_serialization
{
    public partial class view : Form
    {
        public string file;
        public DataSet data;
        public class student
        {
            public string ID;
            public string name;
            public int age;
        }
        public view(string path , DataSet ds = null)
        {
            file = path;
            data = ds;
            InitializeComponent();
        }

        private void view_Load(object sender, EventArgs e)
        {
            if (file == "null")
            {
               student s = jsonTodata("j.json");
                DataTable table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("NAME", typeof(string));
                table.Columns.Add("age", typeof(int));
                table.Rows.Add(s.ID, s.name, s.age);
                dataGridView1.DataSource = table;
            }
            else
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(file);
                
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            
        }

        public static student jsonTodata(string path)
        {


            JObject json = JObject.Parse(File.ReadAllText(@path));

            student jsonObj = JsonConvert.DeserializeObject<student>(json.ToString());

            return jsonObj;

        }
        private void view_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
