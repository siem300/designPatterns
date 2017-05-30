using UnityEngine;
using System.Collections;

public class SpawnPlayers : MonoBehaviour {

    public Transform spawnPosition;
    bool allowSpawn = true;
    bool playerSpawned;
    
    //assigned in the inspector
    private int playerNumber;

    public GameObject player;
    public scr_PlayerSpawn parentScript;

	// Use this for initialization
	void Start () {
        parentScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<scr_PlayerSpawn>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectsWithTag("1").Length <= 0 && GameObject.FindGameObjectsWithTag("2").Length <= 0 && StateContext._instance.getState() == "Play")
        {
            parentScript.readyToSpawn = true;
            parentScript.SpawnPlayers();
            allowSpawn = false;
        }
	}

    public void SpawnPlayer(int number)
    {
        playerNumber = number;
        if (allowSpawn)
        {
            //GameStateManager.ChangeState(GameStateManager.States.Play);
            /*parentScript.readyToSpawn = true;
            parentScript.SpawnPlayers();
            allowSpawn = false;
            playerSpawned = true;*/
        }
    }
}
