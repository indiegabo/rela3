using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Test : MonoBehaviour
{

    [Header("Bounce")]
    [SerializeField] private AnimationCurve _bounceCurve;
    [SerializeField] [Range(0.1f, 2f)] private float _bounceAnimationTime = 1f;
    [SerializeField] private Vector3 _bounceDestination;

    [Header("Squeeze")]
    [SerializeField] private AnimationCurve _squeezeCurve;
    [SerializeField] [Range(0.1f, 2f)] private float _squeezeAnimationTime = 1f;
    [SerializeField] private Vector3 _squeezeDestination;

    void Awake()
    {
    }
    private void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(Scale());
    }

    IEnumerator Move()
    {
        // Remember to remove the setdelay
        int id = LeanTween.move(gameObject, this._bounceDestination, this._bounceAnimationTime).setEase(this._bounceCurve).setDelay(1).id;

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
