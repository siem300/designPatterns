using UnityEngine;
using System.Collections;

public enum WaveState { Moving, Finished, Paused };

public class Wave : MonoBehaviour
{

    public float waveSpeed, interval;
    private float time;
    public WaveState waveState;
    public SpriteRenderer waveSR;
    public Sprite redWave, blueWave;
    public bool blue, red;
    private BoxCollider2D waveCollider;
    public string color;

    public float baseSpeed;

    // Use this for initialization
    void Start()
    {
        waveCollider = GetComponent<BoxCollider2D>();
        waveSR = GetComponent<SpriteRenderer>();
        time = interval;
        SetColorWave();

        //at the start, basespeed gets set to movespeed at the start of runtime so there's a set speed to return to
        baseSpeed = waveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player1":
                Debug.Log("Player1 triggered");
                break;
            case "Player2":
                break;
            case "Player3":
                break;
            case "Player4":
                break;
            case "Blue":
                break;
            case "Red":
                break;
            case "DestroyWave":
                Destroy(this.gameObject);
                break;
        }

    }
    
    private void Move()
    {
        transform.Translate(new Vector3(waveSpeed, 0, 0) * Time.deltaTime);
    }

    private void SetColorWave()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            //waveSR.color = new Color(1, 0, 0, 1f);
            waveSR.sprite = redWave;
            red = true;
            blue = false;
            color = "red";
        }
        else
        {
            //waveSR.color = new Color(0, 0.5f, 1, 1f);
            waveSR.sprite = blueWave;
            red = false;
            blue = true;
            color = "blue";
        }
    }
}
