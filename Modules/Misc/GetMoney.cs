using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static SpectralWave.ToggleManager.ToggleManager;

namespace SpectralWave.Modules.Misc
{
    internal class GetMoney 
    {
        public static void Execute()
        {
            ShopManager.instance.isThief = false;
            PhotonView value = PunManager.instance.R().GetValue<PhotonView>("photonView", false, false);
            value?.RPC("SetRunStatRPC", RpcTarget.MasterClient, "currency", 500);
        }
        public static void ExecuteBuyAllItems()
        {
            StatsManager.instance.BuyAllItems();
            var Item = new Dictionary<string, Item>();
            foreach (string itemName in new List<string>(Item.Keys))
            {
                StatsManager.instance.ItemPurchase(itemName);
            }
        }
    }
}
