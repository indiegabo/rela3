using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace IndieGabo.Rela3.GameModes
{
    public class SimpleModeStateEvaluateMatches : SimpleModeState
    {
        private Board _board;

        public SimpleModeStateEvaluateMatches(SimpleMode simpleMode) : base(simpleMode)
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
            // _currenMatches
            this._board.EvaluateMatch(this._board.swapedA);
            this._board.EvaluateMatch(this._board.swapedB);

            Debug.Log(this._board.currentMatches.Count);

            if (this._board.currentMatches.Count == 0)
            {
                // Case there is no match, swap back and return to Input Check
                this._board.SwapTilesItems(this._board.swapedA, this._board.swapedB);
                _simpleMode.stateMachine.SetActiveState(_simpleMode.simpleModeStateInputCheck);

            }
            else if (this._board.currentMatches.Count > 0)
            {
                // Case there is at least one match, apply matches and move state to
                // Reordering.
                foreach (Match match in this._board.currentMatches)
                {
                    this._board.ApplyMatch(match);
                }
                _simpleMode.stateMachine.SetActiveState(_simpleMode.simpleModeStateReordering);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
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
