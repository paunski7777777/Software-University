namespace SIS.Framework.Attributes.Properties
{
    using System.ComponentModel.DataAnnotations;

    public class NumberRangeAttribute : ValidationAttribute
    {
        private readonly double minimumValue;
        private readonly double maximumValue;

        public NumberRangeAttribute(double minimumValue, double maximumValue)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        public override bool IsValid(object value)
        {
            var valueAsNumber = (double)value;

            return valueAsNumber >= minimumValue && valueAsNumber <= maximumValue;
        }
    }
}