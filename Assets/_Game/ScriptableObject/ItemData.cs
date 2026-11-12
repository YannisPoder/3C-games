using UnityEngine;

[CreateAssetMenu(fileName = "Game", menuName = "Game/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    public string Name { get => _name; }
    public Sprite Sprite { get => _sprite; }
}
