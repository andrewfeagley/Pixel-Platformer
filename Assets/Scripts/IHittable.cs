using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
	//public void EnterHitStun(Vector2 direction, float damageAmount);
	void TakeKnockBackAndHitStun(Vector2 direction, float damageAmount, float time);

	IEnumerator HitStun(Vector2 direction, float damageAmount, float time);
}
