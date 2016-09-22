using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayMovie : MonoBehaviour {
    
    public MovieTexture movieTexture;
    public Text vectorText;


    void OnCollisionEnter2D(Collision2D other)
    {
        vectorText.text = "Collsion";

        movieTexture.Play();
    }
}
