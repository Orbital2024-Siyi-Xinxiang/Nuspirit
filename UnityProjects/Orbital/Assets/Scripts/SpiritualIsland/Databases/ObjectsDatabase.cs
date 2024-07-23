using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;



[CreateAssetMenu(fileName = "ObjectsDatabase", menuName = "ScriptableObjects/ObjectsDatabase")]
public class ObjectsDatabase : ScriptableObject
{
    [System.Serializable]
    public class ObjectData
    {
        public string category;
        public GameObject prefab;
        public int availableQuantity;
    }

    public ObjectData[] objects;
}
