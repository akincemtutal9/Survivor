using System.Threading.Tasks;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private Health health;
    private Material playerMat;
    [SerializeField] private Material playerDamagedMaterial;
    private MeshRenderer playermeshRenderer;

    private void Awake()
    {
        health = GetComponent<Health>();
        playerMat = GetComponent<MeshRenderer>().material;
        playermeshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        health.OnTakeDamage += HandleTakeDamage;
        health.OnDie += HandleDie;
    }
    private void OnDestroy()
    {
        health.OnTakeDamage -= HandleTakeDamage;
        health.OnDie -= HandleDie;
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
