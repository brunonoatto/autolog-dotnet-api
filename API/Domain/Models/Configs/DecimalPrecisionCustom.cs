using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.Domain.Models.Configs
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DecimalPrecisionCustom : PrecisionAttribute
    {
        public DecimalPrecisionCustom() : base(10, 2) { }
    }
}