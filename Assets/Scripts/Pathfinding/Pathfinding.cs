using System;
using System.Collections.Generic;
using UnityEngine;

namespace IA
{
    public abstract class Pathfinding : MonoBehaviour
    {

        public Board board;
        public List<Tile> tilesSearch = new List<Tile>();
        public abstract List<Tile> Search(Tile tileStart, Func<Tile, Tile, bool> searchType);

        public virtual bool ValidateMovement(Tile from, Tile to)
        {
            return (
              to.obj != null
            );
        }

        public void ClearSeach()
        {
            foreach (Tile tile in board.tiles.Values)
            {
                // if( tile.obj != null ) continue;
                tile.costFromOrigin = int.MaxValue;
                tile.costToObjective = int.MaxValue;
                tile.costTotal = int.MaxValue;
                tile.previous = null;
            }
        }
        public List<Tile> BuildPath(Tile lastTile)
        {
            List<Tile> path = new List<Tile>();
            Tile tile = lastTile;
            while (tile.previous != null)
            {
                path.Add(tile);
                tile = tile.previous;
            }
            path.Add(tile);
            path.Reverse();
            return path;
        }
        protected void swapReference(ref Queue<Tile> checkNow, ref Queue<Tile> checkNext)
        {
            Queue<Tile> temp = checkNow;
            checkNow = checkNext;
            checkNext = temp;
        }

    }
}
