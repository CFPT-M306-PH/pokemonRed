using UnityEngine;

public class Teleportation : MonoBehaviour
{
	public Transform teleportDestination; // Référence à la destination de téléportation

	private void OnTriggerEnter2D(Collider2D other)
	{
		// Vérifie si c'est le joueur qui entre dans le trigger
		if (other.CompareTag("Player"))
		{
			TeleportPlayer(other.gameObject);  // Téléporte le joueur
		}
	}

	private void TeleportPlayer(GameObject player)
	{
		if (teleportDestination != null)
		{
			// Téléporte le joueur à la position de la destination
			player.transform.position = teleportDestination.position;
		}
		else
		{
			Debug.LogError("Destination de téléportation non définie !");
		}
	}
}
