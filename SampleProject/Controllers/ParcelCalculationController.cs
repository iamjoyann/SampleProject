using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class ParcelCalculationController : Controller
    {
        // GET: ParcelCalculation
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult CalculateParcel(int weight, int height, int width, int depth) {
            string Rule = "";
            string Cost = "";
            int volume =   height * width * depth;
            try
            {
                Rule = GetRule(weight, volume);
                Cost = GetCost(weight, volume, Rule); 
            }
            catch (Exception)
            { 
                throw;
            }

            var dataResult = new
            {
                Rule = Rule,
                Price = Cost
            };

            return Json(dataResult);
        }

        public string GetRule(int weight, int volume) {
            string Rule = "";
            if (weight > 50)
            {
                Rule = "Reject"; 
            }
            else if (weight > 10 && weight <= 50)
            {
                Rule = "Heavy"; 
            }
            else if (volume < 1500)
            {
                Rule = "Small"; 
            }
            else if (volume < 2500 && volume >= 1500)
            {
                Rule = "Medium"; 
            }
            else
            {
                Rule = "Large"; 
            }
            return Rule;
        }

        public string GetCost(int weight, int volume, string rule) {
            string Cost = "";

            switch (rule)
            {
                case "Reject":
                    Cost = "N/A";
                    break;
                case "Heavy":
                    Cost = (15 * weight).ToString();
                    break;
                case "Small":
                    Cost = ((.05 * volume) * 100).ToString();
                    break;
                case "Medium":
                    Cost = ((.04 * volume) * 100).ToString();
                    break;
                default:
                    Cost = ((.03 * volume) * 100).ToString();
                    break;
            }

            return Cost;
        }
    }
}