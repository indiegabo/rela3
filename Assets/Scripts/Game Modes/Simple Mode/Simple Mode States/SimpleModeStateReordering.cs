using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieGabo.Rela3.GameModes
{
    public class SimpleModeStateReordering : SimpleModeState
    {
        private Board _board;

        public SimpleModeStateReordering(SimpleMode simpleMode) : base(simpleMode)
        {
            this._board = simpleMode.core.board;
        }

        public override void Tick()
        {
            base.Tick();
        }

        public override void FixedTick()
        {
            base.FixedTick();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Entered Reordering");
            this.Reorder();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        private void Reorder()
        {
            Debug.Log("Entered Reordering");

            for (int x = 0; x < this._board.xSize; x++)
            {
                for (int y = 0; y < this._board.ySize; y++)
                {
                    Debug.Log($"[{x}][{y}]");
                }
            }
        }

        private void Move(Tile tile)
        {

        }
    }

}
