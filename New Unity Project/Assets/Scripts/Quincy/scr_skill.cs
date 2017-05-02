using UnityEngine;
using System.Collections;

public class scr_skill : MonoBehaviour
{

    public float cooldown;
    public float curCooldown;
    public float curDuration;
    public float skillDuration;
    public bool isReady;

    public string horizontalInput;
    public string jumpInput;
    public string UseSkillInput;

    public virtual void Start()
    {
        horizontalInput = "Horizontal" + this.tag;
        jumpInput = "Jump" + this.tag;
        UseSkillInput = "UseSkill" + this.tag;
    }

    public virtual void Update()
    {
        //pressing the corresponding player's use skill key triggers the skill effect
        if (Input.GetButton(UseSkillInput) && isReady)
        {
            curCooldown = cooldown;
            Effect();
        }

        //skill duration countdown
        if (curDuration > 0)
        {
            curDuration -= Time.deltaTime;
        }

        //after using a skill, it enters cooldown
        if (curCooldown > 0)
        {
            curCooldown -= Time.deltaTime;
            isReady = false;
        }

        //signal that the skill is ready when the cooldown timer reaches 0
        if (curCooldown <= 0)
        {
            isReady = true;
        }

    }

    //the skill's effect
    public virtual void Effect()
    {

    }

    public float CurCoolDown
    {
        get { return curCooldown; }
    }
}
