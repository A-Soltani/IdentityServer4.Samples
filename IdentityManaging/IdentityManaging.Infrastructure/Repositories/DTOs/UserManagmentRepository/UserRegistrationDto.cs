using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityManaging.Infrastructure.Repositories.DTOs.UserManagmentRepository
{
    public class UserRegistrationDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
        public string USSDPassword { get; set; }
        public bool IsActive { get; set; }
        public string MobilePhone { get; set; }
        public string FullNameOfOwner { get; set; }
        public string HomeAddress { get; set; }
        public string HomeTel { get; set; }
        public string MailAddress { get; set; }
        public string CodeMelli { get; set; }
        public string BDate { get; set; }
        public string FatherName { get; set; }
        public string Description { get; set; }
        public short UserType { get; set; }
        public int UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
