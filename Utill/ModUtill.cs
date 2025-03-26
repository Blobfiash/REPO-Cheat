using Photon.Realtime;
using SpectralWave.TogglesLoadManager;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using System.Collections;
using ExitGames.Client.Photon;
using HarmonyLib;
using AsmResolver.PE.DotNet.ReadyToRun;

namespace SpectralWave.Utill
{
    public class ModUtill : MonoBehaviour
    {

    }

    public static class Helpers
    {
        public static string GetPlayerName(this PlayerAvatar p) => string.IsNullOrEmpty(p.R().GetValue<string>("playerName")) ? p.name : p.R().GetValue<string>("playerName");
        public static bool DeadNot(this PlayerAvatar p) => p?.R().GetValue<bool>("deadSet") ?? false;
        public static string PlayerGetSteamID(PlayerAvatar p) => SemiFunc.PlayerGetSteamID(p);
        public static List<PlayerAvatar> PlayersList() => GameDirector.instance.PlayerList;
        public static bool MonsterDeadNot(this Enemy e) => e?.R()?.GetValue<EnemyHealth>("Health")?.R()?.GetValue<bool>("dead") ?? false;
        public static List<Enemy> EnemiesList() => Object.FindObjectsOfType<Enemy>().Where(e => e != null && !e.MonsterDeadNot()).ToList();
        public static Camera MainCam() => SemiFunc.MainCamera();
    }
}
