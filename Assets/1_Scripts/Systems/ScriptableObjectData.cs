using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectData : ScriptableObject
{   
    public TextAsset CSV;
    public DataType dataType;
    // public virtual void SetType<T>() where T : ScriptableObjectData
    // {
        
    // }
    public virtual void SetDictionaryData() { }
}
