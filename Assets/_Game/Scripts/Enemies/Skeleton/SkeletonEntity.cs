using UnityEngine;
using UnityEngine.AI;

public class SkeletonEntity : EnemyBase
{
    [SerializeField] float _range;
    [SerializeField] float _attackRange;

    private void Reset()
    {
        _range = 5f;
        _attackRange = 1f;
        _speed = 1f;
    }

    protected override void ExecuteBehavior()
    {
        _entity.transform.LookAt(new Vector3(_player.transform.position.x, _entity.transform.position.y, _player.transform.position.z));
        _agent.isStopped = true;

        if (_agent.SetDestination(_player.transform.position))
        {
            var corners = _agent.path.corners;
            float fulldistance = 0f;

            // Correction de la boucle : corners[i - 1]
            for (int i = 1; i < corners.Length; i++)
            {
                fulldistance += Vector3.Distance(corners[i - 1], corners[i]);
            }

            if (fulldistance > _range)
            {
                _animator.SetBool("IsMove", false);
                _agent.isStopped = true;
                return;
            }

            if (fulldistance <= _attackRange)
            {
                _agent.isStopped = true;
                _animator.SetTrigger("TrMelee");
                return;
            }

            _agent.isStopped = false;
            if (_animator.GetBool("IsMove") == false)
            {
                _animator.SetBool("IsMove", true);
            }
        }
    }
}
