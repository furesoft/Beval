namespace Beval.ValueTypes
{
    internal class BevalBool : BevalValue
    {
        public bool Value { get; set; }

        public BevalBool(bool v)
        {
            Value = v;
        }

        public static implicit operator BevalBool(bool val)
        {
            return new BevalBool(val);
        }
    }
}