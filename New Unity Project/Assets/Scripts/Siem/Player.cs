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
    private Vector2 moveDirection;
    private Animator characterAnimator;
    public float jumpTime;
    bool jumping = false;
    public string horizontalInput;
    public string jumpInput;
    public string UseSkillInput;
    public AudioSource audioSource;
    public AudioClip jumpClip, skillClip, deathClip;
    ISkill skill;
    // Use this for initialization
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        horizontalInput = "Horizontal" + this.tag;
        jumpInput = "Jump" + this.tag;
        UseSkillInput = "UseSkill" + this.tag;
    }
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis(horizontalInput);
        moveDirection = new Vector2(inputX * movementSpeed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        skill.UpdateCoolDown();
        if (isTouchingGround && Input.GetButton(horizontalInput))
        {
            if (Input.GetAxis(horizontalInput) > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                characterAnimator.Play("walk");
            }
            else if (Input.GetAxis(horizontalInput) < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                characterAnimator.Play("walk");
            }
            else
            {
                characterAnimator.Play("idle");
            }
        }
        else if (!isTouchingGround)
        {
            if (Input.GetAxis(horizontalInput) > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                characterAnimator.Play("jump");
            }
            else if (Input.GetAxis(horizontalInput) < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                characterAnimator.Play("jump");
            }
            else
            {
                characterAnimator.Play("jump");
            }
        }
        else
        {
            characterAnimator.Play("idle");
        }
        JumpLogic();
        if (Input.GetButton(UseSkillInput))
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
        if (isTouchingGround && Input.GetButtonDown(jumpInput))
        {
            StartCoroutine(JumpRoutine());
            audioSource.PlayOneShot(jumpClip);
        }
    }
    public virtual void FixedUpdate()
    {
        JumpLogic();
        isTouchingGround = Physics2D.OverlapArea(playerGroundCheck.transform.position, playerGroundCheck2.transform.position, groundLayer);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = moveDirection;
    }
    public IEnumerator JumpRoutine()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        float timer = 0;
        while (Input.GetButton(jumpInput) && timer < jumpTime)
        {
            //Calculate how far through the jump we are as a percentage
            //apply the full jump force on the first frame, then apply less force
            //each consecutive frame
            float proportionCompleted = timer / jumpTime;
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
