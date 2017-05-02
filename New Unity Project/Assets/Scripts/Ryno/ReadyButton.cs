using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyButton : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    public Sprite spriteUp, spriteDown;
    public bool ready;
    public ReadyButton ready1, ready2;
    private int count;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ready = false;
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (spriteRenderer.sprite.name == "switch_green_on")
        {
            ready = true;
        }
        else
        {
            ready = false;
        }
        if (ready1.ready && ready2.ready && name == "ReadyButton" && count == 0)
        {
            count++;
            Debug.Log("Start game");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            spriteRenderer.sprite = spriteDown;
            transform.position = new Vector3(transform.position.x, -4.17f, transform.position.z);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        spriteRenderer.sprite = spriteDown;
        transform.position = new Vector3(transform.position.x, -4.17f, transform.position.z);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        spriteRenderer.sprite = spriteUp;
        transform.position = new Vector3(transform.position.x, -4.02f, transform.position.z);
    }
}
