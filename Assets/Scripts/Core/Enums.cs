using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public enum Dir
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    }

    public enum GameState
    {
        World,
        Dialogue,
        Cutscene,
        Battle,
        Menu,
        BarMenu,
    }

    public enum EquipmentEffect
    {
        None,
        IncreasedLoot,
        IncreasedMaxHP,
    }
    public enum Job
    {
        Needly,
        Cleric,
        Mage,
        Burdukow,
    }
}
