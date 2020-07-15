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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
namespace json_xml_serialization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public  class student
        {
            public string name;
            public int age;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            addObject form = new addObject(1);
            this.Hide();
            form.Show();
            
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            addObject form = new addObject(0);
            this.Hide();
            form.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            student s = new student();
            s =(student) xmlTodata("x.xml", s.GetType());
            
            view form = new view("x.xml");
            this.Hide();
            form.Show();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            
           
            
            view form = new view("null");
            this.Hide();
            form.Show();

        }

        public static object xmlTodata(string path, Type T)
        {

            var serializer = new XmlSerializer(T);
            object xmlObj = new object();
            using (var reader = XmlReader.Create(path))
            {
                xmlObj = (object)serializer.Deserialize(reader);
            }
            return xmlObj;

        }


       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
