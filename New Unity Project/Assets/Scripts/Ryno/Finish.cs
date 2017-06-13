using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using ObserverPattern;

public class Finish : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public bool player1ReachedFinish;
    public bool player2ReachedFinish;
    public bool player1Dead;
    public bool player2Dead;
    public bool loadMainMenu;


    //Private members
    private AchievementSubject achievementSubject;
    

	// Use this for initialization
	void Start () {

        InitObservers();
	}

    private void InitObservers()
    {
    achievementSubject = GetComponent<AchievementSubject>();
        if (!achievementSubject)
        {
            Debug.LogWarning("No achievementSubject");
            return;
        }
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
            player2Dead = false;
        }
        else
        {
            player2Dead = false;
        }

        if(player1 == null){
            player1Dead = false;
        }
        else
        {
            player1Dead = false;
        }

        if (player1ReachedFinish && player2ReachedFinish)
        {

            if (loadMainMenu)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {

            }
            {
                SceneManager.LoadScene("Level2");
                StateContext._instance.setState(new StateCharacterSelect());
                StateContext._instance.requestAction();
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
                StateContext._instance.setState(new StateCharacterSelect());
                StateContext._instance.requestAction();
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
                StateContext._instance.setState(new StateCharacterSelect());
                StateContext._instance.requestAction();
            }
        } else if(player1Dead && player2Dead)
        {
            achievementSubject.GetSubject().Notify(new AllDeadEvent());
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "1")
        {
            player1ReachedFinish = true;
            if (coll.gameObject.GetComponent<Player>().getSkillName() == "Dash" && !player2ReachedFinish)
            {
                achievementSubject.NotifyObservers(new WinClassicoEvent());
            }
            
        }

        if (coll.gameObject.tag == "2")
        {
            player2ReachedFinish = true;
            if (coll.gameObject.GetComponent<Player>().getSkillName() == "Dash" && !player1ReachedFinish)
            {
                achievementSubject.NotifyObservers(new WinClassicoEvent());
            }
        }
    }
}
