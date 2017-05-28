using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {


    public GameObject wave;
    public float interval;
    public GameObject theWave;
    bool placed = false;

    float timer;

    private static WaveSpawner _instance;

    public static WaveSpawner Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //theWave = (GameObject)Instantiate(wave, transform.position, Quaternion.identity);
            timer = interval;
        }
        timer = interval;
        if (StateContext._instance.getState() == "Play" && !placed)
        {
            theWave = (GameObject)Instantiate(wave, new Vector3(transform.position.x, -2.96374f, transform.position.z) + new Vector3(0, 0, 1), Quaternion.identity);
            placed = true;
        }

        if (StateContext._instance.getState() == "Play")
        {
            if (transform.position.x - theWave.transform.position.x > theWave.GetComponent<SpriteRenderer>().bounds.extents.x * 1.95f && theWave.transform.position.x < transform.position.x)
            {
                if (StateContext._instance.getState() == "Play")
                    theWave = (GameObject)Instantiate(wave, new Vector3(transform.position.x, -2.96374f, transform.position.z) + new Vector3(0, 0, 1), Quaternion.identity);
            }
        }
	}

    public float Timer
    {
        set { timer = value; }
    }
}
