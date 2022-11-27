using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Prj_CAB_Core_MVC_ADO.Controllers
{
    public class PhonebookController : Controller
    {
        // GET: PhonebookController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PhonebookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhonebookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhonebookController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string first = collection["txtFN"].ToString();
                string last = collection["txtLN"].ToString();

                string constr = "server=localhost;user id=root;password=;database=cab_ncc;";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();

                string sql = "insert into phonebook(firstname,lastname)values('"+first+"','"+last+"')";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhonebookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhonebookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhonebookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhonebookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
