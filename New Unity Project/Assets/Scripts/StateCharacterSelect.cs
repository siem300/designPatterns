using System.Collections;
using System.Collections.Generic;
//using Boo.Lang.Environments;
using UnityEngine;

public class StateCharacterSelect : State {
    public void doAction(StateContext stateContext)
    {
        GameObject UICharacterSelect = GameObject.Instantiate(Resources.Load("CharacterSelect")) as GameObject;
    }
    public string returnStateType()
    {
        return "CharacterSelect";
    }
}
