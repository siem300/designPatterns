using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateContext : MonoBehaviour
{
    public static StateContext _instance;


    public static StateContext Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<StateContext>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("StateContainer");
                    _instance = container.AddComponent<StateContext>();
                }
            }

            return _instance;
        }
    }
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
    public string getState()
    {
        return state.returnStateType();
    }

    public void requestAction()
    {
        state.doAction(this);
    }
}
