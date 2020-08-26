using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SIAM.Data.Models
{
    /// <summary>
    /// Класс-модель Заказ
    /// </summary>
    public class SalesOrder
    {
        [Key]
        public int SalesOrderId { get; set; }

        [Display(Name = "Дата заказа")]
        [Required]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Статус заказа")]
        [Required]
        public int SalesStatusId { get; set; }

        [Display(Name = "Идентификатор клиента")]
        [Required]
        public int CustomerId { get; set; }

        [Display(Name = "Комментарий")]
        [StringLength(2000)]
        public string Comment { get; set; }

        public virtual SalesStatus SalesStatus { get; set; }
        public virtual Customer Customer { get; set; }
        public List<SalesOrderDetail> SalesOrderDetails{ get; set; }
    }
}
