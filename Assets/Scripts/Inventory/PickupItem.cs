using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A attacher aux objets que l'on peut pick up
/// </summary>
public class PickupItem : MonoBehaviour
{
    // A remplir dans l'inspecteur
    public InventoryItem item;
    [SerializeField]
    GameObject player;
    private InventorySystem inventorySystemPlayer;

    // Start is called before the first frame update
    void Start()
    {
        inventorySystemPlayer = player.GetComponent<InventorySystem>();
    }

    // A appeler lorsque l'on interagit avec l'objet
    public void Pickup()
    {
        inventorySystemPlayer.AddItem(item);
        gameObject.SetActive(false);
    }
}
