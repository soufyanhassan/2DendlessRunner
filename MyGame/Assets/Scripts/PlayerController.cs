using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float speedMultipl;

    [SerializeField]
    private float speedIncMilestone;

    private float speedMilestCount;

    private float moveSpeedStore;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float jumpTime;

    private float jumpTimeCounter;
    private float speedMileStoneCount;

    [SerializeField]
    private bool checkGround;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundCheckRad;

    //private Collider2D collider;
    private Rigidbody2D myRigidbody;

    private Animator myAnim;

    [SerializeField]
    private GameManager gameManager;
	
    // Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        //collider = GetComponent<Collider2D>();
        myAnim = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilestCount = speedIncMilestone;
        moveSpeedStore = moveSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //checkGround = Physics2D.IsTouchingLayers(collider, whatIsGround); //kijken of de grond er is
        checkGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRad, whatIsGround);

        if (transform.position.x > speedMilestCount)
        {
            speedMilestCount += speedIncMilestone;
            speedIncMilestone = speedIncMilestone * speedMultipl;
            moveSpeed = moveSpeed * speedMultipl;
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y); //player automatisch laten bewegen

        //als de player op de spatie knop heeft gedrukt
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //player checken als hij de grond heeft geraakt
            if (checkGround)
            {
                //player kan springen als hij de grond heeft geraakt
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            jumpTimeCounter = 0;
        }

        if(checkGround)
        {
            jumpTimeCounter = jumpTime;
        }

        myAnim.SetFloat("Speed", myRigidbody.velocity.x);
        myAnim.SetBool("Grounded", checkGround);
	}

    void OnCollisionEnter2D (Collision2D coll)
    {
        if(coll.gameObject.tag == "killbox")
        {
            gameManager.Restart();
        }
    }
}
