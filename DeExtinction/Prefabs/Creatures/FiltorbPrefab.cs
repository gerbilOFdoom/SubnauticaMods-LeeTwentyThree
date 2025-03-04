﻿using DeExtinction.Mono;
using ECCLibrary;
using ECCLibrary.Data;
using Nautilus.Assets;
using System.Collections;
using UnityEngine;

namespace DeExtinction.Prefabs.Creatures;

internal class FiltorbPrefab : CreatureAsset
{
    public FiltorbPrefab(PrefabInfo prefabInfo) : base(prefabInfo)
    {
    }

    protected override CreatureTemplate CreateTemplate()
    {
        var template = new CreatureTemplate(Plugin.AssetBundle.LoadAsset<GameObject>("Filtorb_Prefab"), BehaviourType.SmallFish, EcoTargetType.SmallFish, 130f)
        {
            SwimRandomData = null,
            Mass = 5f,
            CellLevel = LargeWorldEntity.CellLevel.Near,
            PickupableFishData = new PickupableFishData(TechType.Peeper, "WorldModel", "ViewModel"),
            BioReactorCharge = 300f,
            EdibleData = new EdibleData(2, 0, false),
            SizeDistribution = new AnimationCurve(new []{new Keyframe(0, 0.8f), new Keyframe(1, 1)})
        };
        template.SetWaterParkCreatureData(new WaterParkCreatureDataStruct(0.01f, 0.8f, 0.8f, 1.1f, true, true, "Filtorb"));
        
        return template;
    }

    protected override IEnumerator ModifyPrefab(GameObject prefab, CreatureComponents components)
    {
        components.WorldForces.underwaterDrag = 2;
        var hide = prefab.AddComponent<FiltorbHide>();
        hide.actionLength = 0.5f;
        hide.maxReactDistance = 14f;
        hide.evaluatePriority = 0.2f;
        var freeFloat = prefab.AddComponent<FiltorbSwimBehaviour>();
        freeFloat.evaluatePriority = 0.1f;
        yield break;
    }
}
