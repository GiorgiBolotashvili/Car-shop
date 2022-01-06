using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Insert First Name")]
        [Required(ErrorMessage = "First name length at least 4 characters")]
        public string FirstName { get; set; }
        [Display(Name = "Insert Last Name")]
        [Required(ErrorMessage = "Last name length at least 4 characters")]
        public string LastName { get; set; }
        [Display(Name = "Insert Address")]
        [Required(ErrorMessage = "Address length at least 6 characters")]
        public string Address { get; set; }
        [Display(Name = "Insert Phone number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone length at least 9 characters")]
        public string Phone { get; set; }
        [Display(Name = "Insert Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
