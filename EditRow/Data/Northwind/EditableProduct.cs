using System.ComponentModel.DataAnnotations;

namespace EditRow.Data.Northwind {
    public class EditableProduct {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int? CategoryId { get; set; }

        public int? SupplierID { get; set; }

        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        public string QuantityPerUnit { get; set; }

        [Range(0, 10000, ErrorMessage = "Must be between 0 and 10000$")]
        public decimal? UnitPrice { get; set; }

        [Range(0, 1000, ErrorMessage = "Must be between 0 and 1000")]
        public short? UnitsInStock { get; set; }

        bool? discontinued;
        public bool? Discontinued {
            get { return discontinued; }
            set { discontinued = value == null ? false : value; }
        }
    }
}
