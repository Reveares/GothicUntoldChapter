﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GUC.Server.Scripting.Objects.Character;
using GUC.Enumeration;
using GUC.Server.Scripts.AI.Enumeration;

namespace GUC.Server.Scripts.AI.NPC_Def.Monster
{
    public class Bloodhound : NPC
    {
        public Bloodhound()
            : base()
        {
            Name = "Bluthund";

            Strength = 90;
            Dexterity = 90;
            HPMax = 180;
            HP = 180;


            setProtection(DamageTypeIndex.DAM_INDEX_BLUNT, 90);
            setProtection(DamageTypeIndex.DAM_INDEX_EDGE, 90);
            setProtection(DamageTypeIndex.DAM_INDEX_POINT, 40);
            setProtection(DamageTypeIndex.DAM_INDEX_FIRE, 90);
            setProtection(DamageTypeIndex.DAM_INDEX_FLY, 90);

            setDamageType(DamageTypes.DAM_EDGE);






            this.setVisual("Shadow.mds", "Bhd_Body", 0, 0, "", 0, 0);

            this.InitNPCAI();

            this.setGuild(Guilds.MON_SHADOWBEAST);

            WeaponMode = 1;

            CreateVob();

        }
    }
}
