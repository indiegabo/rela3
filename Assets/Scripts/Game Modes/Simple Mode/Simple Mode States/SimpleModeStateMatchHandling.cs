using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace IndieGabo.Rela3.GameModes
{
    public class SimpleModeStateMatchHandling : SimpleModeState
    {
        private Board _board;
        private bool matchsToHandle => this._board.currentMatches.Count > 0;

        public SimpleModeStateMatchHandling(SimpleMode simpleMode) : base(simpleMode)
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

            Debug.Log("Evaluating matches...");

            // Evaluating possible matches. Case matches are found we put them in 

            if (matchsToHandle)
            {
                // Handle matches
                Debug.Log("Entrou no Handle Matches");
                this.HandleMatches();
                this._simpleMode.ChangeState(this._simpleMode.simpleModeStateReordering);
            }
            else
            {
                this._simpleMode.ChangeState(this._simpleMode.simpleModeStateInputCheck);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        private void HandleMatches()
        {
            foreach (Match match in this._board.currentMatches)
            {
                this._board.ApplyMatch(match);
            }
        }


        // Debug Stuff

        private void DebugTiles(List<Tile> tiles, string title = "Debugging List:")
        {
            if (tiles.Count <= 0) return;

            Debug.Log(title);

            foreach (Tile dTile in tiles)
            {
                Debug.Log($"Tile [{dTile.position.x}][{dTile.position.y}] - {dTile.item.type}");
            }
        }
    }
}
