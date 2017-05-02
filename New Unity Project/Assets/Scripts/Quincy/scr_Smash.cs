using UnityEngine;
using System.Collections;

public class scr_Smash : scr_skill
{
    public GameObject hitboxSmash;
    float timer;
    float startTimer;
    
    //see if the wave exists so there is no null ref exception, then use the trigger coroutine to reset the 
    //wave and move it, then trigger the cooldown.
    public override void Effect()
    {
        timer = startTimer;
        hitboxSmash.SetActive(true);
        Debug.Log("smash");
        Invoke("SmashPrepare", 0.1f);

    }

    void SmashPrepare()
    {
        StartCoroutine(Smash());
        GetComponent<Player>().audioSource.PlayOneShot(GetComponent<Player>().skillClip);
    }

    //set the wave's state to finished and then set to moving once next frame starts
    private IEnumerator Smash()
    {
        hitboxSmash.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
}
