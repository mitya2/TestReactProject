using System.ComponentModel.DataAnnotations;

namespace SIAM.Data.Models
{
    /// <summary>
    /// Класс-модель Продукт
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Наименование продукта")]
        [StringLength(200)]
        [Required(ErrorMessage = "Наименование продукта должно содержать от 1 до 200 символов", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "Цена продукта")]
        [Required]
        public decimal Price;

        [Display(Name = "Комментарий")]
        [StringLength(2000)]
        public string Comment { get; set; }
        
    }
}