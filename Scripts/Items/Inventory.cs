using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory: MonoBehaviour {
  #region Singleton
  public static Inventory instance;
  void Awake() {
    if (instance != null) {
      Debug.LogWarning("More than one instance of Inventory found!");
      return;
    }
    instance = this;
  }
  #endregion
  public delegate void OnItemChanged();
  public OnItemChanged onItemChangedCallback;
  public List<Items> items;
  public List<InventorySlot> slots;
  public InventorySlot curSlot; //Create CRUD interfases
  public bool showInventoryBar = false;
  public GameObject inventoryBar, slotBar, newSlot;

  public float curWeight = 0.0f;
  public float maxWeight = 10.0f;
  public Text weightText;
  private Character player;
  public Text goldText;
  public float freeSpase(){
    return maxWeight-curWeight;
  }
  void Start() {
    player=FindObjectOfType<Character>();
    slots = new List<InventorySlot>();
    slots.AddRange(inventoryBar.GetComponentsInChildren<InventorySlot>());
    startItem();
  }
  void Update() {
    weightText.text = curWeight.ToString() + " / " + maxWeight.ToString();
    if (Input.GetKeyDown(KeyCode.I)) {
      ShowInv();
    }
    goldText.text = player.money.ToString();
  }
  public void ShowInv() {
    if (showInventoryBar != true) {
      inventoryBar.SetActive(true);
      showInventoryBar = true;
    } else {
      inventoryBar.SetActive(false);
      showInventoryBar = false;
    }
  }
  void startItem() {
    while (items.Count >= slots.Count + 1) {
      InventorySlot slotter = Instantiate(newSlot.GetComponent<InventorySlot>(), slotBar.transform);
      slots.Add(slotter);
      for (int i = 0; i < slots.Count; i++) {
        slots[i].item = items[i];
        slots[i].getItem();
      }
    }
    for (int i = 0; i < items.Count; i++) {
      slots[i].item = items[i];
      slots[i].getItem();
      curWeight += items[i].itemWeight;
    }
  }
  public void plussItem(List < Items > buyItem) {
    if (items.Count >= slots.Count) {
      foreach(Items newItem in buyItem) {
        if (!newItem.isDefault) {
          InventorySlot slotter = Instantiate(newSlot.GetComponent<InventorySlot>(), slotBar.transform);
          slots.Add(slotter);
          items.Add(newItem);
          slotter.item = newItem;
          slotter.getItem();
          curWeight += newItem.itemWeight;
        }
      }
    }
    for (int i = 0; i < items.Count; i++) {
      if (!slots[i].item.isDefault) {
        slots[i].item = items[i];
        slots[i].getItem();
      }
    }
  }
  public void dellItem(Items delItem) {
    items.Remove(delItem);
    slots.Remove(curSlot);
    curWeight -= delItem.itemWeight;
  }
  public void useItem() {
    // if (onItemChangedCallback != null)
    if (curSlot!=null)
    {
      curSlot.item.Use();
      dellItem(curSlot.item);
      curSlot.item = null;
    }
  }
    public void dropItem() {
      items.Remove(curSlot.item);
      // if (onItemChangedCallback != null)
      if (curSlot!=null)
      {
        // onItemChangedCallback.Invoke();
        dellItem(curSlot.item);
        curSlot.item = null;
      }
    }
  public void Add(Items item) {
    if (!item.isDefault) {
      items.Add(item);
      if (items.Count >= slots.Count) {
        InventorySlot slotter = Instantiate(newSlot.GetComponent<InventorySlot>(), slotBar.transform);
        slots.Add(slotter);
        slotter.item = item;
        slotter.getItem();
        curWeight += item.itemWeight;
      } else {
        for (int i = 0; i < items.Count; i++) {
          if (!slots[i].item.isDefault) {
            slots[i].item = items[i];
            slots[i].getItem();
          }
        }
      }
    }
    if (onItemChangedCallback != null)
      onItemChangedCallback.Invoke();
  }
}