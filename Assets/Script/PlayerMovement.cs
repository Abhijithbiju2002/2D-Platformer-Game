using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D playerCollider;

    private Vector2 boxColliderSize;
    private Vector2 boxColliderOffset;

    [SerializeField] private float speed;
    [SerializeField] private float jump;

    private bool isGrounded = false;

    [SerializeField] private Rigidbody2D rb;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        boxColliderSize = playerCollider.size;
        boxColliderOffset = playerCollider.offset;
    }

    // Update is called once per frame
    public void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        MoveCharacter(horizontal);
        HandleMovementAnimation();
        HandleJump(vertical);

        //crouch button
        if (Input.GetKey(KeyCode.LeftControl))
        {
            HandleCrouch(true);
        }
        else
        {
            HandleCrouch(false);
        }

    }
    void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

    }

    void HandleMovementAnimation()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));


        Vector3 scale = transform.localScale;

        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

    }

    public void HandleCrouch(bool crouch)
    {
        if (crouch == true)
        {
            float offX = -0.0978f;     //Offset X
            float offY = 0.5947f;      //Offset Y

            float sizeX = 0.6988f;     //Size X
            float sizeY = 1.3398f;     //Size Y

            playerCollider.size = new Vector2(sizeX, sizeY);
            playerCollider.offset = new Vector2(offX, offY);
        }
        else
        {
            playerCollider.size = boxColliderSize;
            playerCollider.offset = boxColliderOffset;
        }
        animator.SetBool("Crouch", crouch);
    }
    public void HandleJump(float vertical)
    {
        if (vertical > 0 && isGrounded)
        {
            animator.SetTrigger("juump");
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);



        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            isGrounded = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "GameOver")
        {
            Destroy(gameObject);
        }
    }

}
