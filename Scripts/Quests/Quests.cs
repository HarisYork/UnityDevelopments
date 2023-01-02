using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Quest", menuName ="Quest")]
public class Quests: ScriptableObject
{
    public bool isActive;
    public bool isSucsess=false;
    public string title, description;
    public int expReward;
    public int goldReward;
    public Items reqItem;
    public QuestGoal goal;
    public void Complete()
    {
        isActive=false;
        isSucsess=true;
    }
}
