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

    private void Awake()
    {
        // Loading Bounce info
        this._bounceCurve = this._data.bounceCurve;
        this._bounceAnimationTime = this._data.bounceAnimationTime;

        // Loading Squeeze info
        this._squeezeCurve = this._data.squeezeCurve;
        this._squeezeAnimationTime = this._data.squeezeAnimationTime;
    }

    public void TransitionTo(Tile tile)
    {
        StartCoroutine(Move(tile.position));
        StartCoroutine(Scale());
    }


    IEnumerator Move(Vector2 destination)
    {
        // Remember to remove the setdelay
        int id = LeanTween.move(gameObject, destination, this._bounceAnimationTime).setEase(this._bounceCurve).id;

        while (LeanTween.descr(id) != null)
        {
            yield return null;
        }
    }
    IEnumerator Scale()
    {
        // Remember to remove the setdelay
        float newScaledX = this.transform.localScale.x - this._data.squeezeFactor;
        float newScaledY = this.transform.localScale.y + this._data.squeezeFactor;
        Vector3 squeezeDestination = new Vector3(newScaledX, newScaledY, this.transform.localScale.z);
        int id = LeanTween.scale(gameObject, squeezeDestination, this._squeezeAnimationTime).setEase(this._squeezeCurve).id;

        while (LeanTween.descr(id) != null)
        {
            yield return null;
        }
    }
}
