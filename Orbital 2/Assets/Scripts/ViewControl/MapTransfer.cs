//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MapTransfer : MonoBehaviour
//{
//    public string sceneToLoad;  // The name of the scene to load
//    public Vector2 targetPosition; // The position where the player should appear in the new scene
//    public float transferCooldown = 1.0f; // Cooldown duration in seconds

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        Debug.Log("Collision detected with: " + collision.gameObject.name);
//        if (collision.CompareTag("Player") && !GameStateManager.justTransferred)
//        {
//            Debug.Log("Player collided with transfer point.");
//            if (PlayerPosition.instance != null)
//            {
//                PlayerPosition.instance.targetPosition = targetPosition;
//                Debug.Log("Loading scene: " + sceneToLoad);
//                SceneManager.LoadScene(sceneToLoad);
//                PlayerPosition.instance.StartCooldown(transferCooldown);
//            }
//            else
//            {
//                Debug.LogError("PlayerPosition instance is not set.");
//            }
//        }
//    }
//}
