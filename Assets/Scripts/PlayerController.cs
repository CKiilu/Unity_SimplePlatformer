using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public float speed;
    public Text vectorText;
    private bool grounded;
    public int jumpHeight;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        grounded = true;
    }

    void FixedUpdate()
    {
        move(Input.GetAxis("Horizontal"));
        if (grounded && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            jump();
        }

    }
    void move(float moveHorizontal)
    {
        Vector2 movement = new Vector2(moveHorizontal, 0f);
        vectorText.text = "" + (movement * speed);
        rb2D.AddForce(movement * speed);
    }

    void jump()
    {
        rb2D.AddForce(Vector3.up * jumpHeight);
        grounded = false;
    }
}