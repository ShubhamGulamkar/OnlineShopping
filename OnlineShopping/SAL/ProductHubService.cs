namespace SAL;
using BOL;
using BLL;

public class ProductHubService
{
    public List<Product> GetAllProducts()
    {
        ProductManager themanager = ProductManager.GetProductManager();
        List<Product> theproduct = themanager.GetAllProducts();
        return theproduct;
    }

    public Product GetProductById(int Id)
    {
        ProductManager manager = ProductManager.GetProductManager();
        Product  theproduct=manager.GetProductById(Id);         
        return theproduct;
    }

}
