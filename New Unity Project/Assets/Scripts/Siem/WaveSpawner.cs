using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {


    public GameObject wave;
    public float interval;
    public GameObject theWave;
    bool placed = false;

    float timer;

    private static WaveSpawner _instance;

    private FactoryUser factoryUser;

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
        factoryUser = GetComponent<FactoryUser>();
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
            theWave = SpawnWave();
            placed = true;
        }

        if (StateContext._instance.getState() == "Play")
        {
            if (transform.position.x - theWave.transform.position.x > theWave.GetComponent<SpriteRenderer>().bounds.extents.x * 1.95f && theWave.transform.position.x < transform.position.x)
            {
                if (StateContext._instance.getState() == "Play")

                    theWave = SpawnWave();
            }
        }
	}

    private GameObject SpawnWave()
    {
        int random = Random.Range(0, 2);
        object[] parameters = new object[1];
        parameters[0] = random;
        return factoryUser.UseFactory(parameters);
    }

    public float Timer
    {
        set { timer = value; }
    }
}
