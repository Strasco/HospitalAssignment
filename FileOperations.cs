using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EssensysHospitalWPF
{
    class FileOperations
    {
        public static void WriteXML(ListOfDoctors docs)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(ListOfDoctors));

            var path = Environment.CurrentDirectory + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, docs);
            file.Close();
        }

        public static ListOfDoctors ReadXML()
        {
            string fileName = Environment.CurrentDirectory + "\\SerializationOverview.xml";
            if (!File.Exists(fileName))
                return new ListOfDoctors();
                
            TextReader file = new StreamReader(fileName);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlSerializer deserializer = new XmlSerializer(typeof(ListOfDoctors));
            ListOfDoctors docs = (ListOfDoctors)deserializer.Deserialize(file);

            file.Close();
            return docs;
        }
    }
}
