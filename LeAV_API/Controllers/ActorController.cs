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
    public class ActorController : ApiController
    {
        // GET api/actor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/actor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/actor
        public void Post([FromBody]string value)
        {
        }

        // PUT api/actor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/actor/5
        public void Delete(int id)
        {
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["LeAvServer"].ConnectionString);

        public List<Actor> GetActor()
        {
            List<Actor> aList = new List<Actor>();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("GetActor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Actor a = new Actor();
                    a.actor_id = Convert.ToInt32(dr["actor_id"]);
                    a.actor_name = dr["actor_name"].ToString();
                    a.cover_path = dr["cover_path"].ToString();
                    aList.Add(a);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
            }
            return aList;
        }
    }
}
