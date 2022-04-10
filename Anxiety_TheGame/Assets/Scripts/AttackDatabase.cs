using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Database", menuName = "Combat System/Database")]
public class AttackDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public AttackObjects[] AttackObjects;

    [ContextMenu("Update ID's")]
    public void UpdateID()
    {
        for (int i = 0; i < AttackObjects.Length; i++)
        {
            if (AttackObjects[i].data.Id != i)
            {
                AttackObjects[i].data.Id = i;
            }
        }
    }
    public void OnAfterDeserialize()
    {
        UpdateID();
    }

    public void OnBeforeSerialize()
    {
    }
}
