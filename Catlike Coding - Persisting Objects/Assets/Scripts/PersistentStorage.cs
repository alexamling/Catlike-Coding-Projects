using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentStorage : MonoBehaviour {

    string savePath;

    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveFile");
    }
	
    public void Save(PersistableObject o)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(savePath, FileMode.Create)))
        {
            o.Save(new GameDataWriter(writer));
        }
    }

    public void Load(PersistableObject o)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(savePath, FileMode.Open)))
        {
            o.Load(new GameDataReader(reader));
        }
    }
}
