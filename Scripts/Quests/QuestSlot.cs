using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour
{
    public Text questTitle, questDesc;
    public bool IsShow = false;
    public GameObject descBody;
    public Quests currentQuest;
    void Start()
    {
        questTitle.text = currentQuest.title;
        questDesc.text = currentQuest.description;
    }
    public void ShowDesc()
    {
        if(IsShow!=true)
        {
            descBody.SetActive(true);
            IsShow = true;
        }
        else{
            descBody.SetActive(false);
            IsShow = false;
        }
    }
}
