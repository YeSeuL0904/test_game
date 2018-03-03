using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float jumpForce = 6f;
    public float runningSpeed = 1.5f;
    private Rigidbody2D rigidBody;
    public Animator animator;
    private Vector3 startingPosition;
    public float maxSpeed = 50f;

    // Use this for initialization
    void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        instance = this;
        startingPosition = this.transform.position;
	}

    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        this.transform.position = startingPosition;
    }

    void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
                rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
        }
       
    }

    // Update is called once per frame
    void Update ()
    {

        if (GameManager.instance.currentGameState == GameState.inGame)
        {
           if (Input.GetMouseButtonDown(0))
            Jump();
        }
        animator.SetBool("isGrounded", Isgrounded());

        // Trying to Limit Speed
        if (rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxSpeed);
        }

    }

    void Jump()
    {
        if (Isgrounded())
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    public LayerMask groundLayer;
    internal object coinLabel;

    bool Isgrounded()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 0.5f, groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Kill()
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);

        //check if highscore save if it is
        if (PlayerPrefs.GetFloat("fighscore", 0) < this.GetDistance())
        {
            //save new highscore
            PlayerPrefs.SetFloat("highscore", this.GetDistance());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KillTrigger")
        {
            Debug.Log("Your collider entered the trigger!");
            Kill();
        }
    }

    public float GetDistance()
    {
        float traveledDistance = Vector2.Distance(new Vector2(startingPosition.x, 0),
                                                  new Vector2(this.transform.position.x, 0));
        return traveledDistance;
    }
}
