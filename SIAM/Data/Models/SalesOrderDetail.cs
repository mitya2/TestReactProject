using System;
using System.ComponentModel.DataAnnotations;

namespace TestDB.Models
{
    /// <summary>
    /// Класс-модель Позиция заказа 
    /// </summary>
    public class SalesOrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Идентификатор заказа")]
        [Required]
        public int SalesOrderId { get; set; }

        [Display(Name = "Идентификатор продукта")]
        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Количество")]
        [Required]
        public int OrderQuantity { get; set; }

        [Display(Name = "Цена по прайсу на момент формирования заказа")]
        [Required]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Дата изменения")]
        [Required]
        public DateTime ModifyDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
