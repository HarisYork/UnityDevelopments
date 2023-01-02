using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
	private InterfaseUI intUI;
	void Start()
	{
		intUI=FindObjectOfType<InterfaseUI>();
	}
	public float countHP, maxHP, countEnergy, maxEnergy, currentExp, requiredExp; //Изменяющиеся переменные
	public int Level=1, Point=0, money=228; //Основные переменные
	private float stren=2,intel=2,speed=2,luck=2; //Характеристики персонажа
    void Update()
    {//Отображение основных показателей персонажа
		// intUI.textHP.text=Mathf.RoundToInt(countHP)+"/"+maxHP;
        // intUI.HealthBarFill.localScale = new Vector3 (countHP/maxHP, 1f, 1f);
        // intUI.textEnergy.text=Mathf.RoundToInt(countEnergy)+"/"+maxEnergy;
        // intUI.EnergyBarFill.localScale = new Vector3 (countEnergy/100, 1f, 1f);
        // intUI.textExp.text=Mathf.RoundToInt(currentExp)+"/"+requiredExp;
        // intUI.ExpBarFill.localScale = new Vector3 (currentExp/requiredExp, 1f, 1f);
        if(currentExp>=requiredExp)//Повышение уровня
	        {
	        	GetLevelUp(false);
	        }
        if(countHP<=0)//Критический урон
	        {
	       		countHP=0;
	        	// GetCrit();
	        }
//Панель уровня и очков прокачки
	    // intUI.levelText.text="Level: "+Level.ToString();
	    // intUI.pointText.text="Points: "+Point.ToString();
    }
    public void GetLevelUp(bool baff) //Повышение уровня - на вход обычное, либо повышение в связи с ивентом
	    {
	    if(baff==false)		
			{
				currentExp=currentExp-requiredExp;
			}
	    else	
			{
				currentExp=0.0f;
			}
	    requiredExp=requiredExp+(Level*2);
	    Level++;
		Point++;
	    }
    public void GetDamage(float dmg) //Получение урона - на вход величина урона и, возможно, тип
	    {
	    	countHP=countHP-dmg;
	    	Debug.Log("Damage");
	    }
    // public void GetCollect() //Результат исследования, сбор элементов ивента (рандомизированно)
	//     {
	//     	Debug.Log("Collected");
	//     }
    // public void GetCrit() //Критический урон, приводящий к завершению игры, без вкачанного перка на бессмертие
	//     {
	//     	Debug.Log("Critical");
	//     	countHP=0.0f;
	//     }
	public void CharUp(string param) //Повышенеие характеристик персонажа - на вход улучшаемый параметр
		{
		if(param=="str")
			{
				stren=stren+0.2f;
			}
		else if(param=="int")
			{
				intel=intel+0.2f;
			}
		else if(param=="speed")
			{
				speed=speed+0.2f;
			}
		else if(param=="luck")
			{
				luck=luck+0.2f;
			}
		}
	public void pay(int cost)
	{
		money-=cost;
	}
}
