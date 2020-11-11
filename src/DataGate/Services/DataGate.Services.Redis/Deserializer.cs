namespace DataGate.Services.Redis
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class Deserializer
    {
        public static IEnumerable<T> ByteArrayToObject<T>(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            var data = (IEnumerable<T>)binForm.Deserialize(memStream);
            return data;
        }
    }
}
