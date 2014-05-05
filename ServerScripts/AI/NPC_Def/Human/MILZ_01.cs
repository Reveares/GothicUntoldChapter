﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GUC.Server.Scripting.Objects.Character;
using GUC.Enumeration;
using GUC.Server.Scripts.AI.Enumeration;

namespace GUC.Server.Scripts.AI.NPC_Def.Human
{
    public class MILZ_01 : NPC
    {
        public MILZ_01()
            : base()
        {
            Name = "Miliz";

            Strength = 125;
            Dexterity = 125;
            HPMax = 400;
            HP = 400;

            setDamageType(DamageType.DAM_EDGE);


            this.setFightTalent(NPCTalents.H1, 50);
            this.setFightTalent(NPCTalents.H2, 50);
            this.setFightTalent(NPCTalents.Bow, 50);
            this.setFightTalent(NPCTalents.CrossBow, 50);


            this.setVisual("HUMANS.MDS", NPCProto.BODYMESH_MALE, NPCProto.BODYTEX_MALE_BLACK, 0, "Hum_Head_FatBald", NPCProto.Face_B_Tough_Silas, 0);
            this.ApplyOverlay("Humans_Militia.mds");

            this.InitNPCAI();

            this.setGuild(Guilds.HUM_MIL);

            this.Equip(this.addItem("ItMw_1h_Mil_Sword", 1));
            this.Equip(this.addItem("ITAR_MIL_L", 1));
            
            CreateVob();
        }
    }
}
