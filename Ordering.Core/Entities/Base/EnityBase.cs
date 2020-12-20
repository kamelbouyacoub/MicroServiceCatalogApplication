namespace Ordering.Core.Entities.Base
{
    public class EnityBase<T> : IEntityBase<T>
    {
        public virtual T Id { get; protected set; }
        int? _requestedHashCode;

        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EnityBase<T>)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            var item = (EnityBase<T>)obj;
            if (item.IsTransient() || IsTransient()) 
                return false;
            else 
                return item == this;
        }

        public static bool operator ==(EnityBase<T> left, EnityBase<T> right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(EnityBase<T> left, EnityBase<T> right)
        {
            return !(left == right);
        }
    }
}