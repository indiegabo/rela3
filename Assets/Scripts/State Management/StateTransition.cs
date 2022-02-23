using System;
using System.Collections.Generic;
using UnityEngine;
namespace IndieGabo.Rela3.StateManagement
{
    public class StateTransition
    {
        public static List<StateTransition> emptyTransitions = new List<StateTransition>(0);
        public Func<bool> Condition { get; }
        public Func<State> To { get; }

        public StateTransition(Func<State> To, Func<bool> Condition)
        {
            this.To = To;
            this.Condition = Condition;
        }
    }
}
