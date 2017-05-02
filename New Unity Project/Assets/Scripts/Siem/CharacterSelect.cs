using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameStateManager.IsCharacterSelect)
        {
            GetComponent<Canvas>().enabled = true;
        }
        else
        {
            GetComponent<Canvas>().enabled = false;
        }
	}
}
