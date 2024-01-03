using System.Collections.Generic;

public class ProductManager : Singleton<ProductManager>
{
    private IProductManager productManager;

    public void Init(int _index)
    {
        switch (_index)
        {
            case 0:
                productManager = CharacterProductManager.Instance;
                break;

            case 1:
                productManager = WeaponProductManager.Instance;
                break;

            case 2:
                productManager = ObjectsProductManager.Instance;
                break;
        }
    }

    public List<ProductViewData> GetAllProductDatas()
    {
        return productManager.GetAllProductDatas();
    }

    public bool HasSProduct(int _index)
    {
        return productManager.HasProduct(_index);
    }

    public void SaveUnlockProduct(int _index)
    {
        productManager.SaveUnlockProduct(_index);
    }

    public void SaveCurrentProduct(int _index)
    {
        productManager.SaveCurrentProduct(_index);
    }

    public int GetCurrentProductIndex()
    {
        return productManager.GetCurrentProductIndex();
    }
}