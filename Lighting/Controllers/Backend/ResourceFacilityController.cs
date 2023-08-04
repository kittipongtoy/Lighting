using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class ResourceFacilityController : Controller
    {

        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;

        public ResourceFacilityController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }

        public IActionResult History()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TableHistory()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.HistoryResponse>();
                var History = await db.History.ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.HistoryResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Title_EN = item.Title_EN,
                        Title_TH = item.Title_TH,
                        Status = item.Status,
                        SubTitle_EN = item.SubTitle_EN,
                        SubTitle_TH = item.SubTitle_TH
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Title_EN.Contains(searchValue)
                    || x.Title_EN.Contains(searchValue)
                    || x.Title_TH.Contains(searchValue)
                    || x.SubTitle_EN.Contains(searchValue)
                    || x.SubTitle_TH.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult History_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> History_Add_Submit(RequestDTO.HistoryRequest model)
        {
            try
            {
                History history = new History();
                history.Title_TH = model.Title_TH;
                history.Title_EN = model.Title_EN;
                history.SubTitle_EN = model.SubTitle_EN;
                history.SubTitle_TH = model.SubTitle_TH;
                history.Status = model.Status;
                history.created_at = DateTime.Now;
                history.updated_at = DateTime.Now;
                db.History.Add(history);
                await db.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult History_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory_Edit(int? Id)
        {
            try
            {
                var DB = await db.History.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> History_Edit_Submit(RequestDTO.HistoryRequest model)
        {
            try
            {
                var DB = await db.History.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.SubTitle_EN = model.SubTitle_EN;
                    DB.SubTitle_TH = model.SubTitle_TH;
                    DB.Status = model.Status;
                    db.Entry(DB).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> History_Delete(int? Id)
        {
            try
            {
                var DB = db.History.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    db.History.Remove(DB);
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> History_Change(int? Id)
        {
            try
            {
                var DB = db.History.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    db.Entry(DB).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> TableHistoryDetail()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.HistoryDetailResponse>();
                var History = await db.HistoryDetail.ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.HistoryDetailResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Title_EN = item.Title_EN,
                        Title_TH = item.Title_TH,
                        Status = item.Status,
                        Detail_EN = item.Detail_TH,
                        Detail_TH = item.Detail_TH,
                        FileCompany_EN = item.FileCompany_EN,
                        FileCompany_TH = item.FileCompany_TH,
                        ImageEN = item.ImageEN,
                        ImageTH = item.ImageTH
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Title_EN.Contains(searchValue)
                    || x.Title_EN.Contains(searchValue)
                    || x.Title_TH.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult HistoryDetail_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> HistoryDetail_Add_Submit(RequestDTO.HistoryDetailRequest model)
        {
            try
            {

                if (model.Status == 1)
                {
                    var check_other = from up2 in db.HistoryDetail
                                      where up2.Status == 1
                                      select up2;
                    foreach (HistoryDetail up2 in check_other)
                    {
                        up2.Status = 0;
                    }
                    db.SaveChanges();
                }

                HistoryDetail historyDetail = new HistoryDetail();
                historyDetail.Title_TH = model.Title_TH;
                historyDetail.Title_EN = model.Title_EN;
                historyDetail.Detail_TH = model.Detail_TH;
                historyDetail.Detail_EN = model.Detail_EN;

                if (model.uploaded_ImageTH != null)
                {
                    foreach (var formFile in model.uploaded_ImageTH)
                    {
                        if (formFile.Length > 0)
                        {
                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            historyDetail.ImageTH = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (model.uploaded_ImageEN != null)
                {
                    foreach (var formFile in model.uploaded_ImageEN)
                    {
                        if (formFile.Length > 0)
                        {
                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            historyDetail.ImageEN = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (model.uploaded_fileEN != null)
                {
                    foreach (var formFile in model.uploaded_fileEN)
                    {
                        if (formFile.Length > 0)
                        {
                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            historyDetail.FileCompany_EN = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (model.uploaded_fileTH != null)
                {
                    foreach (var formFile in model.uploaded_fileTH)
                    {
                        if (formFile.Length > 0)
                        {
                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            historyDetail.FileCompany_TH = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                historyDetail.Status = model.Status;
                historyDetail.created_at = DateTime.Now;
                historyDetail.updated_at = DateTime.Now;
                db.HistoryDetail.Add(historyDetail);
                await db.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult HistoryDetail_Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("History", "ResourceFacility");
            }
            var get_detail = db.HistoryDetail.Where(x => x.Id == Id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("History", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { HistoryDetail = get_detail };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetHistoryDetail_Edit(int? Id)
        {
            try
            {
                var DB = await db.HistoryDetail.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> HistoryDetail_Edit_Submit(RequestDTO.HistoryDetailRequest model)
        {
            try
            {
                var DB = await db.HistoryDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    if (model.Status == 1)
                    {
                        var check_other = from up2 in db.HistoryDetail
                                          where up2.Id != model.Id && up2.Status == 1
                                          select up2;
                        foreach (HistoryDetail up2 in check_other)
                        {
                            up2.Status = 0;
                        }
                        db.SaveChanges();
                    }

                    if (model.uploaded_ImageTH != null)
                    {
                        foreach (var formFile in model.uploaded_ImageTH)
                        {
                            if (formFile.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + DB.ImageTH);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.Ticks.ToString();
                                var extension = Path.GetExtension(formFile.FileName);
                                DB.ImageTH = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFile.CopyTo(stream);
                                }
                            }
                        }
                    }

                    if (model.uploaded_ImageEN != null)
                    {
                        foreach (var formFile in model.uploaded_ImageEN)
                        {
                            if (formFile.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + DB.ImageEN);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.Ticks.ToString();
                                var extension = Path.GetExtension(formFile.FileName);
                                DB.ImageEN = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFile.CopyTo(stream);
                                }
                            }
                        }
                    }

                    if (model.uploaded_fileEN != null)
                    {
                        foreach (var formFile in model.uploaded_fileEN)
                        {
                            if (formFile.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileCompany_EN);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.Ticks.ToString();
                                var extension = Path.GetExtension(formFile.FileName);
                                DB.FileCompany_EN = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFile.CopyTo(stream);
                                }
                            }
                        }
                    }

                    if (model.uploaded_fileTH != null)
                    {
                        foreach (var formFile in model.uploaded_fileTH)
                        {
                            if (formFile.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileCompany_TH);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.Ticks.ToString();
                                var extension = Path.GetExtension(formFile.FileName);
                                DB.FileCompany_TH = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFile.CopyTo(stream);
                                }
                            }
                        }
                    }

                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.Detail_TH = model.Detail_TH;
                    DB.Detail_EN = model.Detail_EN;
                    DB.Status = model.Status;
                    DB.updated_at = DateTime.Now;
                    DB.Status = model.Status;
                    db.Entry(DB).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> HistoryDetail_Delete(int? Id)
        {
            try
            {
                try
                {
                    var DB = db.HistoryDetail.FirstOrDefault(x => x.Id == Id);
                    if (DB is not null)
                    {
                        var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileCompany_TH);
                        if (System.IO.File.Exists(old_filePath) == true)
                        {
                            System.IO.File.Delete(old_filePath);
                        }
                        var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileCompany_EN);
                        if (System.IO.File.Exists(old_filePath2) == true)
                        {
                            System.IO.File.Delete(old_filePath2);
                        }
                        var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.ImageTH);
                        if (System.IO.File.Exists(old_filePath3) == true)
                        {
                            System.IO.File.Delete(old_filePath3);
                        }
                        var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.ImageEN);
                        if (System.IO.File.Exists(old_filePath4) == true)
                        {
                            System.IO.File.Delete(old_filePath4);
                        }

                        db.HistoryDetail.Remove(DB);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("ไม่มีข้อมูล");
                    }
                    return new JsonResult(new { status = "success", messageArray = "success" });
                }
                catch (Exception error)
                {
                    throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> HistoryDetail_Change(int? Id)
        {
            try
            {
                var DB = db.HistoryDetail.FirstOrDefault(x => x.Id == Id);
                if (DB != null)
                {
                    if (DB.Status != 1)
                    {
                        var Change = db.HistoryDetail.ToList();
                        foreach (var item in Change)
                        {
                            item.Status = 0;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        if (DB.Status == 1)
                        {
                            DB.Status = 0;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            DB.Status = 1;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult HistoryVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TableHistoryVideo()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.HistoryDataDetailResponse>();
                var History = await db.HistoryDataDetail.Where(x => x.TypeData == 1).ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.HistoryDataDetailResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        TypeData = item.TypeData,
                        Status = item.Status,
                        ImageEN = item.ImageEN,
                        ImageTH = item.ImageTH,
                        FileVideoEN = item.FileVideoEN,
                        FileVideoTH = item.FileVideoTH
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult HistoryVideo_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> HistoryVideo_Add_Submit(RequestDTO.HistoryDataDetailRequest model)
        {
            try
            {
                HistoryDataDetail historyDataDetail = new HistoryDataDetail();

                //if (model.FileVideoEN == null && model.uploaded_fileEN != null)
                //{
                //    return new JsonResult(new { status = "error", messageArray = "error" });
                //}
                //else
                //{
                //    if (model.FileVideoEN != null)
                //    {
                //        historyDataDetail.FileVideoEN = model.FileVideoEN;
                //    }

                //    if (model.uploaded_fileEN != null)
                //    {
                //        foreach (var formFile in model.uploaded_fileEN)
                //        {
                //            if (formFile.Length > 0)
                //            {
                //                var datestr = DateTime.Now.Ticks.ToString();
                //                var extension = Path.GetExtension(formFile.FileName);
                //                historyDataDetail.FileVideoEN = datestr + extension;
                //                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
                //                using (var stream = System.IO.File.Create(filePath))
                //                {
                //                    formFile.CopyTo(stream);
                //                }
                //            }
                //        }
                //    }
                //}

                //if (model.FileVideoTH == null && model.uploaded_fileTH != null)
                //{
                //    return new JsonResult(new { status = "error", messageArray = "error" });
                //}
                //else
                //{
                //    if (model.FileVideoTH != null)
                //    {
                //        historyDataDetail.FileVideoTH = model.FileVideoTH;
                //    }

                //    if (model.uploaded_fileTH != null)
                //    {
                //        foreach (var formFile in model.uploaded_fileTH)
                //        {
                //            if (formFile.Length > 0)
                //            {
                //                var datestr = DateTime.Now.Ticks.ToString();
                //                var extension = Path.GetExtension(formFile.FileName);
                //                historyDataDetail.FileVideoTH = datestr + extension;
                //                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
                //                using (var stream = System.IO.File.Create(filePath))
                //                {
                //                    formFile.CopyTo(stream);
                //                }
                //            }
                //        }
                //    }
                //}

                if (model.Status == 1)
                {
                    var check_other = from up2 in db.HistoryDataDetail
                                      where up2.Status == 1 && up2.TypeData == 1
                                      select up2;
                    foreach (HistoryDataDetail up2 in check_other)
                    {
                        up2.Status = 0;
                    }
                    db.SaveChanges();
                }

                historyDataDetail.FileVideoTH = model.FileVideoTH;
                historyDataDetail.FileVideoEN = model.FileVideoEN;
                historyDataDetail.TypeData = 1;
                historyDataDetail.Status = model.Status;
                historyDataDetail.created_at = DateTime.Now;
                historyDataDetail.updated_at = DateTime.Now;
                db.HistoryDataDetail.Add(historyDataDetail);
                await db.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult HistoryVideo_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetHistoryVideo_Edit(int? Id)
        {
            try
            {
                var DB = await db.HistoryDataDetail.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> HistoryVideo_Edit_Submit(RequestDTO.HistoryDataDetailRequest model)
        {
            try
            {
                var DB = await db.HistoryDataDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    //if (model.FileVideoEN != null)
                    //{
                    //    DB.FileVideoEN = model.FileVideoEN;
                    //}

                    //if (model.uploaded_fileEN != null)
                    //{
                    //    foreach (var formFile in model.uploaded_fileEN)
                    //    {
                    //        if (formFile.Length > 0)
                    //        {
                    //            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + DB.FileVideoEN);
                    //            if (System.IO.File.Exists(old_filePath) == true)
                    //            {
                    //                System.IO.File.Delete(old_filePath);
                    //            }

                    //            var datestr = DateTime.Now.Ticks.ToString();
                    //            var extension = Path.GetExtension(formFile.FileName);
                    //            DB.FileVideoEN = datestr + extension;
                    //            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
                    //            using (var stream = System.IO.File.Create(filePath))
                    //            {
                    //                formFile.CopyTo(stream);
                    //            }
                    //        }
                    //    }
                    //}
                    //if (model.FileVideoTH == null && model.uploaded_fileTH != null)
                    //{
                    //    return new JsonResult(new { status = "error", messageArray = "error" });
                    //}
                    //else
                    //{
                    //    if (model.FileVideoTH != null)
                    //    {
                    //        DB.FileVideoTH = model.FileVideoTH;
                    //    }

                    //    if (model.uploaded_fileTH != null)
                    //    {
                    //        foreach (var formFile in model.uploaded_fileTH)
                    //        {
                    //            if (formFile.Length > 0)
                    //            {
                    //                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + DB.FileVideoTH);
                    //                if (System.IO.File.Exists(old_filePath) == true)
                    //                {
                    //                    System.IO.File.Delete(old_filePath);
                    //                }

                    //                var datestr = DateTime.Now.Ticks.ToString();
                    //                var extension = Path.GetExtension(formFile.FileName);
                    //                DB.FileVideoTH = datestr + extension;
                    //                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
                    //                using (var stream = System.IO.File.Create(filePath))
                    //                {
                    //                    formFile.CopyTo(stream);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    if (model.Status == 1)
                    {
                        var check_other = from up2 in db.HistoryDataDetail
                                          where up2.Id != model.Id && up2.Status == 1 && up2.TypeData == 1
                                          select up2;
                        foreach (HistoryDataDetail up2 in check_other)
                        {
                            up2.Status = 0;
                        }
                        db.SaveChanges();
                    }

                    DB.FileVideoTH = model.FileVideoTH;
                    DB.FileVideoEN = model.FileVideoEN;
                    DB.Status = model.Status;
                    DB.created_at = DateTime.Now;
                    DB.updated_at = DateTime.Now;
                    db.Entry(DB).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> HistoryVideo_Delete(int? Id)
        {
            try
            {
                try
                {
                    var DB = db.HistoryDataDetail.FirstOrDefault(x => x.Id == Id);
                    if (DB is not null)
                    {
                        var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileVideoTH);
                        if (System.IO.File.Exists(old_filePath) == true)
                        {
                            System.IO.File.Delete(old_filePath);
                        }
                        var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileVideoEN);
                        if (System.IO.File.Exists(old_filePath2) == true)
                        {
                            System.IO.File.Delete(old_filePath2);
                        }
                        var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.ImageTH);
                        if (System.IO.File.Exists(old_filePath3) == true)
                        {
                            System.IO.File.Delete(old_filePath3);
                        }
                        var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.ImageEN);
                        if (System.IO.File.Exists(old_filePath4) == true)
                        {
                            System.IO.File.Delete(old_filePath4);
                        }

                        db.HistoryDataDetail.Remove(DB);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("ไม่มีข้อมูล");
                    }
                    return new JsonResult(new { status = "success", messageArray = "success" });
                }
                catch (Exception error)
                {
                    throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> HistoryVideo_Change(int? Id)
        {
            try
            {
                var DB = db.HistoryDataDetail.FirstOrDefault(x => x.Id == Id);
                if (DB != null)
                {
                    if (DB.Status != 1)
                    {
                        var Change = db.HistoryDataDetail.Where(x => x.TypeData == 1).ToList();
                        foreach (var item in Change)
                        {
                            item.Status = 0;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        if (DB.Status == 1)
                        {
                            DB.Status = 0;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            DB.Status = 1;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult HistoryTimeline()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TableHistoryTimeline()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.HistoryDataDetailResponse>();
                var History = await db.HistoryDataDetail.Where(x => x.TypeData == 2).ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.HistoryDataDetailResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        TypeData = item.TypeData,
                        Status = item.Status,
                        ImageEN = item.ImageEN,
                        ImageTH = item.ImageTH,
                        FileVideoEN = item.FileVideoEN,
                        FileVideoTH = item.FileVideoTH
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult HistoryTimeline_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> HistoryTimeline_Add_Submit(RequestDTO.HistoryDataDetailRequest model)
        {
            try
            {
                HistoryDataDetail historyDataDetail = new HistoryDataDetail();

                if (model.uploaded_fileEN != null)
                {
                    foreach (var formFile in model.uploaded_fileEN)
                    {
                        if (formFile.Length > 0)
                        {
                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            historyDataDetail.ImageEN = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (model.uploaded_fileTH != null)
                {
                    foreach (var formFile in model.uploaded_fileTH)
                    {
                        if (formFile.Length > 0)
                        {
                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            historyDataDetail.ImageTH = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                historyDataDetail.TypeData = 2;
                historyDataDetail.Status = model.Status;
                historyDataDetail.created_at = DateTime.Now;
                historyDataDetail.updated_at = DateTime.Now;
                db.HistoryDataDetail.Add(historyDataDetail);
                await db.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult HistoryTimeline_Edit(int? Id)
        {
            return View();
        }

        [HttpPut]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> HistoryTimeline_Edit_Submit(RequestDTO.HistoryDetailRequest model)
        {
            try
            {
                var DB = await db.HistoryDataDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    if (model.uploaded_fileEN != null)
                    {
                        foreach (var formFile in model.uploaded_fileEN)
                        {
                            if (formFile.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + DB.ImageEN);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.Ticks.ToString();
                                var extension = Path.GetExtension(formFile.FileName);
                                DB.ImageEN = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFile.CopyTo(stream);
                                }
                            }
                        }
                    }
                    if (model.uploaded_fileTH != null)
                    {
                        foreach (var formFile in model.uploaded_fileTH)
                        {
                            if (formFile.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + DB.ImageTH);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.Ticks.ToString();
                                var extension = Path.GetExtension(formFile.FileName);
                                DB.ImageTH = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFile.CopyTo(stream);
                                }
                            }
                        }
                    }
                    DB.Status = model.Status;
                    DB.created_at = DateTime.Now;
                    DB.updated_at = DateTime.Now;
                    db.Entry(DB).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> HistoryTimeline_Delete(int? Id)
        {
            try
            {
                try
                {
                    var DB = db.HistoryDataDetail.FirstOrDefault(x => x.Id == Id);
                    if (DB is not null)
                    {
                        var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileVideoTH);
                        if (System.IO.File.Exists(old_filePath) == true)
                        {
                            System.IO.File.Delete(old_filePath);
                        }
                        var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileVideoEN);
                        if (System.IO.File.Exists(old_filePath2) == true)
                        {
                            System.IO.File.Delete(old_filePath2);
                        }
                        var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.ImageTH);
                        if (System.IO.File.Exists(old_filePath3) == true)
                        {
                            System.IO.File.Delete(old_filePath3);
                        }
                        var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.ImageEN);
                        if (System.IO.File.Exists(old_filePath4) == true)
                        {
                            System.IO.File.Delete(old_filePath4);
                        }

                        db.HistoryDataDetail.Remove(DB);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("ไม่มีข้อมูล");
                    }
                    return new JsonResult(new { status = "success", messageArray = "success" });
                }
                catch (Exception error)
                {
                    throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> HistoryTimeline_Change(int? Id)
        {
            try
            {
                var DB = db.HistoryDataDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    db.Entry(DB).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }



        public IActionResult ORGANIZATION_CHART()
        {
            var checkrow = db.Organization_Chart.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_Organization_chart = count_row, fod_Organization_chart = checkrow };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> TableORGANIZATION_CHART()
        {
            try
            {
                var Data_list = await db.Organization_ChartDetail.ToListAsync();
                var add_count = new List<Resource_FacilityModels.Organization_ChartDetail_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.Organization_ChartDetail_table
                    {
                        count_row = count,
                        Id = items.Id,
                        created_at = items.created_at,
                        Image = items.Image,
                        updated_at = items.updated_at,
                        Status = items.Status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult ORGANIZATION_CHART_submit(Organization_Chart organization_Chart)
        {
            try
            {
                var checkrow = db.Organization_Chart.FirstOrDefault();
                if (checkrow == null)
                {
                    organization_Chart.created_at = DateTime.Now;
                    organization_Chart.updated_at = DateTime.Now;
                    db.Organization_Chart.Add(organization_Chart);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.Title_TH = organization_Chart.Title_TH;
                    checkrow.Title_EN = organization_Chart.Title_EN;
                    checkrow.SubTitle_TH = organization_Chart.SubTitle_TH;
                    checkrow.SubTitle_EN = organization_Chart.SubTitle_EN;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult ORGANIZATION_CHART_Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ORGANIZATION_CHART_Details_Submit(Organization_ChartDetail organization_ChartDetail,
           List<IFormFile> upload_image)
        {
            try
            {

                if (organization_ChartDetail.Status == 1)
                {
                    var check_other = from up2 in db.Organization_ChartDetail
                                      where up2.Status == 1
                                      select up2;
                    foreach (Organization_ChartDetail up2 in check_other)
                    {
                        up2.Status = 0;
                    }
                    db.SaveChanges();
                }

                if (upload_image.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        organization_ChartDetail.Image = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Organization_Chart/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                if (organization_ChartDetail.Status != 1)
                {
                    organization_ChartDetail.Status = 0;
                }
                else
                {
                    organization_ChartDetail.Status = 1;
                }

                organization_ChartDetail.created_at = DateTime.Now;
                organization_ChartDetail.updated_at = DateTime.Now;
                db.Organization_ChartDetail.Add(organization_ChartDetail);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        public IActionResult ORGANIZATION_CHART_Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("ORGANIZATION_CHART", "ResourceFacility");
            }
            var get_detail = db.Organization_ChartDetail.Where(x => x.Id == Id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("ORGANIZATION_CHART", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { Organization_ChartDetail = get_detail };
            return View(model);
        }
        public async Task<IActionResult> ORGANIZATION_CHART_Edit_Submit(Organization_ChartDetail organization_ChartDetail
            , List<IFormFile> upload_image)
        {
            try
            {
                var old_data = db.Organization_ChartDetail.Where(x => x.Id == organization_ChartDetail.Id).FirstOrDefault();

                if (organization_ChartDetail.Status == 1)
                {
                    var check_other = from up2 in db.Organization_ChartDetail
                                      where up2.Id != organization_ChartDetail.Id && up2.Status == 1
                                      select up2;
                    foreach (Organization_ChartDetail up2 in check_other)
                    {
                        up2.Status = 0;
                    }
                    db.SaveChanges();
                }

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Organization_Chart/" + old_data.Image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.Image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Organization_Chart/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (organization_ChartDetail.Status != 1)
                {
                    old_data.Status = 0;
                }
                else
                {
                    old_data.Status = 1;
                }
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }

        }
        [HttpDelete]
        public async Task<IActionResult> ORGANIZATION_CHART_Delete(int? Id)
        {
            try
            {
                var checkrow = db.Organization_ChartDetail.Where(x => x.Id == Id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Organization_Chart/" + checkrow.Image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }


                    db.Organization_ChartDetail.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        [HttpPost]
        public async Task<IActionResult> ORGANIZATION_CHART_Change(int? Id, string? status)
        {
            var i = 0;
            try
            {
                var DB = db.Organization_ChartDetail.FirstOrDefault(x => x.Id == Id);
                if (DB != null)
                {
                    if (DB.Status != 1)
                    {
                        var Change = db.Organization_ChartDetail.ToList();
                        foreach (var item in Change)
                        {
                            item.Status = 0;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        if (DB.Status == 1)
                        {
                            DB.Status = 0;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                            i = 1;
                        }
                        else
                        {
                            DB.Status = 1;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                            i = 1;
                        }
                    }
                    else
                    {
                        i = 2;
                    }
                }
                return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, alert = i });
            }
        }



        public IActionResult AWARDS()
        {
            var checkrow = db.Awards.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_Awards = count_row, fod_Awards = checkrow };
            return View(model);
        }
        public async Task<IActionResult> Award_Details_getTable()
        {
            try
            {
                var Data_list = await db.AwardsDetail.ToListAsync();
                var add_count = new List<Resource_FacilityModels.AwardsDetail_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.AwardsDetail_table
                    {
                        count_row = count,
                        Id = items.Id,
                        created_at = items.created_at,
                        ImageTH = items.ImageTH,
                        ImageEN = items.ImageEN,
                        Title_TH = items.Title_TH,
                        Title_EN = items.Title_EN,
                        SubTitle_TH = items.SubTitle_TH,
                        SubTitle_EN = items.SubTitle_EN,
                        updated_at = items.updated_at,
                        Status = items.Status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Award_submit(Awards award)
        {
            try
            {
                var checkrow = db.Awards.FirstOrDefault();
                if (checkrow == null)
                {
                    award.created_at = DateTime.Now;
                    award.updated_at = DateTime.Now;
                    db.Awards.Add(award);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.Title_TH = award.Title_TH;
                    checkrow.Title_EN = award.Title_EN;
                    checkrow.SubTitle_TH = award.SubTitle_TH;
                    checkrow.SubTitle_EN = award.SubTitle_EN;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult AWARDS_Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Award_Details_submit(AwardsDetail awardsDetail,
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        awardsDetail.ImageTH = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Award/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        awardsDetail.ImageEN = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Award/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (awardsDetail.Status != 1)
                {
                    awardsDetail.Status = 0;
                }
                else
                {
                    awardsDetail.Status = 1;
                }

                awardsDetail.created_at = DateTime.Now;
                awardsDetail.updated_at = DateTime.Now;
                db.AwardsDetail.Add(awardsDetail);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult AWARDS_Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("AWARDS", "ResourceFacility");
            }
            var get_detail = db.AwardsDetail.Where(x => x.Id == Id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("AWARDS", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { AwardsDetail = get_detail };
            return View(model);
        }
        public IActionResult AWARDS_Edit_Submit(AwardsDetail awardsDetail,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.AwardsDetail.Where(x => x.Id == awardsDetail.Id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Award/" + old_data.ImageTH);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.ImageTH = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Award/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Award/" + old_data.ImageEN);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.ImageEN = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Award/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (awardsDetail.Status != 1)
                {
                    old_data.Status = 0;
                }
                else
                {
                    old_data.Status = 1;
                }
                old_data.Title_TH = awardsDetail.Title_TH;
                old_data.Title_EN = awardsDetail.Title_EN;
                old_data.SubTitle_TH = awardsDetail.SubTitle_TH;
                old_data.SubTitle_EN = awardsDetail.SubTitle_EN;

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult AWARDS_Delete(int? Id)
        {
            try
            {
                var checkrow = db.AwardsDetail.Where(x => x.Id == Id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Award/" + checkrow.ImageTH);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Award/" + checkrow.ImageEN);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.AwardsDetail.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult AWARDS_Change(int? Id, string? status)
        {
            var get_data = db.AwardsDetail.Where(x => x.Id == Id).FirstOrDefault();
            if (status == "true")
            {
                get_data.Status = 1;
            }
            else
            {
                get_data.Status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }


        public IActionResult OUR_PHILOSOPHY_VISION_MISSION()
        {
            var checkrow = db.RF_Philosophy_Vision_Mission.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Philosophy_Vision_Mission = count_row, fod_RF_Philosophy_Vision_Mission = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_Philosophy_Vision_Mission_Details_getTable()
        {
            try
            {
                var Data_list = await db.RF_Philosophy_Vision_Mission_Details.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Philosophy_Vision_Mission_Details_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Philosophy_Vision_Mission_Details_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_Philosophy_Vision_Mission_submit(RF_Philosophy_Vision_Mission rf_Philosophy_VM)
        {
            try
            {
                var checkrow = db.RF_Philosophy_Vision_Mission.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_Philosophy_VM.created_at = DateTime.Now;
                    rf_Philosophy_VM.updated_at = DateTime.Now;
                    db.RF_Philosophy_Vision_Mission.Add(rf_Philosophy_VM);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.Title_TH = rf_Philosophy_VM.Title_TH;
                    checkrow.Title_EN = rf_Philosophy_VM.Title_EN;
                    checkrow.SubTitle_TH = rf_Philosophy_VM.SubTitle_TH;
                    checkrow.SubTitle_EN = rf_Philosophy_VM.SubTitle_EN;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Add()
        {
            return View();
        }
        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Add_Submit(RF_Philosophy_Vision_Mission_Details rf_Philosophy_VM_Details,
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        rf_Philosophy_VM_Details.image_name = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Philosophy_VM/" + datestr + imgFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        rf_Philosophy_VM_Details.image_name_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Philosophy_VM/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_Philosophy_VM_Details.active_status != 1)
                {
                    rf_Philosophy_VM_Details.active_status = 0;
                }
                else
                {
                    rf_Philosophy_VM_Details.active_status = 1;
                }

                rf_Philosophy_VM_Details.created_at = DateTime.Now;
                rf_Philosophy_VM_Details.updated_at = DateTime.Now;
                db.RF_Philosophy_Vision_Mission_Details.Add(rf_Philosophy_VM_Details);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("OUR_PHILOSOPHY_VISION_MISSION", "ResourceFacility");
            }
            var get_detail = db.RF_Philosophy_Vision_Mission_Details.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("OUR_PHILOSOPHY_VISION_MISSION", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Philosophy_Vision_Mission_Details = get_detail };
            return View(model);
        }
        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Edit_Submit(RF_Philosophy_Vision_Mission_Details rf_Philosophy_VM_Details,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Philosophy_Vision_Mission_Details.Where(x => x.id == rf_Philosophy_VM_Details.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Philosophy_VM/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Philosophy_VM/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Philosophy_VM/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.image_name_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Philosophy_VM/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (rf_Philosophy_VM_Details.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Philosophy_Vision_Mission_Details.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Philosophy_VM/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Philosophy_VM/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Philosophy_Vision_Mission_Details.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Change(int? id, string? status)
        {
            var i = 0;
            try
            {
                var DB = db.RF_Philosophy_Vision_Mission_Details.FirstOrDefault(x => x.id == id);
                if (DB != null)
                {
                    if (DB.active_status != 1)
                    {
                        var Change = db.RF_Philosophy_Vision_Mission_Details.ToList();
                        foreach (var item in Change)
                        {
                            item.active_status = 0;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        if (DB.active_status == 1)
                        {
                            DB.active_status = 0;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                            i = 1;
                        }
                        else
                        {
                            DB.active_status = 1;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                            i = 1;
                        }
                    }
                    else
                    {
                        i = 2;
                    }
                }
                return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, alert = i });
            }
        }



        public IActionResult RF_Manufacturing()
        {
            var checkrow = db.RF_Manufacturing.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Manufacturing = count_row, fod_RF_Manufacturing = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_Manufacturing_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Manufacturing_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Manufacturing_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Manufacturing_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_Manufacturing_submit(RF_Manufacturing rf_manufacturing)
        {
            try
            {
                var checkrow = db.RF_Manufacturing.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_manufacturing.created_at = DateTime.Now;
                    rf_manufacturing.updated_at = DateTime.Now;
                    db.RF_Manufacturing.Add(rf_manufacturing);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_manufacturing.titleTH;
                    checkrow.titleENG = rf_manufacturing.titleENG;
                    checkrow.detailsTitleTH = rf_manufacturing.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_manufacturing.detailsTitleENG;
                    checkrow.link = rf_manufacturing.link;
                    checkrow.linkENG = rf_manufacturing.linkENG;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_ManufacturingImages_create()
        {
            return View();
        }
        public IActionResult RF_ManufacturingImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_Manufacturing", "ResourceFacility");
            }
            var get_detail = db.RF_Manufacturing_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_Manufacturing", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Manufacturing_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_ManufactufingImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Manufacturing_Images.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.active_status = 1;
            }
            else
            {
                get_data.active_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        public IActionResult RF_ManufactufingImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Manufacturing_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Manufacturing_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_ManufactufingImages_submit(RF_Manufacturing_Images r_ManufacturingImages,
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        r_ManufacturingImages.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + datestr + imgFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        r_ManufacturingImages.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (r_ManufacturingImages.active_status != 1)
                {
                    r_ManufacturingImages.active_status = 0;
                }
                else
                {
                    r_ManufacturingImages.active_status = 1;
                }

                r_ManufacturingImages.created_at = DateTime.Now;
                r_ManufacturingImages.updated_at = DateTime.Now;
                db.RF_Manufacturing_Images.Add(r_ManufacturingImages);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_ManufactufingImages_edit_Submit(RF_Manufacturing_Images rf_ManufacturingImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Manufacturing_Images.Where(x => x.id == rf_ManufacturingImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (rf_ManufacturingImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult RF_WarehouseLogistics()
        {
            var checkrow = db.RF_Warehouse_Logistics.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Warehouse_Logistics = count_row, fod_RF_Warehouse_Logistics = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_WarehouseLogistics_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Warehouse_Logistics_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Warehouse_Logistics_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Warehouse_Logistics_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_WarehouseLogistics_submit(RF_Warehouse_Logistics rf_WarehouseLogistics)
        {
            try
            {
                var checkrow = db.RF_Warehouse_Logistics.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_WarehouseLogistics.created_at = DateTime.Now;
                    rf_WarehouseLogistics.updated_at = DateTime.Now;
                    db.RF_Warehouse_Logistics.Add(rf_WarehouseLogistics);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_WarehouseLogistics.titleTH;
                    checkrow.titleENG = rf_WarehouseLogistics.titleENG;
                    checkrow.detailsTitleTH = rf_WarehouseLogistics.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_WarehouseLogistics.detailsTitleENG;
                    checkrow.link = rf_WarehouseLogistics.link;
                    checkrow.linkENG = rf_WarehouseLogistics.linkENG;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_WarehouseLogisticsImages_create()
        {
            return View();
        }
        public IActionResult RF_WarehouseLogisticsImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_WarehouseLogistics", "ResourceFacility");
            }
            var get_detail = db.RF_Warehouse_Logistics_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_WarehouseLogistics", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Warehouse_Logistics_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_WarehouseLogisticsImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Warehouse_Logistics_Images.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.active_status = 1;
            }
            else
            {
                get_data.active_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        public IActionResult RF_WarehouseLogisticsImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Warehouse_Logistics_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Warehouse_Logistics_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_WarehouseLogisticsImages_submit(RF_Warehouse_Logistics_Images rf_Warehouse_LogisticsImages,
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        rf_Warehouse_LogisticsImages.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + datestr + imgFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        rf_Warehouse_LogisticsImages.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_Warehouse_LogisticsImages.active_status != 1)
                {
                    rf_Warehouse_LogisticsImages.active_status = 0;
                }
                else
                {
                    rf_Warehouse_LogisticsImages.active_status = 1;
                }

                rf_Warehouse_LogisticsImages.created_at = DateTime.Now;
                rf_Warehouse_LogisticsImages.updated_at = DateTime.Now;
                db.RF_Warehouse_Logistics_Images.Add(rf_Warehouse_LogisticsImages);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_WarehouseLogisticsImages_edit_Submit(RF_Warehouse_Logistics_Images rf_Warehouse_LogisticsImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Warehouse_Logistics_Images.Where(x => x.id == rf_Warehouse_LogisticsImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (rf_Warehouse_LogisticsImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult RF_OverseaOffices()
        {
            var checkrow = db.RF_Oversea_Offices.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Oversea_Offices = count_row, fod_RF_Oversea_Offices = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_OverseaOffices_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Oversea_Offices_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Oversea_Offices_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Oversea_Offices_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_OverseaOffices_submit(RF_Oversea_Offices rf_Oversea_Offices)
        {
            try
            {
                var checkrow = db.RF_Oversea_Offices.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_Oversea_Offices.created_at = DateTime.Now;
                    rf_Oversea_Offices.updated_at = DateTime.Now;
                    db.RF_Oversea_Offices.Add(rf_Oversea_Offices);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_Oversea_Offices.titleTH;
                    checkrow.titleENG = rf_Oversea_Offices.titleENG;
                    checkrow.detailsTitleTH = rf_Oversea_Offices.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_Oversea_Offices.detailsTitleENG;
                    checkrow.link = rf_Oversea_Offices.link;
                    checkrow.linkENG = rf_Oversea_Offices.linkENG;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_OverseaOfficesImages_create()
        {
            return View();
        }
        public IActionResult RF_OverseaOfficesImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_OverseaOffices", "ResourceFacility");
            }
            var get_detail = db.RF_Oversea_Offices_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_OverseaOffices", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Oversea_Offices_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_OverseaOfficesImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Oversea_Offices_Images.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.active_status = 1;
            }
            else
            {
                get_data.active_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        public IActionResult RF_OverseaOfficesImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Oversea_Offices_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Oversea_Offices_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_OverseaOfficesImages_submit(RF_Oversea_Offices_Images rf_Oversea_Offices_Images,
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        rf_Oversea_Offices_Images.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + datestr + imgFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        rf_Oversea_Offices_Images.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_Oversea_Offices_Images.active_status != 1)
                {
                    rf_Oversea_Offices_Images.active_status = 0;
                }
                else
                {
                    rf_Oversea_Offices_Images.active_status = 1;
                }

                rf_Oversea_Offices_Images.created_at = DateTime.Now;
                rf_Oversea_Offices_Images.updated_at = DateTime.Now;
                db.RF_Oversea_Offices_Images.Add(rf_Oversea_Offices_Images);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_OverseaOfficesImages_edit_Submit(RF_Oversea_Offices_Images rf_Oversea_Offices_Images,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Oversea_Offices_Images.Where(x => x.id == rf_Oversea_Offices_Images.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (rf_Oversea_Offices_Images.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult RF_SolidState()
        {
            var checkrow = db.RF_Solid_States.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Solid_States = count_row, fod_RF_Solid_States = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_SolidState_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Solid_States_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Solid_States_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Solid_States_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolidState_submit(RF_Solid_States rf_Solid_States)
        {
            try
            {
                var checkrow = db.RF_Solid_States.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_Solid_States.created_at = DateTime.Now;
                    rf_Solid_States.updated_at = DateTime.Now;
                    db.RF_Solid_States.Add(rf_Solid_States);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_Solid_States.titleTH;
                    checkrow.titleENG = rf_Solid_States.titleENG;
                    checkrow.detailsTitleTH = rf_Solid_States.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_Solid_States.detailsTitleENG;
                    checkrow.link = rf_Solid_States.link;
                    checkrow.linkENG = rf_Solid_States.linkENG;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolidStateImages_create()
        {
            return View();
        }
        public IActionResult RF_SolidStateImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_SolidState", "ResourceFacility");
            }
            var get_detail = db.RF_Solid_States_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_SolidState", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Solid_States_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_SolidStateImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Solid_States_Images.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.active_status = 1;
            }
            else
            {
                get_data.active_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        public IActionResult RF_SolidStateImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Solid_States_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Solid_States_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolidStateImages_submit(RF_Solid_States_Images rf_Solid_States_Images,
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        rf_Solid_States_Images.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + datestr + imgFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        rf_Solid_States_Images.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_Solid_States_Images.active_status != 1)
                {
                    rf_Solid_States_Images.active_status = 0;
                }
                else
                {
                    rf_Solid_States_Images.active_status = 1;
                }

                rf_Solid_States_Images.created_at = DateTime.Now;
                rf_Solid_States_Images.updated_at = DateTime.Now;
                db.RF_Solid_States_Images.Add(rf_Solid_States_Images);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolidStateImages_edit_Submit(RF_Solid_States_Images rf_Solid_States_Images,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Solid_States_Images.Where(x => x.id == rf_Solid_States_Images.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (rf_Solid_States_Images.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult RF_AssemblyService()
        {
            var checkrow = db.RF_Assembly_Services.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Assembly_Services = count_row, fod_RF_Assembly_Services = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_AssemblyService_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Assembly_Services_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Assembly_Services_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Assembly_Services_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_AssemblyService_submit(RF_Assembly_Services rf_Assembly_Services)
        {
            try
            {
                var checkrow = db.RF_Assembly_Services.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_Assembly_Services.created_at = DateTime.Now;
                    rf_Assembly_Services.updated_at = DateTime.Now;
                    db.RF_Assembly_Services.Add(rf_Assembly_Services);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_Assembly_Services.titleTH;
                    checkrow.titleENG = rf_Assembly_Services.titleENG;
                    checkrow.detailsTitleTH = rf_Assembly_Services.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_Assembly_Services.detailsTitleENG;
                    checkrow.link = rf_Assembly_Services.link;
                    checkrow.linkENG = rf_Assembly_Services.linkENG;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_AssemblyServiceImages_create()
        {
            return View();
        }
        public IActionResult RF_AssemblyServiceImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_AssemblyService", "ResourceFacility");
            }
            var get_detail = db.RF_Assembly_Services_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_AssemblyService", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Assembly_Services_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_AssemblyServiceImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Assembly_Services_Images.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.active_status = 1;
            }
            else
            {
                get_data.active_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        public IActionResult RF_AssemblyServiceImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Assembly_Services_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Assembly_Services_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_AssemblyServiceImages_submit(RF_Assembly_Services_Images rf_Assembly_ServicesImages,
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        rf_Assembly_ServicesImages.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + datestr + imgFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        rf_Assembly_ServicesImages.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_Assembly_ServicesImages.active_status != 1)
                {
                    rf_Assembly_ServicesImages.active_status = 0;
                }
                else
                {
                    rf_Assembly_ServicesImages.active_status = 1;
                }

                rf_Assembly_ServicesImages.created_at = DateTime.Now;
                rf_Assembly_ServicesImages.updated_at = DateTime.Now;
                db.RF_Assembly_Services_Images.Add(rf_Assembly_ServicesImages);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_AssemblyServiceImages_edit_Submit(RF_Assembly_Services_Images rf_AssemblyServicesImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Assembly_Services_Images.Where(x => x.id == rf_AssemblyServicesImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (rf_AssemblyServicesImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult RF_SolutionCenters()
        {
            var checkrow = db.RF_Solution_Centers.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Solution_Centers = count_row, fod_RF_Solution_Centers = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_SolutionCenters_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Solution_Centers_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Solution_Centers_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Solution_Centers_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolutionCenters_submit(RF_Solution_Centers rf_SolutionCenters)
        {
            try
            {
                var checkrow = db.RF_Solution_Centers.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_SolutionCenters.created_at = DateTime.Now;
                    rf_SolutionCenters.updated_at = DateTime.Now;
                    db.RF_Solution_Centers.Add(rf_SolutionCenters);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_SolutionCenters.titleTH;
                    checkrow.titleENG = rf_SolutionCenters.titleENG;
                    checkrow.detailsTitleTH = rf_SolutionCenters.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_SolutionCenters.detailsTitleENG;
                    checkrow.link = rf_SolutionCenters.link;
                    checkrow.linkENG = rf_SolutionCenters.linkENG;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolutionCentersImages_create()
        {
            return View();
        }
        public IActionResult RF_SolutionCentersImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_SolutionCenters", "ResourceFacility");
            }
            var get_detail = db.RF_Solution_Centers_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_SolutionCenters", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Solution_Centers_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_SolutionCentersImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Solution_Centers_Images.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.active_status = 1;
            }
            else
            {
                get_data.active_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        public IActionResult RF_SolutionCentersImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Solution_Centers_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Solution_Centers_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolutionCentersImages_submit(RF_Solution_Centers_Images rf_SolutionCenters_Images,
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        rf_SolutionCenters_Images.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + datestr + imgFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        rf_SolutionCenters_Images.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_SolutionCenters_Images.active_status != 1)
                {
                    rf_SolutionCenters_Images.active_status = 0;
                }
                else
                {
                    rf_SolutionCenters_Images.active_status = 1;
                }

                rf_SolutionCenters_Images.created_at = DateTime.Now;
                rf_SolutionCenters_Images.updated_at = DateTime.Now;
                db.RF_Solution_Centers_Images.Add(rf_SolutionCenters_Images);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolutionCentersImages_edit_Submit(RF_Solution_Centers_Images rf_SolutionCentersImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Solution_Centers_Images.Where(x => x.id == rf_SolutionCentersImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (rf_SolutionCentersImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }


        //
        public IActionResult RF_InnovationCenters()
        {
            var checkrow = db.RF_Innovation_Centers.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Innovation_Centers = count_row, fod_RF_Innovation_Centers = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_InnovationCenters_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Innovation_Center_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Solution_Centers_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Solution_Centers_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_InnovationCenters_submit(RF_Innovation_Centers rf_InnovationCenters)
        {
            try
            {
                var checkrow = db.RF_Innovation_Centers.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_InnovationCenters.created_at = DateTime.Now;
                    rf_InnovationCenters.updated_at = DateTime.Now;
                    db.RF_Innovation_Centers.Add(rf_InnovationCenters);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_InnovationCenters.titleTH;
                    checkrow.titleENG = rf_InnovationCenters.titleENG;
                    checkrow.detailsTitleTH = rf_InnovationCenters.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_InnovationCenters.detailsTitleENG;
                    checkrow.link = rf_InnovationCenters.link;
                    checkrow.linkENG = rf_InnovationCenters.linkENG;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_InnovationCentersImages_create()
        {
            return View();
        }
        public IActionResult RF_InnovationCentersImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_InnovationCenters", "ResourceFacility");
            }
            var get_detail = db.RF_Innovation_Center_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_InnovationCenters", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Innovation_Center_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_InnovationCentersImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Solution_Centers_Images.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.active_status = 1;
            }
            else
            {
                get_data.active_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        public IActionResult RF_InnovationCentersImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Innovation_Center_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Innovation_Center_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_InnovationCentersImages_submit(RF_Innovation_Center_Images rf_InnovationCenterImages,
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        rf_InnovationCenterImages.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + datestr + imgFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        rf_InnovationCenterImages.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_InnovationCenterImages.active_status != 1)
                {
                    rf_InnovationCenterImages.active_status = 0;
                }
                else
                {
                    rf_InnovationCenterImages.active_status = 1;
                }

                rf_InnovationCenterImages.created_at = DateTime.Now;
                rf_InnovationCenterImages.updated_at = DateTime.Now;
                db.RF_Innovation_Center_Images.Add(rf_InnovationCenterImages);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_InnovationCentersImages_edit_Submit(RF_Innovation_Center_Images rf_InnovationCenterImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Innovation_Center_Images.Where(x => x.id == rf_InnovationCenterImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (rf_InnovationCenterImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Index()
        {
            return View();
        }
    }
}
