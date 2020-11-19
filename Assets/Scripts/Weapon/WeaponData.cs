using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Scriptable Object used to store data related to stats and visual data of a weapon
[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string displayName;
    public string description;

    public Sprite projectileSprite;
    public GameObject ProjectileModel;
    public RawImage buttonIcon;

    public float damage;

    public float explosionRadius;

}
