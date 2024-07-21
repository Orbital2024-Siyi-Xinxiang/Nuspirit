using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ObjectsDatabase", menuName = "ScriptableObjects/ObjectsDatabase")]
public class ObjectsDatabaseSO : ScriptableObject
{
    [System.Serializable]
    public class ObjectData
    {
        public string id;
        public string category;
        public string name;
        public int availableQuantity;
        public Vector2Int size;


        public GameObject prefab;

    }

    public List<ObjectData> objects;
}
