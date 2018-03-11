// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.Extensions.DependencyInjection;
// using sybids.Models;

// namespace sybids.Repo {
//     public class BidsSqlContext {
//         private string ConnectionString { get; set; }

//         public BidsSqlContext(string connectionString) {
//             ConnectionString = connectionString;
//         }

//         private MySqlConnection GetConnection() {
//             return new MySqlConnection(ConnectionString);
//         }

//         public List<LineModel> GetAllLines() {
//             List<LineModel> lines = new List<LineModel>();

//             using(MySqlConnection conn = GetConnection()) {
//                 conn.Open();
//                 MySqlCommand cmd = new MySqlCommand("SELECT * FROM lines", conn);
//                 using(MySqlDataReader reader = cmd.ExecuteReader()) {
//                     while(reader.Read()) {
//                         lines.Add(new LineModel() {
//                             LineId = reader.GetInt16("lineId"),
//                             Base = reader.GetString("base"),

//                         })
//                     }
//                 }
//             }
//         }
//     }
// }