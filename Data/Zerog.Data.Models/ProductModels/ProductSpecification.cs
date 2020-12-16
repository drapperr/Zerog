namespace Zerog.Data.Models.ProductModels
{
    using Zerog.Data.Common.Models;

    public class ProductSpecification : BaseModel<int>
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int SpecificatonId { get; set; }

        public virtual Specificaton Specificaton { get; set; }

        public int SpecificatonInfoId { get; set; }

        public virtual SpecificatonInfo SpecificatonInfo { get; set; }
    }
}
