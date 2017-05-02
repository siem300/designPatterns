using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("1") != null)
        {
            player = GameObject.FindGameObjectWithTag("1");
        }
        if (GameObject.FindGameObjectWithTag("2") != null)
        {
            player = GameObject.FindGameObjectWithTag("2");
        }

        if (player != null)
        {
            this.transform.position = new Vector3(player.transform.position.x + 5, player.transform.position.y, -40);
        }
	}
}
