using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    // Stocke l'état actuel du jeu
    public GameState currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);  // Le GameController ne sera pas détruit entre les scènes
    }

    // Méthodes pour changer l'état du jeu
    public void SetGameState(GameState state)
    {
        currentState = state;
    }
}
