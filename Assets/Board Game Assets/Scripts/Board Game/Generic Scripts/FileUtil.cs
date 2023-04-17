using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace com.digitalmind.towertest
{
    public class FileUtil
    {
        public void WriteToFile(string fileName, string json)
        {
            string path = GetFilePath(fileName);
            FileStream fileStream = new FileStream(path, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        public string ReadFromFIle(string fileName)
        {
            string path = GetFilePath(fileName);
            if (!File.Exists(path))
                return "File not found";
            
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }

        private string GetFilePath(string fileName)
        {
            return Application.persistentDataPath + "/" + fileName;
        }
    }
}