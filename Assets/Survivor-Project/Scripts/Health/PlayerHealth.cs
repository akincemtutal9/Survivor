using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;
public class PlayerHealth : Health
{
    private readonly int GetHitHash = Animator.StringToHash("GetHit");

    [SerializeField] protected PlayerSO playerSO;
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Animator animator;

    [SerializeField] private Material playerDamagedMaterial;
    private Material playerMat;
    private MeshRenderer playermeshRenderer;

    private void Awake()
    {
        health = playerSO.health;
        maxHealth = playerSO.maxHealth;
        health = maxHealth;
        playerMat = GetComponent<MeshRenderer>().material;
        playermeshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        OnTakeDamage += HandleTakeDamage;
        OnDie += HandleDie;

        UpdatePlayerHealthDisplay();
    }
    private void OnDestroy()
    {
        OnTakeDamage -= HandleTakeDamage;
        OnDie -= HandleDie;
    }
    private void HandleTakeDamage()
    {
        Debug.Log("Take Damage");
        MakeMaterialRed();
        UpdatePlayerHealthDisplay();
        HandleGetHitAnimation();
    }
    private void HandleDie()
    {
        Debug.Log("Die");
    }
    private async void MakeMaterialRed() // Call this function whenever the player takes damage
    {
        playermeshRenderer.material = playerDamagedMaterial;
        await Task.Delay(100);
        playermeshRenderer.material = playerMat;
    }

    private void UpdatePlayerHealthDisplay() // Call this function whenever the player takes damage or heals AND on Start
    {
        healthBar.fillAmount = (float)health / maxHealth;
        healthText.text = $"{health}/{maxHealth}";
    }
    
    private void HandleGetHitAnimation()
    {
        animator.SetTrigger(GetHitHash);
    }
    
}
 