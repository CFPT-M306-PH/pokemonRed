using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] HpBar hpBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetData(Pokemon pokemon)
    {
        nameText.text = pokemon.Base.Name;
        levelText.text = "Lvl " + pokemon.Level.ToString();
        hpBar.SetHp((float) pokemon.HP / pokemon.MaxHp);
    }
}
