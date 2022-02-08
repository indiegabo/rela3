using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FallIntoTileTransitionData", menuName = "Transitions/FallIntoTile")]
public class FallIntoTileTransitionData : ScriptableObject
{
    [Header("Bounce")]
    [SerializeField] private AnimationCurve _bounceCurve;
    [SerializeField] [Range(0.1f, 2f)] private float _bounceAnimationTime = 1f;

    [Header("Squeeze")]
    [SerializeField] private AnimationCurve _squeezeCurve;
    [SerializeField] [Range(0.1f, 2f)] private float _squeezeAnimationTime = 1f;
    [SerializeField] [Range(0.1f, 1f)] private float _squeezeFactor = 0.1f;

    public AnimationCurve bounceCurve => this._bounceCurve;
    public float bounceAnimationTime => this._bounceAnimationTime;
    public AnimationCurve squeezeCurve => this._squeezeCurve;
    public float squeezeAnimationTime => this._squeezeAnimationTime;
    public float squeezeFactor => this._squeezeFactor;
}
