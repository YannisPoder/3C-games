using UnityEngine;

public class SkeletonMelee : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float _damage;

    bool _active;
    bool _melee;

    private void Awake()
    {
        _active = false;
        _melee = false;
    }

    private void Update()
    {
        if (!_melee)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Melee"))
            {
                _active = true;
                _melee = true;
            }
            else _active = false;
            return;
        }
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Melee"))
            _melee =false;

    }

    private void OnTriggerStay(Collider other)
    {
        if (_melee && _active)
        {
            if (other.TryGetComponent(out IDamageable entity))
            {
                Debug.Log(other.gameObject.name);
                entity.TakeDamage(_damage);
                _active = false;
            }
        }
    }
}
