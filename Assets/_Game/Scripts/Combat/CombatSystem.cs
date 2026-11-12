using System;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] EntityHealth _entityHealth;      
    public EntityHealth entityHealth { get => _entityHealth; set => _entityHealth = value; }
}