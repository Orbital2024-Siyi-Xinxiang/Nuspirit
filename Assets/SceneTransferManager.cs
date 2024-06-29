using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransferManager : MonoBehaviour
{
    [SerializeField] private string targetScene;

    public void TransferToScene()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            Debug.Log("Transferring to scene: " + targetScene);
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogError("Target scene is not set.");
        }
    }
}
