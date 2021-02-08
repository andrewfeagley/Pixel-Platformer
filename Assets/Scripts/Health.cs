using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	public ActorData actorData;

	public UnityEvent OnTakeDamageEvent;
	public UnityEvent OnTakeHealEvent;
	public UnityEvent OnDeathEvent;

	[Header("Max/Starting Health")]
	public int maxHealth;
	[Header("Current Health")]
	public int currentHealth;

	[Header("IsDeathOrNot")]
	public bool dead = false;

	[Header("Invincible")]
	public bool invincible = false;
	public bool becomeInvincibleOnHit = false;
	public float invincibleTimeOnHit = .5f;
	private float invincibleTimer = 0f;

	[Header("Perform Dead Events after x time")]
	public float DieEventsAfterTime = 1f;

	public enum Type
	{
		HitPoints,
		Percentage
	}


	void Start()
	{
		currentHealth = actorData.maxHealth;
	}

	void Update()
	{
		if (invincibleTimer > 0f)
		{
			invincibleTimer -= Time.deltaTime;

			if (invincibleTimer <= 0f)
			{
				if (invincible)
					invincible = false;
			}
		}
	}

	public bool TakeDamage(int amount)
	{
		if (dead || invincible)
			return false;

		currentHealth = Mathf.Max(0, currentHealth - amount);

		if (OnTakeDamageEvent != null)
			OnTakeDamageEvent.Invoke();

		if (currentHealth <= 0)
		{
			Die();
		}
		else
		{
			if (becomeInvincibleOnHit)
			{
				invincible = true;
				invincibleTimer = invincibleTimeOnHit;
			}

			PixelCameraController.instance.Shake(0.15f);
		}

		return true;
	}

	public bool TakeHeal(int amount)
	{
		if (dead || currentHealth == maxHealth)
			return false;

		currentHealth = Mathf.Min(maxHealth, currentHealth + amount);

		if (OnTakeHealEvent != null)
			OnTakeHealEvent.Invoke();

		PixelCameraController.instance.Shake(0.1f);

		return true;
	}

	public void Die()
	{
		dead = true;
		PixelCameraController.instance.Shake(0.25f);

		StartCoroutine(DeathEventsRoutine(DieEventsAfterTime));
	}

	IEnumerator DeathEventsRoutine(float time)
	{
		yield return new WaitForSeconds(time);
		if (OnDeathEvent != null)
			OnDeathEvent.Invoke();
	}

	public void SetUIHealthBar()
	{
		if (UIHealthBar.instance != null)
		{
			UIHealthBar.instance.setHealthBar(currentHealth);
		}
	}
}
