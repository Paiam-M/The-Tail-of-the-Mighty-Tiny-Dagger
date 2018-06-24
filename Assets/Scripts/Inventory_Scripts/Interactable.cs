using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 1.0f;
    public GameObject player;

    public bool hasInteracted = false;

    public virtual void Interact()
    {
        // This methos is meant to be overwritten
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= radius)
        {
            Interact();
            hasInteracted = true;
        }
    }

    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

}
