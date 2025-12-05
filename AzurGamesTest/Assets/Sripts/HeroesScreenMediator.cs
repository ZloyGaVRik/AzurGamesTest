using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class HeroesScreenMediator : MonoBehaviour
{
    private View _view;

    private CanvasGroup _canvasScreen;
    private CanvasGroup _canvasSkillPanel;
    private CanvasGroup _canvasStatPanel;

    private RectTransform _rectSkill;
    private RectTransform _rectStat;
    private RectTransform _rect;

    private DG.Tweening.Sequence _seq;

    private void Awake()
    {
        _view = GetComponent<View>();

        _rectSkill = _view.SkillPanel.GetComponent<RectTransform>();
        _rectStat = _view.StatPanel.GetComponent<RectTransform>();
        _rect = _view.HeroesImage.GetComponent<RectTransform>();

        _canvasScreen = _view.HeroesImage.GetComponent<CanvasGroup>();
        _canvasSkillPanel = _view.SkillPanel.GetComponent<CanvasGroup>();
        _canvasStatPanel = _view.StatPanel.GetComponent<CanvasGroup>();

        _view.BackButton.onClick.AddListener(OnBackButtonClicked);
        _view.LeftButton.onClick.AddListener(OnLeftButtonClicked);
        _view.RightButton.onClick.AddListener(OnRightButtonClicked);

    }

    private void OnBackButtonClicked()
    {
        _canvasScreen = _view.HeroesScreen.GetComponent<CanvasGroup>();

        if (_seq != null && _seq.IsActive())
            _seq.Kill();

        _seq = DOTween.Sequence();

        _seq.Append(_canvasScreen.DOFade(0f, 0.5f))
            .AppendInterval(2f)
            .Append(_canvasScreen.DOFade(1f, 0.5f));
    }

    private void OnRightButtonClicked()
    {
        if (_seq != null && _seq.IsActive())
            _seq.Kill();

        _seq = DOTween.Sequence();

        _seq.Append(_rect.DOAnchorPos(new Vector2(-300f, _rect.anchoredPosition.y), 0.5f))
            .Join(_canvasScreen.DOFade(0f, 0.5f))
            .Join(_rectSkill.DOAnchorPos(new Vector2(-500f, _rectSkill.anchoredPosition.y), 1f).SetEase(Ease.OutBack, 1.0f))
            .Join(_rectStat.DOAnchorPos(new Vector2(500f, _rectStat.anchoredPosition.y), 1f).SetEase(Ease.OutBack, 1.0f))
            .Join(_canvasSkillPanel.DOFade(0f, 0.15f))
            .Join(_canvasStatPanel.DOFade(0f, 0.15f));

        _seq.Append(_rect.DOAnchorPos(new Vector2(100f, _rect.anchoredPosition.y), 0.5f))
            .Append(_rect.DOAnchorPos(new Vector2(0f, _rect.anchoredPosition.y), 0.5f))
            .Join(_canvasScreen.DOFade(1f, 0.5f))
            .Join(_rectSkill.DOAnchorPos(new Vector2(0f, _rectSkill.anchoredPosition.y), 1f).SetEase(Ease.OutBack, 1.0f))
            .Join(_rectStat.DOAnchorPos(new Vector2(0f, _rectStat.anchoredPosition.y), 1f).SetEase(Ease.OutBack, 1.0f))
            .Join(_canvasSkillPanel.DOFade(1f, 0.15f))
            .Join(_canvasStatPanel.DOFade(1f, 0.15f));
    }

    private void OnLeftButtonClicked()
    {

        if (_seq != null && _seq.IsActive())
            _seq.Kill();

        _seq = DOTween.Sequence();

        _seq.Append(_rect.DOAnchorPos(new Vector2(300f, _rect.anchoredPosition.y), 0.5f))
            .Join(_canvasScreen.DOFade(0f, 0.5f))
            .Join(_rectSkill.DOAnchorPos(new Vector2(-500f, _rectSkill.anchoredPosition.y), 1f).SetEase(Ease.OutBack, 1.0f))
            .Join(_rectStat.DOAnchorPos(new Vector2(500f, _rectStat.anchoredPosition.y), 1f).SetEase(Ease.OutBack, 1.0f))
            .Join(_canvasSkillPanel.DOFade(0f, 0.15f))
            .Join(_canvasStatPanel.DOFade(0f, 0.15f));

        _seq.Append(_rect.DOAnchorPos(new Vector2(100f, _rect.anchoredPosition.y), 0.5f))
            .Append(_rect.DOAnchorPos(new Vector2(0f, _rect.anchoredPosition.y), 0.5f))
            .Join(_canvasScreen.DOFade(1f, 0.5f))
            .Join(_rectSkill.DOAnchorPos(new Vector2(0f, _rectSkill.anchoredPosition.y), 1f).SetEase(Ease.OutBack, 1.0f))
            .Join(_rectStat.DOAnchorPos(new Vector2(0f, _rectStat.anchoredPosition.y), 1f).SetEase(Ease.OutBack, 1.0f))
            .Join(_canvasSkillPanel.DOFade(1f, 0.15f))
            .Join(_canvasStatPanel.DOFade(1f, 0.15f));
    }


    private void OnDestroy()
    {
        _view.BackButton.onClick.RemoveListener(OnBackButtonClicked);
        _view.LeftButton.onClick.RemoveListener(OnLeftButtonClicked);
        _view.RightButton.onClick.RemoveListener(OnRightButtonClicked);
    }

}
