using MelonLoader;
using BTD_Mod_Helper;
using Banan;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Models;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Display;
using static Assets.Scripts.Models.ServerEvents.Coop;
using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using HarmonyLib;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity.Towers;
using Assets.Scripts.Utils;
using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Simulation.Behaviors;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;

[assembly: MelonInfo(typeof(Banan.Banan), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Banan;
public class Banan : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<Banan>("Banan loaded!");
    }
    public override void OnGameModelLoaded(GameModel model)
    {
        base.OnGameModelLoaded(model);
    }
    public override void OnBloonModelUpdated(Bloon bloon, Model model)
    {
        base.OnBloonModelUpdated(bloon, model);
    }
}
[HarmonyPatch(typeof(GameModelLoader), nameof(GameModelLoader.Load))]
class Yes
{
    [HarmonyPostfix]
    public static void Patch(GameModel __result)
    {
        foreach (var tower in __result.towers)
        {
            tower.display = new() { guidRef = "cd01e5de10343944ea24e6a6b3690b3a" };
            tower.GetBehavior<DisplayModel>().display = new() { guidRef = "cd01e5de10343944ea24e6a6b3690b3a" };
            foreach (var weapon in tower.GetWeapons())
            {
                weapon.projectile.display = new() { guidRef = "cd01e5de10343944ea24e6a6b3690b3a" };
                weapon.projectile.GetBehavior<DisplayModel>().display = new() { guidRef = "cd01e5de10343944ea24e6a6b3690b3a" };
            }
            if (tower.GetBehavior<AirUnitModel>() != null)
            {
                tower.GetBehavior<AirUnitModel>().display = new() { guidRef = "cd01e5de10343944ea24e6a6b3690b3a" };
            }
            foreach (var a in tower.GetAbilities())
            {
                if(a.GetBehavior<ActivateAttackModel>() != null)
                {
                    a.GetBehavior<ActivateAttackModel>().attacks[0].weapons[0].projectile.display = new() { guidRef = "cd01e5de10343944ea24e6a6b3690b3a" };
                }
            }
        }
        foreach (var bloon in __result.bloons)
        {
            bloon.display = new() { guidRef = "cd01e5de10343944ea24e6a6b3690b3a" };
            bloon.GetBehavior<DisplayModel>().display = new() { guidRef = "cd01e5de10343944ea24e6a6b3690b3a" };
            bloon.disallowCosmetics = true;
            foreach (var state in bloon.damageDisplayStates)
            {
                state.displayPath = new() { guidRef = "cd01e5de10343944ea24e6a6b3690b3a" };
            }
        }
    }
}