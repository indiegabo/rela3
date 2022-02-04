using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FallIntoTileTransitionData", menuName = "Transitions/FallIntoTile")]
public class FallIntoTileTransitionData : ScriptableObject
{
    [Header("Bounce")]
    [SerializeField] public AnimationCurve _bounceCurve;
    [SerializeField] [Range(0.1f, 2f)] public float _bounceAnimationTime = 1f;

    [Header("Squeeze")]
    [SerializeField] public AnimationCurve _squeezeCurve;
    [SerializeField] [Range(0.1f, 2f)] public float _squeezeAnimationTime = 1f;
    [SerializeField] public Vector3 _squeezeDestination;
}
