using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
  public Items item;
  public Image itemIcon;
  public Text itemNameText, itemCountText;
  private Inventory inventoryParent;
  private InterfaseUI intUI;
  void Start() {
    inventoryParent = FindObjectOfType<Inventory>();
    intUI=FindObjectOfType<InterfaseUI>();
    getItem();
  }
  void Update() {
    if (item == null) {
      itemIcon.sprite = null;
      itemNameText.text = "Empty";
      itemCountText.text = null;
      inventoryParent.slots.Remove(gameObject.GetComponent<InventorySlot>());
      Destroy(gameObject);
    }
  }
  public void getItem() {
    itemIcon.sprite = item.itemIcon;
    itemNameText.text = item.itemName;
    itemCountText.text = item.itemWeight.ToString();
  }
  public void Selected() {
    inventoryParent.curSlot = gameObject.GetComponent<InventorySlot>();
  }
  public void OnPointerEnter(PointerEventData eventData)
  {
      intUI.ShowTooltip(transform.position, item);
  }
  public void OnPointerExit(PointerEventData eventData)
  {
      intUI.HideTooltip();
  }
}