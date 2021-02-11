using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dash.Models;
using System.IO;

namespace Dash.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [HttpGet]
        [CheckLoginSessionFilter]
        public ActionResult DisplayProjectList()
        {
           /* var projectfiles = new ProjectFiles();
            projectfiles.*/
            List<ProjectFiles> DisplayProjectList = new List<ProjectFiles>();
            ProjectFiles pf = new ProjectFiles();
            pf.NameP = "Hotel Management";
            pf.Description = "Project is build in ASP.NET Using C# language and MS-SQL";
            DisplayProjectList.Add(pf);

            pf = new ProjectFiles();
            pf.NameP = "Client Management";
            pf.Description = "Project is build in ASP.NET Using Visual Basic language and SQL server";
            DisplayProjectList.Add(pf);
            return View(DisplayProjectList);
        }

        [HttpGet]
        [CheckLoginSessionFilter]
        public ActionResult UploadFiles()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase[] files)
        {

            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Data/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                }
             }
            return View();
        }
        [HttpGet]
        public ActionResult Downloads()
        {
            var dir = new DirectoryInfo(Server.MapPath("~/Data/"));
            FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }
        public FileResult Download(string FileName)
        {
            var FileVirtualPath = "~/Data/" + FileName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }


    }
}