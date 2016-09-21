using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D player;
    public float speed;
    public Text vectorText;
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
        vectorText.text = climbing.ToString();

        if (player.velocity.y == 0 && !grounded)
        {
            setGrounded(true);
        }

        if (climbing)
        {
            player.transform.Translate(new Vector3(0, (moveVertical > 0)? 1 : -1, 0) * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            setClimbingBools(true);
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
        player.gravityScale = (val) ? 1 : 0;
    }
}