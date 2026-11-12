using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damage);
    void RecoverHealth(float amount);
    bool IsDead();
}
