using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveProtocolSettings
{
    public static void SaveProgress(PlayerSettings settings)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/settings.hackme";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(settings);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadProgress()
    {
        string path = Application.persistentDataPath + "/settings.hackme";
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
            Debug.LogError("Save file wasn't found in the specified path");
            return null;
        }
    }
}