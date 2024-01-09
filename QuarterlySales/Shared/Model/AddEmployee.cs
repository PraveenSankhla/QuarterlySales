using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Shared.Model
{
    public class AddEmp
    {
        [Required(ErrorMessage = "First name is required")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        [DateOfBirthValidation(ErrorMessage = "Date of Birth should be less than today")]
        public DateTime? dob { get; set; }

        [Required(ErrorMessage = "Hire Date is required")]
        [HireDateValidation(ErrorMessage = "Hire date should be on or after 01/01/1995")]
        public DateTime? hiredate { get; set; }

        [Required(ErrorMessage = "Manager name is required")]
        [ManagerValidation(ErrorMessage = "Manager and Employee can't be the the same person")]
        public string manager { get; set; }
    }

    public class DateOfBirthValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime? dateOfBirth = value as DateTime?;
            if (dateOfBirth.HasValue && dateOfBirth.Value > DateTime.Today)
            {
                return false;
            }
            return true;
        }
    }

    public class HireDateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime? hireDate = value as DateTime?;
            DateTime minHireDate = new DateTime(1995, 1, 1);

            if (hireDate.HasValue && (hireDate.Value < minHireDate || hireDate.Value > DateTime.Today))
            {
                return false;
            }
            return true;
        }
    }

    public class ManagerValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var managerProperty = validationContext.ObjectType.GetProperty("manager");
            var managerValue = managerProperty.GetValue(validationContext.ObjectInstance, null)?.ToString().ToLower();

            var firstNameProperty = validationContext.ObjectType.GetProperty("firstname");
            var lastNameProperty = validationContext.ObjectType.GetProperty("lastname");

            var firstNameValue = firstNameProperty.GetValue(validationContext.ObjectInstance, null)?.ToString().ToLower();
            var lastNameValue = lastNameProperty.GetValue(validationContext.ObjectInstance, null)?.ToString().ToLower();

            if (managerValue != null && firstNameValue != null && lastNameValue != null)
            {
                if (managerValue.Equals($"{firstNameValue} {lastNameValue}"))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }


    public class AddSale
    {
        [Required(ErrorMessage = "Quarter is required")]
        [Range(1, 4, ErrorMessage = "Quarter must be between 1 and 4")]
        public int? Quarter { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [RegularExpression(@"^(200[1-9]|20[1-9]\d|[2-9]\d{3,})$", ErrorMessage = "Year must be after the year 2000")]
        public int? year { get; set; }

        [Required(ErrorMessage = "Amount is Required")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public double? amount { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [UniqueSalesData(ErrorMessage = "Sales data with the same Quarter, Year, and Employee already exists")]
        public string employee { get; set; }
    }

    public class UniqueSalesDataAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<AddSale> result = new List<AddSale>
            {
             new AddSale
             {
                 year = 2019,
                 Quarter = 1,
                 employee = "Grace Hopper",
                 amount = 664.83
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 2,
                 employee = "Grace Hopper",
                 amount = 458.23
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 3,
                 employee = "Grace Hopper",
                 amount = 8847.45
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 4,
                 employee = "Grace Hopper",
                 amount = 152.52
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 1,
                 employee = "Katherine Johnson",
                 amount = 369.23
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 2,
                 employee = "Katherine Johnson",
                 amount = 749.23
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 3,
                 employee = "Katherine Johnson",
                 amount = 29.23
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 4,
                 employee = "Katherine Johnson",
                 amount = 519.23
             },
            };

            var quarterProperty = validationContext.ObjectType.GetProperty("Quarter");
            var yearProperty = validationContext.ObjectType.GetProperty("year");
            var employeeProperty = validationContext.ObjectType.GetProperty("employee");

            var quarterValue = quarterProperty.GetValue(validationContext.ObjectInstance) as int?;
            var yearValue = yearProperty.GetValue(validationContext.ObjectInstance) as int?;
            var employeeValue = employeeProperty.GetValue(validationContext.ObjectInstance)?.ToString();

            var salesData = result.ToList();

            if (salesData.Any(s => s.Quarter == quarterValue && s.year == yearValue && s.employee == employeeValue))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
