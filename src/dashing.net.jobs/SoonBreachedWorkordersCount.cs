﻿using System;
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
    class SoonBreachedWorkordersCount : IJob
    {
        private int requestsCount;

        public Lazy<Timer> Timer { get; private set; }

        public SoonBreachedWorkordersCount()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["SDP_MySQL"].ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = (Properties.Resources.sooBreachedWOsCount_sql);
            cmd.Connection = con;

            MySqlDataReader reader;
            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    requestsCount = Convert.ToInt16(reader["soonBreachedWorkordersCount"]);
                }
            }
            catch
            {

            }
            finally
            {
                cmd.Connection.Close();
            }

            Timer = new Lazy<Timer>(() => new Timer(SendMessage, null, TimeSpan.Zero, TimeSpan.FromSeconds(120)));
        }

        public void SendMessage(object sent)
        {

            Dashing.SendMessage(new { current = requestsCount, id = "soonBreachedWorkordersCount" });
        }
    }
}
