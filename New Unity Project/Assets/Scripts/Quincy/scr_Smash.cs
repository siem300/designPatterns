using UnityEngine;
using System.Collections;

public class scr_Smash : MonoBehaviour, ISkill
{
    //see if the wave exists so there is no null ref exception, then use the trigger coroutine to reset the 
    //wave and move it, then trigger the cooldown.
    float smashAmount;
    bool usingSmash;


    public void Start()
    {
        smashAmount = 101;
    }


    public void executeSkill()
    {
        if (smashAmount >= 100)
        {
            StartCoroutine(Smash());
        }
    }

    public void UpdateCoolDown()
    {
        if(smashAmount < 100)
        {
            smashAmount += Time.deltaTime * 25;
        }
        else
        {
            smashAmount = 101;
        }
    }

    public float CoolDown
    {
        get { return smashAmount; }
    }

    public bool usingSkill
    {
        get { return usingSmash; }
        set { usingSmash = value; }
    }
    
    //set the wave's state to finished and then set to moving once next frame starts
    private IEnumerator Smash()
    {
        if(this.gameObject.tag == "1")
        {
            GameObject player2 = GameObject.FindGameObjectWithTag("2");
            if (player2 != null)
            {
                Vector2 directionToTarget = player2.transform.position - this.transform.position;
                float angle = Vector2.Angle(this.gameObject.transform.position, directionToTarget);
                float distance = directionToTarget.magnitude;
                if (Mathf.Abs(angle) <= 90 && distance < 2)
                {
                    if (this.gameObject.GetComponent<SpriteRenderer>().flipX)
                        player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, -2) * 300);
                    if (!this.gameObject.GetComponent<SpriteRenderer>().flipX)
                        player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, -2) * 300);
                    smashAmount = 0;
                }
            }
        }

        if(this.gameObject.tag == "2")
        {
            GameObject player1 = GameObject.FindGameObjectWithTag("1");
            if (player1 != null)
            {
                Vector2 directionToTarget = player1.transform.position - this.transform.position;
                float angle = Vector2.Angle(this.gameObject.transform.forward, directionToTarget);
                float distance = directionToTarget.magnitude;
                if (Mathf.Abs(angle) <= 90 && distance < 2)
                {
                    if (this.gameObject.GetComponent<SpriteRenderer>().flipX)
                        player1.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, -2) * 300);
                    if (!this.gameObject.GetComponent<SpriteRenderer>().flipX)
                        player1.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, -2) * 300);
                    smashAmount = 0;
                }
            }
        }
       
        yield return new WaitForEndOfFrame();
    }
}
