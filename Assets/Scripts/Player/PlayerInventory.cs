using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlayerInventory: IInventory
{
    private List<ICollectible> BodyParts = new List<ICollectible>();

    public void AddItem(ICollectible BodyPart)
    {
        BodyParts.Add(BodyPart);
    }

    public bool HasItem(string BodyPartName)
    {
        return BodyParts.Any(BodyPart => BodyPart.Item == BodyPartName);
    }

    public int ItemCount()
    {
        return BodyParts.Count;
    }
}
