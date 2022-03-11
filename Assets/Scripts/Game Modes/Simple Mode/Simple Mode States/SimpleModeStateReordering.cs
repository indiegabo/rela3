using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieGabo.Rela3.Items;
using System.Threading.Tasks;

namespace IndieGabo.Rela3.GameModes
{
    public class SimpleModeStateReordering : SimpleModeState
    {
        private Board _board;
        private ItemFactory _itemFactory;
        private List<Match> _matchesOnEnter = new List<Match>();
        private bool _reordering = false;

        public SimpleModeStateReordering(SimpleMode simpleMode) : base(simpleMode)
        {
            this._board = simpleMode.core.board;
            this._itemFactory = simpleMode.core.itemFactory;
        }

        public override void Tick()
        {
            base.Tick();
        }

        public override void FixedTick()
        {
            base.FixedTick();

            if (!_reordering)
            {
                this._board.currentMatches.Clear();

                if (this.EvaluateNewMatches())
                {
                    this._simpleMode.ChangeState(this._simpleMode.simpleModeStateMatchHandling);
                }
                else
                {
                    this._simpleMode.ChangeState(this._simpleMode.simpleModeStateInputCheck);
                }
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            this._matchesOnEnter = new List<Match>(this._board.currentMatches);
            this._reordering = true;
            this.Reorder();

        }

        public override void OnExit()
        {
            base.OnExit();
            this._matchesOnEnter.Clear();
        }

        private async void Reorder()
        {
            Task[] tasks = new Task[this._board.columns];

            for (int column = 0; column < this._board.columns; column++)
            {
                tasks[column] = this.FixColumn(column);
            }

            await Task.WhenAll(tasks);

            this._reordering = false;
        }

        private async Task FixColumn(int column)
        {
            for (int row = 0; row < this._board.rows; row++)
            {
                Vector2 tilePos = new Vector2(column, row);
                this.MoveTile(this._board.GetTile(tilePos));
                await Task.Yield();
            }
        }

        private void MoveTile(Tile tile)
        {
            if (tile.item != null) return;

            Vector2 abovePosition = tile.position + Vector2.up;

            // se a posição de cima sai da board, não continua

            if (abovePosition.y >= this._board.rows)
            {
                this.InstantiateAndBring(tile);
            }
            else
            {

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
                    this.InstantiateAndBring(tile);
                }
                else
                {
                    tile.BringItemFrom(aboveTile);
                }

            }
        }

        private void InstantiateAndBring(Tile tile)
        {
            Tile lastColumnTile = this._board.LastColumnTile((int)tile.position.x);

            if (tile.position != lastColumnTile.position)
            {
                this._itemFactory.SpawnRandomItemOnBoard(lastColumnTile, this._board);
                tile.BringItemFrom(lastColumnTile);
            }
            else
            {
                this._itemFactory.SpawnRandomItemOnBoard(lastColumnTile, this._board);
            }
        }

        private bool EvaluateNewMatches()
        {
            for (int x = 0; x < this._board.rows; x++)
            {
                for (int y = 0; y < this._board.columns; y++)
                {
                    Vector2 pos = new Vector2(x, y);
                    Tile tile = this._board.GetTile(pos);
                    this._board.EvaluateMatch(tile);
                }
            }

            return this._board.currentMatches.Count > 0;
        }
    }

}
