using System;
using UnityEngine;
public class QuestOwner : InteractableObject
{
    public Quests currentQuest;
    private QuestJournal journal;
    public override void Interact()
    {
        Debug.Log("Quest:" + currentQuest.title);
        FindObjectOfType<QuestJournal>().OpenWindow(currentQuest);
    }
}
