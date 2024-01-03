using System.Collections.Generic;
using UnityEngine;

public class ProductCreator : MonoBehaviour
{
    [SerializeField] private ProductView productViewPrefab;

    [Space]
    [SerializeField] private Transform viewsParent;

    private List<ProductViewData> productDatas = new List<ProductViewData>();
    private List<ProductView> productViews = new List<ProductView>();

    private int productIndex;

    private void Awake()
    {
        CreateProducts();
    }

    private void CreateProducts()
    {
        productDatas = ProductManager.Instance.GetAllProductDatas();

        for (int i = 0; i < productDatas.Count; i++)
        {
            ProductView spawnedProductView = Instantiate(productViewPrefab, viewsParent);
            spawnedProductView.Init(productDatas[i], i, ButtonBuy);
            spawnedProductView.UpdateView();
            productViews.Add(spawnedProductView);
        }
    }

    private void ChooseProduct(int _index)
    {
        productViews[_index].UpdateView();
        productViews[_index].OpenProduct();
        productViews[_index].UpdateChooseView();

        productIndex = _index;
    }

    private void ButtonBuy(int _index, string _analitycsKey, ProductViewData.EnPriceType _priceType)
    {
        switch (_priceType)
        {
            case ProductViewData.EnPriceType.FREE:

                ChooseProduct(_index);

                break;

            case ProductViewData.EnPriceType.MONEY:

                if (CurrencySystem.Instance.Take(productDatas[_index].Price))
                {
                    ChooseProduct(_index);
                }

                break;

            case ProductViewData.EnPriceType.AD:

                if (AdsManager.IsRewardedAvailable())
                {
                    AdsManager.ShowRewarded(() =>
                    {
                        AnalyticsEventer.AddLog(_analitycsKey);

                        ChooseProduct(_index);
                    });
                }
                else
                {
                    NoAdsConnection.Instance.StartAnimation();
                }

                break;

            case ProductViewData.EnPriceType.DAILY:

                break;
        }
    }
}
