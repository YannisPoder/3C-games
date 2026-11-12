using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour, IEnemies
{
    [SerializeField] protected Entity _entity;
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Player _player;
    [SerializeField] protected GameObject _dropObject;
    [SerializeField] protected CombatSystem _combatSystem;
    [SerializeField] protected float _speed = 1f;

    protected bool _isDead;

    protected virtual void Start()
    {
        _isDead = false;
        if (_agent != null) _agent.speed = _speed;
    }

    protected virtual void Update()
    {

        if (_isDead)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
                Destroy(_entity.gameObject);
            return;
        }

        if (_combatSystem != null && _combatSystem.entityHealth != null && _combatSystem.entityHealth.IsDead())
        {
            Die();
            return;
        }

        ExecuteBehavior();
    }

    protected abstract void ExecuteBehavior();

    public virtual void Die()
    {
        _animator.SetTrigger("TrDie");
        _agent.isStopped = true;
        _agent.enabled = false;
        _entity.enabled = false;
        _isDead = true;

        if (_dropObject != null)
        {
            Instantiate(_dropObject, _entity.transform.position, Quaternion.identity);
        }
    }
}