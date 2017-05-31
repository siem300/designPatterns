using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    public int movementSpeed;
    public int jumpForce;
    public bool isTouchingGround;
    public Transform playerGroundCheck;
    public Transform playerGroundCheck2;
    public LayerMask groundLayer;
    public AudioSource audioSource;
    public AudioClip jumpClip, skillClip, deathClip;

    private ISkill skill;
    private PlayerData playerData;


    // Use this for initialization
    void Start()
    {
        playerData = gameObject.AddComponent<PlayerData>();
        playerData.CharacterAnimator = GetComponent<Animator>();
        playerData.HorizontalInput = "Horizontal" + this.tag;
        playerData.JumpInput = "Jump" + this.tag;
        playerData.UseSkillInput = "UseSkill" + this.tag;
        playerData.JumpTime = 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis(playerData.HorizontalInput);
        playerData.MoveDirection = new Vector2(inputX * movementSpeed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        skill.UpdateCoolDown();
        if (isTouchingGround && Input.GetButton(playerData.HorizontalInput))
        {
            if (Input.GetAxis(playerData.HorizontalInput) > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                playerData.CharacterAnimator.Play("walk");
            }
            else if (Input.GetAxis(playerData.HorizontalInput) < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                playerData.CharacterAnimator.Play("walk");
            }
            else
            {
                playerData.CharacterAnimator.Play("idle");
            }
        }
        else if (!isTouchingGround)
        {
            if (Input.GetAxis(playerData.HorizontalInput) > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                playerData.CharacterAnimator.Play("jump");
            }
            else if (Input.GetAxis(playerData.HorizontalInput) < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                playerData.CharacterAnimator.Play("jump");
            }
            else
            {
                playerData.CharacterAnimator.Play("jump");
            }
        }
        else
        {
            playerData.CharacterAnimator.Play("idle");
        }

        if (Input.GetButton(playerData.UseSkillInput))
        {
            skill.executeSkill();
        }
        else
        {
            skill.usingSkill = false;
        }
    }
    public virtual void JumpLogic()
    {
        if (isTouchingGround && Input.GetButtonDown(playerData.JumpInput))
        {
            StartCoroutine(JumpRoutine());
            audioSource.PlayOneShot(jumpClip);
        }
    }
    public virtual void FixedUpdate()
    {
        JumpLogic();
        isTouchingGround = Physics2D.OverlapArea(playerGroundCheck.transform.position, playerGroundCheck2.transform.position, groundLayer);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = playerData.MoveDirection;
    }
    public IEnumerator JumpRoutine()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        float timer = 0;
        while (Input.GetButton(playerData.JumpInput) && timer < playerData.JumpTime)
        {
            //Calculate how far through the jump we are as a percentage
            //apply the full jump force on the first frame, then apply less force
            //each consecutive frame
            float proportionCompleted = timer / playerData.JumpTime;
            Vector2 thisFrameJumpVector = Vector2.Lerp(Vector2.up * jumpForce, Vector2.zero, proportionCompleted);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(thisFrameJumpVector);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "DeathWall")
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(deathClip);
            Destroy(this.gameObject);
        }
    }
    public void setSkill(ISkill iSkill)
    {
        skill = iSkill;
    }
    void OnDestroy()
    {
        //Camera.main.GetComponent<ScreenShake>().StartShaking();
    }
}
