namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;

public class DBManagerDisConnected
{
    public static string constring = @"server = localhost;port=3306;user=root;password=Shubham;database=transflower";
    public static List<Department>GetAllDepartment(){
        List<Department> allDepartments = new List<Department>();
        
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString  = constring;
        try
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            string query = "SELECT * FROM departments";
            cmd.CommandText=query;

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection  rows = dt.Rows;
            foreach(DataRow row in rows)
            {
                int id = int.parse(row["id"].ToString());
                String name = (row["name"].ToString());
                string location = row["location"].ToString();
                Department dept=new Department{
                                                    Id = id,
                                                    Name = name,
                                                    Location = location
                    };
                allDepartments.Add(dept);
            }



        }
        catch(Exception ee){
                Console.WriteLine(ee.Message);
        }
        return allDepartments;
    