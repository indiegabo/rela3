using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;

namespace IndieGabo.Rela3.GameModes
{
    public class SimpleModeStateMatchHandling : SimpleModeState
    {
        private Board _board;
        private bool matchsToHandle => this._board.currentMatches.Count > 0;
        private bool matchesHandled = false;

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

            if (this.matchesHandled)
            {
                this._simpleMode.ChangeState(this._simpleMode.simpleModeStateReordering);
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            this.matchesHandled = false;
            // GenericLogger.I?.Success($"Handling Matches");

            // Evaluating possible matches. Case matches are found we put them in 

            if (matchsToHandle)
            {
                // Handle matches
                this.HandleMatches();
            }
            else
            {
                this._simpleMode.ChangeState(this._simpleMode.simpleModeStateInputCheck);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            this.matchesHandled = false;
        }

        private async void HandleMatches()
        {

            foreach (Match match in this._board.currentMatches)
            {
                await this._board.ApplyMatch(match);
                await Task.Delay(250);
            }

            this.matchesHandled = true;
        }
    }
}
