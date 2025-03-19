using System.ComponentModel.DataAnnotations;

namespace Nuevo_Proyecto.Model
{
    public class Person
    {
        [Key]
        public required string BusinessEntityID { get; set; }
        public required string PersonType { get; set; }
        public required string NameStyle { get; set; }
        public string Title {  get; set; } = string.Empty;
        public required string FirstName { get; set; }
        public string MiddleName {  get; set; } = string.Empty ;
        public required string LastName { get; set; }

        public string Suffix { get; set; } = string.Empty;

        public required string EmailPromotion { get; set; }

        public string AdditionalContactInfo { get; set; } = string.Empty;

        public string Demographics { get; set;} = string.Empty;

        public required string rowguid { get; set; }

        public required string ModifiedDate { get; set; }

      



    }
}
