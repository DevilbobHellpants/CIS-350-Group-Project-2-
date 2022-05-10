using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Noah Trillizio, Anna Breuker
 * Project 5 
 * Controls the creation of the items and the data it can store
 */

public enum Attributes
{
    /*Agility,
    Intellect,
    Stamina,
    Strength,
    Health*/ //going to replace these using only the attributes described in the doc - anna

    PlayerAnxiety, //goes up or down by either a flat amount or a random amount within a range
    EnemyHealth, //goes up or down by either a flat amount or a random amount within a range

    //^ these two are honestly the only necessary ones ^

    MovementSpeed, //effects movement in the overworld (i think that's the intention)
    Blindness, //blindness in the overworld 
    EndEncounterEarly, //a chance between 0 and 100
    ChangeEnemyText, //different depending on enemy
    CloudSpawnRate, //cloud spawn would be multiplied by whatever this number is
    Asleep, //if true, cannot make selections for two turns / enemy gets two free attacks.
    Defense,
    Drunk, //if true, controls swaped in overworld
    MusicVolume, //directly effects background music
    Agoraphobic //cannot use social related skills until X amount of combat turns have passed
                //   this was something i added back in last minute, probably not theisable for 
                //   playtest build.

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
        //Debug.Log(value);
    }
}
