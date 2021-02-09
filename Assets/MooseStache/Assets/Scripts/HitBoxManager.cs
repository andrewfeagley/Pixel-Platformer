using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{

	public AttackData CurrentAttack;
	// Set these in the editor
	public PolygonCollider2D attack1; //may be unnecessary

	// Used for organization
	private PolygonCollider2D[] colliders;

	// Collider on this game object
	private PolygonCollider2D localCollider;

	// We say box, but we're still using polygons.
	/// <summary>
	/// This is probably no longer necessary
	/// </summary>
	public enum hitBoxes
	{
		// Add more of these here and on line 8 and 37 to add more possible hitboxes per character
		SwordHitBox,
		PunchHitBox,
		clear // special case to remove all boxes
	}

	[SerializeField]
	private Hittable owner;

	List<Health> healthsDamaged = new List<Health>();
	List<Knockable> knockablesDamaged = new List<Knockable>();

	void Start()
	{		
		attack1 = CurrentAttack.collider;
		if (owner == null) {
			owner = GetComponentInParent<Hittable> ();
			if (owner == null) {
				Debug.Log ("There is no owner hittable component asigned to this HitBoxManager");
			}
		}
		// Set up an array so our script can more easily set up the hit boxes
		colliders = new PolygonCollider2D[]{attack1};

		// Create a polygon collider
		localCollider = gameObject.AddComponent<PolygonCollider2D>();
		localCollider.isTrigger = true; // Set as a trigger so it doesn't collide with our environment
		localCollider.pathCount = 0; // Clear auto-generated polygons
	}

	void OnTriggerEnter2D (Collider2D col) {
		DoDamage(col);
		DoKnockBack(col);
	}
	
	public void setHitBox(AttackData _data)
	{
		healthsDamaged.Clear (); // Clear the list of damaged healths everytime we start a new attack
		knockablesDamaged.Clear();
		CurrentAttack = _data;
        // Set the polygon collider to be equal as the target one
        //if (val != hitBoxes.clear)
        //{
        //    localCollider.SetPath(0, colliders[(int)val].GetPath(0));
        //    return;
        //}
        if (_data != null)
        {
			localCollider.SetPath(0, _data.collider.points);
			return;
        }

		// If the value is Clear, set the pathcount of the polygoncollider2D to 0 (No Collisions)
		localCollider.pathCount = 0;
	}

	private void DoDamage(Collider2D col)
	{
		var component = col.GetComponent<Health>();
		// If the target the hitbox collided with has a health component and it is not our owner and it is not on the already on the list of healths damaged by the current hitbox
		if (component != null && component != owner.Health && !healthsDamaged.Contains(component))
		{
			// Try to Apply the damage
			var PlayerComponent = GetComponentInParent<Player>();
			//this should get attack damage from the attackdata for the corresponding attack
			//Use a string to match the attackdata to the hitbox enum value name?
			var damageToDo = PlayerComponent != null ? PlayerComponent.MeleeAttackDamage : 1;
			var didDamage = component.TakeDamage(damageToDo);

			if (didDamage)
			{
				// Add the health component to the list of damaged healths
				healthsDamaged.Add(component);
			}
		}
	}

	private void DoKnockBack(Collider2D col)
    {
		Debug.Log("Enemy should be knocked");
		var component = col.GetComponent<Knockable>();

		if (component != null && component != owner.Knockable && !knockablesDamaged.Contains(component))
		{
			var ActorComponent = GetComponentInParent<Actor>();
			float distance = Vector2.Distance(component.transform.position, owner.transform.position);
			//this should get knockback vector from the attackdata for the corresponding attack
			//Use a string to match the attackdata to the hitbox enum value name?
			var knock = component.TakeKnockBack(new Vector2(CurrentAttack.KnockBackVector.x * (int)ActorComponent.Facing, CurrentAttack.KnockBackVector.y) * distance, CurrentAttack.KnockBackAmount, CurrentAttack.HitStunAmount);

			if (knock)
            {
				knockablesDamaged.Add(component);
            }
		}
    }
}
