using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskSystem.BL.Models;
using TaskSystem.BL.Utils;
using TaskSystem.DL;
using ControllerBase = TaskSystem.Controllers._Common.ControllerBase;

namespace TaskSystem.Controllers
{
    public class WorkTasksController : ControllerBase
    {
        public WorkTasksController(IConfiguration configuration, AppDbContext appDbContext, IHostingEnvironment environment)
            : base(configuration, appDbContext, environment)
        {
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search(string term, string orderBy, bool isAsc = true, int take = 10, int skip = 0)
        {
            var model = Service.WorkTask.Search(term, orderBy, isAsc, take, skip);
            return Ok(model);
        }


        [HttpGet]
        [Route("CustomerUsers/{id}")]
        public IActionResult CustomerUsers(int id)
        {
            var items = Service.CustomerUser.CustomerUsers(id)
                .Select(x => new { id = x.Id, text = x.Name })
                .ToList();

            return Ok(new { results = items });
        }

        [HttpPost]
        [Route("SearchCustomer")]
        public IActionResult SearchCustomer(string term)
        {
            var items = Service.Customer.Autocomplete(term);
            return Ok(new { results = items });
        }

        [HttpPost]
        [Route("SearchCustomerUsers/{id?}")]
        public IActionResult SearchCustomerUsers(int? id)
        {
            if (!id.HasValue)
                return Ok(new { results = new List<CustomerUserItem>() });
            var items = Service.CustomerUser.CustomerUsers(id.Value);
            return Ok(new { results = items.Select(x => new { id = x.Id, text = x.Name }).ToList() });
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id = null)
        {
            var item = Service.WorkTask.Edit(id);
            return Ok(item);
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromBody] WorkTaskItem item)
        {
            Service.WorkTask.Save(item);
            return Ok(item);
        }

        [HttpPost]
        [Route("AddNote")]
        public IActionResult AddNote([FromBody] WorkTaskNoteItem item)
        {
            var note = Service.Note.AddNote(item.Note, item.WorkTaskId ?? 0);
            return Ok(note);
        }

        [HttpPost]
        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            Service.WorkTask.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("deletenote/{id?}")]
        public IActionResult DeleteNote(int id)
        {
            Service.Note.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("UploadDocument/{taskId}")]
        public IActionResult UploadDocument(IFormFile file, int taskId)
        {
            if (file == null)
                return BadRequest("Error while uploading file");

            var result = CommonUtils.UploadFileToDirectory(file, "UploadedDocuments");
            var doc = Service.Document.AddFile(result, taskId);
            return Ok(doc);
        }

        [HttpPost]
        [Route("DeleteDocument/{id}")]
        public IActionResult DeleteDocument(int id)
        {
            try
            {
                var path = Service.Document.GetFile(id).Path;
                var fullPath = ServiceProviders.RootDirectory + path.Replace("/", "\\").Trim('\\');
                System.IO.File.Delete(fullPath);
            }
            catch { }
            Service.Document.DeleteFile(id);
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("DownloadDocument")]
        public IActionResult DownloadDocument(string path)
        {
            var fullPath = ServiceProviders.RootDirectory + path.Replace("/", "\\").Trim('\\');
            var bytes = System.IO.File.ReadAllBytes(fullPath);
            var extension = System.IO.Path.GetExtension(fullPath);
            var fileName = System.IO.Path.GetFileName(fullPath);
            var mime = CommonValues.FileMappings.Single(x => x.Key.ToLower() == extension).Value;
            return File(bytes, mime, fileName);
        }
    }
}
