using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillCanvas : MonoBehaviour
{
    [SerializeField] private List<Card> cards = new List<Card>();
    private List<Card> skillCards = new List<Card>();
    private void OnEnable()
    {
        AddRandomSkillCardsToSkillCanvas();
    }
    private void OnDisable()
    {
        cards.Clear();
    }
    private void AddRandomSkillCardsToSkillCanvas() { 
        var randomSkillCard = cards[Random.Range(0, cards.Count)];
        for(int i = 0; i < 3; i++)
        {
            skillCards.Add(randomSkillCard);
            randomSkillCard = cards[Random.Range(0, cards.Count)];
        }
        for(int j=0; j < 3; j++)
        {
            Card skillButton = Instantiate(skillCards[j], transform);  
        }
    }
    
}


