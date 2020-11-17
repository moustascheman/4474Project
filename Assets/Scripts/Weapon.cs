using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public string displayName;
    public string description;

    public Sprite projectileSprite;

    public float weight;
    public float damage;

}
