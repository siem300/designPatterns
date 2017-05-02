using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "1":
                Destroy(collision.gameObject);
                break;
            case "2":
                Destroy(collision.gameObject);
                break;
            case "Player2":
                break;
            case "Player3":
                break;
            case "Player4":
                break;
        }
    }
}
