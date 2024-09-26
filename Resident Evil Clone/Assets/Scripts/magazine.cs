using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazine : MonoBehaviour, Ipickupable
{
    [SerializeField] private GameObject magPrefab;

    [SerializeField] private int ammoCount;

    [SerializeField] private int ammoCapacity;

    [SerializeField] private string magType;
    int Ipickupable.AmmoCount { get => ammoCount; set => ammoCount = value; }
    int Ipickupable.AmmoCapacity { get => ammoCapacity; set => ammoCapacity = value; }
    string Ipickupable.magType { get => magType; set => magType = value; }
    public void OnDrop()
    {
        GameObject mag = Instantiate(magPrefab, transform.position, transform.rotation);
    }

    public void OnPickup(Player_Controller player)
    {
        player.CurrentMag = Instantiate(this);
        Destroy(gameObject);
    }
}
