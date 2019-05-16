using System.ComponentModel.DataAnnotations;

namespace BankAccountApp.Web.Models
{
    public class BankAccountViewModel
    {
        // Unique identifier
        public int Id { get; set; }

        // Bank account owner's first name
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        // Bank account owner's second name
        [Display(Name = "Second Name")]
        [Required]
        public string SecondName { get; set; }

        // Current amount of money
        [Required]
        public decimal Balance { get; set; }

        // Bonus points
        [Display(Name = "Bonus Points")]
        public int BonusPoints { get; set; }

        // Bank account type
        [Display(Name = "Account Type")]
        public string Type { get; set; }

        // Bank account status
        [Display(Name = "Closed?")]
        public bool IsOpened { get; set; }
    }
}