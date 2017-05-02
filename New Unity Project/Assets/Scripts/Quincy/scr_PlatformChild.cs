using UnityEngine;
using System.Collections;

public class scr_PlatformChild : MonoBehaviour
{

    private scr_platform parentScript;

    void Start()
    {
        parentScript = GetComponentInParent<scr_platform>();
    }

    //if the object this collides with has "Wave" as name, send the order to check wave's color to parent object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wave")
        {
            parentScript.needsToCheckWave = true;
            parentScript.CheckColor(other.gameObject);
        }
    }
}
