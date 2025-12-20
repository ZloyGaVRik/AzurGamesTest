using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Object _heroesScreen;

    [SerializeField] private Button _backButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _leftButton;

    [SerializeField] private TextMeshProUGUI _resourceCount;
    [SerializeField] private TextMeshProUGUI _coinCount;


    public Object HeroesScreen => _heroesScreen;
    public Button BackButton => _backButton;
    public Button RightButton => _rightButton;
    public Button LeftButton => _leftButton;
    public TextMeshProUGUI ResourceCount => _resourceCount;
    public TextMeshProUGUI CoinCount => _coinCount;

    [Header("Heroes Panel")]
    [SerializeField] private Image _heroesImage;

    [SerializeField] private Object _skillPanel;
    [SerializeField] private Object _statPanel;
    [SerializeField] private Object _slider;

    public Image HeroesImage => _heroesImage;
    public Object SkillPanel => _skillPanel;
    public Object StatPanel => _statPanel;
    public Object Slider => _slider;

}
