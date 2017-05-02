using UnityEngine;
using System.Collections;

public class scr_Dash : scr_skill {

    private Vector2 moveDirection;
    public int dashSpeed;
    public float maxDashAmount;
    bool usingDash;
    float dashAmount;
    private AudioSource audioSource;
    private AudioClip skillClip;

    public override void Start()
    {
        horizontalInput = "Horizontal" + this.tag;
        jumpInput = "Jump" + this.tag;
        UseSkillInput = "UseSkill" + this.tag;
        dashAmount = maxDashAmount;
        audioSource = GetComponent<AudioSource>();
        skillClip = GetComponent<Player>().skillClip;
    }

	//runs the basic Update() and checks if the skill's duration has run out to reset the wave's speed.
	public override void Update() {
        base.Update();
        if (!usingDash && dashAmount < maxDashAmount)
        {
            dashAmount += Time.deltaTime / 4;
        }
        else{
            dashAmount -= Time.deltaTime;
        }

        if (!Input.GetButton(UseSkillInput))
        {
            usingDash = false;
        }

        if (dashAmount < 0)
        {
            dashAmount = 0;
        }
	}

    //if the wave object exists and the effect needs to run, run the effect.
    public override void Effect()
    {
       StartCoroutine(Dash());
    }

    //sets the wave to half movement speed, sets skill on cooldown and adds the skill's duration to a timer.
    public IEnumerator Dash()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().flipX && dashAmount > 0)
        {
            moveDirection = new Vector2(dashSpeed, 0);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = moveDirection;
            usingDash = true;
            yield return new WaitForEndOfFrame();
        }
        else if (!this.gameObject.GetComponent<SpriteRenderer>().flipX && dashAmount > 0)
        {
            moveDirection = new Vector2(-dashSpeed, 0);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = moveDirection;
            usingDash = true;
            yield return new WaitForEndOfFrame();
        }
    }

    public float DashAmount
    {
        get { return dashAmount; }
    }
}
