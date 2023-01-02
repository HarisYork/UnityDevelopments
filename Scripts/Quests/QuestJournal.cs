using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestJournal : MonoBehaviour
{
    private int gold, exp;
    public List<Quests> activeQuests;
    public List<Quests> complitedQuests;
    public Quests curQuest;
    public Quests inputQuest;
    public GameObject questWindow;
    public Text questTitleText, questDescText, questExpirienceText, questRewardText;

    public List<QuestSlot> activeSlots;
    public List<QuestSlot> compitedSlots;
    public GameObject newSlot;
    public GameObject activeQuestBody;
    public GameObject complitedQuest;
    public GameObject complitedQuestBody;

    public GameObject jornalWindow;

    public Inventory inventory;
    public bool isShowJornal;

    void Awake(){
        inventory = GetComponentInChildren<Inventory>();   
    }
    void Start()
    {
        complitedQuest.SetActive(false);
        OpenWindow(curQuest);   //Ok I make this for show Quest window. In other situation use real trigger, f.e. collider or s.e.

        QuestSlot slotter = Instantiate(newSlot.GetComponent<QuestSlot>(), activeQuestBody.transform);
        activeSlots.Add(slotter);
        for (int i = 0; i < activeSlots.Count; i++) {
        activeSlots[i].currentQuest = activeQuests[i];
      }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(isShowJornal==true) {
                isShowJornal = false;
            }
            else {
                isShowJornal = true;
                Quester(); 
            }
        }
        if(isShowJornal==true)
        {
        jornalWindow.SetActive(true);
        }
        else{
        jornalWindow.SetActive(false);
        }   
        // foreach(QuestSlot oldSlots in activeSlots)
        // {
        //     if(oldSlots.currentQuest.isSucsess==true)
        //     {
        //         activeSlots.Remove(oldSlots);
        //         Destroy(oldSlots.gameObject);
        //     }
        // }
    }
    public void OpenWindow(Quests quest)
    {
        inputQuest = quest;
        Debug.Log("Quest:" + inputQuest.title);
        questWindow.SetActive(true);
        questTitleText.text = inputQuest.title;
        questDescText.text = inputQuest.description;
        questExpirienceText.text = inputQuest.expReward.ToString();
        questRewardText.text = inputQuest.goldReward.ToString();
    }
    public void AcceptQuest()
    {
        inputQuest.isActive = true;
        activeQuests.Add(inputQuest);
        QuestSlot slotter = Instantiate(newSlot.GetComponent<QuestSlot>(), activeQuestBody.transform);
        activeSlots.Add(slotter);
        slotter.currentQuest = inputQuest;
        if(activeQuests.Count<=1)
            curQuest=inputQuest;
        inputQuest=null;
        questWindow.SetActive(false);
    }
    public void Quester()
    {
        Debug.Log("Quester");
        if (activeQuests.Count!=0)
        foreach (Quests singleQuest in activeQuests) {
            if(singleQuest.isActive)
            {
                // if(curQuest.goal.goalType == GoalType.Kill)
                // {
                //     curQuest.goal.EnemyKilled();
                //     if(curQuest.goal.IsReached())
                //     {
                //         exp += curQuest.expReward;
                //         gold += curQuest.goldReward;
                //         curQuest.Complete();
                //         curQuest = null;
                //     }
                // }
                if(singleQuest.goal.goalType == GoalType.Gathering)
                {
                    if(Inventory.instance.items.Find(Items=>Items == singleQuest.reqItem)!=null)
                    {
                        Debug.Log("Quest:" + singleQuest.title + " - you have enough " + singleQuest.reqItem.itemName);
                        singleQuest.goal.ItemCollected(singleQuest.reqItem);
                    }
                    if(singleQuest.goal.IsReached())
                    {
                        exp += singleQuest.expReward;
                        gold += singleQuest.goldReward;
                        QuestComplited(singleQuest);
                        singleQuest.Complete();
                        activeQuests.Remove(singleQuest);
                        inventory.dellItem(singleQuest.reqItem);
                    }
                }
            }
        }
    }
    void QuestComplited(Quests endQuest)
    {
        if(complitedQuests.Count>=0)
        {
            complitedQuest.SetActive(true);
        }
        activeQuests.Remove(endQuest);
        complitedQuests.Add(endQuest);
        QuestSlot slotter = Instantiate(newSlot.GetComponent<QuestSlot>(), complitedQuestBody.transform);
        compitedSlots.Add(slotter);
        slotter.currentQuest = endQuest;
    }
    
}

