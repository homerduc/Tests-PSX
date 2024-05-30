using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Repr�sente un item d'inventaire, n'est pas h�rit� de MonoBehavior
/// </summary>
[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public Sprite icon;
    public int id;
}
