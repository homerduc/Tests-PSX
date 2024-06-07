using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Représente un item d'inventaire, n'est pas hérité de MonoBehavior
/// </summary>
[System.Serializable]
[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int id;
}
