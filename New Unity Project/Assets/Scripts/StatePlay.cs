using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlay : State {

    public void doAction(StateContext stateContext)
    {
        GameObject UIAbility = GameObject.Instantiate(Resources.Load("AbilityUI")) as GameObject;
        //RankManager rankManager = new RankManager();

    }
    public string returnStateType()
    {
        return "Play";
       
    }
}
