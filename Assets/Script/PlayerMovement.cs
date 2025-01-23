using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerCollider;

    private Vector2 boxColliderSize;
    private Vector2 boxColliderOffset;

    public float speed;
    public float jump;

    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        float Vertical = Input.GetAxisRaw("Vertical");

        MoveCharacter(horizontal);
        HandleMovementAnimation();
        HandleJump(Vertical);

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
        if (vertical > 0)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);

            animator.SetBool("Jump", true);

        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

}
