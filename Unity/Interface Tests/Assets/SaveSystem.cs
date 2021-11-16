using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    
    public static void SavePlayer (Player player) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.saveData";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerDataLevel1 data = new PlayerDataLevel1(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerDataLevel1 LoadPlayer() {
        string path = Application.persistentDataPath + "/player.saveData";

        if (File.Exists(path)) {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerDataLevel1 data = formatter.Deserialize(stream) as PlayerDataLevel1;
            stream.Close();

            return data;

        } else {

            Debug.LogError("Save file not found in " + path);
            return null;

        }
    }

}
