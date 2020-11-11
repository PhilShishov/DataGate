namespace DataGate.Services.Redis
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    public static class Serializer
    {
        public static byte[] ObjectToByteArray<T>(IEnumerable<T> data)
        {
            if (data == null)
            {
                return null;
            }

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, data);
            return ms.ToArray();
        }
    }
}