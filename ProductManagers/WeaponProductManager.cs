using System.Collections.Generic;
using UnityEngine;

public class WeaponProductManager : Singleton<WeaponProductManager>, IProductManager
{
    [SerializeField] private List<ProductViewData> weaponsViewDatas = new List<ProductViewData>();

    public List<ProductViewData> GetAllProductDatas()
    {
        return weaponsViewDatas;
    }

    public int GetCurrentProductIndex()
    {
        if (!PlayerPrefs.HasKey("CurrentWeaponIndex"))
        {
            return 0;
        }
        else
        {
            return PlayerPrefs.GetInt("CurrentWeaponIndex", -1);
        }
    }

    public bool HasProduct(int _index)
    {
        return PlayerPrefs.HasKey("Weapon " + _index);
    }

    public void SaveCurrentProduct(int _index)
    {
        PlayerPrefs.SetInt("CurrentWeaponIndex", _index);
    }

    public void SaveUnlockProduct(int _index)
    {
        PlayerPrefs.SetInt("Weapon " + _index, 1);
    }
}