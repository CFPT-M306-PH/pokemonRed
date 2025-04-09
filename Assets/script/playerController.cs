using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 moveInput;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Interact()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        var faceDir = new Vector3(moveX, moveY);
        var interactPos = transform.position + faceDir;

        Debug.DrawLine(transform.position, interactPos, Color.green, 0.5f);
    }

    void Update()
    {
        // Vérifie l'état du jeu avant de permettre le mouvement
        if (GameController.Instance.currentState == GameState.Exploring)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            // Empêcher le mouvement diagonal : Priorité au mouvement vertical
            if (moveY != 0)
            {
                moveX = 0;
            }

            moveInput = new Vector2(moveX, moveY).normalized;

            // Appliquer le mouvement
            rb.linearVelocity = moveInput * speed;

            // Désactiver toutes les animations
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingRight", false);

            // Activer l'animation correspondante
            if (moveY < 0)
                animator.SetBool("isWalkingDown", true);
            else if (moveY > 0)
                animator.SetBool("isWalkingUp", true);
            else if (moveX < 0)
                animator.SetBool("isWalkingLeft", true);
            else if (moveX > 0)
                animator.SetBool("isWalkingRight", true);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Interact();
            }
        }
        else
        {
            // Si l'état du jeu est différent de "Exploring" (par exemple, Dialogue),
            // le joueur ne peut pas se déplacer.
            rb.linearVelocity = Vector2.zero;
        }
    }
}
