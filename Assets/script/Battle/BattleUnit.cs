using UnityEngine;
using UnityEngine.UIElements;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Pokemon pokemon {  get; set; }

    public void Setup()
    {
        pokemon = new Pokemon(_base, level);
        if (isPlayerUnit)
        {
            GetComponent<Image>().sprite = pokemon.Base.BackSprite;
        }
        else
        {
            GetComponent<Image>().sprite = pokemon.Base.FrontSprite;
        }
    }
}
