using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(TMP_Text))]
public class DOText : MonoBehaviour
{
    [SerializeField] private float _duration = 2f;
    [SerializeField] private float _delay = 2f;

    private void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        Sequence sequence = DOTween.Sequence();

        sequence.Append(text.DOText("Этот текст был изменен", _duration).SetDelay(_delay));
        sequence.Append(text.DOText(" ,а этот текст был добавлен", _duration).SetRelative().SetDelay(_delay));
        sequence.Append(text.DOText("Этот текст был изменен с перебором",_duration, true, ScrambleMode.All).SetDelay(_delay));

        sequence.SetLoops(-1, LoopType.Incremental);
    }
}
