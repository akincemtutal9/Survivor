using UnityEngine;
using System.Threading.Tasks;
public class PlayerHealth : Health
{

    [SerializeField] protected PlayerSO playerSO;
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
    }
    private void HandleDie()
    {
        Debug.Log("Die");
        //GameManager.EndGame();
    }
    private async void MakeMaterialRed()
    {
        playermeshRenderer.material = playerDamagedMaterial;
        await Task.Delay(100);
        playermeshRenderer.material = playerMat;
    }
}
 