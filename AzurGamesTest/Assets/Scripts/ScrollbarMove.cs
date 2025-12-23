using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarMove : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private float duration = 0.3f;

    public void MoveTo(float targetValue)
    {
        if (scrollbar == null) return;

        DOTween.Kill(scrollbar);

        DOTween.To(
            () => scrollbar.value,
            x => scrollbar.value = x,
            targetValue,
            duration
        )
        .SetEase(Ease.OutCubic)
        .SetTarget(scrollbar)
        .SetUpdate(true);
    }
}
