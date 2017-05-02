using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject first, last, player1, player2;
    public GameObject[] players;
    public float smoothing;
    //private SpriteRenderer oneRenderer, twoRenderer;
    private Vector3 averagePosition;

    // Use this for initialization
    void Start()
    {
        //players = GameObject.FindGameObjectsWithTag("Player");
        //player1 = players[0];
        //player2 = players[1];
        //oneRenderer = player1.GetComponent<SpriteRenderer>();
        //twoRenderer = player2.GetComponent<SpriteRenderer>();
        if (smoothing == 0)
        {
            smoothing = 7;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (player1 == null)
        {
            player1 = GameObject.FindGameObjectWithTag("1");
        }
        if (player2 == null)
        {
            player2 = GameObject.FindGameObjectWithTag("2");
        }
        /*if (player1.transform.position.x > player2.transform.position.x)
        {
            first = player1;
            last = player2;
        }
        else
        {
            first = player2;
            last = player1;
        }*/
        if (player1 != null && player2 != null)
        {
            averagePosition = ((player1.transform.position + player2.transform.position) / 2);
            StartCoroutine(CameraMoveToFirst());
        }
        else
        {
            if (player1 == null && GameStateManager.IsPlay)
            {
                averagePosition = player2.transform.position;
                StartCoroutine(CameraMoveToFirst());
            }
            else if (player2 == null && GameStateManager.IsPlay)
            {
                averagePosition = player1.transform.position;
                StartCoroutine(CameraMoveToFirst());
            }
        }

        /*if (!oneRenderer.isVisible && Time.timeSinceLevelLoad > 3 && oneRenderer.gameObject.name == "Player1" || !twoRenderer.isVisible && Time.timeSinceLevelLoad > 3 && oneRenderer.gameObject.name == "Player2")
        {
            Debug.Log(first.name + " Wins!");
        }*/
    }

    public IEnumerator CameraMoveToFirst()
    {
        while (Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(averagePosition.x, averagePosition.y)) >= 1)
        {
            gameObject.transform.position = Vector3.Lerp(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10), new Vector3(averagePosition.x, averagePosition.y, -10), smoothing * Time.deltaTime);
            yield return null;
        }
        StopCoroutine(CameraMoveToFirst());
    }
}
