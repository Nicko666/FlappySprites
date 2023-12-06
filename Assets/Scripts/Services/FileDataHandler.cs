using System;
using System.IO;
using UnityEngine;

public class FileDataHandler<T> where T : class
{
    private string dataDirPath;
    private string dataFileName;
    
    private readonly string encryptionCodeWord;

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;// Application.persistentDataPath;
        this.dataFileName = dataFileName;//"LocalData";
        this.encryptionCodeWord = "";
    }

    public FileDataHandler(string dataDirPath, string dataFileName, string encryptionCodeWord)
    {
        this.dataDirPath = dataDirPath;// Application.persistentDataPath;
        this.dataFileName = dataFileName;//"LocalData";
        this.encryptionCodeWord = encryptionCodeWord;

    }

    public T Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        T loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using ( FileStream stream = new FileStream(fullPath, FileMode.Open) )
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        dataToLoad = streamReader.ReadToEnd();
                    }
                }

                if (encryptionCodeWord != "")
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                loadedData = JsonUtility.FromJson<T>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }
    public void Save(T localData)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(localData, true);

            if (encryptionCodeWord != "")
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using ( FileStream stream = new FileStream(fullPath, FileMode.Create) )
            {
                using (StreamWriter writer = new StreamWriter(stream)) 
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}