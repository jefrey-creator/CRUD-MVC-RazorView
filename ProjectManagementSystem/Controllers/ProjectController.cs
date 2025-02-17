
using ProjectManagementSystem.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            return View(db.ProjectDb.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectId,ProjectName,ProjectCost,ProjectStatus")] ProjectModel project)
        {
            if (!ModelState.IsValid)
            {
                 return View();
            }

            db.ProjectDb.Add(project);
            db.SaveChanges();
            TempData["Message"] = $"{project.ProjectName} successfully created.";
            return RedirectToAction("Index");
        }

        public ActionResult Edit (int? id)
        {
            if(id == null)
            {
                TempData["400"] = "Bad request.";
                return RedirectToAction("Index");
            }

            ProjectModel project = db.ProjectDb.Find(id);

            if(project == null)
            {
                TempData["404"] = "Not found!.";
                return RedirectToAction("Index");
            }
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectId,ProjectName,ProjectCost,ProjectStatus")] ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = $"{project.ProjectName} successfully updated.";
                return RedirectToAction("Index");
            }

            return View(project);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["400"] = "Bad request.";
                return RedirectToAction("Index");
            }
            ProjectModel project = db.ProjectDb.Find(id);
            if (project == null)
            {
                TempData["404"] = "Project not found.";
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["400"] = "Bad request.";
                return RedirectToAction("Index");
            }
            ProjectModel project = db.ProjectDb.Find(id);
            if (project == null)
            {
                TempData["404"] = "Project not found.";
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectModel project = db.ProjectDb.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            db.ProjectDb.Remove(project);
            db.SaveChanges();
            TempData["Message"] = $"{project.ProjectName} successfully deleted.";
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
