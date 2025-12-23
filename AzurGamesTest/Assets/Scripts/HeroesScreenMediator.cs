using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeroesScreenMediator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float panelsOffset = 500f;
    [SerializeField] private float imageOffset = 300f;
    [SerializeField] private float sliderOffset = 10f;

    private View _view;

    private CanvasGroup _canvasScreen;
    private CanvasGroup _canvasScreenImage;
    private CanvasGroup _canvasInfoPanel;
    private CanvasGroup _canvasStatPanel;

    private RectTransform _rectInfoPanel;
    private RectTransform _rectStatPanel;
    private RectTransform _rectHeroImage;
    private RectTransform _slider;

    private bool _isAnimating;

    private void Awake()
    {
        _view = GetComponent<View>();
        CacheUI();
        BindButtons();
    }

    private void CacheUI()
    {
        _rectInfoPanel = _view.InfoPanel;
        _rectStatPanel = _view.StatPanel;
        _rectHeroImage = _view.HeroesImage;
        _slider = _view.Slider;

        _canvasScreenImage = _view.HeroesImageCanvas;
        _canvasScreen = _view.HeroesScreenCanvas;
        _canvasInfoPanel = _view.InfoPanellCanvas;
        _canvasStatPanel = _view.StatPanelCanvas;
    }

    private void BindButtons()
    {
        _view.BackButton.onClick.AddListener(OnBackButtonClicked);
        _view.LeftButton.onClick.AddListener(() => OnNavigateButtonClicked(isLeft: true));
        _view.RightButton.onClick.AddListener(() => OnNavigateButtonClicked(isLeft: false));
    }

    private void OnSkillButtonClicked(RectTransform btnRect)
    {
        if (_isAnimating) return;

        _isAnimating = true;
        _slider.DOAnchorPosX(btnRect.anchoredPosition.x - sliderOffset, slideDuration)
            .SetEase(Ease.OutBack)
            .OnComplete(() => _isAnimating = false);
    }

    private void OnBackButtonClicked()
    {
        if (_isAnimating) return;

        _isAnimating = true;
        Sequence seq = DOTween.Sequence();
        seq.Append(_canvasScreen.DOFade(0f, fadeDuration))
           .AppendInterval(0.5f)
           .Append(_canvasScreen.DOFade(1f, fadeDuration))
           .OnComplete(() => _isAnimating = false);
    }

    private void OnNavigateButtonClicked(bool isLeft)
    {
        if (_isAnimating) return;

        _isAnimating = true;

        float direction = isLeft ? 1f : -1f;
        Sequence seq = DOTween.Sequence();

        seq.Append(_rectHeroImage.DOAnchorPosX(direction * imageOffset, slideDuration))
           .Join(_canvasScreenImage.DOFade(0f, fadeDuration))
           .Join(_rectInfoPanel.DOAnchorPosX(-panelsOffset, slideDuration).SetEase(Ease.OutBack, 1f))
           .Join(_rectStatPanel.DOAnchorPosX(panelsOffset, slideDuration).SetEase(Ease.OutBack, 1f))
           .Join(_canvasInfoPanel.DOFade(0f, 0.15f))
           .Join(_canvasStatPanel.DOFade(0f, 0.15f));

        seq.Append(_rectHeroImage.DOAnchorPosX(0f, slideDuration))
           .Join(_canvasScreenImage.DOFade(1f, fadeDuration))
           .Join(_rectInfoPanel.DOAnchorPosX(0f, slideDuration).SetEase(Ease.OutBack, 1f))
           .Join(_rectStatPanel.DOAnchorPosX(0f, slideDuration).SetEase(Ease.OutBack, 1f))
           .Join(_canvasInfoPanel.DOFade(1f, 0.15f))
           .Join(_canvasStatPanel.DOFade(1f, 0.15f))
           .OnComplete(() => _isAnimating = false);
    }

    private void OnDestroy()
    {
        _view.BackButton.onClick.RemoveListener(OnBackButtonClicked);
        _view.LeftButton.onClick.RemoveAllListeners();
        _view.RightButton.onClick.RemoveAllListeners();
    }
}