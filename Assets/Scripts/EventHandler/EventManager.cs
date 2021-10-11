using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager 
{
    public static Events OnMovementStart = new Events();
    public static Events OnDistanceAttack = new Events();
    public static Events OnMeelAttack = new Events();
    public static Events OnPlayerOneDie = new Events();
    public static Events OnPlayerTwoDie = new Events();
}
