using UnityEngine.Events;
using UnityEngine;
using MonsterLove.StateMachine;
using System;

public class Knockable : MonoBehaviour
{
    public KnockBackEvent OnTakeKnockBackEvent;
    public TimedKnockBackEvent OnTakeKnockBackTimedEvent;

    private Actor owner;
    //Should percentage be on Knockable or on another script?
    //Probably another script like health or an inherited Percentage script
    public int Percentage;


    // Start is called before the first frame update
    void Start()
    {
        owner = GetComponent<Actor>();
    }

    /// <summary>
    /// Sends the direction and amount data to the parent actor script to send the actor flying
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool TakeKnockBack(Vector2 direction, float amount)
    {        
        Debug.Log("I was knocked for: " + amount.ToString());
        direction.Normalize();
        OnTakeKnockBackEvent.Invoke(direction, amount);
        return true;
    }
    public bool TakeKnockBack(Vector2 direction, float amount, float time)
    {
        Debug.Log("I was knocked for: " + amount.ToString());
        direction.Normalize();
        OnTakeKnockBackTimedEvent.Invoke(direction, amount, 1);
        return true;
    }
}
[Serializable]
public class KnockBackEvent : UnityEvent<Vector2, float>
{

}
[Serializable]
public class TimedKnockBackEvent : UnityEvent<Vector2, float, float>
{

}