using Photon.Pun;
using SpectralWave.ConfigManager;
using SpectralWave.Modules.Misc;
using SpectralWave.Modules.Player;
using SpectralWave.Modules.Utill;
using SpectralWave.TogglesLoadManager;
using SpectralWave.Utill;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static SpectralWave.ToggleManager.ToggleManager;
using static SpectralWave.UI.Managment.GUIButtons;

namespace SpectralWave.UI
{
    public class SpectralUI : MonoBehaviour
    {
        private int SelectiveTab = 0;

        public Rect windowRect = new Rect(50f, 50f, 700f, 450f);
        public Rect tabRect = new Rect(10, 45, 130, 350f);
        private Rect TabSliding;

        public string[] Tabs = new string[] { "Logs", "Visual", "Exploits", "Player", "Items", "Player's" ,"Settings", "MonstersTab" };

        // Textures
        private Texture2D BcTexture;
        private Texture2D backgroundTexture;
        public static Texture2D guibackground;
        public static Texture2D normalbuttonTexture;
        public static Texture2D activebuttonTexture;
        public static Texture2D hoverbuttonTexture;
        private Texture2D SelectedTexture;
        private Texture2D UnSelectedTexture;
        public static Texture2D SliderBcTexture;
        public static Texture2D SliderTexture;
        public static Texture2D normalToggleTexture;
        public static Texture2D hoverToggleTexture;
        public static Texture2D activeToggleTexture;
        public static Texture2D ToggleButtons;
        public static Texture2D TogglesAndButtons;
        private static Texture2D CatagTexture;
        private static Texture2D HeaderTexture;
        public static Texture2D SectionTexture;
        public static Texture2D SectionL;
        public static Texture2D DropDownTexture;
        public static Texture2D SlidingTexture;
        public static Texture2D BoxTexture;
        public static Texture2D VSliderTexture;


        // Styles
        public static GUIStyle sliderStyle;
        public static GUIStyle thumbStyle;
        public static GUIStyle tabStylebase;
        public static GUIStyle tabSelected;
        private GUIStyle guistyle;
        public static GUIStyle Boxstyle;
        public static GUIStyle VSliderStyle; 

        public static List<TogglesLoad> TogglesLoad;

        public static PlayerController PlayerP;

        private void Start()
        {

            TogglesAndButtons = DrawTexture.CreateTex(390, 39, new Color32(94, 93, 92, 100));
            ToggleButtons = DrawTexture.CreateTex(240, 30, new Color(0.9f, 0.9f, 0.9f));
            SectionL = DrawTexture.CreateTex(220, 4, new Color32(254, 254, 254, byte.MaxValue));
            BcTexture = backgroundTexture = DrawTexture.CreateTex(256, 64, new Color(0.9f, 0.9f, 0.9f));
            SelectedTexture = DrawTexture.CreateTex(35, 125, new Color32(70, 70, 70, 100));
            UnSelectedTexture = DrawTexture.CreateTex(35, 125, new Color32(33, 33, 33, 0)); 
            CatagTexture = HeaderTexture = DrawTexture.CreateTex(120, 24, new Color32(50, 50, 50, byte.MaxValue));
            DropDownTexture = DrawTexture.CreateTex(390, 39, new Color32(50, 50, 50, 100));
            normalbuttonTexture = hoverbuttonTexture = activebuttonTexture = DrawTexture.CreateTex(26, 26, new Color32(98, 98, 98, byte.MaxValue));
            normalToggleTexture =  hoverToggleTexture = activeToggleTexture = DrawTexture.CreateTex(26, 26, new Color32(84, 84, 84, byte.MaxValue));

            guibackground = DrawTexture.CreateTex(600, 450, new Color32(51, 51, 51, 246));
            BoxTexture = DrawTexture.CreateTex(300, 300, new Color32(94, 93, 92, 100));

            SliderTexture = DrawTexture.CreateTex((int)SlideWidth, 18, new Color32(210, 210, 210, 200));
            SliderBcTexture = DrawTexture.CreateTex((int)SlideWidth, 18, new Color32(81, 82, 82, 200));
            SlidingTexture = DrawTexture.CreateTex(3, 35, new Color32(48, 127, 255, 120));
            SectionTexture = DrawTexture.CreateTex(240, 280, new Color32(63, 33, 44, 200));
            VSliderTexture = DrawTexture.CreateTex(50, 50, new Color32(122, 122, 122, byte.MaxValue));
            TabSliding = new Rect(tabRect.x, tabRect.y + 5, 3, 35);
            

        }

        private void OnGUI()
        {
            tabStylebase = new GUIStyle(GUI.skin.button) { normal = { background = UnSelectedTexture }, hover = { background = UnSelectedTexture }, active = { background = UnSelectedTexture } };
            tabSelected = new GUIStyle(GUI.skin.button) { normal = { background = SelectedTexture }, hover = { background = SelectedTexture }, active = { background = SelectedTexture } };

            sliderStyle = new GUIStyle(GUI.skin.horizontalSlider) { normal = { background = backgroundTexture }, active = { background = backgroundTexture }, hover = { background = backgroundTexture } };
            thumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb) { normal = { background = BcTexture }, active = { background = BcTexture }, hover = { background = BcTexture } };

            Boxstyle = new GUIStyle(GUI.skin.box)
            {
                normal = { background = BoxTexture },
                active = { background = BoxTexture },
                hover = { background = BoxTexture },
                focused = { background = BoxTexture },
                onNormal = { background = BoxTexture },
                onActive = { background = BoxTexture },
                
                onHover = { background = BoxTexture },
                onFocused = { background = BoxTexture }
            };

            guistyle = new GUIStyle(GUI.skin.window)
            {
                /* doing null so drawtexture can takeover */
                normal = { background = null },
                active = { background = null },
                hover = { background = null },
                focused = { background = null },
                onNormal = { background = null },
                onActive = { background = null },
                onHover = { background = null },
                onFocused = { background = null }
            }; 

            VSliderStyle = new GUIStyle(GUI.skin.horizontalSlider)
            {
                normal = { background = VSliderTexture },
                active = { background = VSliderTexture },
                hover = { background = VSliderTexture },
                focused = { background = VSliderTexture },
                onNormal = { background = VSliderTexture },
                onActive = { background = VSliderTexture },
                onHover = { background = VSliderTexture },
                onFocused = { background = VSliderTexture }
            };
            if (ToggleGui.Open)
            {
                DrawTexture.DrawTextureRounded(windowRect, guibackground, ScaleMode.StretchToFill, true, 1.0f, Color.white, Vector4.zero, new Vector4(22, 22, 22, 22));
                windowRect = GUI.Window(0, windowRect, Wind, "", guistyle);

            }
        }
        private void Wind(int windowID)
        {
            GUI.DragWindow(new Rect(0, 0, windowRect.width, 20));
            GUI.Label(new Rect(20, 10, 400, 400), "<size=16><b>SpectralWave</b></size>");

            GUILayout.BeginArea(tabRect);
            for (int i = 0; i < Tabs.Length; i++)
                if (GUILayout.Button(Tabs[i], SelectiveTab == i ? tabSelected : tabStylebase, GUILayout.Height(35), GUILayout.Width(125))) SelectiveTab = i;
            GUILayout.EndArea();

            TabSliding.y = Mathf.Lerp(TabSliding.y, tabRect.y + SelectiveTab * 38, Time.deltaTime * 5);
            GUI.DrawTexture(new Rect(TabSliding.x, TabSliding.y - 0.2f, TabSliding.width, TabSliding.height - 3), SlidingTexture);

            switch (SelectiveTab) {
                case 0: LogsTab(); break;
                case 1: VisualModTab(); break; 
                case 2: MiscTab(); break; 
                case 3: PlayerTab(); break;
                case 4: ItemListTab(); break;
                case 5: PlayersTab(); break;
                case 6: SettingsTab(); break;
                case 7: MonstersTav(); break;
            }
        }
        private void LogsTab()
        {
            CreateLabel("FIRST EVER CHEAT FOR REPO!!!!");
        }
        private Vector2 V_SettingsScroll = Vector2.zero;
        private void SettingsTab()
        {
            CreateLeftBox("Settings", () =>
            {
                V_SettingsScroll = GUILayout.BeginScrollView(V_SettingsScroll, false, false, GUIStyle.none, GUIStyle.none);
                CreateButton("Save Configs", SaveConfig.Save);
                CreateButton("Load Configs", SaveConfig.Load);
                GUILayout.EndScrollView(); 
            });
        }
        private Vector2 V_VisualScroll = Vector2.zero;
        
        public void VisualModTab()
        {
            CreateBox("Visual", () =>
            {
                V_VisualScroll = GUILayout.BeginScrollView(V_VisualScroll, false, false, GUIStyle.none, GUIStyle.none);
                BDisableGrain = CreateToggle(BDisableGrain, "DisableGrainEffect");
                GUILayout.EndScrollView();
            });
            CreateRightBox("Settings", () =>
            {
            });
        }

        private Vector2 V_MiscScroll = Vector2.zero;
        private Vector2 V_RightBoxMiscScroll = Vector2.zero;
        public void MiscTab()
        {
            CreateLeftBox("Exploits", () =>
            {
                V_PlayerScroll = GUILayout.BeginScrollView(V_PlayerScroll, false, false, GUIStyle.none, GUIStyle.none);
                BAntiBreakItems = CreateToggle(BAntiBreakItems, "AntiBreakItems");
                BCrashAll = CreateToggle(BCrashAll, "CrashAll");
                BEnemiesCantSee = CreateToggle(BEnemiesCantSee, "Enemies Cant See");
                BVibrateScreen = CreateToggle(BVibrateScreen, "VibrateScreen");
                CreateButton("Restart Scene", Players.ExecuteRestartScene);
                CreateButton("Kick All", KickAll.Execute);
                CreateButton("GetMoney", GetMoney.Execute);
                CreateButton("Screen Say LOW", SetScreenText.Execute);
                CreateButton("Tax Man Say SpectralWave", SetScreenText.ExecuteTaxManText);
                CreateButton("Damage All Players", KillAll.Execute);
                CreateButton("Heal All Players", KillAll.ExecuteHeal);
                CreateButton("Set Name All", SetPlayersName.Execute);
                CreateButton("Freeze All Monsters", Enemys.ExecuteFreeze);
                CreateSlider(ref FreezeAllTime, 1f, 255f, "Freeze Monsters Time");
                CreateButton("Kill All Monsters", Enemys.ExecuteKillAll);
                CreateButton("Revive All Players", KillAll.ExecuteReviveAll);
                CreateButton("Kill All Players", () => { var pv = FindObjectOfType<PlayerHealth>()?.R().GetValue<PhotonView>("photonView", false); if (pv != null && !pv.IsMine) pv.RPC("HurtOtherRPC", RpcTarget.All, int.MaxValue, Vector3.zero, false, 1); });

                CreateButton("Complete All Extraction Points", CompleteExtro.CompleteAllExtroPoints);
                CreateButton("Force Short All", Players.ExecutePlayerShortAll);
                CreateButton("Trans Owner All", TransferOwnership.TakeAllOwnership);
                
                GUILayout.EndScrollView();
            });
        } 
         
        private Vector2 V_PlayerScroll = Vector2.zero;
        public void PlayerTab()
        { 
            CreateBox("Player", () =>
            {
                V_PlayerScroll = GUILayout.BeginScrollView(V_PlayerScroll, false, false, GUIStyle.none, GUIStyle.none);
                BGodMode = CreateToggle(BGodMode, "God Mode");
                BInfStamina = CreateToggle(BInfStamina, "Inf Stamina");
                BSpeedBoost = CreateToggle(BSpeedBoost, "Speed Boost");
                BNoTumble = CreateToggle(BNoTumble, "No Tumble");
                BInfBattery = CreateToggle(BInfBattery, "Inf Battery");
                CreateButton("Set Troll Name", SetName.Execute);
                CreateButton("Reset Name", SetName.ExecuteResetName);
                CreateButton("Get More Strength", Strength.Execute); 
                CreateButton("Give Crown", GiveCrown.Execute);
                
                GUILayout.EndScrollView(); 
            });
            CreateRightBox("Settings", () =>
            {
            });
        } 
        private Vector2 V_ItemScroll = Vector2.zero;
        public void ItemListTab()
        {
            CreateBox("Items", () =>
            {
                CreateButton("Buy All Items", GetMoney.ExecuteBuyAllItems);
            });
        }
        public Vector2 V_MonsterScroll = Vector2.zero;
        public void MonstersTav()
        {
            CreateBox("Items", () =>
            {
                V_MonsterScroll = GUILayout.BeginScrollView(V_MonsterScroll, false, false, GUIStyle.none, GUIStyle.none);
                foreach (var Monsters in Helpers.EnemiesList())
                {
                    CreateButton(Monsters.name, () => Debug.Log("Skibidi"));
                }
                GUILayout.EndScrollView();
            });
        }
        private Vector2 V_PlayersScroll = Vector2.zero;
        private Vector2 V_PlayersActionScroll = Vector2.zero;
        public static PlayerAvatar GetPlayer = null;
        string PlayerSay = ""; 

        public void PlayersTab()
        {
            CreateBox("Players", () =>
            {
                V_PlayersScroll = GUILayout.BeginScrollView(V_PlayersScroll, false, false, GUIStyle.none, GUIStyle.none);
                foreach (PlayerAvatar Players in Helpers.PlayersList())
                {
                    if (Players == null) continue;
                    if (GetPlayer == null) GetPlayer = Players;
                    if (GetPlayer != null && GetPlayer.GetInstanceID() == Players.GetInstanceID())
                    {
                        CreateButton($"► {Players.GetPlayerName()}", () => GetPlayer = Players);
                    }
                    else
                    {
                        CreateButton(Players.GetPlayerName(), () => GetPlayer = Players);
                    }
                }
                GUILayout.EndScrollView(); 
            }); 
            CreateRightBox("Actions", () =>
            {
                V_PlayersActionScroll = GUILayout.BeginScrollView(V_PlayersActionScroll, false, false, GUIStyle.none, GUIStyle.none);
                CreateButton("Kill Player", () => GetPlayer.photonView.RPC("PlayerDeathRPC", RpcTarget.All, 0));
                CreateButton("Revive Player", () => { if (GetPlayer.DeadNot()) { GetPlayer.photonView.RPC("ReviveRPC", RpcTarget.All, false); } });
                CreateButton("Hurt Player", () => FindObjectOfType<PlayerHealth>()?.R().GetValue<PhotonView>("photonView", false)?.RPC("HurtOtherRPC", GetPlayer.photonView.Owner, 20, Vector3.zero, false, 1));
                CreateButton("Heal Player", () => FindObjectOfType<PlayerHealth>()?.R().GetValue<PhotonView>("photonView", false)?.RPC("HealOtherRPC", GetPlayer.photonView.Owner, 20, true));
                CreateButton("Crash Player", () => CrashAll.CrashSelectedPlayer(GetPlayer.photonView.Owner.ActorNumber));
                CreateButton("Say Bye!!", () => GetPlayer.photonView.RPC("OutroStartRPC", GetPlayer.photonView.Owner));
                CreateButton("Get Ownership Of Player", () => TransferOwnership.CallTransferOwnership(GetPlayer.photonView.ViewID, PhotonNetwork.LocalPlayer.ActorNumber));
                CreateButton("Monsters Go to Player", () => Helpers.EnemiesList().Where(u => u != null && !u.MonsterDeadNot()).ToList().ForEach(u => u.SetChaseTarget(GetPlayer)));
                CreateButton("Force Tumble Player", () => GetPlayer?.tumble?.R()?.GetValue<PhotonView>("photonView", false, false)?.RPC("TumbleSetRPC", GetPlayer.photonView.Owner, true, false));
                CreateTextField(ref PlayerSay, "player say");
                CreateButton("Make Player Say " + PlayerSay, () => Players.MakePlayerSayThis(PlayerSay, GetPlayer));
                CreateButton("Break Player Item", ()=> Players.BreakSelectedPlayerItem(GetPlayer));
                GUILayout.EndScrollView(); 
            });
        }
       
        public static void Update() => TogglesLoad.ForEach(t => t.Update());
        
        public static void FixedUpdate() => TogglesLoad.ForEach(t => t.FixedUpdate());  
 
    }

}  