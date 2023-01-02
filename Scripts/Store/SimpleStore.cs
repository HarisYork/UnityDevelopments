using System.Collections.Generic;
using UnityEngine;

public class SimpleStore: InteractableObject {
  public string storeName;
  public List<Items> items;
  private StoreManager manager;
  private InterfaseUI intUI;
  void Start() {
    manager = FindObjectOfType<StoreManager>();
    intUI = FindObjectOfType<InterfaseUI>();
  }

  public override void Interact() {
    base.Interact();
    Debug.Log("Store");
    if (Input.GetKeyDown(KeyCode.E)) {
      manager.ShowMarket();
      manager.currentStore = this;
      storeSelected();
    }
  }
  public void storeSelected() {
    manager.fillItem();
  }
}