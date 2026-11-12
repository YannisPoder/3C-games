using UnityEngine;
using UnityEngine.AI;

public class GhostEntity : EnemyBase
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _range;
    [SerializeField] float _attackRange;
    [SerializeField] float _cD;
    [SerializeField] Transform _projectilePos;

    float _lastAttackTime;

    private void Reset()
    {
        _range = 5f;
        _attackRange = 1f;
        _speed = 1f;
    }

    protected override void ExecuteBehavior()
    {
        _agent.SetDestination(_player.transform.position);
        _entity.transform.LookAt(new Vector3(_player.transform.position.x, _entity.transform.position.y, _player.transform.position.z));

        var corners = _agent.path.corners;
        float fulldistance = 0f;

        for (int i = 1; i < corners.Length; i++)
        {
            fulldistance += Vector3.Distance(corners[i - 1], corners[i]);
        }

        if (fulldistance > _range)
        {
            _agent.isStopped = true;
            return;
        }

        float distanceToPlayer = Vector3.Distance(_entity.transform.position, _player.transform.position);
        Ray ray = new Ray(_entity.transform.position, _player.transform.position - _entity.transform.position);
        bool isPlayerVisible = Physics.Raycast(ray, out RaycastHit hit, _range) && hit.collider.GetComponentInParent<Player>();

        if (!isPlayerVisible)
        {
            _agent.isStopped = true;
            return;
        }

        if (distanceToPlayer <= _attackRange)
        {
            if (Time.time - _lastAttackTime >= _cD)
            {
                _lastAttackTime = Time.time;
                Vector3 projectilePosition = new Vector3(_entity.transform.position.x, _projectilePos.position.y + _entity.transform.position.y,_entity.transform.position.z);
                Instantiate(_projectilePrefab, projectilePosition, _entity.transform.rotation);
            }
            _agent.isStopped = true;
            return;
        }

        _agent.isStopped = false;
    }
}
