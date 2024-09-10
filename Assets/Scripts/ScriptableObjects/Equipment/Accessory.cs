using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Accessory", menuName = "New Accessory")]
public class Accessory : Equipment
{
    [SerializeField] private EquipmentEffect effect;

    public EquipmentEffect Effect => effect;
}
