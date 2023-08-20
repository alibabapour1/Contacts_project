using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

public class Contacts
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }

    public string Address { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^09\d{9}$", ErrorMessage = "Phone number must start with '09' and have a total of 11 digits.")]
    public string PhoneNumber { get; set; }



    public override string ToString()
    {
        return $"{Name} {LastName} - {PhoneNumber}  ---    {Address}";
    }
}

