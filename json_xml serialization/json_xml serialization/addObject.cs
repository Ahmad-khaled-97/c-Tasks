using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace json_xml_serialization
{
    public partial class addObject : Form
    {
        public int f;
        public addObject(int i)
        {
            f = i;
           
            InitializeComponent();
        }
        public class student
        {
            public string ID;
            public string name;
            public int age;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            student stud = new student
            {
                ID = textBox1.Text,
                name = textBox2.Text,
                age = Int32.Parse(textBox3.Text)

            };

            if (f == 1)
            {
                richTextBox1.Text = appendDataTojson(stud, "j.json");
            }
            else
            {
                richTextBox1.Text = appendDataToxml(stud, stud.GetType(), "x.xml" , "students");
            }
        }

        private void addObject_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            student stud = new student
            {
                ID = textBox1.Text,
                name = textBox2.Text,
                age=Int32.Parse(textBox3.Text)
            
            };

            if (f == 1)
            {
                richTextBox1.Text = dataTojson(stud, "j.json");
            }
            else
            {
                richTextBox1.Text = dataToxml(stud, stud.GetType(), "x.xml");
            }
            
        }

        public static string dataTojson(object data, string path)
        {

            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

            
           
            System.IO.File.WriteAllText(path,json);
          


            return json;
        }

        public static string dataToxml(object data, Type T, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            var serializer = new XmlSerializer(T);

            using (var writer = XmlWriter.Create(path, settings))
            {
                serializer.Serialize(writer, data);
            }
            string xmlString = System.IO.File.ReadAllText(path);
            return xmlString;

        }









        public static string appendDataTojson(object data, string path)
        {

            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);



            System.IO.File.AppendAllText(path, json);

            string jsonString = System.IO.File.ReadAllText(path);
          

            return jsonString;
        }
        
        public static string appendDataToxml(object data, Type T, string path , string root)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            var serializer = new XmlSerializer(T );
            List<object> xmlObj = new List<object>();
            using (var reader = XmlReader.Create(path))
            {
                xmlObj = (List<object>)serializer.Deserialize(reader);
            }
            using (var writer = XmlWriter.Create(path, settings))
            {
                serializer.Serialize(writer, xmlObj);
            }
            string xmlString = System.IO.File.ReadAllText(path);
            return xmlString;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addObject_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
