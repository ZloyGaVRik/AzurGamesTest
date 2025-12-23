using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [Header("UI References")]
    public CanvasGroup HeroesScreenCanvas;
    public CanvasGroup HeroesImageCanvas;
    public CanvasGroup InfoPanellCanvas;
    public CanvasGroup StatPanelCanvas;

    public RectTransform HeroesImage;
    public RectTransform InfoPanel;
    public RectTransform StatPanel;
    public RectTransform Slider;

    public Button BackButton;
    public Button RightButton;
    public Button LeftButton;
}