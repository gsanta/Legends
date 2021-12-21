using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public bool isMovementDeactivated = false;

    [SerializeField]
    private float moveSpeed = 1f;

    private Rigidbody2D rigidBody;
    private Animator animator;

    public string transitionName;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    public void SetLimit(Vector3 bottomLeftEdge, Vector3 topRightEdge)
    {
        this.bottomLeftEdge = bottomLeftEdge;
        this.topRightEdge = topRightEdge;
    }

    void Start()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else
        {
            instance = this;

            rigidBody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        if (isMovementDeactivated)
        {
            rigidBody.velocity = Vector2.zero;
        } else
        {
            rigidBody.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;
        }

        animator.SetFloat("movementX", rigidBody.velocity.x);
        animator.SetFloat("movementY", rigidBody.velocity.y);

        if (horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            if (!isMovementDeactivated)
            {
                animator.SetFloat("lastMovementX", horizontalMovement);
                animator.SetFloat("lastMovementY", verticalMovement);
            }
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
            Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)
        );
    }
}
