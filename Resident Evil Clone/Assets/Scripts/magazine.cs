using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazine : MonoBehaviour, Ipickupable
{
    [SerializeField] private int ammoCount;

    [SerializeField] private int ammoCapacity;

    [SerializeField] private string magType;

    [SerializeField] private int reloadAmount;

    int Ipickupable.AmmoCount { get => ammoCount; set => ammoCount = value; }
    int Ipickupable.AmmoCapacity { get => ammoCapacity; set => ammoCapacity = value; }
    string Ipickupable.magType { get => magType; set => magType = value; }

    public int ReloadAmount { get => reloadAmount; set => reloadAmount = value; }
    public void OnDrop(Transform position)
    {
        gameObject.SetActive(true);
        transform.position = position.position;
        gameObject.transform.parent = null;
    }

    public void OnPickup(Player_Controller player)
    {
        player.CurrentMag = this;
        gameObject.SetActive(false);
        gameObject.transform.parent = player.transform;
    }
    public void Reload()
    {
        if (ammoCapacity > 0)
        {
            ammoCount = reloadAmount;
            ammoCapacity -= reloadAmount;
        }
    }
}
