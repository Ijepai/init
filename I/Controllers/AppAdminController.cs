using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using I.Models;

namespace I.Controllers
{
    public class AppAdminController : Controller
    {
        private DB db = new DB();

        //
        // GET: /AppAdmin/

        public ActionResult Index()
        {
            var organizations = db.Organizations.Include(o => o.Organization_Status);
            return View(organizations.ToList());
        }

        //
        // GET: /AppAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // GET: /AppAdmin/Create

        public ActionResult Create()
        {
            ViewBag.OrganizationStatusID = new SelectList(db.Organization_Status, "ID", "Status");
            return View();
        }

        //
        // POST: /AppAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Add(organization);
                db.SaveChanges();
                //WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserCode", autoCreateTables: true);
                var PropertyValues = new
                {
                    OrganizationID = organization.ID,
                    UserStatusID = 1,
                    UserName = "admin"
                };
                WebMatrix.WebData.WebSecurity.CreateUserAndAccount(organization.OrganizationCode + "-" + "admin", "admin", propertyValues: PropertyValues);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationStatusID = new SelectList(db.Organization_Status, "ID", "Status", organization.OrganizationStatusID);
            return View(organization);
        }

        //
        // GET: /AppAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationStatusID = new SelectList(db.Organization_Status, "ID", "Status", organization.OrganizationStatusID);
            return View(organization);
        }

        //
        // POST: /AppAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationStatusID = new SelectList(db.Organization_Status, "ID", "Status", organization.OrganizationStatusID);
            return View(organization);
        }

        //
        // GET: /AppAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // POST: /AppAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}