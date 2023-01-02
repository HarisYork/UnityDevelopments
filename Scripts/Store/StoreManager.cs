using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    //SIDE
    private Character player;
    private Inventory inventory;
    //General
    public SimpleStore currentStore;
    private List<StoreSlot> slots;
    private List<Items> items;
    private int pay=0;
    private float weight=0.0f;
    public List<Items> buyList;
    //UI
    public Text payText, weightText, allertText, nameText;
    public bool showMarketBar=false;
    public GameObject marketBar, allertBar, storeSlotsField, storeSlotPrefab;
    private InterfaseUI intUI;

    void Awake()
    {
        nameText.text=currentStore.storeName;
        payText.text=pay.ToString();
        items=currentStore.items;
    }
    void Start()
    {
        player=FindObjectOfType<Character>();
        inventory=FindObjectOfType<Inventory>();
        slots = new List<StoreSlot>();
        slots.AddRange(storeSlotsField.GetComponentsInChildren<StoreSlot>());
        intUI=FindObjectOfType<InterfaseUI>();
        fillItem();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) {
        ShowMarket();
        }
    }
    public void fillItem() {
        items=currentStore.items;

        while (items.Count >= slots.Count + 1) {
        StoreSlot slotter = Instantiate(storeSlotPrefab.GetComponent<StoreSlot>(), storeSlotsField.transform);
        slots.Add(slotter);
        for (int i = 0; i < slots.Count; i++) {
            slots[i].item = items[i];
            slots[i].getItem();
        }
        }
        for (int i = 0; i < items.Count; i++) {
        slots[i].item = items[i];
        slots[i].getItem();
        }
    }
    public void chooseSlot(Items buyItem)
    {
        float freeSpase = inventory.freeSpase();
        pay+=buyItem.itemCost;
        weight+=buyItem.itemWeight;
        buyList.Add(buyItem);
        payText.text=pay.ToString();

        if (pay == player.money){
            payText.color = Color.yellow;
        }
        else if (pay > player.money){
            payText.color = Color.red;
        }
        else{
            payText.color = Color.black;
        }
        weightText.text=weight.ToString();
        if (weight == freeSpase){
            weightText.color = Color.yellow;
        }
        else if (weight > freeSpase){
            weightText.color = Color.red;
        }
        else{
            weightText.color = Color.black;
        }
    }

    public void buyAll()
    {
        if((player.money>=pay) & (inventory.freeSpase()>=weight)) {
            player.pay(pay);
            pay=0;
            weight=0;
            inventory.plussItem(buyList);
            buyList.Clear();
            clearShop();
        }
        else {
            allertBar.SetActive(true);
        }
    }
    private void clearShop(){
        buyList.Clear();
        pay=0;
        weight=0;
        weightText.color = Color.black;
        payText.color = Color.black;
        payText.text=pay.ToString();
        weightText.text=weight.ToString();
        allertBar.SetActive(false);
    }
    public void ShowMarket()
    {
        if(showMarketBar!=true)
        {
            marketBar.SetActive(true);
            showMarketBar=true;
        }
        else
        {
            marketBar.SetActive(false);
            showMarketBar=false;
            clearShop();
        }
    }
}
