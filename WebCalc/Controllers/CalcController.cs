using Calc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        private string queryString;

        public Helper  CalcHelper { get; set; }
        // GET: Calc
        public ActionResult Index(CalcModel data)
        {
            var model = data ?? new CalcModel();

            if (ModelState.IsValid)
            {

                var calcHelper = new Helper();

                model.Result = calcHelper.Sum(model.X, model.Y);

                var oper = string.Format("{0} {1} {2} = {3}", model.X, "SUM", model.Y, model.Result);

                AddOperation(oper);
            }

            ViewData.Model = model;

            return View(GetOperation());
        }

        private object GetOperation()
        {
            throw new NotImplementedException();
        }
        #region работа с бд
        private void AddOperation(string oper)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ElmaCon"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            // connectionString))
            {
                var qerystring = string.Format("INSERT INTO [dbo].[History] ([Operation]) VALUES (N'{0}')", oper);
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        #endregion

     /*   private IEnumerable<string> GetOperation(string oper)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["tlmacon"].ConnectionString;

            var result = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            // connectionString))
            {
                var qerystring = string.Format("SELECT [Operation]FROM [dbo].[History] ");
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }
                reader.Close();
                
            }
            return result;
        }*/

        public ActionResult History()
        {
            return View(new List<string>() { "asdad", "asdass", "asdasdasdasdas" });
        }
        
    }
}