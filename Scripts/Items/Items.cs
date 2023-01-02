using UnityEngine;
[CreateAssetMenu (fileName = "New Item", menuName ="Item")]
public class Items : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int itemCost;
    public float itemWeight;
    public string itemDesc;
    public bool isDefault=false;
    public virtual void Use ()
	{
		Debug.Log("Using " + name);
	}
    
    public void RemoveFromInventory()
    {
        // inventory.instance.dellItem(this);
    }
}
