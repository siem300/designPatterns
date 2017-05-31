using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private Vector2 moveDirection;
    private Animator characterAnimator;
    private float jumpTime;
    private bool jumping = false;
    private string horizontalInput;
    private string jumpInput;
    private string useSkillInput;

	// Use this for initialization
	void Start ()
	{
	    characterAnimator = GetComponent<Animator>();
	}

    public Vector2 MoveDirection
    {
        get { return moveDirection; }
        set { moveDirection = value; }
    }

    public Animator CharacterAnimator
    {
        get { return characterAnimator; }
        set { characterAnimator = value; }
    }

    public float JumpTime
    {
        get { return jumpTime;}
        set { jumpTime = value; }
    }

    public bool Jumping
    {
        get { return jumping;}
        set { jumping = value; }
    }

    public string HorizontalInput
    {
        get { return horizontalInput;}
        set { horizontalInput = value; }
    }

    public string JumpInput
    {
        get { return jumpInput; }
        set { jumpInput = value; }
    }

    public string UseSkillInput
    {
        get { return useSkillInput; }
        set { useSkillInput = value; }
    }
}
