using Battle;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Region", menuName = "New Region")]
public class BattleRegion : ScriptableObject
{
    [SerializeField] private List<EnemyPack> enemyPacks;

    public static int currentIndex = 0;

    public EnemyPack GetEnemyPack()
    {
        var enemyPack = enemyPacks[currentIndex];
        currentIndex = (currentIndex + 1) % enemyPacks.Count;

        if (currentIndex == enemyPacks.Count + 1)
        {
            currentIndex = 0;
        }
        else
            return enemyPack;

        return enemyPacks[currentIndex];
    }

    public void CheckForEncounter(Map map)
    {
        if (Party.activeMembers.Count > 0)
        {
            EnemyPack enemyPack = GetEnemyPack();
            Game.Battle.StartBattle(enemyPack);
        }
    }
}

