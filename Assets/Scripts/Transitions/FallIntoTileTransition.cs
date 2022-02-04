using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallIntoTileTransition : MonoBehaviour, ITransition
{

    [Header("Data")]
    [SerializeField] private FallIntoTileTransitionData _data;

    // Bounce
    private AnimationCurve _bounceCurve;
    private float _bounceAnimationTime = 1f;

    // Squeeze
    private AnimationCurve _squeezeCurve;
    private float _squeezeAnimationTime = 1f;
    private Vector3 _squeezeDestination;

    private void Awake()
    {
        // Loading Bounce info
        this._bounceCurve = this._data._bounceCurve;
        this._bounceAnimationTime = this._data._bounceAnimationTime;

        // Loading Squeeze info
        this._squeezeCurve = this._data._squeezeCurve;
        this._squeezeAnimationTime = this._data._squeezeAnimationTime;
        this._squeezeDestination = this._data._squeezeDestination;
    }

    public void TransitionTo(Tile tile)
    {
        StartCoroutine(Move(tile.position));
        StartCoroutine(Scale());
    }


    IEnumerator Move(Vector3 destination)
    {
        // Remember to remove the setdelay
        int id = LeanTween.move(gameObject, destination, this._bounceAnimationTime).setEase(this._bounceCurve).setDelay(1).id;

        while (LeanTween.descr(id) != null)
        {
            yield return null;
        }
    }
    IEnumerator Scale()
    {
        // Remember to remove the setdelay
        int id = LeanTween.scale(gameObject, this._squeezeDestination, this._squeezeAnimationTime).setEase(this._squeezeCurve).setDelay(1f).id;

        while (LeanTween.descr(id) != null)
        {
            yield return null;
        }
    }
}
