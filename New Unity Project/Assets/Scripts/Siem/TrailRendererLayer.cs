using UnityEngine;
using System.Collections;

public class TrailRendererLayer : MonoBehaviour {

    public TrailRenderer trail;

	// Use this for initialization
	void Start () {
        trail.sortingLayerName = "Default";
        trail.sortingOrder = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
