using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    [SerializeField] protected Button skillCardButton;

    protected void OnEnable()
    {
        skillCardButton.onClick.AddListener(ResumeGame);
    }
    protected void OnDisable()
    {
        skillCardButton.onClick.RemoveAllListeners();
    }
    private void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
    }
}
