using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputHorizontal;
    private int maxNumJumps;
    private int numJumps;
    //because this is public we have access to it in unity editor
    public float horizontalMoveSpeed;
    public float jumpForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //I can only get this component because the rigigdbody2d is attached to
        //this script is also attached to the other player
        rb = GetComponent<Rigidbody2D>();

        maxNumJumps = 1;
        numJumps = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        //if A/D/<-/-> are pressed move accordingly
        //"Horizontal" is defined in the input section of the project settings
        //the line below will return :
        //0 - no button pressed
        //1 - right arrow or d pressed
        //2 - left arrow or a pressed
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        flipPlayerSprite(inputHorizontal);

        rb.linearVelocity = new Vector2(horizontalMoveSpeed * inputHorizontal, rb.linearVelocity.y);
    }

    private void flipPlayerSprite(float inputHorizontal)
    {
        // this how we will make the player face the direction they are moving
        if(inputHorizontal > 0)
        {
            transform.eulerAngles = new Vector3( 0, 0, 0);
        }
        else if(inputHorizontal < 0)
        {
            transform.eulerAngles = new Vector3( 0, 180, 0);
        }
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && numJumps <= maxNumJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            numJumps++;
        }
    }

    //collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collusion will contain information about the object that the player collided with
        //Debug.Log(collision.gameObject);
        if(collision.gameObject.CompareTag("Ground"))
        {
            numJumps = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
       if(collison.gameObject.CompareTag("PinkCollectable"))
       {
            maxNumJumps = 2;
       }

        
    }


}




