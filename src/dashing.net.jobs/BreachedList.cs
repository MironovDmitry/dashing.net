using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;

using MySql.Data.MySqlClient;

using dashing.net.common;
using dashing.net.streaming;

namespace dashing.net.jobs
{
    [Export(typeof(IJob))]
    public class BreachedList : IJob
    {
        private List<Workorder> rows = new List<Workorder>();

        public Lazy<Timer> Timer { get; private set; }

        public BreachedList()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["SDP_MySQL"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = (Properties.Resources.Top5BreachedRequests_sql);
            cmd.Connection = con;

            MySqlDataReader reader;
            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    //rows = [{ "cols"=>[{"value"=>"Name 1"}, {"value"=>"Value 1"}]},
                    //        {"cols"=>[{"value"=>"Name 2"}, {"value"=>"Value 2"}]},
                    //        {"cols"=>[{"value"=>"Name 3"}, {"value"=>"Value 3"}]},
                    //    {"cols"=>[{"value"=>"Name 4"}, {"value"=>"Value 4"}]}]
                    Workorder wo;
                    wo.workorderId = reader["WORKORDERID"].ToString();
                    wo.workorderTitle = reader["TITLE"].ToString();
                    wo.workorderOwner = reader["Technician"].ToString();
                    wo.workorderService = reader["ServiceName"].ToString();
                    wo.workorderDelay = Convert.ToInt16(reader["delay"].ToString()).ToString();

                    rows.Add(wo);
                }
            }
            catch
            {

            }
            finally
            {
                cmd.Connection.Close();
                con.Close();
            }

            Timer = new Lazy<Timer>(() => new Timer(SendMessage, null, TimeSpan.Zero, TimeSpan.FromSeconds(120)));
        }

        public void SendMessage(object sent)
        {

            //Dashing.SendMessage(new { id = "breachedList", rows = rows.Select(r => new { workorderId = r.workorderId, workorderTitle = r.workorderTitle, workorderOwner = r.workorderOwner, workorderDelay = r.workorderDelay }) });
            Dashing.SendMessage(new { id = "breachedList", rows});
        }

        private struct Workorder
        {
            public string workorderId;
            public string workorderTitle;
            public string workorderOwner;
            public string workorderDelay;
            public string workorderService;
        }
    }
}

