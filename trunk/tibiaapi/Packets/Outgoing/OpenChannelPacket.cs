﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tibia.Packets.Outgoing
{
    public class OpenChannelPacket : OutgoingPacket
    {

        public ChatChannel ChannelId { get; set; }

        public OpenChannelPacket(Objects.Client c)
            : base(c)
        {
            Type = OutgoingPacketType_t.OPEN_CHANNEL;
            Destination = PacketDestination_t.SERVER;
        }

        public override bool ParseMessage(NetworkMessage msg, PacketDestination_t destination, Objects.Location pos)
        {
            if (msg.GetByte() != (byte)OutgoingPacketType_t.OPEN_CHANNEL)
                return false;

            Destination = destination;
            Type = OutgoingPacketType_t.OPEN_CHANNEL;

            ChannelId = (ChatChannel)msg.GetUInt16();

            return true;
        }

        public override byte[] ToByteArray()
        {
            NetworkMessage msg = new NetworkMessage(0);

            msg.AddByte((byte)Type);

            msg.AddUInt16((ushort)ChannelId);

            return msg.Packet;
        }
    }
}