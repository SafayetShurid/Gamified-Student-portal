using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using EasyUI.Toast;
using Base;

public class SaveGameManager : Singleton<SaveGameManager> 
{
    public const string baseDirectory = "/Save";

    public void SaveData<T>(T data,string fileName)
    {
        if (!DirectoryExists())
        {
            Directory.CreateDirectory(Application.persistentDataPath + baseDirectory);
        }

        if(!FileExists(fileName))
        {
            FileStream file = File.Create(Application.persistentDataPath + baseDirectory + "/" + fileName + ".dat");
            file.Close();
        }

        var json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + baseDirectory + "/" + fileName + ".dat";

        File.WriteAllText(path, json);
        
    }

    public void LoadData<T>(ref T dataType,string fileName)
    {
        if (!FileExists(fileName))
        {
            Toast.Show("File doesn't exist");
           // return default(T);
        }

        else
        {
            string path = Application.persistentDataPath + baseDirectory + "/" + fileName + ".dat";
            StreamReader file = File.OpenText(path);
            JsonUtility.FromJsonOverwrite(file.ReadToEnd(), dataType);
            file.Close();
        }   
    }

    public bool DirectoryExists()
    {
        return Directory.Exists(Application.persistentDataPath + baseDirectory);
    }

    public bool FileExists(string fileName)
    {
        return File.Exists(Application.persistentDataPath + baseDirectory + "/" + fileName + ".dat");
    }


}
