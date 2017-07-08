using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LeAV_API.Models;

namespace LeAV_API.Controllers
{
    public class CategoryController : ApiController
    {
        // GET api/category
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/category/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/category
        public void Post([FromBody]string value)
        {
        }

        // PUT api/category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/category/5
        public void Delete(int id)
        {
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LeAvServer"].ConnectionString);

        public List<Cat> GetCategory()
        {
            List<Cat> catList = new List<Cat>();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("GetCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Cat c = new Cat();
                    c.cat_id = Convert.ToInt32(dr["cat_id"]);
                    c.cat_name = dr["cat_name"].ToString();
                    catList.Add(c);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
            }
            return catList;
        }
    }
}
