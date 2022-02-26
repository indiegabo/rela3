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

            for (int column = 0; column < this._board.columns; column++)
            {
                this.FixColumn(column);
            }
        }

        private void FixColumn(int column)
        {
            for (int row = 0; row < this._board.rows; row++)
            {
                Vector2 tilePos = new Vector2(column, row);
                this.MoveTile(this._board.GetTile(tilePos));
            }
        }

        private void MoveTile(Tile tile)
        {
            if (tile.item != null) return;

            Vector2 abovePosition = tile.position + Vector2.up;

            // se a posição de cima sai da board, não continua

            if (abovePosition.y >= this._board.rows)
            {
                return;
            }

            Tile aboveTile = this._board.GetTile(abovePosition);

            while (aboveTile != null && aboveTile.item == null)
            {
                abovePosition = aboveTile.position + Vector2.up;

                if (abovePosition.y >= this._board.rows)
                {
                    aboveTile = null;
                }
                else
                {
                    aboveTile = this._board.GetTile(abovePosition);
                }

            }

            if (aboveTile == null)
            {
                return;
            }
            else
            {
                tile.BringItemFrom(aboveTile);
            }
        }
    }

}
