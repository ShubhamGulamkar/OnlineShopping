
namespace BLL;
using BOL;
using DAL;
using System.Collections.Generic;

public class ProductManager
{
public static ProductManager _ref = null;

private ProductManager()    ////Singleton 
{

}
public static ProductManager GetProductManager()
{
    if(_ref == null)
    {
        _ref = new ProductManager();
    }
    return _ref;
}

public List<Product> GetAllProducts()
{
    //List<Product>products = JSONRepository.GetAll();
    List<Product>products = MySqlRepository.GetAll();
    return products;
}
public Product GetProductById(int id){
        Product product=JSONRepository.GetById(id);
        return product;
    }

public List<Product> GetSoldOutProducts()
{
    List<Product>products=GetAllProducts();
    var SoldOutProduct = from prod in products where prod.StockAvailable == 0
                            select prod;
    return SoldOutProduct as List<Product>;
}

/*Public List<Product> GetProuductsInStockLessthan(int amount)
{
    List<Product> products = GetAllProducts();
    var theproducts = from prod in products where prod.StockAvailable > 0 && prod.UnitPrice > @amount
    select prod;
    return theproducts as List<Product>;
}*/

public List<String> GetProductTitles()
{
    List<Product> products = GetAllProducts();
    var title = from name in products select name.Title;

    return title as List<String>;
}

public List<Product> GetProductsOrderBy()
{
     List<Product> products = GetAllProducts();
    var sortedlist = from prod in products orderby prod.Title
                        select prod;

    return sortedlist as List<Product>;

}

public List<String> GetProductDistinct()
{
    List<Product> products = GetAllProducts();
    var distinctcat = (from prod in products select prod.Category).Distinct();   
    return distinctcat as List<String>; 
}


}
