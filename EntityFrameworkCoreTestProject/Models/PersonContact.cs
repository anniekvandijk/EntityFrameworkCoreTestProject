using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkCoreTestProject.Models
{
    [Table("Person Contact")]
    public class PersonContact
    {

        public PersonContact()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ContactId { get; set; }

        [MaxLength(8)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(25)]
        public string HomePhone { get; set; }

        [MaxLength(25)]
        public string MobilePhone { get; set; }

        public virtual AddressType Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }


}
