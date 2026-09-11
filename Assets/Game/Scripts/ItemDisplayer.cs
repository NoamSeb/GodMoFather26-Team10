using UnityEngine;
using TMPro;
public class ItemDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI namePriceTxt;

    public TextMeshProUGUI NamePriceTxt
    {
        get => namePriceTxt;
        set => namePriceTxt = value;
    }

    [SerializeField] private TextMeshProUGUI descriptionTxt;
    public TextMeshProUGUI DescriptionTxt
    {
        get => descriptionTxt;
        set => descriptionTxt = value;
    }
    
}
