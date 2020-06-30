using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an isntance of XmlTextReader and call Read method to read the file  
            XmlTextReader textReader = new XmlTextReader("books.xml");
            textReader.Read();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(textReader);
            xmlDoc.Save(Console.Out);

            XmlNode node = xmlDoc.SelectSingleNode("/book/genere[@value = 'computer']");

            // Select a list of nodes
            XmlNodeList nodes = xmlDoc.SelectNodes("/book");
            foreach (XmlNode userNode in nodes)
            {
                int age = int.Parse(userNode.Attributes["age"].Value);
                userNode.Attributes["age"].Value = (age + 1).ToString();
            }
        }
    }
}
