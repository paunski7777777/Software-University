namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Store
    {
        public int StoreId { get; set; }

        [Column(TypeName = "NVARCHAR(80)")]
        public string Name { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}