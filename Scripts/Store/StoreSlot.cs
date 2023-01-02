using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Image itemIcon;
    public Text itemCost;
    public Items item;
    private InterfaseUI intUI;
    private StoreManager storeParent;
     private void Awake() {
        intUI=FindObjectOfType<InterfaseUI>();
        storeParent=FindObjectOfType<StoreManager>();
    }
    public void getItem() {
        itemIcon.sprite=item.itemIcon;
        itemCost.text = item.itemCost.ToString();
    }
    public void OnPointerEnter(PointerEventData eventData) {
        intUI.ShowTooltip(transform.position, item);
    }
    public void OnPointerExit(PointerEventData eventData) {
        intUI.HideTooltip();
    }
    public void Selected() {
        storeParent.chooseSlot(item);
    }
}
