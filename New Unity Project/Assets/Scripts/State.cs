using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    void doAction(StateContext stateContext);
}
