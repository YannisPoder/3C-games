using System;
using TMPro;
using UnityEngine;

public class EntityHealth : MonoBehaviour, IContextInitialise, IDamageable
{
    [SerializeField] EntityData _entityData;
    float _currentHealth;
    EventBus _eventBus;
    bool _hasPublishDeath;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _entityData.MaxHealth;

    public void Initialise(EventBus events)
    {
        _eventBus = events;
    }

    private void Start()
    {
        _currentHealth = MaxHealth;
        _hasPublishDeath = false;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            if (!_hasPublishDeath)
            {
                _hasPublishDeath = true;
                _eventBus.Publish(new OnEntityDieEvent(_entityData));
            }
        }
        GameObject gameObject = this.GetComponentInParent<Entity>().gameObject;
        gameObject.transform.Translate(Vector3.back * 0.4f);
    }
    public void RecoverHealth(float amount)
    {
        if (amount < 0 || _currentHealth <= 0)
            return;
        _currentHealth += amount;
        if (_currentHealth > MaxHealth) 
            _currentHealth = MaxHealth;
    }    

    public bool IsDead()
    {
        return _currentHealth <= 0;
    }
        
}