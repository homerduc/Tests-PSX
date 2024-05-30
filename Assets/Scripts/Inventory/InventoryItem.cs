using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Représente un item d'inventaire, n'est pas hérité de MonoBehavior
/// </summary>
[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public Sprite icon;
    public int id;
}
