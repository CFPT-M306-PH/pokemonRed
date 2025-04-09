using UnityEngine;

public enum GameState
{
    Exploring,  // Exploration, le joueur peut se déplacer
    Dialogue,   // En état de dialogue, le joueur ne peut pas se déplacer
    OtherState,  // Pour d'autres états comme un menu ou une cinématique
    CombatState
}
