using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public float speed = 5f; // Vitesse du joueur
	private Rigidbody2D rb;
	private Vector2 movement;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		// R�cup�re l'entr�e du clavier (ZQSD ou Fl�ches)
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		// Normalisation pour �viter d'aller plus vite en diagonale
		movement = movement.normalized;
	}

	void FixedUpdate()
	{
		// D�placement du joueur
		rb.linearVelocity = movement * speed;
	}


}
