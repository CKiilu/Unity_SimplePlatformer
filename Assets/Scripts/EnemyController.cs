using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

    public int stepsLeft, stepsRight;

    public string direction;
    private int stepsTaken;
    private Vector3 moveLeft, moveRight;

    void Start()
    {
        moveLeft= new Vector3(-1, 0, 0);
        moveRight = new Vector3(1, 0, 0);
    }

    
    void Update()
    {
        ++stepsTaken;
        if (direction.Equals("left"))
        {
            transform.Translate(moveLeft * Time.deltaTime);
            if(stepsTaken == stepsLeft)
            {
                updateStepsTaken("right");
            }
        }
        if (direction.Equals("right"))
        {
            transform.Translate(moveRight * Time.deltaTime);
            if (stepsTaken == stepsRight)
            {
                updateStepsTaken("left");
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Dead");
        }
    }

    void updateStepsTaken(string side)
    {
        direction = side;
        stepsTaken = 0;
    }
}
