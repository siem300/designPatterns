using UnityEngine;
using System.Collections;

public class scr_platform : MonoBehaviour
{

    /*
     *when wave collides with platform's child, make platform check wave color
     *if wave color == platform color, platform is invis/untouchable (no sprite/hitbox)
     */
    public string isColor;
    public bool needsToCheckWave = false;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D hitbox;
    private bool isEnabled = true;
    public GameObject wave;
    private Wave waveScript;

    void Start()
    {
        //get the renderer & collider for manipulation
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        hitbox = this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {


    }

    public void CheckColor(GameObject wave)
    {
        //if the child object says to check the wave, find the wave, check the wave, then react to its color.
        if (needsToCheckWave)
        {
            this.wave = wave;
            //read the wave's color
            waveScript = this.wave.GetComponent<Wave>();


            //if the platform color is same as wave color and the platform IS enabled, run disable() and reset the need to check the wave
            if (isColor == waveScript.color && isEnabled)
            {
                Disable();
                needsToCheckWave = false;
            }

            //if the platform color is NOT same as wave color and the platform IS NOT enabled, run enable() and reset the need to check the wave      
            if (isColor != waveScript.color && !isEnabled)
            {
                Enable();
                needsToCheckWave = false;
            }

            if (isColor != waveScript.color && isEnabled)
            {
                needsToCheckWave = false;
            }

            if (isColor == waveScript.color && !isEnabled)
            {
                needsToCheckWave = false;
            }
        }
    }

    //disable the sprite as well as the hitbox. then reset the need to check the wave's color.
    private void Disable()
    {
        this.spriteRenderer.enabled = false;
        this.hitbox.enabled = false;
        this.isEnabled = false;
        needsToCheckWave = false;
    }

    //enable the sprite as well as the hitbox. then reset the need to check the wave's color.
    private void Enable()
    {
        this.spriteRenderer.enabled = true;
        this.hitbox.enabled = true;
        this.isEnabled = true;
        needsToCheckWave = false;
    }
}
