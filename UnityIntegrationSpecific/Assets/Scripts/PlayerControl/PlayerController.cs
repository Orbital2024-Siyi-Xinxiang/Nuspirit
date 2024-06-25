using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public bool isMoving;
    public Vector2 input; // Vector2 is holding a 2D object with x and y coordinates 
    private Animator animator;
    public LayerMask solidObjectLayer;

    private static PlayerController instance;
    private Coroutine moveCoroutine;
    private BoxCollider2D boxCollider;
    public Joystick joystick; // Reference to the joystick

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

        // Adjust BoxCollider2D size and offset to cover the entire body
        if (boxCollider != null)
        {
            boxCollider.size = new Vector2(1f, 2f); // Adjust these values as needed
            boxCollider.offset = new Vector2(0f, 0f); // Adjust the offset as needed
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
            // Use joystick input if available, otherwise fallback to keyboard input
            input.x = joystick.Horizontal();
            input.y = joystick.Vertical();

            if (input == Vector2.zero)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");
            }

            // Ban diagonal movement
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }

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
            var nextPos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            if (IsWalkable(nextPos))
            {
                transform.position = nextPos;
            }
            else
            {
                break;
            }
            yield return new WaitForFixedUpdate(); // Use FixedUpdate for physics consistency
        }

        // Final position check
        if (!IsWalkable(targetPos))
        {
            transform.position = targetPos; // Ensure target position is set correctly
        }
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        // Increase the radius of the overlap check for better detection of thin colliders
        float detectionRadius = 0.2f;

        // Check the entire box collider area
        Vector2 colliderSize = boxCollider.size;
        Vector2 colliderOffset = boxCollider.offset;
        Vector2 colliderCenter = (Vector2)targetPos + colliderOffset;

        Collider2D hitCollider = Physics2D.OverlapBox(colliderCenter, colliderSize, 0f, solidObjectLayer);
        if (hitCollider != null)
        {
            Debug.LogWarning("not walkable!!!!!");
            return false;
        }
        return true;
    }
}
