using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    public float climbSpeed;
    public Rigidbody2D rig;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GroundCheck groundCheck;
    public Collider2D footCollider;
    public CapsuleCollider2D playerCollider;

    private Vector3 velocity = Vector3.zero;
    private bool isJumping;
    private bool isGrounded;

    public bool isClimbing;

    private float horizontal;
    private float vertical;

    public static MovePlayer instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Double instance singleton");
            return;
        }
        instance = this;

    }

    private void FixedUpdate()
    {
        if (!isClimbing)
        {
            Movement(horizontal);
        }
        else
        {
            Climb(vertical);
        }
    }

    void Update()
    {
        isGrounded = groundCheck.isGrounded;

        horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        Flip(rig.velocity.x);
        float characterVelocity = Mathf.Abs(rig.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("IsClimbing", isClimbing);

        //savoir si le joueur tombe, si il ne tombe pas désactiver les colliders des pieds
        if (rig.velocity.y > 0.3f)
        {
            //désactive le colldier des pieds
            footCollider.enabled = false;
        }
        else
        {
            //active le collider des pieds
            footCollider.enabled = true;
        }
    }

    public void Stop()
    {
        Movement(0);
        Climb(0);
    }

    void Movement(float _horizontal)
    {
        Vector3 targetVelocity = new Vector2(_horizontal, rig.velocity.y);    
        rig.velocity = Vector3.SmoothDamp(rig.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            Jump();
        }
    }

    void Climb(float _vertical)
    {
        Vector3 targetVelocity = new Vector2(0, _vertical);
        rig.velocity = Vector3.SmoothDamp(rig.velocity, targetVelocity, ref velocity, .05f);
        //lancer le trigger de l'anim de climb
    }

    public void Jump()
    {
        rig.AddForce(new Vector2(0f, jumpForce));
        isJumping = false;
    }

    void Flip(float _velocity)
    {
        if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
