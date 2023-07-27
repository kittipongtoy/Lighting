using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
	[Authorize]
	public class IR_StockController : Controller
	{
		private readonly LightingContext _context;
		public IR_StockController(LightingContext context)
		{
			_context = context;
		}

		public IActionResult IR_Stock_Quote_Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Table_IR_Stock_Quote()
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
                var list = new List<ResponseDTO.IR_Stock_QuoteResponse>();
                var IR_Contact = await _context.IR_Stock_Quote.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_Stock_QuoteResponse
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

        public IActionResult IR_Stock_Quote_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IR_Stock_Quote_Add_Submit(RequestDTO.IR_Stock_QuoteRequest model)
        {
            try
            {
                IR_Stock_Quote iR_Stock_Quote = new IR_Stock_Quote();
                iR_Stock_Quote.Title_TH = model.Title_TH;
                iR_Stock_Quote.Title_EN = model.Title_EN;
                iR_Stock_Quote.SubTitle_EN = model.SubTitle_EN;
                iR_Stock_Quote.SubTitle_TH = model.SubTitle_TH;
                iR_Stock_Quote.Status = model.Status;
                iR_Stock_Quote.created_at = DateTime.Now;
                iR_Stock_Quote.updated_at = DateTime.Now;
                _context.IR_Stock_Quote.Add(iR_Stock_Quote);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_Stock_Quote_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetIR_Stock_Quote_Edit(int? Id)
        {
            try
            {
                var DB = await _context.IR_Stock_Quote.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> IR_Stock_Quote_Edit_Submit(RequestDTO.IR_Stock_QuoteRequest model)
        {
            try
            {
                var DB = await _context.IR_Stock_Quote.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.SubTitle_EN = model.SubTitle_EN;
                    DB.SubTitle_TH = model.SubTitle_TH;
                    DB.Status = model.Status;
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> IR_Stock_Quote_Delete(int? Id)
        {
            try
            {
                try
                {
                    var DB = _context.IR_Stock_Quote.FirstOrDefault(x => x.Id == Id);
                    if (DB is not null)
                    {
                        _context.IR_Stock_Quote.Remove(DB);
                        await _context.SaveChangesAsync();
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
        public async Task<IActionResult> IR_Stock_Quote_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Stock_Quote.FirstOrDefault(x => x.Id == Id);
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
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
		public async Task<IActionResult> Table_IR_Stock_QuoteDetail()
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
                var list = new List<ResponseDTO.IR_Stock_QuoteDetailResponse>();
                var IR_Contact = await _context.IR_Stock_QuoteDetail.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_Stock_QuoteDetailResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        STOCK_PRICE_TH = item.STOCK_PRICE_TH,
                        STOCK_PRICE_EN = item.STOCK_PRICE_EN,
                        SET_INDEX_TH = item.SET_INDEX_TH,
                        SET_INDEX_EN = item.SET_INDEX_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.STOCK_PRICE_TH.Contains(searchValue)
                    || x.STOCK_PRICE_TH.Contains(searchValue)
                    || x.STOCK_PRICE_EN.Contains(searchValue)
                    || x.SET_INDEX_TH.Contains(searchValue)
                    || x.SET_INDEX_EN.Contains(searchValue)
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

		public IActionResult IR_Stock_QuoteDetail_Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> IR_Stock_QuoteDetail_Add_Submit(RequestDTO.IR_Stock_QuoteDetailRequest model)
		{
			try
			{
                IR_Stock_QuoteDetail iR_Stock_QuoteDetail = new IR_Stock_QuoteDetail();
                iR_Stock_QuoteDetail.STOCK_PRICE_TH = model.STOCK_PRICE_TH;
                iR_Stock_QuoteDetail.STOCK_PRICE_EN = model.STOCK_PRICE_EN;
                iR_Stock_QuoteDetail.Link_STOCK_PRICE = model.Link_STOCK_PRICE;
                iR_Stock_QuoteDetail.SET_INDEX_TH = model.SET_INDEX_TH;
                iR_Stock_QuoteDetail.SET_INDEX_EN = model.SET_INDEX_EN;
                iR_Stock_QuoteDetail.Link_SET_INDEX_TH = model.Link_SET_INDEX_TH;
                iR_Stock_QuoteDetail.Link_SET_INDEX_EN = model.Link_SET_INDEX_EN;
                iR_Stock_QuoteDetail.Status = model.Status;
                iR_Stock_QuoteDetail.created_at = DateTime.Now;
                iR_Stock_QuoteDetail.updated_at = DateTime.Now;
                await _context.IR_Stock_QuoteDetail.AddAsync(iR_Stock_QuoteDetail);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
			catch (Exception error)
			{
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
		}

		public IActionResult IR_Stock_QuoteDetail_Edit(int? Id)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetIR_Stock_QuoteDetail_Edit(int? Id)
		{
            try
            {
                var DB = await _context.IR_Stock_QuoteDetail.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

		[HttpPut]
		public async Task<IActionResult> IR_Stock_QuoteDetail_Edit_Submit(RequestDTO.IR_Stock_QuoteDetailRequest model)
		{
            try
            {
                var DB = await _context.IR_Stock_QuoteDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    var iR_Stock_QuoteDetail = await _context.IR_Stock_QuoteDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                    iR_Stock_QuoteDetail.STOCK_PRICE_TH = model.STOCK_PRICE_TH;
                    iR_Stock_QuoteDetail.STOCK_PRICE_EN = model.STOCK_PRICE_EN;
                    iR_Stock_QuoteDetail.Link_STOCK_PRICE = model.Link_STOCK_PRICE;
                    iR_Stock_QuoteDetail.SET_INDEX_TH = model.SET_INDEX_TH;
                    iR_Stock_QuoteDetail.SET_INDEX_EN = model.SET_INDEX_EN;
                    iR_Stock_QuoteDetail.Link_SET_INDEX_TH = model.Link_SET_INDEX_TH;
                    iR_Stock_QuoteDetail.Link_SET_INDEX_EN = model.Link_SET_INDEX_EN;
                    iR_Stock_QuoteDetail.Status = model.Status;
                    iR_Stock_QuoteDetail.created_at = DateTime.Now;
                    iR_Stock_QuoteDetail.updated_at = DateTime.Now;
                    _context.Entry(iR_Stock_QuoteDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
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
		public async Task<IActionResult> IR_Stock_QuoteDetail_Delete(int? Id)
		{
            try
            {
                var DB = _context.IR_Stock_QuoteDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_Stock_QuoteDetail.Remove(DB);
                    await _context.SaveChangesAsync();
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
		public async Task<IActionResult> IR_Stock_QuoteDetail_Change(int? Id)
		{
            try
            {
                var DB = _context.IR_Stock_QuoteDetail.FirstOrDefault(x => x.Id == Id);
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
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_Stock_Chart_Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Table_IR_Stock_Chart()
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
                var list = new List<ResponseDTO.IR_Stock_ChartResponse>();
                var IR_Contact = await _context.IR_Stock_Chart.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_Stock_ChartResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Title_TH = item.Title_TH,
                        Title_EN = item.Title_EN,
                        SubTitle_TH = item.SubTitle_TH,
                        SubTitle_EN = item.SubTitle_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Title_TH.Contains(searchValue)
                           || x.Title_EN.Contains(searchValue)
                           || x.SubTitle_TH.Contains(searchValue)
                           || x.SubTitle_EN.Contains(searchValue)
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

        public IActionResult IR_Stock_Chart_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IR_Stock_Chart_Add_Submit(RequestDTO.IR_Stock_ChartRequest model)
        {
            try
            {
                IR_Stock_Chart iR_Stock_Chart = new IR_Stock_Chart();
                iR_Stock_Chart.Title_TH = model.Title_TH;
                iR_Stock_Chart.Title_EN = model.Title_EN;
                iR_Stock_Chart.SubTitle_EN = model.SubTitle_EN;
                iR_Stock_Chart.SubTitle_TH = model.SubTitle_TH;
                iR_Stock_Chart.Status = model.Status;
                iR_Stock_Chart.created_at = DateTime.Now;
                iR_Stock_Chart.updated_at = DateTime.Now;
                _context.IR_Stock_Chart.Add(iR_Stock_Chart);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_Stock_Chart_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetIR_Stock_Chart_Edit(int? Id)
        {
            try
            {
                var DB = await _context.IR_Stock_Chart.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> IR_Stock_Chart_Edit_Submit(RequestDTO.IR_Stock_ChartRequest model)
        {
            try
            {
                var DB = await _context.IR_Stock_Chart.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.SubTitle_EN = model.SubTitle_EN;
                    DB.SubTitle_TH = model.SubTitle_TH;
                    DB.Status = model.Status;
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> IR_Stock_Chart_Delete(int? Id)
        {
            try
            {
                try
                {
                    var DB = _context.IR_Stock_Chart.FirstOrDefault(x => x.Id == Id);
                    if (DB is not null)
                    {
                        _context.IR_Stock_Chart.Remove(DB);
                        await _context.SaveChangesAsync();
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
        public async Task<IActionResult> IR_Stock_Chart_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Stock_Chart.FirstOrDefault(x => x.Id == Id);
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
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
		public async Task<IActionResult> Table_IR_Stock_ChartDetail()
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
                var list = new List<ResponseDTO.IR_Stock_ChartDetailResponse>();
                var IR_Contact = await _context.IR_Stock_ChartDetails.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_Stock_ChartDetailResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Link_IR_Stock_Chart = item.Link_IR_Stock_Chart,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Link_IR_Stock_Chart.Contains(searchValue)
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

		public IActionResult IR_Stock_ChartDetail_Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> IR_Stock_ChartDetail_Add_Submit(RequestDTO.IR_Stock_ChartDetailRequest model)
		{
            try
            {
                try
                {
                    IR_Stock_ChartDetail iR_Stock_ChartDetail = new IR_Stock_ChartDetail();
                    iR_Stock_ChartDetail.Link_IR_Stock_Chart = model.Link_IR_Stock_Chart;
                    iR_Stock_ChartDetail.Status = model.Status;
                    iR_Stock_ChartDetail.created_at = DateTime.Now;
                    iR_Stock_ChartDetail.updated_at = DateTime.Now;
                    await _context.IR_Stock_ChartDetails.AddAsync(iR_Stock_ChartDetail);
                    await _context.SaveChangesAsync();
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

		public IActionResult IR_Stock_ChartDetail_Edit(int? Id)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetIR_Stock_ChartDetail_Edit(int? Id)
		{
            try
            {
                var DB = await _context.IR_Stock_ChartDetails.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

		[HttpPut]
		public async Task<IActionResult> IR_Stock_ChartDetail_Edit_Submit(RequestDTO.IR_Stock_ChartDetailRequest model)
		{
            try
            {
                try
                {
                    var iR_Stock_ChartDetail = _context.IR_Stock_ChartDetails.FirstOrDefault(x => x.Id == model.Id);
                    if (iR_Stock_ChartDetail is not null)
                    {
                        iR_Stock_ChartDetail.Link_IR_Stock_Chart = model.Link_IR_Stock_Chart;
                        iR_Stock_ChartDetail.Status = model.Status;
                        iR_Stock_ChartDetail.updated_at = DateTime.Now;
                        _context.Entry(iR_Stock_ChartDetail).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
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

		[HttpDelete]
		public async Task<IActionResult> IR_Stock_ChartDetail_Delete(int? Id)
		{
            try
            {
                try
                {
                    var DB = _context.IR_Stock_ChartDetails.FirstOrDefault(x => x.Id == Id);
                    if (DB is not null)
                    {
                        _context.IR_Stock_ChartDetails.Remove(DB);
                        await _context.SaveChangesAsync();
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
		public async Task<IActionResult> IR_Stock_ChartDetail_Change(int? Id)
		{
            try
            {
                var DB = _context.IR_Stock_ChartDetails.FirstOrDefault(x => x.Id == Id);
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
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_Stock_Link_Index()
		{
			return View();
		}

        [HttpPost]
		public async Task<IActionResult> Table_IR_Stock_LinkDetail()
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
                var list = new List<ResponseDTO.IR_Stock_LinkDetailResponse>();
                var IR_Contact = await _context.IR_Stock_LinkDetail.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_Stock_LinkDetailResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Link_IR_Stock_Link = item.Link_IR_Stock_Link
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Link_IR_Stock_Link.Contains(searchValue)
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

		public IActionResult IR_Stock_LinkDetail_Add()
		{
            return View();
		}

        [HttpPost]
		public async Task<IActionResult> IR_Stock_LinkDetail_Add_Submit(RequestDTO.IR_Stock_LinkDetailRequest model)
		{
            try
            {
                try
                {
                    IR_Stock_LinkDetail iR_Stock_LinkDetail = new IR_Stock_LinkDetail();
                    iR_Stock_LinkDetail.Link_IR_Stock_Link = model.Link_IR_Stock_Link;
                    iR_Stock_LinkDetail.Status = model.Status;
                    iR_Stock_LinkDetail.created_at = DateTime.Now;
                    iR_Stock_LinkDetail.updated_at = DateTime.Now;
                    await _context.IR_Stock_LinkDetail.AddAsync(iR_Stock_LinkDetail);
                    await _context.SaveChangesAsync();
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

        public IActionResult IR_Stock_LinkDetail_Edit(int? Id)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetIR_StockDetail_Link(int? Id)
		{
            try
            {
                var DB = await _context.IR_Stock_LinkDetail.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

		[HttpPut]
        public async Task<IActionResult> IR_Stock_LinkDetail_Edit_Submit(RequestDTO.IR_Stock_LinkDetailRequest model)
		{
            try
            {
                var iR_Stock_LinkDetail = _context.IR_Stock_LinkDetail.FirstOrDefault(x => x.Id == model.Id);
                if (iR_Stock_LinkDetail is not null)
                {
                    iR_Stock_LinkDetail.Link_IR_Stock_Link = model.Link_IR_Stock_Link;
                    iR_Stock_LinkDetail.Status = model.Status;
                    iR_Stock_LinkDetail.created_at = DateTime.Now;
                    iR_Stock_LinkDetail.updated_at = DateTime.Now;
                    _context.Entry(iR_Stock_LinkDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
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
		public async Task<IActionResult> IR_Stock_LinkDetail_Delete(int? Id)
		{
            try
            {
                try
                {
                    var DB = _context.IR_Stock_LinkDetail.FirstOrDefault(x => x.Id == Id);
                    if (DB is not null)
                    {
                        _context.IR_Stock_LinkDetail.Remove(DB);
                        await _context.SaveChangesAsync();
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
		public async Task<IActionResult> IR_Stock_LinkDetail_Change(int? Id)
		{
            try
            {
                var DB = _context.IR_Stock_LinkDetail.FirstOrDefault(x => x.Id == Id);
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
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }
    }
}
