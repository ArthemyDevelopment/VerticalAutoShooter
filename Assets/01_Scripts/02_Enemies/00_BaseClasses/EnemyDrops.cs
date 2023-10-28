

using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public DropChances CurrentDropChances;


    public void Drop()
    {
        GameObject ItemToDrop = CurrentDropChances.GetDrop();
        if (ItemToDrop != null)
            Instantiate(ItemToDrop, transform.position, ItemToDrop.transform.rotation);
    }
    
    
}
