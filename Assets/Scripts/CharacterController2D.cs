
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	[Header("Components")]
	private PlayerMovement playerMovement;
	private Rigidbody2D rb2D;
	public GameObject sprite;

	[Header("Checks")]
	[SerializeField] private LayerMask whatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform groundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform frontCheck;
	const float checkRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool grounded;            // Whether or not the player is grounded.
	public bool touchingFront;
	

	[Header("Movement")]
	private Vector3 velocity = Vector3.zero;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private float jumpForce = 400f;                          // Amount of force added when the player jumps.
	[SerializeField] private bool airControl = false;                         // Whether or not a player can steer while jumping;
	           
	[Header("Jumping")]
	public bool jumping;
	public bool doubleJump;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	[Header("Wall Sliding")]
	public bool wallSliding;
	public float wallSlidingSpeed;

	[Header("Wall Jumping")]
	public bool walljumping;
	public float wallJumpTime;
	public float xWallForce;
	public float yWallForce;
	

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


	public void FlipRight()
	{
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = sprite.transform.localScale;
		theScale.x = -5;
		sprite.transform.localScale = theScale;
	}

    public void FlipLeft()
    {
		Vector3 theScale = sprite.transform.localScale;
		theScale.x = 5;
		sprite.transform.localScale = theScale;
	}


	void SetWallJumpToFalse()
    {
		walljumping = false;
    }

	public void Die()
	{
		Destroy(gameObject);
	}
}
