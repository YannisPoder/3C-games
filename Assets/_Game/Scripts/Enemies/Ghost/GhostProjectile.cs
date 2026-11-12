using UnityEngine;

public class GhostProjectile : MonoBehaviour
{
    [SerializeField] Rigidbody _rB;
    [SerializeField] float _speed;
    [SerializeField] float _damage;
    float _lifetime = 10f;

    void Start()
    {
        _rB.linearVelocity = transform.forward * _speed;
    }

    void Update()
    {
        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable entity))
        {
            entity.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
