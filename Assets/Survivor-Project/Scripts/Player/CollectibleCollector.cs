using UnityEngine;
public class CollectibleCollector : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, playerSO.collectibleArea,LayerMask.GetMask("Collectible")); 
        foreach (var collider in colliders)
        {
            ICollectible collectible = collider.GetComponent<ICollectible>();
            if (collectible != null)
            {
                collectible.Collect();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,playerSO.collectibleArea);
    }
}
