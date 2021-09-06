using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public abstract class Stat
{
    [SerializeField] protected float baseValue;

    [SerializeField, ReadOnly]
    private List<int> effectModifiers = new List<int>();

    protected virtual float GetModifiedValue()
    {
        float finalValue = baseValue;
        effectModifiers.ForEach(x => finalValue += x); //Add each modified value x to final value and return that value
        return finalValue;
    }

    public void AddEffectModifier(int modifiedvalue)
    {
        if (modifiedvalue != 0)
        {
            effectModifiers.Add(modifiedvalue);
            Debug.Log("Modified value added " + modifiedvalue);
        }
    }

    public void RemoveEffectModifier(int modifiedvalue)
    {
        if (modifiedvalue != 0)
        {
            effectModifiers.Remove(modifiedvalue);
            Debug.Log("Modified value removed " + modifiedvalue);
        }
    }

    public virtual float GetValueAtLevel(int level)
    {
        return GetModifiedValue();
    }
}

[System.Serializable]
public class XP : Stat
{
    private string name = "XP";
    public string Name => name;

    public override float GetValueAtLevel(int level)
    {
        return (float)level * level / 0.02f;
    }
}

[System.Serializable]
public class HP : Stat
{
    private string name = "HP";
    public string Name => name;

    public override float GetValueAtLevel(int level)
    {
        float value = baseValue;

        for (int i = 1; i <= level; i++)
        {
            value += i * 10f;
        }

        return value;
    }
}

[System.Serializable]
public class MP : Stat
{
    private string name = "MP";
    public string Name => name;

    public override float GetValueAtLevel(int level)
    {
        float value = baseValue;

        for (int i = 1; i <= level; i++)
        {
            value += i * 7f;
        }

        return value;
    }
}

[System.Serializable]
public class Patk : Stat
{
    private string name = "Patk";
    public string Name => name;

    public override float GetValueAtLevel(int level)
    {
        float value = baseValue;

        for (int i = 1; i <= level; i++)
        {
            value = Mathf.FloorToInt(value + i * 1.1f);
        }

        return value;
    }
}

[System.Serializable]
public class Pdef : Stat
{
    private string name = "Pdef";
    public string Name => name;

    public override float GetValueAtLevel(int level)
    {
        float value = baseValue;

        for (int i = 1; i <= level; i++)
        {
            value = Mathf.FloorToInt(value + i * 1.1f);
        }

        return value;
    }
}

[System.Serializable]
public class Speed : Stat
{
    private string name = "Speed";
    public string Name => name;

    public override float GetValueAtLevel(int level)
    {
        float value = baseValue;

        for (int i = 1; i <= level; i++)
        {
            value += i * 0.5f;
        }

        return value;
    }
}

[System.Serializable]
public class Accuracy : Stat
{
    private string name = "Accuracy";
    public string Name => name;

    public override float GetValueAtLevel(int level)
    {
        float value = baseValue;

        for (int i = 1; i <= level; i++)
        {
            value += i;
        }

        return value;
    }
}