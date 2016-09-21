using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

    
    void OnFixedUpdate()
    {
        transform.position = new Vector3(50, 0, 0) * Time.deltaTime;
    }
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Dead");
        }
    }
}
