using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    public enum States { CharacterSelect, Play, GameOver, MainMenu };
    public static States states = States.CharacterSelect;

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void ChangeState(States statesTo)
    {
        if (states == statesTo)
        {
            return;
        }
        states = statesTo;
    }

    public static bool IsState(States statesTo)
    {
        if (states == statesTo)
        {
            return true;
        }
        return false;
    }

    public static bool IsCharacterSelect
    {
        get
        {
            return IsState(States.CharacterSelect);
        }
    }

    public static bool IsPlay
    {
        get
        {
            return IsState(States.Play);
        }
    }

    public static bool IsGameOver
    {
        get
        {
            return IsState(States.GameOver);
        }
    }

    public static bool IsMainMenu
    {
        get
        {
            return IsState(States.MainMenu);
        }
    }
}
