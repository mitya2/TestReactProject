using System.ComponentModel.DataAnnotations;

namespace TestDB.Models
{
    /// <summary>
    /// Класс-модель Клиент
    /// </summary>
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Наименование клиента")]
        [StringLength(2000)]
        [Required(ErrorMessage = "Наименование клиента должно содержать от 1 до 2000 символов", AllowEmptyStrings = false)]
        public string Name { get; set; }
       
    }
}
