using UnityEngine;

[CreateAssetMenu(fileName = "ProductViewData", menuName = "ProductView/ProductViewData")]
public class ProductViewData : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private int price;
    [SerializeField] private EnPriceType priceType;
    [SerializeField] private EnSpawnObjectType spawnObjectType;
    [SerializeField] private string analitycsKey;

    [Space]
    [SerializeField] private GameObject prefab;

    public enum EnPriceType
    {
        FREE,
        MONEY,
        AD,
        DAILY,
    }

    public enum EnSpawnObjectType
    {
        CHARACTER,
        WEAPON,
        INTERACTIVE_OBJECT
    }

    public Sprite Icon
    {
        get => icon;
    }

    public int Price
    {
        get => price;
    }

    public EnPriceType PriceType
    {
        get => priceType;
    }

    public EnSpawnObjectType SpawnObjectType
    {
        get => spawnObjectType;
    }

    public string AnalitycsKey
    {
        get => analitycsKey;
    }

    public GameObject Prefab
    {
        get => prefab;
    }
}