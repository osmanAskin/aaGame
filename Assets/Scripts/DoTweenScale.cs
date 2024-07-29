using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenScale : MonoBehaviour
{
    [SerializeField] private GameObject rotatorObject;

    private Vector2 originalScale;
    private Vector2 scaleTo;

    public void RotatorScaleIncrease() 
    {
        //increase 
        originalScale = transform.localScale;
        scaleTo = originalScale * 6;
        transform.DOScale(scaleTo, 4f);
    }
}
