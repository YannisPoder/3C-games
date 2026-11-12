using UnityEngine;

[CreateAssetMenu(fileName = "CraftingRecette", menuName = "Scriptable Objects/CraftingRecette")]
public class CraftingRecette : ScriptableObject
{
    public ItemData InputItem;
    public int InputAmount;

    public ItemData OutputItem;
    public int OutputAmount;
}
