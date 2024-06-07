using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Le système d'inventaire, à attacher au joueur
/// </summary>
public class InventorySystem : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();
    // L'indice 0 est la main vide
    private int currentIndex = 0;


    private void Start()
    {
        items.Add(new InventoryItem { icon = null, id = 0, itemName = "main vide" });
    }


    private void Update()
    {
        // Récupérer l'input du scroll de la souris
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput > 0f)
        {
            NextItem();
        }
        else if (scrollInput < 0f)
        {
            PreviousItem();
        }
    }

    // Ne prend pas en compte la main vide, renvoie vrai si le joueur n'a pas ramassé d'objets
    public bool IsEmpty()
    {
        if (items.Count == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        items.Remove(item);
    }

    public InventoryItem GetCurrentItem()
    {
        // Si l'inventaire est vide
        if (IsEmpty())
        {
            return null;
        }
        else
        {
            return items[currentIndex];
        }
    }

    public void NextItem()
    {
        // Si l'inventaire est vide
        if (IsEmpty())
        {
            return;
        }
        else // On incrémente l'index pour équiper l'objet suivant
        {
            currentIndex = (currentIndex + 1) % items.Count;
        }
    }

    public void PreviousItem()
    {
        // Si l'inventaire est vide
        if (IsEmpty())
        {
            return;
        }
        else // On incrémente l'index pour équiper l'objet suivant
        {
            currentIndex = (currentIndex - 1 + items.Count) % items.Count;
        }
    }
}
