﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GUC.Enumeration;
using RakNet;
using GUC.WorldObjects;
using GUC.Types;
using GUC.Network;

namespace GUC.Server.Scripting.GUI.GuiList
{
    public class ListText : ListRow
    {
        internal ListText(List aParent, String aText, ColorRGBA aActiveRowColor, ColorRGBA aInactiveRowColor)
            : base(aParent, aText, aActiveRowColor, aInactiveRowColor)
        {
            create(-1);
        }

        protected override void create(int to)
        {
            BitStream stream = Program.server.SendBitStream;
            stream.Reset();
            stream.Write((byte)RakNet.DefaultMessageIDTypes.ID_USER_PACKET_ENUM);
            stream.Write((byte)NetworkID.GuiMessage);
            stream.Write((byte)GuiMessageType.CreateListText);

            stream.Write(this.id);
            stream.Write(this.m_Text);
            stream.Write(this.m_Parent.ID);
            stream.Write(m_ActiveRowColor);
            stream.Write(m_InactiveRowColor);

            sendStream(to, stream);


            if (!isSingleUser && allShown && to != -1)
            {
                show((GUC.Server.Scripting.Objects.Character.Player)((GUC.WorldObjects.Character.NPCProto)sWorld.VobDict[to]).ScriptingNPC);
            }
        }
    }
}
