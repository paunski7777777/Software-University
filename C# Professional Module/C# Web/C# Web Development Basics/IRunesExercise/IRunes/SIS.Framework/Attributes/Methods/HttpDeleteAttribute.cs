namespace SIS.Framework.Attributes.Methods
{
    class HttpDeleteAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToLower() == "delete")
            {
                return true;
            }

            return false;
        }
    }
}
