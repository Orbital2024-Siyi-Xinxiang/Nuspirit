using System.Collections;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public static PlayerPosition instance;
    public Vector2 targetPosition;
    public GameObject joystickCanvas;  // Add this line to reference the joystick canvas

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(joystickCanvas);  // Add this line to keep the joystick canvas persistent
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartCooldown(float cooldownDuration)
    {
        StartCoroutine(TransferCooldown(cooldownDuration));
    }

    private IEnumerator TransferCooldown(float cooldownDuration)
    {
        Debug.Log("Starting transfer cooldown in PlayerPosition.");
        GameStateManager.justTransferred = true;
        yield return new WaitForSeconds(cooldownDuration);
        GameStateManager.justTransferred = false;
        Debug.Log("Transfer cooldown ended in PlayerPosition. Transfer can happen again.");
    }
}
