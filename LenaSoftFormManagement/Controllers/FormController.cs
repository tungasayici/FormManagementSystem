using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LenaSoftFormManagement.Models;

namespace LenaSoftFormManagement.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        DbModel db = new DbModel();
        // GET: Form
        public ActionResult Index(string searching)
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(db.Forms.Where(x => x.FormName.Contains(searching) || searching == null).ToList());
            }
        }

        // GET: Form/Details/5
        public ActionResult Details(int id)
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Forms.Where(x => x.FormID == id).FirstOrDefault());
            }
        }

        // GET: Form/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Form/Create
        [HttpPost]
        public ActionResult Create(Form form)
        {
            try
            {
                using (DbModel dbModel = new DbModel())
                {
                    dbModel.Forms.Add(form);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Form/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Forms.Where(x => x.FormID == id ).FirstOrDefault());
            }
        }

        // POST: Form/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Form form)
        {
            try
            {
                using (DbModel dbModel = new DbModel())
                {
                    dbModel.Entry(form).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Form/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Forms.Where(x => x.FormID == id).FirstOrDefault());
            }
        }

        // POST: Form/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModel dbModel = new DbModel())
                {
                    Form form = dbModel.Forms.Where(x => x.FormID == id).FirstOrDefault();
                    dbModel.Forms.Remove(form);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
