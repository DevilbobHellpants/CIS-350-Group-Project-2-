using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Attribute[] attributes;
    public bool Lightbulb01pickedup;
    public bool Lightbulb02pickedup;
    public bool Lightbulb03pickedup;
    public bool Lightbulb04pickedup;
    public bool Lightbulb05pickedup;
    public bool Lightbulb06pickedup;
    public bool Lightbulb07pickedup;
    public bool Lightbulb08pickedup;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        //attributes[1].value.BaseValue = 3;
        Lightbulb01pickedup = false;
        Lightbulb02pickedup = false;
        Lightbulb03pickedup = false;
        Lightbulb04pickedup = false;
        Lightbulb05pickedup = false;
        Lightbulb06pickedup = false;
        Lightbulb07pickedup = false;
        Lightbulb08pickedup = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnBeforeAttackUpdate()
    //{
    //    for (int j = 0; j < attributes.length; j++)
    //    {
    //        if (playerstats.attributes[0].type == clickedattack.attack.data.buffs[0].attribute)
    //        {
    //            clickedattack.attack.data.buffs[0].generatevalue();
    //            playerstats.attributes[0].value.basevalue = (playerstats.attributes[0].value.basevalue) + clickedattack.attack.data.buffs[0].value;
    //            debug.log(string.concat(playerstats.attributes[0].type, " was updated! value is now ", playerstats.attributes[0].value.modifiedvalue));
    //        }
    //    }
    //}

    //public void OnAfterAttackUpdate()
    //{
    //    for (int j = 0; j < attributes.Length; j++)
    //    {
    //        if (attributes[0].type == clickedAttack.attack.data.buffs[0].attribute)
    //        {
    //            clickedAttack.attack.data.buffs[0].GenerateValue();
    //            attributes[0].value.BaseValue = (attributes[0].value.BaseValue) + clickedAttack.attack.data.buffs[0].value;
    //            Debug.Log(string.Concat(attributes[0].type, " was updated! Value is now ", attributes[0].value.ModifiedValue));
    //        }
    //    }
    //}

    public void AttributeModified(Attribute attribute)
    {
        //Debug.Log(string.Concat(attribute.type, " was updated! Value is now ", attribute.value.ModifiedValue));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lightbulb")
        {
            if (other.gameObject.name.Contains("Lightbulb 1.1"))
            {
                Lightbulb01pickedup = true;
                Destroy(other);
            }
            if (other.gameObject.name.Contains("Lightbulb 1.2"))
            {
                Lightbulb02pickedup = true;
                Destroy(other);
            }
            if (other.gameObject.name.Contains("Lightbulb 2.1"))
            {
                Lightbulb03pickedup = true;
                Destroy(other);
            }
            if (other.gameObject.name.Contains("Lightbulb 2.2"))
            {
                Lightbulb04pickedup = true;
                Destroy(other);
            }
            if (other.gameObject.name.Contains("Lightbulb 3.1"))
            {
                Lightbulb05pickedup = true;
                Destroy(other);
            }
            if (other.gameObject.name.Contains("Lightbulb 3.2"))
            {
                Lightbulb06pickedup = true;
                Destroy(other);
            }
            if (other.gameObject.name.Contains("Lightbulb 4.1"))
            {
                Lightbulb07pickedup = true;
                Destroy(other);
            }
            if (other.gameObject.name.Contains("Lightbulb 4.2"))
            {
                Lightbulb08pickedup = true;
                Destroy(other);
            }
        }
    }
}

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public PlayerStats parent;
    public Attributes type;
    public ModifiableInt value;

    public void SetParent(PlayerStats _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }
    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}