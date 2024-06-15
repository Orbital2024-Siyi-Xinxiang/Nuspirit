using UnityEngine;

[CreateAssetMenu(fileName = "CategoryDatabase", menuName = "ScriptableObjects/CategoryDatabase")]
public class CategoryDatabaseSO : ScriptableObject
{
    [System.Serializable]
    public class CategoryData
    {
        public string category;
        public GameObject prefab;
    }

    public CategoryData[] categories;
}
