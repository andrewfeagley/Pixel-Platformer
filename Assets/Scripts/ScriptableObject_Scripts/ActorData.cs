using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActorData", menuName = "ActorData")]
public class ActorData : ScriptableObject
{
	[Header("Movement Variables")]
	// Gravity, Maximun fall speed & fastfall Speed
	public float Gravity = 900f; // Speed at which you are pushed down when you are on the air
	public float MaxFall = -160f; // Maximun common speed at which you can fall
	public float FastFall = -240f; // Maximun fall speed when you're fast falling
								   // Run Speed & Acceleration
	public float MaxRun = 90f; // Maximun Horizontal Run Speed
	public float RunAccel = 1000f; // Horizontal Acceleration Speed
	public float RunReduce = 400f; // Horizontal Acceleration when you're already when your horizontal speed is higher or equal to the maximun
								   // Air value multiplier
	public float AirMult = 0.65f; // Multiplier for the air horizontal movement (friction) the higher the more air control you'll have
								  // Jump Variables
	public float JumpSpeed = 135f; // Vertical Jump Speed/Force
	public float JumpHBoost = 40f; // Extra Horizontal Speed Boost when jumping
	public float VariableJumpTime = 0.2f; // Time after performing a jump on which you can hold the jump key to jump higher
	public float SpringJumpSpeed = 275f; // Vertical Jump Speed/Force for spring jumps
	public float SpringJumpVariableTime = 0.05f; // ime after performing a spring jump (jumping off a spring) on which you can hold the jump key to jump higher
												 // Wall Jump variables
	public float WallJumpForceTime = 0.16f; // Time on which the horizontal movement is restrcited/forced after a wall jump (if too low the player migh be able to climb up a wall)
	public float WallJumpHSpeed = 130f; // Horizontal Speed Boost when performing a wall jump
	public int WallJumpCheckDist = 2; // Distance at which we check for walls before performing a wall jump (2-4 is recommended)
									  // Wall Slide Variables
	public float WallSlideStartMax = -20f; // Starting vertical speed when you wall slide
	public float WallSlideTime = 1.2f; // Maximun time you can wall slide before gaining the full fall speed again
									   // Dash Variables
	public float DashSpeed = 240f; // Speed/Force which you dash at
	public float EndDashSpeed = 160f; // Extra Speed Boost when the dash ends (2/3 of the dash speed recommended)
	public float EndDashUpMult = 0.75f; // Multiplier applied to the Speed after a dash ends if the direction you dashed at was up
	public float DashTime = 0.15f; // The total time which a dash lasts for
	public float DashCooldown = 0.4f; // The Cooldown time of a dash
									  // Other variables used for responsive movement
	public float clingTime = 0.125f; // Wall Cling/Stick time after touching a wall where you can't leave the wall (to avoid unintentionally leaving the wall when trying to perform a wall jump)
	public float JumpGraceTime = 0.1f; // Jump Grace Time after leaving the ground non-jump on which you can still make a jump
	public float JumpBufferTime = 0.1f; // If the player hits the ground within this time after pressing the the jump button, the jump will be executed as soon as they touch the ground
										// Ladder Variables 
	public float LadderClimbSpeed = 60f;

	public string Name;

    [Range(1,100)]
    public int maxHealth;
    [Tooltip("Pixels per second")]
    public float Speed;


    public List<AttackData> attackDatas;

}
