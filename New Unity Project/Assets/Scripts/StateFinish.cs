using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFinish : State {

    public void doAction(StateContext stateContext)
    {
        GameObject UIAbility = GameObject.Instantiate(Resources.Load("FinishUI")) as GameObject;
    }

    public string returnStateType()
    {
        return "Finish";
    }
}
