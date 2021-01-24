﻿using System.Collections.Generic;
using BattleMiniMap.View;
using MissionLibrary.Controller;
using MissionSharedLibrary.Controller;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.Missions;

namespace BattleMiniMap.Logic
{
    public class MissionStartingHandler : AMissionStartingHandler
    {
        public override void OnCreated(MissionView entranceView)
        {

            List<MissionBehaviour> list = new List<MissionBehaviour>
            {
                new BattleMiniMapView()
            };


            foreach (var missionBehaviour in list)
            {
                MissionStartingManager.AddMissionBehaviour(entranceView, missionBehaviour);
            }
        }

        public override void OnPreMissionTick(MissionView entranceView, float dt)
        {
        }
    }
}
