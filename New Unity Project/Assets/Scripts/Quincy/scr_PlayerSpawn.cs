using UnityEngine;
using System.Collections;

public class scr_PlayerSpawn : MonoBehaviour
{

    public int[] spawnlist = new int[3];
    public int player1 = 0;
    public int player2 = 0;

    public int counter = 0;

    public GameObject[] players = new GameObject[3];

    public bool readyToSpawn = false;

    public void SpawnPlayers()
    {
        for (int i = 0; i < spawnlist.Length; i++)
        {
            if (spawnlist[i] == 1)
            {
                GameObject player = Instantiate(players[0], new Vector3(0,0,0), Quaternion.identity) as GameObject;
                if (i == 0)
                {
                    player.tag = "1";
                    player.GetComponent<Player>().setSkill(player.AddComponent<scr_Dash>());
                    
                }
                else if(i == 1)
                {
                    player.tag = "2";
                    player.GetComponent<Player>().setSkill(player.AddComponent<scr_Dash>());
                }
            }
            if (spawnlist[i] == 2)
            {
                GameObject player = Instantiate(players[1], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                if (i == 0)
                {
                    player.tag = "1";                    
                }
                else if(i == 1)
                {
                    player.tag = "2";
                }
            }
            if (spawnlist[i] == 3)
            {
                GameObject player = Instantiate(players[0], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                if (i == 0)
                {
                    player.tag = "1";
                    player.GetComponent<Player>().setSkill(player.AddComponent<scr_Smash>());
                }
                else if(i == 1)
                {
                    player.tag = "2";
                    player.GetComponent<Player>().setSkill(player.AddComponent<scr_Smash>());
                }
            }
        }
    }

    public void StoreCharacter(int trigger)
    {
        int count = trigger;
        if (count == 1)
        {
            spawnlist[0] = player1;
        }
        if (count == 2)
        {
            spawnlist[1] = player2;
            readyToSpawn = true;
        }

    }
}
