using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    public static void SaveGame(int partida)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/DatosGuardados "+partida+".MMM";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelSave levelSave = new LevelSave();

        formatter.Serialize(stream, levelSave);
        stream.Close();

    }

    public static LevelSave LoadGame(int partida)
    {
        string path = Application.persistentDataPath + "/DatosGuardados " + partida + ".MMM"; ;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelSave levelSave = formatter.Deserialize(stream) as LevelSave;

            stream.Close();
            return levelSave;
        }else
        {
            Debug.LogError("El archivo con extension .MMM no existe en"+path+", error al cargar");
            return null;
        }
    }

}
