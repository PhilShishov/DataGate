namespace DataGate.Web.Infrastructure.Attributes.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    [AttributeUsage(AttributeTargets.Property)]
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            this.maxFileSize = maxFileSize;
        }

        public string GetErrorMessage()
        {
            return $"Maximum allowed file size is {this.maxFileSize} bytes.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > this.maxFileSize)
                {
                    return new ValidationResult(this.GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }
    }
}
