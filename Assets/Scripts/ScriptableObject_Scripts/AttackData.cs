using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "AttackData")]
public class AttackData : ScriptableObject
{
    public PolygonCollider2D collider;
    public int DamageAmount;
    public Vector2 KnockBackVector;
    public float KnockBackAmount;
    public float HitStunAmount;

    public AnimationClip AnimationClip;
    public string AttackName;
}
