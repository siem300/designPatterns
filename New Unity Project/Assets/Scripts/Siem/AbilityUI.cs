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

    Text ranking;


    // Use this for initialization
    void Start()
    {
        ranking = gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        ranking.text = RankManager.Instance().getNumber1() + "\n" + RankManager.Instance().getNumber2();

        if (StateContext._instance.getState() != "Play")
        {
            Destroy(this);
        }
        if (StateContext._instance.getState() == "Play")
        {
            player1 = GameObject.FindGameObjectWithTag("1");

            player2 = GameObject.FindGameObjectWithTag("2");

        }



        if (StateContext._instance.getState() == "Play")
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }

        if (StateContext._instance.getState() == "Play")
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
            }
        }


        if (StateContext._instance.getState() == "Play")
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
            }
        }
    }
}
