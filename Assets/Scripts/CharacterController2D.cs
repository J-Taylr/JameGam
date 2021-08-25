
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	private PlayerMovement playerMovement;
	[SerializeField] private float jumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool airControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask whatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform groundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform frontCheck;
	           

	const float checkRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool grounded;            // Whether or not the player is grounded.
	public bool doubleJump;
	public bool jumping;
	public bool touchingFront;
	public bool wallSliding;
	public float wallSlidingSpeed;
	public bool walljumping;
	public float xWallForce;
	public float yWallForce;
	public float wallJumpTime;

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	
	private Rigidbody2D rb2D;
	private bool facingRight = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;

	private void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
		playerMovement = GetComponent<PlayerMovement>();

	}


	private void FixedUpdate()
	{
		grounded = false;
		touchingFront = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, checkRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				grounded = true;
			jumping = false;
			doubleJump = true;
		}

		touchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);
		if (touchingFront && !grounded && playerMovement.horizontalMove != 0)
        {
			wallSliding = true;
			doubleJump = true;
		}
        else
        {
			wallSliding = false;
        }


		if (wallSliding)
        {
			rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

		
	}

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space) && wallSliding == true)
		{
			walljumping = true;

			Invoke("SetWallJumpToFalse", wallJumpTime);

		}

		if (walljumping == true)
		{
			rb2D.velocity = new Vector2(xWallForce * -playerMovement.horizontalMove, yWallForce);
		}

	}

    public void Move(float move, bool jump)
	{
		

		//only control the player if grounded or airControl is turned on
		if (grounded || airControl)
		{

			

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, rb2D.velocity.y);
			// And then smoothing it out and applying it to the character
			rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && facingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (grounded && jump)
		{
			// Add a vertical force to the player.
			grounded = false;
			jumping = true;
			rb2D.AddForce(new Vector2(0f, jumpForce));
		}
		else if (doubleJump && jump)
		{

			doubleJump = false;
			jumping = false;
			rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
			jumping = true;
			rb2D.AddForce(new Vector2(0f, jumpForce));
			
			
		}
		
		if (jumping)
        {
			Jump();
        }
	}

	public void Jump()
    {
		if (rb2D.velocity.y < 0 && !wallSliding)
        {
			rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
		else if (rb2D.velocity.y > 0 && !Input.GetButton("Jump") && !wallSliding)
        {
			rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	void SetWallJumpToFalse()
    {
		walljumping = false;
    }
}
