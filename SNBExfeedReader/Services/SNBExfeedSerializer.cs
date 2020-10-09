using System.IO;
using System.Xml.Serialization;

namespace SNBExfeedReader.Services
{
    public class SNBExfeedSerializer
    {
        public static rss Deserialize(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(rss));
            serializer.UnknownNode += new
            XmlNodeEventHandler(Deserializing_UnknownNode);
            serializer.UnknownAttribute += new
            XmlAttributeEventHandler(Deserializing_UnknownAttribute);
            return (rss)serializer.Deserialize(stream);
        }

        private static void Deserializing_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            // TODO: Handle UnknownNode
        }

        private static void Deserializing_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            // TODO: Handle UnknownAttribute
        }

        public static void Serialize(rss snbFeedRss, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(rss));
            StreamWriter streamWriter = new StreamWriter(filename);
            serializer.Serialize(streamWriter,  snbFeedRss);
        }
    }
}
