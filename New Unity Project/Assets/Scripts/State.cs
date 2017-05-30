using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface State
{
    void doAction(StateContext stateContext);
    string returnStateType();
}
