using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IndieGabo.Rela3.GameModes
{
    public class SimpleMode : Entity<SimpleModeCore>
    {
        public List<Match> currentMatches = new List<Match>();
        public SimpleModeStateLoading simpleModeStateLoading;
        public SimpleModeStateInputCheck simpleModeStateInputCheck;
        public SimpleModeStateMatchHandling simpleModeStateMatchHandling;
        public SimpleModeStateReordering simpleModeStateReordering;

        private void Start()
        {
            this.LoadStates();

            this.stateMachine.SetActiveState(this.simpleModeStateLoading);
        }

        private void LoadStates()
        {
            this.simpleModeStateLoading = new SimpleModeStateLoading(this);
            this.simpleModeStateInputCheck = new SimpleModeStateInputCheck(this);
            this.simpleModeStateMatchHandling = new SimpleModeStateMatchHandling(this);
            this.simpleModeStateReordering = new SimpleModeStateReordering(this);
        }
    }
}
