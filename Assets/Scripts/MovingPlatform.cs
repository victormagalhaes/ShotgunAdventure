using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 endPosition;
    public float duration;
    public bool isRelative = true;
    public LoopType whichLoop = LoopType.Yoyo;
    public Ease whichEase = Ease.InOutSine;

    // Use this for initialization
    void Start()
    {
        Tweener moveTween = transform.DOMove(endPosition, duration);
        moveTween.SetRelative(isRelative);
        moveTween.SetLoops(-1, whichLoop);
        moveTween.SetEase(whichEase);
    }
}
