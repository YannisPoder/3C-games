using UnityEngine;

public class CraftPanelScript : MonoBehaviour
{
    [SerializeField] private GameObject _image; 
    [SerializeField] private GameObject _txt;

    public GameObject Image { get => _image; set => _image = value; }
    public GameObject Txt { get => _txt; set => _txt = value; }
}
