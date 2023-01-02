using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int reqAmount, curAmount;

    public bool IsReached()
    {
        return(curAmount>=reqAmount);
    }
    public void EnemyKilled()
    {
        if(goalType == GoalType.Kill)
            curAmount++;
    }
    public void ItemCollected(Items item)
    {
        if(goalType == GoalType.Gathering)
            curAmount++;
    }
}
public enum GoalType
{
    Kill,
    Gathering
}
