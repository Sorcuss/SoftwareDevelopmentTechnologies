﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary.Entities
{
    [DataContract]
    public class DestroyEvent : Event
    {
        public DestroyEvent()
        {

        }

        public DestroyEvent(Guid id, Client warehouseClient, EventStatus status, string description) : base(id, warehouseClient, status, description)
        {
            

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString() + " - DestroyEvent";
        }

        public override string Serialize(ObjectIDGenerator idGenerator)
        {
            return this.GetType().FullName + "|"
                   + idGenerator.GetId(this, out bool firstTime) + "|"
                   + Id + "|"
                   + idGenerator.GetId(WarehouseClient, out firstTime) + "|"
                   + idGenerator.GetId(Status, out firstTime) + "|"
                   + Description + "|" + "\n";
        }

        public override void Deserialize(string[] details, Dictionary<long, object> objReferences)
        {
            Id = Guid.Parse(details[2]);
            WarehouseClient = (Client)objReferences[Int64.Parse(details[3])];
            Status = (EventStatus)objReferences[Int64.Parse(details[4])];
            Description = details[5];
        }
    }
}
