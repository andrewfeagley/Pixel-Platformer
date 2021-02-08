using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an empty class that should be attached to anything that can be hit by an attack
/// </summary>
public class Hittable : MonoBehaviour
{
    [HideInInspector]
    public Health Health;
    [HideInInspector]
    public Knockable Knockable;

    private void Start()
    {
        Health = GetComponent<Health>();
        Knockable = GetComponent<Knockable>();
    }

    //Just in case this needs to be enabled on an already existing object that had a component added to it
    private void OnEnable()
    {
        if(!Health)
            Health = GetComponent<Health>();
        if(!Knockable)
            Knockable = GetComponent<Knockable>();
    }
}
