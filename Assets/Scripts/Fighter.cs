using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MonsterLove.StateMachine;

/// <summary>
/// The base class for all fighters to use
/// </summary>
public class Fighter : Actor, IKillable
{
    [Header("Data")]
    [Tooltip("The data for movement and health")]
    public ActorData actorData;
    [Header("Input")]
    public Player_One_Controls controls;

    [Header("Squash & Stretch")]
    public Transform SpriteHolder; // Reference to the transform of the child object which holds the sprite renderer of the player
    public Vector2 SpriteScale = Vector2.one; // The current X and Y scale of the sprite holder (used for Squash & Stretch)

    [Header("Animator")]
    public Animator animator; // Reference to the animator

    [Header("Particles")]
    public GameObject DustParticle;
    public GameObject DashDustParticle;

    public StateMachine<States> fsm;
    public HitBoxManager hitboxManager;


    #region Helper private Variables
    private int moveX; // Variable to store the horizontal Input each frame
    private int moveY; // Variable to store the vectical Input each frame
    private int oldMoveY; // Variable to store the vertical Input for the last frame
    private float varJumpSpeed; // Vertical Speed to apply on each frame of the variable jump
    private float varJumpTimer = 0f; // Variable to store the time left on the variable jump
    private int forceMoveX; // Used to store the forced horizontal movement input
    private float forceMoveXTimer = 0f; // Used to store the time left on the force horizontal movement
    private float maxFall; // Variable to store the current maximun fall speed
    private float wallSlideTimer = 0f; // Used to store the time left on the wallslide
    private Vector2 DashDir; // Here we store the direction in which we are dashing
    private float dashCooldownTimer = 0f; // Timer to store how much cooldown has the dash
    private bool canStick = false; // Helper variable for the wall sticking functionality
    private bool sticking = false; // Variable to store if the player is currently sticking to a wall
    private float stickTimer = 0f; // Timer to store the time left sticking to a wall 
    private float jumpGraceTimer = 0f; // Timer to store the time left to perform a jump after leaving a platform/solid
    private float jumpBufferTimer = 0f; // Timer to store the time left in the JumpBuffer timer
    private bool jumpIsInsideBuffer = false;
    private float meleeAttackCooldownTimer = 0f; // Timer to store the cooldown left to use the melee attack
    private float bowAttackCooldownTimer = 0f; // Timer to store cooldown left on the bow attak
    private float moveToRespawnPositionAfter = .5f; // Time to wait before moving to the respawn position
    private float moveToRespawnPosTimer = 0f; // Timer to store how much time is left before moving to the respawn position
    private float ledgeClimbTime = 1f; // Total time it takes to climb a wall
    private float ledgeClimbTimer = 0f; // Timer to store the current time passed in the ledgeClimb state
    private Vector2 extraPosOnClimb = new Vector2(10, 16); // Extra position to add to the current position to the end position of the climb animation matches the start position in idle state
    #endregion


    public enum States
    {
        Normal,
        Walk,
        Jump,
        Attack,
        HitStun,
        LedgeGrab,
        LedgeClimb,
        Respawn
    }

    public bool CanAttack
	{
		get
		{
			return controls.Fight.Attack0.triggered && meleeAttackCooldownTimer <= 0f;
		}
	}

    public bool CanJump
    {
        get
        {
            return controls.Fight.JumpPressDown.triggered;
        }
    }


    public void Die()
    {
        // Set the speed to 0
        Speed = Vector2.zero;
        // Trigget the respawn state
        //fsm.ChangeState(States.Respawn, StateTransition.Overwrite);
        // Trigger the Dead Events on the gamemanager
        if (GameManager.instance != null)
        {
            GameManager.instance.PlayerDead();
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    new void Awake()
    {
        base.Awake();
        hitboxManager = GetComponentInChildren<HitBoxManager>();
        fsm = StateMachine<States>.Initialize(this);
        if (controls == null)
            controls = new Player_One_Controls();
    }

    // Start is called before the first frame update
    void Start()
    {
        fsm.ChangeState(States.Normal);
        animator.Play("Idle");
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        if (fsm.State == States.Respawn)
            return;

        // Update all collisions here
        wasOnGround = onGround;
        onGround = OnGround();

        if (forceMoveXTimer > 0f)
        {
            forceMoveXTimer -= Time.deltaTime;
            moveX = forceMoveX;
        }
        else
        {
            moveX = (int)controls.Fight.Move.ReadValue<Vector2>().x;//(int)Input.GetAxisRaw("Horizontal");
        }

        // Update the moveY Variable and assign the current vertical input for this frame 
        oldMoveY = moveY;
        moveY = (int)controls.Fight.Move.ReadValue<Vector2>().y;//(int)Input.GetAxisRaw("Vertical");
    }

    void LateUpdate()
    {
        var moveh = base.MoveH(Speed.x * Time.deltaTime);
        if (moveh)
        {
            Speed.x = 0;
        }

        // Vertical
        var movev = base.MoveV(Speed.y * Time.deltaTime);
        if (movev)
        {
            Speed.y = 0;
        }

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        string currentAttackName = hitboxManager != null ? hitboxManager.CurrentAttack.AnimationClip.name : "Jab 0";
        //Put all logic for each state here
        switch (fsm.State)
        {
            //Needs to be able to get the name of the current attack
            //and set the animator to play the animation of the desired attack
            case States.Attack:
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName(currentAttackName))
                    animator.Play(currentAttackName);
                break;
            case States.Normal:
                if (onGround)
                {
                    if (moveX == 0)
                    {
                        // Idle Animation
                        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                        {
                            animator.Play("Idle");
                        }
                    } else
                    {
                        // Run Animation
                        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                        {
                            animator.Play("Walk");
                        }
                    }
                }
                break;
        }
        if (Speed.y > 0)
        {
            // Jump Animation
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                animator.Play("Jump");
            }
        }

        // Set the x scale to the current facing direction
        var targetLocalScale = new Vector3((int)Facing, transform.localScale.y, transform.localScale.z);
        if (transform.localScale != targetLocalScale)
        {
            transform.localScale = new Vector3((int)Facing, transform.localScale.y, transform.localScale.z);
        }
    }

    private void Normal_Update()
    {
        Speed.x = Calc.Approach(Speed.x, moveX * actorData.MaxRun, actorData.RunReduce * 1 * Time.deltaTime);

        if (!onGround)
        {
            float target = actorData.MaxFall;
            Speed.y = Calc.Approach(Speed.y, target, actorData.Gravity * Time.deltaTime);
        }

        if (moveX != 0)
        {
            Facings facings = (Facings)moveX;
            Facing = facings;
        }

        if (CanAttack)
            fsm.ChangeState(States.Attack);

        float num = onGround ? 1f : actorData.AirMult;
        if (!sticking)
        {
            if (Mathf.Abs(Speed.x) > actorData.MaxRun && Mathf.Sign(Speed.x) == moveX)
            {
                Speed.x = Calc.Approach(Speed.x, actorData.MaxRun * moveX, actorData.RunReduce * num * Time.deltaTime);
            }
            else
            {
                Speed.x = Calc.Approach(Speed.x, actorData.MaxRun * moveX, actorData.RunAccel * num * Time.deltaTime);
            }
        }
    }

    private void HitStun_Enter()
    {
        animator.Play("HitStun");        
    }
    void HitStun_Update()
    {
        Speed = Vector2.zero;
    }
    private void Normal_Enter()
    {
        animator.Play("Idle");
    }

    private void Attack_Enter()
    {
        Speed.x = 0;
        animator.Play("Jab 0");
        Debug.Log("Player has enterd attack mode");
    }


    private void Attack_Update()
    {
        Speed.x = 0;
    }

    public void TakeKnockBackAndHitStun(Vector2 direction, float amount, float time)
    {
        fsm.ChangeState(States.HitStun);   
        StartCoroutine(HitStun(direction, amount, time));
    }

    IEnumerator HitStun(Vector2 direction, float amount, float time)
    {
        Health h = GetComponent<Health>(); //use this to multiply knockback by if using percentage
        yield return new WaitForSeconds(1);
        Speed += direction * amount;
        fsm.ChangeState(States.Normal, StateTransition.Overwrite);
    }

    IEnumerator WaitBeforeChangingTo(float seconds, States state)
    {
        yield return new WaitForSeconds(seconds);
        fsm.ChangeState(state, StateTransition.Overwrite);
    }


    #region Inputs
    //public void JumpInput(InputAction.CallbackContext context)
    //{
    //    var pushed = context.ReadValueAsButton();
    //    Debug.Log("Jump was just pressed");
    //}

    public void NormalAttackInput(InputAction.CallbackContext context)
    {
        fsm.ChangeState(States.Attack);
    }

    //public void MoveInput(InputAction.CallbackContext context)
    //{
    //    moveX = (int)context.ReadValue<Vector2>().x;
    //    moveY = (int)context.ReadValue<Vector2>().y;
    //}
    #endregion
}
