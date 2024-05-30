using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Représente un game object qui est interactable
/// </summary>
public class Interactable : MonoBehaviour
{
    Outline outline;

    public UnityEvent onInteraction;

    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    // On lance l'évènement onInteraction (à configurer dans l'interface Unity)
    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }
    public void EnableOutline()
    {
        outline.enabled = true;
    }
}
