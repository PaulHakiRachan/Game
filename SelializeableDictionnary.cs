using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SerializableDictionnary<Tkey, Tvalue> : Dictionary<Tkey, Tvalue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<Tkey> keys = new List<Tkey>();
    [SerializeField] private List<Tvalue> values = new List<Tvalue>();

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        foreach(KeyValuePair<Tkey, Tvalue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        Clear();

        if(keys.Count != values.Count)
        {
            Debug.LogError("จำนวน KEY ไม่ตรงกับ จำนวน VALUE");
        }

        for (int i = 0; i < keys.Count; i++)
        {
            Add(keys[i], values[i]);
        }
    }
}
