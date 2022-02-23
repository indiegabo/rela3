using System.Collections;
using System.Collections.Generic;
using IndieGabo.Rela3.Items;
using UnityEngine;

namespace IndieGabo.Rela3
{
    public class Tile
    {
        public Vector2 position;
        public string name;
        public GameObject obj;
        public Item item { get; set; }



        #region Pathfinding

        public float costToObjective;
        public float costTotal;
        public float costFromOrigin;
        public float movementCost = 1;
        public Tile previous;


        #endregion

        public Tile(Vector2 position, string name, GameObject obj)
        {
            this.position = position;
            this.name = name;
            this.obj = obj;
        }
    }
}
