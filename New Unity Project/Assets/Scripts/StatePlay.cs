﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatePlay : State
{

    public void doAction(StateContext stateContext)
    {
        GameObject UIAbility = GameObject.Instantiate(Resources.Load("AbilityUI")) as GameObject;
    }
    public string returnStateType()
    {
        return "Play";
    }
}
