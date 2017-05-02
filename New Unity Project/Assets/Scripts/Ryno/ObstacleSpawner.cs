using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject crate, rock;
    public float interval;
    private float time;


	// Use this for initialization
	void Start () {
        time = interval;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = interval;
            int random;
            random = Random.Range(0, 2);
            if (random == 1)
            {
                Instantiate(crate, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(rock, transform.position, Quaternion.identity);
            }
        }
	}
}
