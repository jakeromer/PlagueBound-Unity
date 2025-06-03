using UnityEngine;

public interface IInventory
{
    void AddItem(ICollectible item);
    bool HasItem(string BodyPart);
}
