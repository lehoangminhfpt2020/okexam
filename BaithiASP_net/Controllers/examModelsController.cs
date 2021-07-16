using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaithiASP_net.DbConnect;
using BaithiASP_net.Models;

namespace BaithiASP_net.Controllers
{
    public class examModelsController : Controller
    {
        private DataConnect db = new DataConnect();

        // GET: examModels
        public ActionResult Index()
        {
            return View(db.examModel.ToList());
        }

        // GET: examModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examModel examModel = db.examModel.Find(id);
            if (examModel == null)
            {
                return HttpNotFound();
            }
            return View(examModel);
        }

        // GET: examModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: examModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Subject,StartTime,ExamDate,Duration,ClassRoom,Faculty,Status")] examModel examModel)
        {
            if (ModelState.IsValid)
            {
                db.examModel.Add(examModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examModel);
        }

        // GET: examModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examModel examModel = db.examModel.Find(id);
            if (examModel == null)
            {
                return HttpNotFound();
            }
            return View(examModel);
        }

        // POST: examModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject,StartTime,ExamDate,Duration,ClassRoom,Faculty,Status")] examModel examModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examModel);
        }

        // GET: examModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            examModel examModel = db.examModel.Find(id);
            if (examModel == null)
            {
                return HttpNotFound();
            }
            return View(examModel);
        }

        // POST: examModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            examModel examModel = db.examModel.Find(id);
            db.examModel.Remove(examModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
