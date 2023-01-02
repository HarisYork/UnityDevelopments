using UnityEngine;
using UnityEngine.UI;

public class InterfaseUI : MonoBehaviour
{
    [SerializeField] private GameObject toolTip;
    public Text tooltipTitle, tooltipText;
    public Image tooltipIcon;
    private void Awake() {
        tooltipText=toolTip.GetComponentInChildren<Text>();        
    }
    public void ShowTooltip(Vector3 position, Items item) {
        toolTip.SetActive(true);
        tooltipTitle.text=item.itemName;
        tooltipText.text=item.itemDesc;
        tooltipIcon.sprite=item.itemIcon;
        toolTip.transform.position=position + new Vector3(70f, 70f, 0f);
    }
    public void HideTooltip() {
        toolTip.SetActive(false);
    }
}