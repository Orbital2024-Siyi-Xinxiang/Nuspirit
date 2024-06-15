using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public bool isMoving;
    public Vector2 input; // vector2 is holding a 2D object with x and y coordinates 
    private Animator animator;
    public LayerMask solidObjectLayer;

    private static PlayerController instance;
    private Coroutine moveCoroutine;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        // Ensure only one instance of the player exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        // Adjust BoxCollider2D size and offset
        if (boxCollider != null)
        {
            boxCollider.size = new Vector2(0.5f, 0.1f); // Adjust these values as needed
            boxCollider.offset = new Vector2(0f, -0.5f); // Adjust the offset as needed
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (PlayerPosition.instance != null)
        {
            transform.position = PlayerPosition.instance.targetPosition;
        }

        // Stop any ongoing movement
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }

        // Reset input and movement state
        input = Vector2.zero;
        isMoving = false;
        animator.SetBool("isMoving", false);
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero) // Vector2.zero is (0.0)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                {
                    moveCoroutine = StartCoroutine(Move(targetPos));
                }
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectLayer) != null)
        {
            return false;
        }
        return true;
    }
}
