﻿using DeExtinction.Prefabs.Creatures;
using ECCLibrary;
using ECCLibrary.Data;
using Nautilus.Assets;
using Nautilus.Handlers;
using UnityEngine;

namespace DeExtinction;

internal static class CreaturePrefabManager
{
    public static FiltorbPrefab Filtorb { get; private set; }
    public static AxetailPrefab Axetail { get; private set; }
    public static JellySpinnerPrefab JellySpinner { get; private set; }

    private static AssetBundle Bundle => Plugin.AssetBundle;

    private static Sprite LoadIcon(string name) => Bundle.LoadAsset<Sprite>(name);

    public static void RegisterCreatures()
    {
        Filtorb = new FiltorbPrefab(PrefabInfo.WithTechType("Filtorb", "Filtorb", "Small, filter feeding organism.", unlockAtStart: false).WithIcon(LoadIcon("Filtorb_Item")));
        Filtorb.Register();
        
        Axetail = new AxetailPrefab(PrefabInfo.WithTechType("Axetail", "Axetail", "Small, edible prey fish.", unlockAtStart: false).WithIcon(LoadIcon("Axetail_Item")));
        Axetail.Register();
        
        JellySpinner = new JellySpinnerPrefab(PrefabInfo.WithTechType("JellySpinner", "Jelly spinner", "Small organism.", unlockAtStart: false).WithIcon(LoadIcon("JellySpinner_Item")));
        JellySpinner.Register();
    }

    public static void RegisterFood()
    {
        CookedCreatureHandler.RegisterAllCreatureFood(
            Filtorb,
            "Cooked filtorb",
            "Juicy.",
            LoadIcon("Filtorb_Cooked"),
            "Cured filtorb",
            "Chalky. Dehydrating, but keeps well.",
            LoadIcon("Filtorb_Cured"),
            new EdibleData(5, 20, true),
            new VFXFabricatingData("CraftModel", 0, 0.3f)
        );
        
        CookedCreatureHandler.RegisterAllCreatureFood(
            Axetail,
            "Cooked axetail",
            "A sharp taste. Somewhat hydrating.",
            LoadIcon("Axetail_Cooked"),
            "Cured axetail",
            "Eat around the pointy bits. Dehydrating, but keeps well.",
            LoadIcon("Axetail_Cured"),
            new EdibleData(20, 13, true),
            new VFXFabricatingData("CraftModel", 0, 0.3f)
        );

        CookedCreatureHandler.RegisterAllCreatureFood(
            JellySpinner,
            "Cooked jelly spinner",
            "Pops in your mouth.",
            LoadIcon("JellySpinner_Cooked"),
            "Cured jelly spinner",
            "Like eating bubble wrap. Dehydrating, but keeps well.",
            LoadIcon("JellySpinner_Cured"),
            new EdibleData(9, 2, true),
            new VFXFabricatingData("CraftModel", 0, 0.3f)
        );

    }
}
