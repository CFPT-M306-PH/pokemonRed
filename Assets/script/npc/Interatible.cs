using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }
    }

    private void Interact()
    {
      
      DialogManager.Instance.ShowDialog(dialog);
      
       
    }
}
