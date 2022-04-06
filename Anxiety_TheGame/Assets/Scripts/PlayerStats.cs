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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log(string.Concat(attribute.type, " was updated! Value is now ", attribute.value.ModifiedValue));
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