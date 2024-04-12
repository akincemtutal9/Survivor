using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected int maxHealth;
    protected int health;
    protected bool isInvunerable;

    public event Action OnTakeDamage;
    public event Action OnDie;

    public bool isDead => health == 0;
    private void Start()
    {
        health = maxHealth;
    }

    public void SetInvunerable(bool isInvunerable)
    {
        this.isInvunerable = isInvunerable;
    }

    public void DealDamage(int damage)
    {
        if (health == 0) { return; }

        if (isInvunerable) { return; }

        health = Mathf.Max(health - damage, 0);

        OnTakeDamage?.Invoke();

        if (health == 0)
        {
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }
}