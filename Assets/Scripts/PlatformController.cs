using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float movementSpeed;
    public bool horizontalMovement;
    public bool verticalMovement;

    private bool moveLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlatForm();
    }
    private void movePlatForm()
    {
        if(horizontalMovement)
        {
            
            if(moveLeft)
            {
                //this needs to be multiplied by.deltatime so that we are moving
                //the object based off time and not framerate. We do not do this when
                //when moving the player because velocity is already a time metric;

                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            }
            else
            {
                //this needs to be multiplied by.deltatime so that we are moving
                //the object based off time and not framerate. We do not do this when
                //when moving the player because velocity is already a time metric;

                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallMoveLeftBound"))
        {
            moveLeft = false;
        }
        else if (collision.gameObject.CompareTag("WallMoveRightBound"))
        {
            moveLeft = true;
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
