using UnityEngine;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] private CraftPanelScript _craftingPanel;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private CraftingRecette _recette;

    private void Start()
    {
        _craftingPanel.Image.GetComponent<Image>().sprite = _recette.OutputItem.Sprite;
    }
    public void InteractWithTable()
    {
        _craftingPanel.gameObject.SetActive(!gameObject.activeSelf);
    }

    public void OnClick()
    {
        if(_inventory.RemoveItem(_recette.InputItem, _recette.InputAmount))
        {
            _inventory.AddItem(new OnPickupItemEvent(_recette.OutputItem, _recette.OutputAmount));
        }
    }
}
