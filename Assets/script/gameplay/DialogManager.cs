using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private Text dialogText;
    [SerializeField] private int lettersPerSec = 10;

    private List<string> lines;
    private int currentLine;
    public static DialogManager Instance { get; private set; }

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
    }

    private void Start()
    {
        lines = new List<string>();
    }

    public void ShowDialog(Dialog dialog)
    {
        if (dialog.Lines.Count == 0)
        {
            Debug.LogWarning("Le dialogue est vide !");
            return;
        }

        dialogBox.SetActive(true);
        GameController.Instance.SetGameState(GameState.Dialogue);
        lines.Clear();

        foreach (string line in dialog.Lines)
        {
            lines.Add(line);
        }

        StartCoroutine(TypeDialog(dialog));
        
    }

    private bool isTyping = false;

    private IEnumerator TypeDialog(Dialog dialog)
    {
        if (isTyping) yield break; // Si la coroutine est déjà en cours, on sort
        isTyping = true;

        while (currentLine < lines.Count)
        {
            string sentence = lines[currentLine];
            dialogText.text = "";

            foreach (char letter in sentence)
            {
                dialogText.text += letter;
                yield return new WaitForSeconds(1f / lettersPerSec);
            }

            currentLine++;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        }
        if (dialog.isFight)
        {
            GameController.Instance.SetGameState(GameState.CombatState);
        }

        dialogBox.SetActive(false);
        GameController.Instance.SetGameState(GameState.Exploring);
        isTyping = false;
        currentLine = 0;
    }

}
