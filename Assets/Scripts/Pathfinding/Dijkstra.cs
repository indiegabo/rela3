using System;
using System.Collections.Generic;
using UnityEngine;
using IndieGabo.Rela3;

namespace IA
{
    public class Dijkstra : Pathfinding
    {
        public int searchLength = 8;
        private Vector2[] directions = new Vector2[4]
        {
            Vector2.up,
            Vector2.right,
            Vector2.down,
            Vector2.left
        };

        private int findType;
        public override bool ValidateMovement(Tile from, Tile to)
        {
            return !(
              to.item?.type != from.item?.type ||
              to.costFromOrigin > searchLength
            );
        }

        public override List<Tile> Search(Tile tileStart, Func<Tile, Tile, bool> searchType)
        {
            ClearSeach();
            tilesSearch = new List<Tile>();
            tilesSearch.Add(tileStart);
            Queue<Tile> checkNow = new Queue<Tile>();
            Queue<Tile> checkNext = new Queue<Tile>();
            tileStart.costFromOrigin = 0;
            checkNow.Enqueue(tileStart);
            while (checkNow.Count > 0)
            {
                Tile current = checkNow.Dequeue();
                SearchAdjacent(current, checkNext, searchType);
                if (checkNow.Count == 0)
                {
                    swapReference(ref checkNow, ref checkNext);
                }
            }
            return tilesSearch;
        }
        private void SearchAdjacent(Tile current, Queue<Tile> checkNext, Func<Tile, Tile, bool> searchType)
        {
            foreach (Vector2 direction in directions)
            {
                Tile next = board.GetTile(current.position + direction);
                if (next == null || next.costFromOrigin <= current.costFromOrigin + next.movementCost) continue;
                next.costFromOrigin = current.costFromOrigin + next.movementCost;
                if (searchType(current, next))
                {
                    next.previous = current;
                    if (!tilesSearch.Contains(next))
                    {
                        checkNext.Enqueue(next);
                        tilesSearch.Add(next);
                    }
                }
            }
        }

        public List<Tile> FindPath(Tile from)
        {
            Debug.Log("Initiating Search");
            return Search(from, ValidateMovement);
        }

        public List<Tile> FindPath(Tile from, Func<Tile, Tile, bool> Condition)
        {
            Debug.Log("Initiating Search");
            return Search(from, Condition);
        }

    }
}
