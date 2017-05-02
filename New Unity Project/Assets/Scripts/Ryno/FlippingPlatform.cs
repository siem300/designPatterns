using UnityEngine;
using System.Collections;

public class FlippingPlatform : MonoBehaviour {

    public float interval, turnSpeed;
    private float time;
    private bool rotate;

	// Use this for initialization
	void Start () {
        time = interval;
        rotate = false;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = interval;
            rotate = true;
        }
        if (rotate && turnSpeed >= 0)
        {
            transform.Rotate(0, 0, turnSpeed);
            if (transform.rotation.eulerAngles.z >= 175)
            {
                turnSpeed *= -1;
                rotate = false;
            }
        }
        else if(rotate && turnSpeed <= 0)
        {
            transform.Rotate(0, 0, turnSpeed);
            if (transform.rotation.eulerAngles.z <= 0)
            {
                turnSpeed *= -1;
                rotate = false;
            }
        }
	}
}
