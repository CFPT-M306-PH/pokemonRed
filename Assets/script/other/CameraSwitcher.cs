using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera combatCamera;

    private bool inCombat = false;

    void Start()
    {
        // On démarre avec la caméra principale active
        mainCamera.enabled = true;
        combatCamera.enabled = false;
    }

    void Update()
    {
        // Appuie sur C pour switcher de caméra
        if (GameController.Instance.currentState == GameState.CombatState)
        {
            mainCamera.enabled = false;
            combatCamera.enabled = true;
        }
        else
        {
            mainCamera.enabled = true;
            combatCamera.enabled = false;
        }
    }

    void SwitchCamera()
    {
        inCombat = !inCombat;
        mainCamera.enabled = !inCombat;
        combatCamera.enabled = inCombat;
    }
}
