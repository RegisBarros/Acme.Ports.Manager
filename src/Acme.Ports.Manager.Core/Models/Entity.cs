using System;

namespace Acme.Ports.Manager.Core.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (obj is not Entity item)
                return false;
            
            if (ReferenceEquals(this, item))
                return true;
            
            if(this.GetType() != item.GetType())
                return false;

            return item.Id == this.Id;
        }
        
        public static bool operator ==(Entity a, Entity b)
        {
            if ((object) a == null && (object) b == null)
                return true;
            return (object) a != null && (object) b != null && a.Equals((object) b);
        }
        
        public static bool operator !=(Entity a, Entity b) => !(a == b);

        public override int GetHashCode() => (this.GetType().GetHashCode() ^ 93) + this.Id.GetHashCode();
        
        public override string ToString() => string.Format("{0} [Id={1}]", (object) this.GetType().Name, (object) this.Id);
    }
}