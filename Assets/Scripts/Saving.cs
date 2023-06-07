using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class Saving : MonoBehaviour
{
    public Popit popit;
    public Shop shop;
    public async void Awake()
    {
        await UnityServices.InitializeAsync();
        SignInAnonymouslyAsync();
    }

    async void SignInAnonymouslyAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Sign in anonymously succeeded!");
            Load();

            // Shows how to get the playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

        }
        catch (AuthenticationException ex)
        {
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            Debug.LogException(ex);
        }
    }

    public async void Save()
    {
        //money ; clicks ; popits: active skin, skin bought or not ; stats: times flipped , popits owned.
        string money = Menu.деньги.ToString();
        string clicks = Menu.счетѕопа.ToString();
        string activeSkin = Popit.activePopitID.ToString();
        string flips = Menu.перевернул.ToString();
        string popitsOwned = Menu.естьѕопытов.ToString();
        string skinBoughtOrNot = "";

        for (int i = 0; i < shop.items.Length; i++)
        {
            if (shop.items[i].isBought == true)
            {
                skinBoughtOrNot += 1;
            }
            else
            {
                skinBoughtOrNot += 0;
            }
        }

        var data = new Dictionary<string, object> {
            {"Money", money},
            {"Clicks", clicks},
            {"ActiveSkin", activeSkin},
            {"Flips", flips},
            {"PopitsOwned", popitsOwned},
            {"SkinBoughtOrNot", skinBoughtOrNot}
        };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
        Debug.Log("Saved");
    }

    public async void Load()
    {
        Dictionary<string, string> savedData = await CloudSaveService.Instance.Data.LoadAllAsync();
        Menu.деньги = Convert.ToInt32(savedData["Money"]);
        Menu.счетѕопа = Convert.ToInt32(savedData["Clicks"]);
        Popit.activePopitID = Convert.ToInt32(savedData["ActiveSkin"]);
        Menu.перевернул = Convert.ToInt32(savedData["Flips"]);
        Menu.естьѕопытов = Convert.ToInt32(savedData["PopitsOwned"]);

        for (int i = 0; i < shop.items.Length; i++)
        {
            if (savedData["SkinBoughtOrNot"][i] == '1')
            {
                shop.items[i].isBought = true;
            }
            else
            {
                shop.items[i].isBought = false;
            }
        }

        popit.ќбновитьѕопыт();
    }
}
