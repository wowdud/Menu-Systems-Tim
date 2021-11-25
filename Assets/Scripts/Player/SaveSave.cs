using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSave
{
    public static void SavePlayerData(PlayerHandler player)
    {
        //reference formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //give save location
        string path = Application.persistentDataPath + "/meme.jpeg";
        //create file
        FileStream stream = new FileStream(path, FileMode.Create);
        //specify data to write
        BinarySave data = new BinarySave(player);
        //write and convert
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static BinarySave LoadPlayerData(PlayerHandler player)
    {
        //location to load from
        string path = Application.persistentDataPath + "/meme.jpeg";
        //if there is a file there
        if (File.Exists(path))
        {
            //call formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //read data
            FileStream stream = new FileStream(path, FileMode.Open);
            //convert data to useable form
            BinarySave data = formatter.Deserialize(stream) as BinarySave;
            stream.Close();
            //send useable data back to player
            return data;
        }
        return null;
    }
}
