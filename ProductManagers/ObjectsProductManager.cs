using System.Collections.Generic;
using UnityEngine;

public class ObjectsProductManager : Singleton<ObjectsProductManager>, IProductManager
{
    [SerializeField] private List<ProductViewData> objectsViewDatas = new List<ProductViewData>();

    public List<ProductViewData> GetAllProductDatas()
    {
        return objectsViewDatas;
    }

    public int GetCurrentProductIndex()
    {
        if (!PlayerPrefs.HasKey("CurrentObjectIndex"))
        {
            return 0;
        }
        else
        {
            return PlayerPrefs.GetInt("CurrentObjectIndex", -1);
        }
    }

    public bool HasProduct(int _index)
    {
        return PlayerPrefs.HasKey("InteractiveObject " + _index);
    }

    public void SaveCurrentProduct(int _index)
    {
        PlayerPrefs.SetInt("CurrentObjectIndex", _index);
    }

    public void SaveUnlockProduct(int _index)
    {
        PlayerPrefs.SetInt("InteractiveObject " + _index, 1);
    }
}
