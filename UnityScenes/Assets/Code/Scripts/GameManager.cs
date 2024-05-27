using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }


    void Start()
    {
        // Initialization code here
    }

    void Update()
    {
        // Game-wide logic here
    }

    public void LoadScene(string MyIsland)
    {
        SceneManager.LoadScene(MyIsland);
    }
}
