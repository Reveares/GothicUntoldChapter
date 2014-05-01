﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GUC.Server.Scripts.AI.Waypoints;
using GUC.Server.Scripting.Objects.Character;
using GUC.Server.Scripting;
using GUC.Server.Scripts.AI.Enumeration;

namespace GUC.Server.Scripts.AI
{
    public static class AISystem
    {
        public static Dictionary<String, WayNet> WayNets = new Dictionary<string, WayNet>();
        public static Dictionary<Guilds, Dictionary<Guilds, GuildsAttitude>> GuildAttitudes = new Dictionary<Guilds, Dictionary<Guilds, GuildsAttitude>>();
        public static void Init()
        {
            WayNets.Add("NEWWORLD\\NEWWORLD.ZEN", WayNet.loadFromFile("newworld.wp"));

            Player.playerConnects += new Events.PlayerEventHandler(playerConnects);
        }

        public static void playerConnects(Player player)
        {
            player.InitNPCAI();
        }




        public static void initGuildAttitudes()
        {
            setGuildAttitude(Guilds.HUM_NONE, Guilds.MON_NONE, GuildsAttitude.HOSTILE);
            setGuildAttitude(Guilds.HUM_NONE, Guilds.MON_WOLF, GuildsAttitude.HOSTILE);
            setGuildAttitude(Guilds.HUM_NONE, Guilds.ORC_NONE, GuildsAttitude.HOSTILE);
            setGuildAttitude(Guilds.MON_NONE, Guilds.HUM_NONE, GuildsAttitude.HOSTILE);
            setGuildAttitude(Guilds.MON_WOLF, Guilds.HUM_NONE, GuildsAttitude.HOSTILE);
            setGuildAttitude(Guilds.ORC_NONE, Guilds.HUM_NONE, GuildsAttitude.HOSTILE);

        }

        public static GuildsAttitude getGuildAttitude(Guilds g1, Guilds g2)
        {
            if (GuildAttitudes.ContainsKey(g1) &&
                GuildAttitudes[g1].ContainsKey(g2))
            {
                return GuildAttitudes[g1][g2];
            }
            else if (GuildAttitudes.ContainsKey(g2) &&
               GuildAttitudes[g2].ContainsKey(g1))
                return GuildAttitudes[g2][g1];

            if (g1 < Guilds.HUM_SPERATOR && g2 < Guilds.HUM_SPERATOR)
                return GuildsAttitude.FRIENDLY;
            if (g1 < Guilds.HUM_SPERATOR && g2 > Guilds.HUM_SPERATOR)
                return GuildsAttitude.HOSTILE;
            if (g2 < Guilds.HUM_SPERATOR && g1 > Guilds.HUM_SPERATOR)
                return GuildsAttitude.HOSTILE;


            return GuildsAttitude.NEUTRAL;
        }

        public static void setGuildAttitude(Guilds g1, Guilds g2, GuildsAttitude ga)
        {
            if (!GuildAttitudes.ContainsKey(g1))
            {
                GuildAttitudes.Add(g1, new Dictionary<Guilds, GuildsAttitude>());
            }
            if (GuildAttitudes[g1].ContainsKey(g2))
                GuildAttitudes[g1][g2] = ga;
            else
                GuildAttitudes[g1].Add(g2, ga);
        }


    }
}
