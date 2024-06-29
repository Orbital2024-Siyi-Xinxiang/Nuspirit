using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    public Button signUpButton;
    public string signUpSceneName;  // Public property to set the sign-up scene name

    public Button signInButton;
    public string signInSceneName;  // Public property to set the sign-in scene name

    void Start()
    {
        signUpButton.onClick.AddListener(SignUp);
        signInButton.onClick.AddListener(SignIn);
    }

    void SignUp()
    {
        SceneManager.LoadScene(signUpSceneName); // Load the sign-up scene specified in the Inspector
    }

    void SignIn()
    {
        SceneManager.LoadScene(signInSceneName); // Load the sign-in scene specified in the Inspector
    }
}
