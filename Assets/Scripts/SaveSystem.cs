using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem {

    public static void SavePlayer (ScoreManager scoreScript){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player";
        FileStream stream = new FileStream(path,FileMode.Create);

        HighestScoreData data = new HighestScoreData(scoreScript);

        formatter.Serialize(stream, data);
        stream.Close(); 
    }

    public static HighestScoreData LoadPlayer (){
        string path = Application.persistentDataPath + "/player";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighestScoreData data = formatter.Deserialize(stream) as HighestScoreData;
            stream.Close();

            return data;
        }else{
            Debug.LogError("SavePlayer file not found in" + path);
            return null;
        }
    }   
}
