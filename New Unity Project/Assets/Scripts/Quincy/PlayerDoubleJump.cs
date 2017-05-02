using UnityEngine;
using System.Collections;

public class PlayerDoubleJump : Player
{
    private int canStillJump;
    public bool spacePressed;

    //if the player is standing on the floor and pressing button, jump and set number of jumps to 2
    //if the player is not standing on the floor and pressing button, jump and subtract 1 from jumps
    public override void JumpLogic()
    {
        if (Input.GetButtonDown(jumpInput))
        {
            if (isTouchingGround)
            {
                StartCoroutine(JumpRoutine());
                canStillJump = 2;
                audioSource.PlayOneShot(jumpClip);
            }

            else if (canStillJump > 1 && !isTouchingGround)
            {
                StartCoroutine(JumpRoutine());
                canStillJump -= 1;
                audioSource.PlayOneShot(skillClip);
            }
        }

    }

    public int CanStillJump
    {
        get { return canStillJump; }
    }
}
