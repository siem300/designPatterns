using UnityEngine;
using System.Collections;

public class scr_Dash : MonoBehaviour, ISkill {

    private Vector2 moveDirection;
    public int dashSpeed;
    public float maxDashAmount;
    float dashAmount;

    bool usingDash = false;

    public void Start()
    {
        dashSpeed = 2;
        maxDashAmount = 100;
        dashAmount = 100;
    }

    public void executeSkill()
    {

        StartCoroutine(Dash());
        
    }

    public void UpdateCoolDown()
    {
        if (dashAmount < maxDashAmount && !usingDash && dashAmount > 100)
        {
            dashAmount = maxDashAmount;
        }
        else if (dashAmount < maxDashAmount && !usingDash)
        {
            dashAmount += Time.deltaTime * 25;
        }
        else if (usingDash && dashAmount > 0)
        {
            dashAmount -= Time.deltaTime * 50;
        }
    }

    public float CoolDown
    {
        get { return dashAmount; }
    }

    public bool usingSkill
    {
        get { return usingDash; }
        set { usingDash = value; }
    }

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


}
