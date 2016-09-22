using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D player;
    public float speed;
    private bool grounded = true, climbing = false;
    public int jumpHeight;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        move(moveHorizontal, 0);
        if (grounded && moveVertical > 0 && !climbing)
        {
            jump();
        }

        if (player.velocity.y == 0 && !grounded)
        {
            setGrounded(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            player.velocity = new Vector2(0, 0);
            setClimbingBools(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (climbing)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
                player.transform.Translate(new Vector2(0, 1) * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                player.transform.Translate(new Vector2(0, -1) * Time.deltaTime * speed);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            setClimbingBools(false);
        }
    }


    void move(float moveHorizontal, float moveVertical)
    {
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        player.AddForce(movement * speed);
    }

    void jump()
    {
        player.AddForce(Vector3.up * jumpHeight);
        setGrounded(false);
    }

    void setGrounded(bool val)
    {
        grounded = val;
    }

    void setClimbingBools(bool val)
    {
        climbing = val;
        player.gravityScale = (val) ? 0 : 1;
    }
}