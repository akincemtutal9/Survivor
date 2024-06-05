using System.Collections.Generic;
using UnityEngine;

public class SkillCanvas : MonoBehaviour
{
    private List<Card> skillCards = new List<Card>(); // 3 cards to be displayed on the skill canvas
    private void OnEnable()
    {
        AddRandomSkillCardsToSkillCanvas();
    }
    private void OnDisable()
    {
        skillCards.Clear();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void AddRandomSkillCardsToSkillCanvas() { 
        var randomSkillCard = GameManager.Instance.cards[Random.Range(0, GameManager.Instance.cards.Count)];
        for (int i = 0; i < 3; i++)
        {
            // if card already exists, get another random card
            while (skillCards.Contains(randomSkillCard))
            {
                randomSkillCard = GameManager.Instance.cards[Random.Range(0, GameManager.Instance.cards.Count)];
            }
            skillCards.Add(randomSkillCard);
        }
        for(int j=0; j < 3; j++)
        {
            Card skillButton = Instantiate(skillCards[j], transform);  
        }
    }
    
}


