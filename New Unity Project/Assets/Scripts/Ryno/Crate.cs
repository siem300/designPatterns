using UnityEngine;
using System.Collections;

public class Crate : MonoBehaviour {
    
    public float lifeTime;
    private float rndmRotation;

    // Use this for initialization
    void Start () {
        rndmRotation = Random.Range(-2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, rndmRotation);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Player1":
                Debug.Log("GameOver");
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
