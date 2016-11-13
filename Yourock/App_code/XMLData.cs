using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Yourock.App_code
{
    public static class XMLData
    {
        public static List<T> LoadXmlData<T>(string file, string errorMessage)
        {
            List<T> list = new List<T>();
            if (File.Exists(file) && new FileInfo(file).Length > 0)
            {
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<T>));
                    TextReader textReader = new StreamReader(file);
                    list = (List<T>)deserializer.Deserialize(textReader);
                    textReader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(errorMessage);
                }
            }
            return list;
        }

        public static void SaveXmlData<T>(List<T> list, string file, string errorMessage)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                TextWriter textWriter = new StreamWriter(file);
                serializer.Serialize(textWriter, list);
                textWriter.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show(errorMessage);
            }

        }
    }
}
