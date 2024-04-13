namespace Trevo.API.Application.Implementations
{
    public static class UtilService
    {
        public static void CopyIfNotNullOrEmpty<TModel, T>(TModel source, T destination) where T : class
        {
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.CanRead && property.CanWrite)
                {
                    var value = source?.GetType().GetProperty(property.Name)?.GetValue(source);

                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                    {
                        property.SetValue(destination, value);
                    }
                }
            }
        }
    }
}
