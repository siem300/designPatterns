using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevelName(string name)
    {
        GameStateManager.ChangeState(GameStateManager.States.CharacterSelect);
        SceneManager.LoadScene(name);
    }
}
