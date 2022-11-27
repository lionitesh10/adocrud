using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Prj_CAB_Core_MVC_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prj_CAB_Core_MVC_ADO.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            string constr = "server=localhost;user id=root;password=;database=cab_ncc;";
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            string sql = "select * from phonebook";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Student> list = new List<Student>();

            while (reader.Read())
            {
                Student obj = new Student();
                obj.id = Convert.ToInt32(reader["id"]);
                obj.FirstName = reader["firstname"].ToString();
                obj.LastName = reader["lastname"].ToString();

                list.Add(obj);
            }

            con.Close();
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            string constr = "server=localhost;user id=root;password=;database=cab_ncc;";
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            string sql = "select * from phonebook";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader reader = cmd.ExecuteReader();

            Student obj = new Student();
            while (reader.Read())
            {
                obj.id = Convert.ToInt32(reader["id"]);
                obj.FirstName = reader["firstname"].ToString();
                obj.LastName = reader["lastname"].ToString();
            }

            con.Close();
            return View(obj);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student collection) //Using Model
        {
            try
            {
                string first = collection.FirstName;
                string last = collection.LastName;

                string constr = "server=localhost;user id=root;password=;database=cab_ncc;";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();

                string sql = "insert into phonebook(firstname,lastname)values('" + first + "','" + last + "')";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            string constr = "server=localhost;user id=root;password=;database=cab_ncc;";
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            string sql = "select * from phonebook";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader reader = cmd.ExecuteReader();

            Student obj = new Student();
            while (reader.Read())
            {
                obj.id = Convert.ToInt32(reader["id"]);
                obj.FirstName = reader["firstname"].ToString();
                obj.LastName = reader["lastname"].ToString();
            }

            con.Close();
            return View(obj);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student collection)
        {
            try
            {
                string first = collection.FirstName;
                string last = collection.LastName;

                string constr = "server=localhost;user id=root;password=;database=cab_ncc;";
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();

                //update phonebook set firstname='ram',lastname='karki' where id=9
                string sql = "update phonebook set firstname='" + first + "',lastname='" + last + "' where id=" + id;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            string constr = "server=localhost;user id=root;password=;database=cab_ncc;";
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();

            string sql = "delete from phonebook where id=" + id;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            con.Close();
            return RedirectToAction(nameof(Index));
        }

        // POST: StudentController/Delete/5
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
