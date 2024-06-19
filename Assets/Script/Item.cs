using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New item",menuName ="Inventory/New item",order = 0)]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite ItenIcon;
}
