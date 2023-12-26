using JinjiApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace JinjiApp1.Data
{
    public class HrmsoService
    {
        private HrmsoContext _context { get; }
        public static string? ConnectionString { get; set; }

        public HrmsoService(HrmsoContext context)
        {
            _context = context;
            ConnectionString = _context.Database.GetDbConnection().ConnectionString;
        }

        public void InsertData(string name, int age)
        {
            Person p = new Person();
            p.Name = name;
            p.Age = age;
            _context.Add(p);
            _context.SaveChanges();
        }

        public List<Person> GetPersonAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select *");
            sb.AppendLine("from Person");
            string sql = sb.ToString();
            DataTable dt = HrmsoService.ExecQuery(sql);
            List<Person> results = new List<Person>();
            foreach (DataRow row in dt.Rows)
            {
                Person p = new Person();
                p.Id = (int)row["Id"];
                p.Name = row["Name"] == DBNull.Value ? "" : (string)row["Name"];
                p.Age = (int)row["Age"];
                results.Add(p);
            }

            return results;
        }

        public static DataTable ExecQuery(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConnectionString;
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }

            return dt;
        }
    }
}
