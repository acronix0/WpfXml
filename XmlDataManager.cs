using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace helloapp
{
    public class XmlDataManager
    {
        
        public static List<T> LoadData<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath)) return new List<T>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using FileStream fileStream = new FileStream(filePath, FileMode.Open);
            return (List<T>)serializer.Deserialize(fileStream);
        }

        
        public static void SaveData<T>(string filePath, List<T> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            serializer.Serialize(fileStream, data);
        }

        public static void AddRecord<T>(string filePath, T record) where T : new()
        {
            var data = LoadData<T>(filePath);
            data.Add(record);
            SaveData(filePath, data);
        }


        public static void UpdateRecord<T>(string filePath, T updatedRecord, Predicate<T> matchPredicate) where T : new()
        {
            var data = LoadData<T>(filePath);
            var recordIndex = data.FindIndex(matchPredicate);
            if (recordIndex != -1)
            {
                data[recordIndex] = updatedRecord;
                SaveData(filePath, data);
            }
        }


        public static void DeleteRecord<T>(string filePath, Predicate<T> matchPredicate) where T : new()
        {
            var data = LoadData<T>(filePath);
            data.RemoveAll(matchPredicate);
            SaveData(filePath, data);
        }
    }

}
