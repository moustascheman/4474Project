using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO: Not sure about this. Might be too complex for our purposes. Might just be better to opt for a simpler system of using Ints for ammo count.
//In that case you can use this to just store sprite, description, and displayName info for store/weapon selection

//Scriptable Object used to store data related to stats and visual data of a weapon
[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string displayName;
    public string description;

    public Sprite projectileSprite;
    public GameObject ProjectileAsset;


    public float damage;

    public float explosionRadius;

}
