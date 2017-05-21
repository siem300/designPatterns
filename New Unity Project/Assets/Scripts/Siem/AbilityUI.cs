using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbilityUI : MonoBehaviour
{

    public Transform positionPlayer1;
    public Transform positionPlayer2;

    public Image cooldownBarPlayer1;
    public Image cooldownBarPlayer2;
    public GameObject player1;
    public GameObject player2;

    public int existingPlayers = 0;

    float cooldown;

    public Sprite fist;
    public Sprite jump;
    public Sprite dash;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.IsPlay)
        {
            player1 = GameObject.FindGameObjectWithTag("1");

            player2 = GameObject.FindGameObjectWithTag("2");

        }

        if (!GameStateManager.IsPlay)
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }

        if (GameStateManager.IsPlay)
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }

        if (GameStateManager.IsPlay)
        {
            if (player1 != null)
            {
                if (player1.GetComponent<scr_Dash>() != null)
                {
                    cooldown = player1.GetComponent<scr_Dash>().CoolDown;
                    cooldownBarPlayer1.sprite = dash;
                    cooldownBarPlayer1.fillAmount = cooldown / 100;
                }
                if (player1.GetComponent<scr_Smash>() != null)
                {
                    cooldown = player1.GetComponent<scr_Smash>().CoolDown;
                    cooldownBarPlayer1.fillAmount = cooldown / 100;
                    if (cooldownBarPlayer1.fillAmount <= 0)
                    {
                        cooldownBarPlayer1.sprite = fist;
                        cooldownBarPlayer1.fillAmount = 1;
                    }
                }
                if (player1.GetComponent<PlayerDoubleJump>() != null)
                {
                    if (player1.GetComponent<PlayerDoubleJump>().CanStillJump > 1)
                    {
                        cooldownBarPlayer1.sprite = jump;
                        cooldownBarPlayer1.fillAmount = 1;
                    }
                    else
                    {
                        cooldownBarPlayer1.fillAmount = 0;
                    }
                }
            }
        }


        if (GameStateManager.IsPlay)
        {
            if (player2 != null)
            {
                if (player2.GetComponent<scr_Dash>() != null)
                {
                    cooldown = player2.GetComponent<scr_Dash>().CoolDown;
                    cooldownBarPlayer2.sprite = dash;
                    cooldownBarPlayer2.fillAmount = cooldown / 100;
                }
                if (player2.GetComponent<scr_Smash>() != null)
                {
                    cooldown = player2.GetComponent<scr_Smash>().CoolDown;
                    cooldownBarPlayer2.fillAmount = cooldown / 100;
                    if (cooldownBarPlayer2.fillAmount <= 0)
                    {
                        cooldownBarPlayer2.sprite = fist;
                        cooldownBarPlayer2.fillAmount = 1;
                    }
                }
                if (player2.GetComponent<PlayerDoubleJump>() != null)
                {
                    if (player2.GetComponent<PlayerDoubleJump>().CanStillJump > 1)
                    {
                        cooldownBarPlayer2.sprite = jump;
                        cooldownBarPlayer2.fillAmount = 1;
                    }
                    else
                    {
                        cooldownBarPlayer2.fillAmount = 0;
                    }
                }
            }
        }
    }
}
