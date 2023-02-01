namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;

public static class MySqlRepository
{

public static string constring = @"server=localhost;port=3306;user=root;password=Shubham;database=ecommerce";
public static List<Product> GetAll()
    {
            List <Product> products = new List <Product>();
            string query = "SELECT * FROM products";

            IDbConnection con = new MySqlConnection();
            con.ConnectionString = constring;
            IDbCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
        try
        {
                    con.Open();
                    IDataReader reader = cmd.ExecuteReader();
             while(reader.Read())
            {
                    String id = reader["productid"].ToString();
                    string title=reader["title"].ToString();
                    string description=reader["description"].ToString();
                    int stockAvailable=int.Parse(reader["unitinstock"].ToString());
                    double unitPrice=double.Parse(reader["unitprice"].ToString());
                    //string category=reader["productLine"].ToString();

                Product product = new Product
                    {
                        ProductId = id,
                        Title = title,
                        Description=description,
                        UnitPrice=unitPrice,
                        //Category=category,
                        StockAvailable=stockAvailable,
                        //ImageUrl="/images/nano.jpg"
                    };
                    products.Add(product);
            }

        }
        catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        finally
            {
                con.Close();
            }
       return products;
    
    }  
     
}
