using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scr_CharacterSelected : MonoBehaviour
{

    public int thisCharacter;

    public scr_PlayerSpawn parentScript;

    public void SelectThisChar(int number)
    {
        parentScript = gameObject.GetComponentInParent<scr_PlayerSpawn>();


        if (parentScript.player1 == 0 && parentScript.player2 == 0)
        {
            parentScript.player1 = number;
            Debug.Log(parentScript.player1);
            parentScript.StoreCharacter(1);
        }
        else if (parentScript.player1 != 0 && parentScript.player2 == 0)
        {
            parentScript.player2 = number;
            Debug.Log(parentScript.player2 + " " + parentScript.player1);
            parentScript.StoreCharacter(2);
            parentScript.SpawnPlayers();
            StateContext._instance.setState(new StatePlay());
            StateContext._instance.requestAction();
        }


    }
}
