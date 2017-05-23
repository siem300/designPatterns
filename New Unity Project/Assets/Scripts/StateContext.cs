using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateContext : MonoBehaviour
{

    private State state;

	// Use this for initialization
	void Start ()
	{
	    setState(new StateCharacterSelect());
	}

    public void setState(State state)
    {
        this.state = state;
        this.state.doAction(this);
    }

    public State getState()
    {
        return state;
    }

    public void request()
    {
        state.doAction(this);
    }
}
