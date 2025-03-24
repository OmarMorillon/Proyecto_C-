using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace Nuevo_Proyecto.Model
{
    public class Person
    {
        [Key]
        public required int BusinessEntityID { get; set; }

        public required string PersonType { get; set; }

        public required bool NameStyle { get; set; }

        public string? Title { get; set; }

        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public string? Suffix { get; set; }

        public required int EmailPromotion { get; set; }

        public XmlDocument? AdditionalContactInfo { get; set; }

        public XmlDocument? Demographics { get; set; }

        public required Guid rowguid { get; set; }

        public required DateTime ModifiedDate { get; set; }



    }
}
