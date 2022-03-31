using System.ComponentModel.DataAnnotations;

namespace ClientApi.DTO.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NonEmptyGuidAttribute : ValidationAttribute
    {
        public override bool IsValid(object propValue)
        {
            if (propValue is not Guid guid)
            {
                return false;
            }
            return Guid.Empty != guid;
        }
    }
}
