using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary;
using ModelLibrary.Model;

namespace Skabelon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkabelonController : ControllerBase
    {

        private string connectionstring =
                "Server=tcp:thefarmand.database.windows.net,1433;Initial Catalog=Thefarmand;Persist Security Info=False;User ID=Thefarmand;Password=Killer1963;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            ;

        // GET: api/BarCodeDatabase
        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<Cars> Get()
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query = new SqlCommand("SELECT * FROM  cars", conn);
            conn.Open();
            SqlDataReader laeser = query.ExecuteReader();
            List<Cars> UsersList = new List<Cars>();
            if (laeser.HasRows)
            {
                while (laeser.Read())
                {
                    Cars hs = new Cars { car_id = Convert.ToInt32(laeser[0]), car_model = Convert.ToString(laeser[1]), car_type = Convert.ToString(laeser[2]), car_year = Convert.ToInt32(laeser[3]), car_price = Convert.ToInt32(laeser[4])};
                    UsersList.Add(hs);
                }
            }
            conn.Close();
            return UsersList;
        }

        // GET: api/cars/1
        [HttpGet("{id}", Name = "GetOne")]
        public List<Cars> GetOne(int id)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query = new SqlCommand($"SELECT * FROM  cars WHERE car_id={id}", conn);
            conn.Open();
            SqlDataReader laeser = query.ExecuteReader();
            List<Cars> us = new List<Cars>();

            if (laeser.HasRows)
            {
                while (laeser.Read())
                {
                    Cars cs = new Cars
                    {
                        car_id = Convert.ToInt32(laeser[0]),
                        car_model = Convert.ToString(laeser[1]),
                        car_type = Convert.ToString(laeser[2]),
                        car_year = Convert.ToInt32(laeser[3]),
                        car_price = Convert.ToInt32(laeser[4])
                    };
                    us.Add(cs);
                }
            }
            conn.Close();
            return us;
        }

        // POST: /api/skabelon/model/Ford/type/Mustang/year/1966/price/85000 indsætter ny car
        [HttpPost("model/{model}/type/{type}/year/{year}/price/{price}")]
        public void Put(string model, string type, int year, int price)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query =
                new SqlCommand(
                    $"INSERT INTO cars(car_model, car_type, car_year, car_price) VALUES('{model}', '{type}', {year}, {price})",
                    conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }

        // PUT: api/skabelon/id/5/model/Ford/type/Mustang/year/1966/price/85000 opdaterer id 1
        [HttpPut("id/{id}/model/{model}/type/{type}/year/{year}/price/{price}")]
        public void Put(int id, string model, string type, int year, int price)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query =
                new SqlCommand(
                    $"UPDATE cars SET car_model = '{model}', car_type = '{type}', car_year = {year}, car_price = {price} WHERE car_id = {id}",
                    conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }

        // DELETE: api/skabelon/6 sletter car nr. 16
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand query = new SqlCommand($"DELETE FROM cars WHERE car_id = {id}", conn);
            conn.Open();
            query.ExecuteNonQuery();
            conn.Close();
        }
    }
}
