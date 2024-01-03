using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProductView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text price;

    [SerializeField] private Image chosenIndicator;

    [Header("Price")]
    [SerializeField] private GameObject moneyPriceBackground = null;
    [SerializeField] private GameObject adPriceBackground = null;
    [SerializeField] private GameObject dailyPriceBackground = null;

    private ProductViewData.EnPriceType priceType;

    private int productIndex;
    private string analitycsKey;

    private event Action<int, string, ProductViewData.EnPriceType> OnBuy;

    public void Init(ProductViewData _productViewData, int _index, Action<int, string, ProductViewData.EnPriceType> _onBuy)
    {
        productIndex = _index;

        icon.sprite = _productViewData.Icon;
        price.text = _productViewData.Price.ToString();
        priceType = _productViewData.PriceType;

        analitycsKey = _productViewData.AnalitycsKey;

        SetPreviewPriceView(true);

        OnBuy = _onBuy;
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void SetPreviewPriceView(bool _state)
    {
        moneyPriceBackground.SetActive(priceType == ProductViewData.EnPriceType.MONEY && _state);
        adPriceBackground.SetActive(priceType == ProductViewData.EnPriceType.AD && _state);
        dailyPriceBackground.SetActive(priceType == ProductViewData.EnPriceType.DAILY && _state);
    }

    private void Click()
    {
        OnBuy?.Invoke(productIndex, analitycsKey, priceType);
    }

    public void UpdateView()
    {
        priceType = ProductManager.Instance.HasProduct(productIndex) ? ProductViewData.EnPriceType.FREE : priceType;

        SetPreviewPriceView(true);
    }

    public void OpenProduct()
    {
        ProductManager.Instance.SaveUnlockProduct(productIndex);

        priceType = ProductViewData.EnPriceType.FREE;
        SetPreviewPriceView(false);
    }

    public void UpdateChooseView()
    {
        DOTween.Sequence()
            .AppendCallback(() => chosenIndicator.DOFade(1, 0.5f))
            .AppendInterval(0.3f)
            .AppendCallback(() => chosenIndicator.DOFade(0, 0.5f));
    }
}