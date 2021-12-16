using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoSingleton<ShopManager>
{
    public List<Item> items;
    public List<Item> equipItem;
    public Material cubeRenderer, ghostRenderer;
    
    private float _emissionColorIntensityForGhost = .15f;
    private float _emissionColorIntensityForCube = .002f;
    private bool _firstGame;

    private void Start()
    {
        _firstGame = PlayerPrefs.GetInt("firstgame") == 0;
        if (_firstGame)
        {
            PlayerPrefs.SetInt("firstgame", 1);
            PlayerPrefs.SetInt("item" + items[0].name, 2);
        }
        CheckItems();

    }

    public void CheckItems()
    {
        foreach (Item item in items)
        {
            item.CheckItem();
            if (item.itemId == 2)
            {
                equipItem.Remove(equipItem[0]);
                equipItem.Add(item);
                cubeRenderer.color = item.color;
                cubeRenderer.SetColor("_EmissionColor", item.color * _emissionColorIntensityForCube);
                ghostRenderer.color = item.color;
                ghostRenderer.SetColor("_EmissionColor", item.color * _emissionColorIntensityForGhost);
            }
        }
    }

    public void EquipButton(int index)
    {
        PlayerPrefs.SetInt("item" + equipItem[0].name, 1);
        equipItem[0].GetComponent<Outline>().enabled = false;
        equipItem[0].CheckItem();
        equipItem.Remove(equipItem[0]);
        PlayerPrefs.SetInt("item" + items[index].name, 2);
        items[index].GetComponent<Outline>().enabled = true;
        cubeRenderer.color = items[index].color;
        cubeRenderer.SetColor("_EmissionColor", items[index].color * _emissionColorIntensityForCube);
        ghostRenderer.color = items[index].color;
        ghostRenderer.SetColor("_EmissionColor", items[index].color * _emissionColorIntensityForGhost);
        items[index].CheckItem();
        equipItem.Add(items[index]);
    }

    public void UnlockRandomItem()
    {
    again:
        PlayerPrefs.SetInt("Coin", (GameManager.Instance.TotalCoin - 500));
        int random = Random.Range(0, 9);
        if (items[random].itemId == 0)
        {
            PlayerPrefs.SetInt("item" + items[random].name, 1);
            CheckItems();
        }
        else
        {
            goto again;
        }

    }

}
