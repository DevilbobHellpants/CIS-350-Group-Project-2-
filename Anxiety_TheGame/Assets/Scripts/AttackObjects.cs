using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attributes
{
    Agility,
    Intellect,
    Stamina,
    Strength,
    Health
}

[CreateAssetMenu(fileName = "New Attack", menuName = "Combat System/Attacks")]
public class AttackObjects : ScriptableObject
{
    public Sprite uiDisplay;
    //public bool stackable;
    [TextArea(15, 20)]
    public string description;
    public Attack data = new Attack();

    public Attack CreateAttack()
    {
        Attack newItem = new Attack(this);
        return newItem;
    }
}

[System.Serializable]
public class Attack
{
    public string Name;
    public int Id = -1;
    public AttackEffect[] buffs;
    //public GameObject note;
    public Attack()
    {
        Name = "";
        Id = -1;
        //note = null;
    }
    public Attack(AttackObjects attack)
    {
        Name = attack.name;
        Id = attack.data.Id;
        buffs = new AttackEffect[attack.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new AttackEffect(attack.data.buffs[i].min, attack.data.buffs[i].max)
            {
                attribute = attack.data.buffs[i].attribute
            };
        }
        //note = item.data.note;
    }
}

[System.Serializable]
public class AttackEffect : IModifiers
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public AttackEffect(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }

    public void AddValue(ref int baseValue)
    {
        baseValue += value;
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}
