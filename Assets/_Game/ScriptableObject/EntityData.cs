using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/EntityData")]
public class EntityData : ScriptableObject
{
    [SerializeField] float _maxHealth;
    [SerializeField] float _damage;
    public float MaxHealth => _maxHealth;
}
