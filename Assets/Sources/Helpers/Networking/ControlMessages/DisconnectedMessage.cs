﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Helpers.Networking.ControlMessages
{
	using ProtoBuf;

	[ProtoContract]
	public class DisconnectedMessage : IControlMessage
	{
		[ProtoMember(1)]
		public Player Player;
	}
}
