using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ipickupable
{
    int AmmoCount { get; set; }
    int AmmoCapacity { get; set; }

    string magType { set; get; }
    void OnPickup(Player_Controller player);

    void OnDrop();
}
