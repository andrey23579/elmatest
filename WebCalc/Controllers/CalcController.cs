using Calc;
using Domain.Managers;
using Domain.Models;
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
        private IHistoryManager Manager { get; set; }

        public CalcController()
        {
            Manager = new HistoryManager();
        }


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

            return View();
        }

        public ActionResult History()
       {  
            return View(GetOperation());
        }
  
    #region работа с бд
    private void AddOperation(string oper)
        {
           
            var history = new Domain.Models.History();
            history.CreationDate = DateTime.Now;
            history.Operation = "SUM";
            Manager.Add(history);
        }
        #endregion


        #region сохранение
        private IEnumerable<History> GetOperation()
        {
            return Manager.List();
          
        }

        #endregion
    }
}