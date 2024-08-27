using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class SaveGame{
/*    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
*/    public static void SaveDialogues(Dialogue[] dialogues) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dialogue.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, dialogues);
        stream.Close();
    }
    public static Dialogue[] LoadDialogues()
    {
        string path = Application.persistentDataPath + "/dialogue.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Dialogue[] dialogues = formatter.Deserialize(stream) as Dialogue[];
            return dialogues;
        }
        else
        {
            Debug.Log("Dialogues not found! Creating new");
            return null;
        }
    }
    public static void DeleteSaves()
    {
        string path = Application.persistentDataPath + "/dialogue.save";
        File.Delete(path);
    }

/*    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Player save file not found");
            return null;
        }
    }
*/}
