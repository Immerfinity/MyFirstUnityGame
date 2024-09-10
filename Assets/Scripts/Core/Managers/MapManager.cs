using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class MapManager
    {
        private StateManager stateManager;
        public Map Map { get; private set; }
        public MapManager(StateManager stateManager, Map startingMap)
        {
            this.stateManager = stateManager;
            Map = GameObject.Instantiate(startingMap);
        }
        public void LoadMap(Map newMap, int destinationId)
        {
            SwapMap(newMap);

            LocatePlayerOnNewMap(destinationId);
        }
        private void SwapMap(Map newMap)
        {
            Map oldMap = Map;
            Map = GameObject.Instantiate(newMap);
            GameObject.Destroy(oldMap.gameObject);
        }
        private void LocatePlayerOnNewMap(int destinationId)
        {
            Transfer[] transfers = GameObject.FindObjectsOfType<Transfer>();
            Transfer transfer = transfers.Where(transfer => transfer.Id == destinationId).ToList().FirstOrDefault();
            Game.Player.transform.position = transfer.Cell.Center2D();
        }
    }
}