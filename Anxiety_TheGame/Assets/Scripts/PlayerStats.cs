using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Attribute[] attributes;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        //attributes[0].value.BaseValue = 100;
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