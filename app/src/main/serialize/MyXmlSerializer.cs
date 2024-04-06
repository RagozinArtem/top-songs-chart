using System.Xml.Serialization;

namespace app.main.serialize;

public class MyXmlSerializer<T> : MySerializer<T> where T : class
{
    public override bool Write(T t, string fileName)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            try
            {
                xmlSerializer.Serialize(fs, t);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        return true;
    }

    public override T Read(string fileName)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            try
            {
                T t = xmlSerializer.Deserialize(fs) as T;
                return t;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}