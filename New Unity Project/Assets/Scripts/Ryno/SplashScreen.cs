﻿using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

    public float delay;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > startTime + delay)
        {
            Destroy(gameObject);
        }
	}
}
