using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace IndieGabo.Rela3.GameModes
{
    public class SimpleModeStateEvaluateMatches : SimpleModeState
    {
        private Board _board;
        private List<Match> _currentMatches = new List<Match>();

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

            this.ApplyMatch(this._board.ScanMatch(_board.swapedA));
            this.ApplyMatch(this._board.ScanMatch(_board.swapedB));

            Debug.Log(this._currentMatches.Count);

            if (this._currentMatches.Count == 0)
            {
                _simpleMode.stateMachine.SetActiveState(_simpleMode.simpleModeStateInputCheck);
            }
            else if (this._currentMatches.Count > 0)
            {
                _simpleMode.stateMachine.SetActiveState(_simpleMode.simpleModeStateReordering);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            this._currentMatches.Clear();
            if (this._board.swapedA != null || this._board.swapedB != null)
            {
                // TODO: Swap back
            }
        }

        private void ApplyMatch(Match match)
        {
            if (match == null) return;

            this._currentMatches.Add(match);

            foreach (Tile tile in match.tiles)
            {
                tile.RemoveItem();
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
