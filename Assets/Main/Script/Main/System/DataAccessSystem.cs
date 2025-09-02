using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class DataAccessSystem
{
    const byte FOURBITE = 4;
    const byte ONEBYTE = 8;
    const byte TWOBYTE = 16;
    const byte THREEBYTE = 24;

    int CheckNumberCaculate(byte[] data)
    {
        int csum = data[data.Length - 1];
        csum <<= 1;
        return csum;
    }
    static void EncryptionSystem(byte[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] ^= 0xff;
        }
    }

    public bool SaveFileSystem<T>(string folderPath, string fileName, T saveData) where T : struct
    {
        fileName = folderPath + fileName;
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        byte[] binaryData;
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter writer = new BinaryFormatter();
            writer.Serialize(ms, saveData);
            binaryData = new byte[ms.Length + FOURBITE];
            ms.ToArray().CopyTo(binaryData, FOURBITE);

            int csum = CheckNumberCaculate(binaryData);

            binaryData[0] = (byte)((csum >> THREEBYTE) & 0xff);
            binaryData[1] = (byte)((csum >> TWOBYTE) & 0xff);
            binaryData[2] = (byte)((csum >> ONEBYTE) & 0xff);
            binaryData[3] = (byte)(csum & 0xff);
        }

        EncryptionSystem(binaryData);

        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        {
            try
            {
                fs.Write(binaryData, 0, binaryData.Length);
            }
            catch (Exception)
            {
                return false;
            }
        }
        return true;
    }
    public bool LoadFileSystem<T>(string folderPath, string fileName, out T loadData) where T : struct
    {
        fileName = folderPath + fileName;
        if (!Directory.Exists(folderPath) || !File.Exists(fileName))
        {
            loadData = default;
            return false;
        }
        byte[] fileData;
        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            try
            {
                fileData = new byte[fs.Length];
                fs.Read(fileData, 0, fileData.Length);
            }
            catch (Exception)
            {
                loadData = default;
                return false;
            }
        }

        EncryptionSystem(fileData);

        int csum = CheckNumberCaculate(fileData);
        int sum = (fileData[0] << THREEBYTE) | (fileData[1] << TWOBYTE) | (fileData[2] << ONEBYTE) | (fileData[3]);
        if (csum != sum)
        {
            loadData = default;
            return false;
        }
        byte[] binaryData = new byte[fileData.Length - FOURBITE];
        Array.Copy(fileData, FOURBITE, binaryData, 0, binaryData.Length);
        using (MemoryStream ms = new MemoryStream(binaryData))
        {
            BinaryFormatter reader = new BinaryFormatter();
            loadData = (T)reader.Deserialize(ms);
        }

        return true;
    }
}