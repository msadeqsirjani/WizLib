namespace WizLib.Domain.Common
{
    public class BaseEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }

    public class BaseEntity : BaseEntity<int>
    {

    }
}
