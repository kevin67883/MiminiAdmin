using System.ComponentModel.DataAnnotations;

namespace MiminiAdmin.Models
{
    public class tblProducto {
        [Key]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripción { get; set; }
        public decimal precio { get; set; }
        public string categoría { get; set; }
        public string sku { get; set; }
    }
}
