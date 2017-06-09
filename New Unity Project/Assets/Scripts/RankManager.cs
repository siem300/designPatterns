using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RankManager : MonoBehaviour
{


    GameObject P1, P2;
    Transform newPosP1, newPosP2;
    string[] ranking;
    private static RankManager _instance = null;

    public static RankManager Instance()
    {
        if (_instance == null)
        {
            GameObject rankManager = new GameObject("RankManager") as GameObject;
            _instance = rankManager.AddComponent<RankManager>();
        }

        return _instance;
    }



    void Start()
    {

        P1 = GameObject.FindGameObjectWithTag("1");
        P2 = GameObject.FindGameObjectWithTag("2");
        ranking = new string[2];
        ranking[0] = "";
        ranking[1] = "";

    }


    void Update()
    {
        if (P1 != null)
        {
            newPosP1 = P1.GetComponent<Transform>();
        }
        if (P2 != null)
        {
            newPosP2 = P2.GetComponent<Transform>();
        }

        // Player 1 leads
        if (newPosP1.position.x > newPosP2.position.x)
        {
            ranking[0] = "player 1";
            ranking[1] = "player 2";
        }

        // Player 2 leads
        if (newPosP2.position.x > newPosP1.position.x)
        {
            ranking[0] = "player 2";
            ranking[1] = "player 1";
        }
    }

    public string getNumber1()
    {
        return ranking[0];
    }


    public string getNumber2()
    {
        return ranking[1];
    }


}
