using UnityEngine.Events;
using UnityEngine;
using MonsterLove.StateMachine;
using System;

public class Knockable : MonoBehaviour
{
    public KnockBackEvent OnTakeKnockBackEvent;

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
}
[Serializable]
public class KnockBackEvent : UnityEvent<Vector2, float>
{

}