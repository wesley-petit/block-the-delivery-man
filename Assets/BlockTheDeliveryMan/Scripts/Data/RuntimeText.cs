using UnityEngine;
using System.IO;

public static class RuntimeText
{

    public static string ReadString(string name_DataText)
    {
        string textFromData;
        string path = PathApp() + name_DataText;
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        textFromData = reader.ReadToEnd();

        Debug.Log("ma var text : " + textFromData);
        reader.Close();
        return textFromData;
    }

    static string PathApp()
    {
        string path;
        path = Application.dataPath;
        if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            path += "/../../";

            return path;
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            path += "/../";
            return path;
        }
        //racine du projet 
        return path = Application.dataPath + "/../";
    }
}