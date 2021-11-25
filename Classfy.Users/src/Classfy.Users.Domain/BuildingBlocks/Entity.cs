using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classfy.Users.Domain.BuildingBlocks
{
    public abstract class Entity<IdType>
    {
        public virtual IdType Id { get; protected set; }

        protected Entity() { }

        protected Entity(IdType id) : this()
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Entity<IdType>;
            if (!(obj is Entity<IdType>))
                return false;
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetRealType() != other.GetRealType())
                return false;
            if (Id == null)
                return false;
            if (Id.GetType() == Guid.Empty.GetType())
            {
                if ((Id as Guid?) == Guid.Empty)
                    return false;
            }
            if (Id.GetType() == typeof(long))
            {
                if ((Id as long?) <= 0)
                    return false;
            }
            return Id as object == other.Id as object;
        }

        public static bool operator ==(Entity<IdType>? a, Entity<IdType>? b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Entity<IdType>? a, Entity<IdType>? b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }

        private Type GetRealType()
        { // we still need it only because of EF lazy load
            Type type = GetType();
            if (type.ToString().Contains("Castle.Proxies."))
#pragma warning disable CS8603 // possibly null return
                return type.BaseType;
#pragma warning restore CS8603
            return type;
        }
    }
}
