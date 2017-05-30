using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour {

 
    GameObject P1, P2;
    Transform newPosP1, newPosP2;
    Text textComponent; 


    void Start () {

        P1 = GameObject.FindGameObjectWithTag("1");
        P2 = GameObject.FindGameObjectWithTag("2");
        textComponent = gameObject.GetComponent<Text>();


    }
	

	void Update () {
        newPosP1 = P1.GetComponent<Transform>();
        newPosP2 = P2.GetComponent<Transform>();

        // Player 1 leads
        if (newPosP1.position.x > newPosP2.position.x)
        {
            textComponent.text = "1: Player 1 \n2: Player 2";
        }

        // Player 2 leads
        if (newPosP2.position.x > newPosP1.position.x)
        {
            textComponent.text = "1: Player 2 \n2: Player 1";
        }
    }
}
