namespace SimplyHorsePower.Models
{
    public class EditProduct
    {
        public int Id { get; set; }

        public void EditAProduct(Product product)
        {
            product.ProductName = product.ProductName;
            product.ProductPrice = product.ProductPrice;
            product.ProductDescription = product.ProductDescription;
            product.MakeName = product.MakeName;
            product.CategoryName = product.CategoryName;
        }
    }
}
