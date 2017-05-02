using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Finish : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public bool player1ReachedFinish;
    public bool player2ReachedFinish;
    public bool player1Dead;
    public bool player2Dead;
    public bool loadMainMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            loadMainMenu = true;
        }

        player1 = GameObject.FindGameObjectWithTag("1");
        player2 = GameObject.FindGameObjectWithTag("2");
        if (player2 == null)
        {
            player2Dead = true;
        }
        else
        {
            player2Dead = false;
        }

        if(player1 == null){
            player1Dead = true;
        }
        else
        {
            player1Dead = false;
        }

        Debug.Log(SceneManager.GetActiveScene().name);

        if (player1ReachedFinish && player2ReachedFinish)
        {

            if (loadMainMenu)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                SceneManager.LoadScene("Level2");
                GameStateManager.ChangeState(GameStateManager.States.CharacterSelect);
            }
        }
        else if(player1ReachedFinish && player2Dead){
            if (loadMainMenu)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                SceneManager.LoadScene("Level2");
                GameStateManager.ChangeState(GameStateManager.States.CharacterSelect);
            }
        }
        else if(player2ReachedFinish && player1Dead){
            if (loadMainMenu)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                SceneManager.LoadScene("Level2");
                GameStateManager.ChangeState(GameStateManager.States.CharacterSelect);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "1")
        {
            player1ReachedFinish = true;
        }

        if (coll.gameObject.tag == "2")
        {
            player2ReachedFinish = true;
        }
    }
}
