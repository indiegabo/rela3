using System.Collections;
using System.Collections.Generic;
using IndieGabo.Rela3.Items;
using UnityEngine;
using IndieGabo.Rela3.Transitions;

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

        public void RemoveItem()
        {
            if (this.item == null) return;

            this.item.Remove();
            this.item = null;
        }

        public void BringItemFrom(Tile tile)
        {
            ITransition itemTransition = tile.item.GetComponent<ITransition>();
            itemTransition.TransitionTo(this);

            this.item = tile.item;
            this.item.transform.parent = this.obj.transform;
            tile.item = null;
        }
    }
}
