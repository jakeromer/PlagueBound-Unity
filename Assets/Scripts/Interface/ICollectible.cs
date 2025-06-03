using UnityEngine;
using System.Collections.Generic;

public interface ICollectible
{
    string Item { get; }
    void OnPickup(IInventory PlayerInventory, AudioSource PickUpSource);
}
