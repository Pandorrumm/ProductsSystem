using System.Collections.Generic;
using UnityEngine;

public class CharacterProductManager : Singleton<CharacterProductManager>, IProductManager
{
    [SerializeField] private List<ProductViewData> characterViewDatas = new List<ProductViewData>();

    public List<ProductViewData> GetAllProductDatas()
    {
        return characterViewDatas;
    }

    public int GetCurrentProductIndex()
    {
        if (!PlayerPrefs.HasKey("CurrentSpriteSkinIndex"))
        {
            return 0;
        }
        else
        {
            return PlayerPrefs.GetInt("CurrentSpriteSkinIndex", -1);
        }
    }

    public bool HasProduct(int _index)
    {
        return PlayerPrefs.HasKey("Skin " + _index);
    }

    public void SaveCurrentProduct(int _index)
    {
        PlayerPrefs.SetInt("CurrentSpriteSkinIndex", _index);
    }

    public void SaveUnlockProduct(int _index)
    {
        PlayerPrefs.SetInt("Skin " + _index, 1);
    }
}
