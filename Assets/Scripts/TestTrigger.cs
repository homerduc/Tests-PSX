using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Test de trigger d'évènements lorsque le joueur enntre dans un collider, à appliquer aux colliders en question
/// </summary>
public class TestTrigger : MonoBehaviour
{
    public AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("T'es rentré !!!!");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("T'es sorti !!!!");
            audiosource.Play();
        }
    }
}
