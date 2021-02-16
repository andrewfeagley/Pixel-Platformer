using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder
{
    public static CharacterHolder Instance;
    public ActorData PlayerOne, PlayerTwo, PlayerThree, PlayerFour;

    public enum Fighters
    {
        One,
        Two,
        Three,
        Four
    }
}
