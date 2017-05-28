using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (StateContext.Instance.getState() != "CharacterSelect")
        {
            Destroy(this.gameObject);
        }
	}
}
