namespace Pharus.Services.Attributes
{
    using System;

    public class StringValue : Attribute
    {
        public string Value { get; private set; }

        public StringValue(string value)
        {
            Value = value;
        }
    }
}
