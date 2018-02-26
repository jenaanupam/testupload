using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
 

namespace UserRegistration.Controllers
{
    public class WelComeController : Controller
    {
        public IActionResult Index()
        {
            EndUserDetailsModel md = new EndUserDetailsModel();
            return View(md);
        }
        public IActionResult Test()
        {
           
            return View( );
        }
        [HttpGet]
        public IActionResult EmailDetail()
        {
            return View(new EndUserDetailsModel());
        }

        [HttpPost]
        public IActionResult EmailDetail(EndUserDetailsModel mod)
        {
            return RedirectToAction("uploaddocuments");
        }

         
        public IActionResult FileUpload()
        {
            return View();
        }

        // [HttpGet]
        //public IActionResult Postjson()
        //{
        //    return null;
        //}


         
        public IActionResult Postjson( )
        {
            var files = Request.Form.Files;
            filesModel fmodel = new filesModel();
            fmodel.files = new List<FileUploadModel>();
            //FileUploadModel fl = new FileUploadModel();
            //fl.name = "twitter.png";
            //fl.size = 600000;
            //fl.url = "Download?fname=" + fl.name;
            //fl.thumbnail_url = "https://jquery-file-upload.appspot.com/image%2Fpng/195107973/twitter.png";
            
            //fl.delete_type = "DELETE";
            //fl.delete_url = "";
            //fmodel.files.Add(fl);

            foreach(var file in files)
            {
                savetodisk(file);
                fmodel.files.Add(new FileUploadModel {
                    name=file.FileName,
                    size=file.Length,
                    url= "Download?fname=" +file.FileName,
                    thumbnailUrl= "Download?fname=" + file.FileName,
                    deleteType="DELETE",
                    deleteUrl = "delete?fname=" + file.FileName

                });
            }


            // string k = @"{'files': [  {'name': 'picture1.jpg',  'size': 902604, 'url': 'http:\/\/ example.org\/ files\/ picture1.jpg', 'thumbnailUrl': 'http:\/\/ example.org\/ files\/ thumbnail\/ picture1.jpg', 'deleteUrl': 'http:\/\/ example.org\/ files\/ picture1.jpg','deleteType': 'DELETE'  }]}";
            return Json(fmodel);
           
        }

        private void savetodisk(IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);
            using (FileStream source =System.IO.File.Open(path,FileMode.Create))
            { 
                file.CopyTo(source);
            }
        }

        public FileResult Download(string fname)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fname);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            string fileName = fname;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public void delete(string fname)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fname);
            System.IO.File.Delete(path);
        }
    }
}