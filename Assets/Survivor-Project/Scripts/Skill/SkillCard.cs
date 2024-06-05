using UnityEngine;

public class SkillCard : Card
{
    [SerializeField] private Skill skillPrefab;
    private SkillCaster skillCaster;
    new void OnEnable()
    {
        skillCardButton.onClick.AddListener(ResumeGame);
        skillCardButton.onClick.AddListener(AddSkillToPlayer);
    }
    private void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
    }
    public void AddSkillToPlayer()
    {
        GameManager.Instance.skillCaster.AddSkill(skillPrefab); 
    }
    
}
