using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class MeleeScript : MonoBehaviour
{
    [SerializeField] PlayerInputController _pIC;
    [SerializeField] Animator _animator;
    [SerializeField] float _damage;

    bool _active;

    private void Awake()
    {
        _active = false;
        _pIC.OnMelee += Melee;
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (_active && !stateInfo.IsName("Melee"))
        {
            if (!_animator.IsInTransition(0))
            {
                _active = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_active)
        {
            Debug.Log(other.gameObject.name);
            if (other.TryGetComponent(out IDamageable entity))
            {                
                entity.TakeDamage(_damage);
                _active = false;
            }
        }        
    }

    void Melee(InputAction.CallbackContext context)
    {
        Debug.Log(_animator.GetCurrentAnimatorStateInfo(0));
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Melee"))
        {
            Debug.Log("Melee");
            _animator.SetTrigger("TrMelee");
            _active = true;
        }
    }
}
