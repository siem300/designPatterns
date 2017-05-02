using UnityEngine;
using System.Collections;

public class Smash : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!transform.parent.GetComponent<SpriteRenderer>().flipX)
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y = 180;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        if (transform.parent.GetComponent<SpriteRenderer>().flipX)
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y = 0;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "1" || coll.gameObject.tag == "2" || coll.gameObject.tag == "Obstacles")
        {
            if (!transform.parent.GetComponent<SpriteRenderer>().flipX)
            {
                coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(700, -300));
                Debug.Log("smashed character");
            }
            if (transform.parent.GetComponent<SpriteRenderer>().flipX)
            {
                coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-700, -300));
                Debug.Log("smashed character");
            }
        }
    }
}
