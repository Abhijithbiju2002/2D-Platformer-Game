using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerCollider;

    private Vector2 boxColliderSize;
    private Vector2 boxColliderOffset;

    // Start is called before the first frame update
    void Start()
    {
        boxColliderSize = playerCollider.size;
        boxColliderOffset = playerCollider.offset;
    }

    // Update is called once per frame
    public void Update()
    {
        float VerticalInput = Input.GetAxis("Vertical");

        HandleMovement();
        HandleJump(VerticalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            HandleCrouch(true);
        }
        else
        {
            HandleCrouch(false);
        }

    }

    void HandleMovement()
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
            animator.SetTrigger("Jump");

        }

    }

}
