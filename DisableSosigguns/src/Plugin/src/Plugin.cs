using BepInEx;
using HarmonyLib;
using FistVR;
using UnityEngine;

namespace H3VRMod
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.NAME, PluginInfo.VERSION)]
	[BepInProcess("h3vr.exe")]

	public class Plugin : BaseUnityPlugin
	{
		private readonly Hooks _hooks;
		public Plugin()
		{
			_hooks = new Hooks();
			_hooks.Hook();
		}
		private void Awake()
        {
			var harmony = new Harmony("com.disablesosigguns.patch");
			harmony.PatchAll(typeof(PatchValues));
		}
		//private void Update()
		//{
		
		//}
		
		class PatchValues
		{
			//private string TNHCHAR;
			[HarmonyPatch(typeof(SosigWeapon), "PlayerPickup")]
			[HarmonyPrefix]
			public static bool PickupPatch(SosigWeapon __instance)
			{
				if (GM.TNH_Manager && GM.TNH_Manager.C)
                {
					if (GM.TNH_Manager.C.DisplayName == "Class Collection Cooper")
                    {
						UnityEngine.Object.Destroy(__instance.gameObject);
						return true;
					}
                }
				return true;
			}
		}

		private void OnDestroy()
		{
			_hooks.Unhook();
		}
	}
}