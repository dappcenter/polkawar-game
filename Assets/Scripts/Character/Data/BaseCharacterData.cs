using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterData : ScriptableObject
{
    public XP xp;
    public HP hp;
    public MP mp;
    public Patk patk;
    public Pdef pdef;
    public Speed speed;
    public Accuracy accuracy;
}
