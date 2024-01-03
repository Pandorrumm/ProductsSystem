using System.Collections.Generic;

public interface IProductManager
{
    public List<ProductViewData> GetAllProductDatas();

    public bool HasProduct(int _index);

    public void SaveUnlockProduct(int _index);

    public void SaveCurrentProduct(int _index);

    public int GetCurrentProductIndex();
}