using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;



    public void UseItem()
    {
        Debug.Log("Using item: " + itemName);
    }



    public enum StatToChange
    {
        none,
        
    };
}
