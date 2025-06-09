using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JsonConventer 
{
    static Settings settings = Settings.GetInstance();

    [Serializable]
    public class AboutItemsInfo
    {
        public int id;

        public string name;
        public string category;

        public string reactionPhrase;
        public string notePhrase;

        //public AboutItemsInfo(int _id, string _name, string _category, string _reactionPhrase, string _notePhrase)
        //{
        //    id = _id;
        //    name = _name;
        //    category = _category;
        //    reactionPhrase = _reactionPhrase;
        //    notePhrase = _notePhrase;
        //}
    }

    [Serializable]
    public class JsonDataWrapper
    {
        public List<AboutItemsInfo> aboutItemsInfo;
    }

    
    public static JsonDataWrapper GetItemsFromJson()
    {
        string jsonText = File.ReadAllText(Settings.GetInstance().itemsInfoFilePath);
        JsonDataWrapper data = JsonUtility.FromJson<JsonDataWrapper>(jsonText);
        return data;
    }
    



}
