using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gère la fonctionnalité d'interaction du joueur, met continuellement à jour l'objet avec lequel le joueur peut interagir
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    public Camera camera;
    Interactable currentInteractable;
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();

        // Si le joueur appuie sur la touche et qu'un objet interactable est devant lui à portée
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        // On donne la direction au ray
        ray.origin = camera.transform.position;
        ray.direction = camera.transform.forward;

        // On cast un rayon, si il touche alors
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            // Si le rayon a touché un game object Interactable
            if (hit.collider.tag == "Interactable")
            {
                // On va chercher l'Interactable du game object cible
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                // Si on regarde bien toujours un Interactable mais que ce n'est plus le même qu'à la frame précédente
                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else // newInteractable n'est pas enabled
                {
                    DisableCurrentInteractable();
                }
            }
            else // Sinon ce n'est pas un Interactable
            {
                DisableCurrentInteractable();
            }
        }
        else // Sinon le rayon n'a rien touché
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
