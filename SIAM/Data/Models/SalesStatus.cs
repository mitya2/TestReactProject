using System.ComponentModel.DataAnnotations;

namespace TestDB.Data.Models
{
    /// <summary>
    /// Класс-модель Статус заказа
    /// </summary>
    public class SalesStatus
    {
        [Key]
        public int SalesStatusId { get; set; }

        [Display(Name = "Название статуса")]
        [StringLength(50)]
        [Required(ErrorMessage = "Название статуса должно содержать от 1 до 50 символов", AllowEmptyStrings = false)]
        public string Name { get; set; }
       
    }
}
