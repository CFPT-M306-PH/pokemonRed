using UnityEngine;

public class Teleportation : MonoBehaviour
{
	public Transform teleportDestination; // R�f�rence � la destination de t�l�portation

	private void OnTriggerEnter2D(Collider2D other)
	{
		// V�rifie si c'est le joueur qui entre dans le trigger
		if (other.CompareTag("Player"))
		{
			TeleportPlayer(other.gameObject);  // T�l�porte le joueur
		}
	}

	private void TeleportPlayer(GameObject player)
	{
		if (teleportDestination != null)
		{
			// T�l�porte le joueur � la position de la destination
			Vector3 newPosition = teleportDestination.position;
			newPosition.z = -2;
			player.transform.position = newPosition;

		}
		else
		{
			Debug.LogError("Destination de t�l�portation non d�finie !");
		}
	}
}
