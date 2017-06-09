using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private Vector2 moveDirection;
    private Animator characterAnimator;
    private float jumpTime;
    private int jumpForce;

    private bool jumping = false;
    private string horizontalInput;
    private string jumpInput;
    private string useSkillInput;
    private ISkill iSkill;

    // Use this for initialization
    void Start()
    {
    }

    public void Initialize(Animator animator, string horizontalInput, string jumpInput, string useSkillInput, float jumpTime, int jumpForce)
    {
        characterAnimator = animator;
        this.horizontalInput = horizontalInput;
        this.jumpInput = jumpInput;
        this.useSkillInput = useSkillInput;
        this.jumpTime = jumpTime;
        this.jumpForce = jumpForce;
    }

    public Vector2 MoveDirection
    {
        get { return moveDirection; }
        set { moveDirection = value; }
    }

    public Animator CharacterAnimator
    {
        get { return characterAnimator; }
    }

    public float JumpTime
    {
        get { return jumpTime;}
    }

    public int JumpForce
    {
        get { return jumpForce; }
    }

    public bool Jumping
    {
        get { return jumping;}
        set { jumping = value; }
    }

    public string HorizontalInput
    {
        get { return (horizontalInput + this.tag) ;}
    }

    public string JumpInput
    {
        get { return (jumpInput + this.tag); }
    }

    public string UseSkillInput
    {
        get { return (useSkillInput + this.tag); }
    }

    public ISkill Skill
    {
        get { return iSkill; }
        set { iSkill = value; }
    }
}
