using Lighting.Areas.Identity.Data;
using Lighting.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Org.BouncyCastle.Asn1.Ess;
using System.Globalization;

namespace Lighting.Controllers.Frontend
{
    public class Frontend_IRController : Controller
    {
        //private IConfiguration _config;
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public Frontend_IRController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }
        public IActionResult change_lang(string? lang)
        {
            string getcookie_lang = Request.Cookies["lang"];
            if (getcookie_lang == null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("lang", lang, option);
            }
            else
            {
                Response.Cookies.Delete("lang");

                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("lang", lang, option);
            }
            return Json(new { status = "success", message = "เปลี่ยนภาษาเรียบร้อย" });
        }

        public async Task<IActionResult> IR_index()
        {
            ViewBag.IR_Banner = await db.IR_Banner.Where(x => x.Status == 1).OrderByDescending(o => o.created_at).ToListAsync();
            ViewBag.IR_Button_Below_Banner = await db.IR_Button_Below_Banner.Where(x => x.Status == 1).OrderByDescending(o => o.created_at).ToListAsync();
            ViewBag.IR_Lighting_Equipment = await db.IR_LIGHTING_EQUIPMENT.Where(x => x.Status == 1).OrderByDescending(o => o.created_at).ToListAsync();
            ViewBag.IR_Summary_Financial_Highlights = await db.IR_Summary_Financial_Highlight.Where(x => x.Status == 1).OrderByDescending(o => o.created_at).ToListAsync();
            ViewBag.IR_Summary_Financial_HighlightsDetail = await db.IR_Summary_Financial_HighlightsDetail.Where(x => x.Status == 1).OrderByDescending(o => o.created_at).ToListAsync();
            ViewBag.IR_Report = await db.IR_Report.Where(x => x.Status == 1).OrderByDescending(o => o.created_at).ToListAsync();
            ViewBag.IR_Highlight = await db.IR_Hightlight.Where(x => x.Status == 1).OrderByDescending(o => o.created_at).ToListAsync();
            ViewBag.IR_HighlightDetail = await db.IR_HightlightDetail.Where(x => x.Status == 1).OrderByDescending(o => o.created_at).ToListAsync();                
            ViewBag.IR_Latest_NewDetail = await db.IR_Latest_NewDetail.Where(x => x.Status == 1).OrderByDescending(o => o.NewDate).Take(5).ToListAsync();
            ViewBag.IR_NewDetail = await db.IR_NewDetail.Where(x => x.Status == 1).OrderByDescending(o => o.NewDate).Take(5).ToListAsync();
            ViewBag.IR_Stock_QuoteDetail = await db.IR_Stock_QuoteDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.Finance_Statement = await db.SH_IR_Finance_Statement.Where(x => x.active_status == 1).ToListAsync();
            ViewBag.SH_IR_prospectus = await db.SH_IR_prospectus.ToListAsync();

            return View();
        }

        public async Task<IActionResult> IR_annual_report()
        {
            var data = db.SH_annual_Report.ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var details = db.SH_annual_ReportData.Where(x => x.use_status == 1).ToList();
            if (details.Count != 0)
            {
                ViewBag.Body = details;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public IActionResult Get_IR_annual_report()
        {
            var IR_AnnualReport = db.SH_annual_ReportData.Where(x => x.use_status == 1).OrderByDescending(x => x.year).AsEnumerable().Select((op) => new IR_Important_Financial_model.ResponserAnnualReport
            {
                id = op.id,
                titleTH = op.titleTH,
                titleENG = op.titleENG,
                file_name = op.file_name,
                file_name_ENG = op.file_name_ENG,
                upload_image = op.upload_image,
                upload_image_ENG = op.upload_image_ENG,
                year = op.year
            }).ToList();

            return Json(new { obj = IR_AnnualReport });

            //return View();
        }

        public async Task<IActionResult> IR_anti_corruption_policy()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Anti_fraud_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Anti_fraud.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/AntiFraud/",
                path_image = "/upload_image/AntiFraud/",
                title_th = "นโยบายการต่อต้านการทุจริตและคอร์รัปชั่น",
                title_en = "Anti-Fraud and Corruption Policy"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_author_audit_committee()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Author_audit_committee_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Author_audit_committee.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/Author_audit_committee/",
                path_image = "/upload_image/Author_audit_committee/",
                title_th = "ขอบเขตอำนาจหน้าที่ของคณะกรรมการตรวจสอบ",
                title_en = "Scope of duties and responsibilities of the Audit Committee"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_author_board_director()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Author_board_director_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Author_board_director.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/Author_board_director/",
                path_image = "/upload_image/Author_board_director/",
                title_th = "ขอบเขตอำนาจหน้าที่ของคณะกรรมการบริษัท",
                title_en = "Scope of duties and responsibilities of the Board of Directors"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_author_cg()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Author_cg_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Author_cg.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/Author_cg/",
                path_image = "/upload_image/Author_cg/",
                title_th = "ขอบเขตอำนาจหน้าที่ของคณะกรรมการกำกับดูแลกิจการ สรรหาและค่าตอบแทน",
                title_en = "Scope of duties and responsibilities of the Corporate Governance Committee Nomination and Remuneration"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_author_chairman_board()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Author_chairman_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Author_chairman.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/Author_chairman/",
                path_image = "/upload_image/Author_chairman/",
                title_th = "ขอบเขตอำนาจหน้าที่ของประธานกรรมการ",
                title_en = "The scope of duties and responsibilities of the Chairman"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_author_chairman_executive()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Author_chairman_executive_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Author_chairman_executive.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/Author_chairman_executive/",
                path_image = "/upload_image/Author_chairman_executive/",
                title_th = "ขอบเขตอำนาจหน้าที่ของประธานกรรมการบริหาร",
                title_en = "Scope of duties and responsibilities of the Executive Chairman"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_author_executive_board()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Author_executive_board_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Author_executive_board.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/Author_executive_board/",
                path_image = "/upload_image/Author_executive_board/",
                title_th = "ขอบเขตอำนาจหน้าที่ของคณะกรรมการบริหาร",
                title_en = "Scope of duties and responsibilities of the Executive Committee"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_author_secretary()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Author_secretary_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Author_secretary.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/Author_secretary/",
                path_image = "/upload_image/Author_secretary/",
                title_th = "ขอบเขตอำนาจหน้าที่เลขานุการบริษัท",
                title_en = "Scope of duties and responsibilities of the Company Secretary"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_board_directors()
        {
            var get_data1 = db.Board_of_Directors.Where(x => x.use_status == 1 && x.type_board == 1).ToList();
            var count1 = 0;
            if (get_data1.Count > 0)
            {
                count1 = 1;
            }

            var get_data2 = db.Board_of_Directors.Where(x => x.use_status == 1 && x.type_board == 2).ToList();
            var count2 = 0;
            if (get_data2.Count > 0)
            {
                count2 = 1;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                list_Board = get_data1,
                count_list_Board = count1,
                list_Manage = get_data2,
                count_list_Manage = count2,
            };
            return View(model);
        }
        public IActionResult IR_board_directors_getData(int? id)
        {
            var get_data1 = db.Board_of_Directors.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data1 });
        }
        public async Task<IActionResult> IR_calendar()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_InvestorCalendar = await db.IR_InvestorCalendar.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_InvestorCalendarDetail = await db.IR_InvestorCalendarDetail.Where(x => x.Status == 1).OrderByDescending(o => o.NewDate).ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetIR_calendar(int? Year)
        {
            var DB = await db.IR_InvestorCalendarDetail.Where(x => x.Status == 1).OrderByDescending(o=>o.NewDate).ToListAsync();
            if (Year != null && Year != 0)
            {

                DB = DB.Where(x => x.NewDate.Value.Year == Year).ToList();
            }

            return Json(new { obj = DB });
        }

        [HttpGet]
        public async Task<IActionResult> GetIR_calendar_Year()
        {
            var DB = await db.IR_InvestorCalendarDetail.Where(x => x.Status == 1).OrderByDescending(o=>o.NewDate).Select(x => new
            {
                Year = x.NewDate.Value.Year
            }).ToListAsync();
            return Ok(DB);
        }

        public async Task<IActionResult> IR_chairman()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var get_message = db.M_message_chairman.FirstOrDefault();
            var get_chairman = db.M_chairman.Where(x => x.use_status == 1).ToList();
            var count = 0;
            var count_list = 0;

            if (get_message != null)
            {
                count = 1;
            }

            if (get_chairman.Count > 0)
            {
                count_list = 1;
            }
            var model = new model_input
            {
                list_chairman = get_chairman,
                fod_message_chairman = get_message,
                count_row_chairman = count,
                count_list_chairman = count_list
            };
            return View(model);
        }
        public async Task<IActionResult> IR_channel_clue()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Channel_clue_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Channel_clue.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/Channel_clue/",
                path_image = "/upload_image/Channel_clue/",
                title_th = "ช่องทางแจ้งเบาะแส",
                title_en = "Whistleblowing channels"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_code_conduct()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_business_ethics_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_business_ethics.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_type = items.file_type,
                        file_name_ENG = items.file_name_ENG,
                        image_name_ENG = items.image_name_ENG,
                        id = items.id,
                        image_name = items.image_name,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/BusinessEthics/",
                path_image = "/upload_image/BusinessEthics/",
                title_th = "จรรยาบรรณธุรกิจ",
                title_en = "Business ethics"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_companyprofile()
        {
            var getData = db.Companyprofile.Where(x => x.use_status == 1).ToList();
            var count = 0;
            if (getData.Count > 0)
            {
                count = 1;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input { count_list_Companyprofile = count, list_Companyprofile = getData };
            return View(model);
        }
        public IActionResult IR_companyprofile_getData(int? id)
        {
            var getData = db.Companyprofile.Where(x => x.id == id).FirstOrDefault();
            var get_detail = "";
            if (Request.Cookies["lang"] == "EN")
            {
                get_detail = getData.detail_en;
            }
            else
            {
                get_detail = getData.detail_th;
            }
            return Json(new { status = "success", message = "เรียบร้อย", data = get_detail });
        }
        public async Task<IActionResult> IR_complaints()
        {
            ViewBag.IR_complaints = await db.IR_Complaints.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_contact()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.Get_IR_Contact = await db.IR_Contact.Where(x => x.Status == 1).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_corporate_governance()
        {
            var get_data_main = db.CorporateGovernance.FirstOrDefault();
            var get_data_file = db.CorporateGovernance_File.Where(x => x.use_status == 1).ToList();
            var get_data_cate = db.CorporateGovernance_Cate.Where(x => x.use_status == 1).ToList();
            var count_main = 0;
            var count_file = 0;
            var count_cate = 0;

            if (get_data_main != null)
            {
                count_main = 1;
            }
            if (get_data_file.Count > 0)
            {
                count_file = 1;
            }
            if (get_data_cate.Count > 0)
            {
                count_cate = 1;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_row_CorporateGovernance = count_main,
                count_list_CorporateGovernance_Cate = count_cate,
                count_list_CorporateGovernance_File = count_file,
                list_CorporateGovernance_Cate = get_data_cate,
                list_CorporateGovernance_File = get_data_file,
                fod_CorporateGovernance = get_data_main
            };
            return View(model);
        }
        public async Task<IActionResult> IR_csr_policy()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_CRS_policy_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_CRS_policy.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/CRSpolicy/",
                path_image = "/upload_image/CRSpolicy/",
                title_th = "นโยบายและความรับผิดชอบต่อสังคมและสิ่งแวดล้อม",
                title_en = "Policies and Responsibilities to Society and Environment"
            };
            return View(model);
        }
        public async Task<IActionResult> IR_dividend()
        {
            var data = db.SH_dividen.OrderByDescending(x => x.created_at).ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var details = db.SH_dividen_Data.Where(x => x.use_status == 1).OrderByDescending(x => x.created_at).ToList();
            if (details.Count != 0)
            {
                ViewBag.Body = details;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_email_alerts()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_Email_Alerts = await db.IR_Email_Alerts.Where(x => x.Status == 1).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_email_alerts_unsubscribe()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_Cancel_Email = await db.IR_Cancel_Email.Where(x => x.Status == 1).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_fact_sheet()
        {
            var data = db.Import_Info_ShareHolder.ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var details = db.ImportInfo_ShareHolderData.Where(x => x.use_status == 1).ToList();
            if (details.Count != 0)
            {
                ViewBag.Body = details;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_faq()
        {
            ViewBag.IR_faq = await db.IR_faq.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_faq_Detail = await db.IR_faq_Detail.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_finance_statement()
        {
            var data = db.SH_IR_important_financial.ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var details = db.SH_IR_financial_position.Where(x => x.active_status == 1).ToList();
            if (details.Count != 0)
            {
                ViewBag.Body1 = details;
            }

            var details1 = db.SH_IR_financial_position_DataDetails.ToList();
            if (details1.Count != 0)
            {
                ViewBag.Bodyfinancial_position = details1;
            }

            var detailsProfit_Lose = db.SH_IR_Profit_Lose.ToList();
            if (detailsProfit_Lose.Count != 0)
            {
                ViewBag.ContentProfit_Lose = detailsProfit_Lose;
            }

            var detailsProfit_LoseOthers = db.SH_IR_Profit_Lose_others.ToList();
            if (detailsProfit_LoseOthers.Count != 0)
            {
                ViewBag.ContentProfit_LoseOthers = detailsProfit_LoseOthers;
            }

            var detailsCash_flow = db.SH_IR_cashFlow_statements.ToList();
            if (detailsCash_flow.Count != 0)
            {
                ViewBag.ContentCash_flow = detailsCash_flow;
            }

            var detailsDownload = db.SH_IR_download_financial_statements.ToList();
            if (detailsDownload.Count != 0)
            {
                ViewBag.ContentDownload = detailsDownload;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public IActionResult Get_IR_Finance_Statement()
        {
            var IR_DFS = db.SH_IR_download_financial_statements.Where(x => x.active_status == 1).OrderByDescending(x => x.inputDate).AsEnumerable().Select((op, index) => new IR_Important_Financial_model.ResponserDFStatement
            {
                id = op.id,
                titleTH = op.titleTH,
                titleENG = op.titleENG,
                file_name = op.file_name,
                file_name_ENG = op.file_name_ENG,
                inputDate = op.inputDate
            }).ToList();

            return Json(new { obj = IR_DFS });
        }
        public async Task<IActionResult> IR_financial_highlight()
        {
            var data = db.SH_IR_financial_highlight.ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var topTitle = db.SH_IR_financial_highlight_Data.Where(x => x.active_status == 1).ToList();
            if (topTitle.Count != 0)
            {
                ViewBag.ContentTop = topTitle;
            }

            var topDetails = db.SH_IR_financial_highlight_DataDetails.OrderByDescending(x => x.year).ToList();
            if (topDetails.Count != 0)
            {
                ViewBag.ContentTopDetails = topDetails;
            }

            var details_title = db.SH_IR_financial_highlight_Details.Where(x => x.active_status == 1).ToList();
            if (details_title.Count != 0)
            {
                ViewBag.BodyItem = details_title;
            }

            var data_details = db.SH_IR_financial_highlight_DetailsData.Where(x => x.active_status == 1).ToList();
            if (data_details.Count != 0)
            {
                ViewBag.BodyTitle = data_details;
            }

            var data_details_Item = db.SH_IR_financial_highlight_DetailsData_Items.ToList();
            if (data_details_Item.Count != 0)
            {
                ViewBag.BodyDetails = data_details_Item;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_form56()
        {
            var data = db.SH_IR_Form.ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var details = db.SH_IR_FormData.Where(x => x.active_status == 1).OrderByDescending(x => x.year).ToList();
            if (details.Count != 0)
            {
                ViewBag.Body = details;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_general_meeting()
        {
            var data =await db.SH_generalMeeting.ToListAsync();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var details =await db.SH_generalMeeting_Data.Where(x => x.use_status == 1).OrderByDescending(x => x.id).ToListAsync();
            if (details.Count != 0)
            {
                ViewBag.Body = details;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_gift_and_entertainment_policy()
        {
            var main_content = new model_input.page_corporate_governance_content();
            var main_file = new List<model_input.page_corporate_governance_file>();


            var get_file = db.O_Gift_entertainment_File.Where(x => x.use_status == 1).ToList();
            var getdata = db.O_Gift_entertainment.FirstOrDefault();
            var count_file = 0;
            var count_data = 0;
            if (get_file.Count > 0)
            {
                count_file = 1;
                foreach (var items in get_file)
                {
                    main_file.Add(new model_input.page_corporate_governance_file
                    {
                        use_status = items.use_status,
                        created_at = items.created_at,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
                        file_type = items.file_type,
                        id = items.id,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        title_file_en = items.title_file_en,
                        title_file_th = items.title_file_th,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_data = 1;
                main_content.id = getdata.id;
                main_content.title_TH = getdata.title_TH;
                main_content.title_ENG = getdata.title_ENG;
                main_content.titleDetails_TH = getdata.titleDetails_TH;
                main_content.titleDetails_ENG = getdata.titleDetails_ENG;
                main_content.detailsTitleTH = getdata.detailsTitleTH;
                main_content.detailsTitleENG = getdata.detailsTitleENG;
                main_content.detail_en = getdata.detail_en;
                main_content.detail_th = getdata.detail_th;
            }

            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input
            {
                count_fod_page_corporate_governance_content = count_data,
                fod_page_corporate_governance_content = main_content,
                count_list_page_corporate_governance_file = count_file,
                list_page_corporate_governance_file = main_file,
                path_file = "/upload_file/Gift_entertainment/",
                path_image = "/upload_image/Gift_entertainment/",
                title_th = "นโยบายการให้หรือรับของขวัญ และการเลี้ยงรับรอง",
                title_en = "Policy on Giving or Accepting Gifts and entertainment"
            };
            return View(model);
        }
        public IActionResult IR_inc_corporate_governance_content()
        {
            return View();
        }
        public async Task<IActionResult> IR_mda()
        {
            var data = db.SH_IR_MDA.ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var data_details = db.SH_IR_MDA_Data.Where(x => x.active_status == 1).ToList();
            if (data_details.Count != 0)
            {
                ViewBag.Body = data_details;
            }

            var file_details = db.SH_IR_MDA_DataDetails.Where(x => x.active_status == 1).OrderByDescending(x => x.year).ToList();
            if (file_details.Count != 0)
            {
                ViewBag.BodyFile = file_details;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_news()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_Latest_News = await db.IR_Latest_News.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_Latest_NewDetail = await db.IR_Latest_NewDetail.Where(x => x.Status == 1).OrderByDescending(o => o.NewDate).ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetIR_news()
        {
            var DB = await db.IR_Latest_NewDetail.Where(x => x.Status == 1).OrderByDescending(o=>o.NewDate).ToListAsync();
            return Json(new { obj = DB });
        }

        public async Task<IActionResult> IR_news_clipping()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_Print_Media = await db.IR_Print_Media.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_Print_MediaDetail = await db.IR_Print_MediaDetail.Where(x => x.Status == 1).OrderByDescending(o => o.NewDate).ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get_IR_news_clipping(string? Start, string? End)
        {
            var DB = await db.IR_Print_MediaDetail.Where(x => x.Status == 1).OrderByDescending(o => o.NewDate).ToListAsync();
            if (Start != null)
            {
                DateTime CStart = Convert.ToDateTime(Start);
                DB = DB.Where(x => x.NewDate.Value.Date >= CStart).ToList();
            }
            if (End != null)
            {
                DateTime CEnd = Convert.ToDateTime(End);
                DB = DB.Where(x => x.NewDate.Value.Date <= CEnd).ToList();
            }

            return Json(new { obj = DB });
        }

        public async Task<IActionResult> IR_news_detail(int? Id)
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_Latest_News = await db.IR_Latest_News.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_Latest_NewDetail = await db.IR_Latest_NewDetail.Where(x => x.Status == 1 && x.Id == Id).OrderByDescending(o => o.NewDate).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_organization()
        {
            var get_data = db.OrganizationalStructure.Where(x => x.use_status == 1).ToList();
            var count = 0;
            if (get_data.Count > 0)
            {
                count = 1;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input { count_list_OrganizationalStructure = count, list_OrganizationalStructure = get_data };
            return View(model);
        }
        public async Task<IActionResult> IR_philosophy()
        {
            var getData = db.P_philosophy.Where(x => x.use_status == 1).ToList();
            var count = 0;
            if (getData.Count > 0)
            {
                count = 1;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input { list_philosophy = getData, count_list_philosophy = count };
            return View(model);
        }
        public async Task<IActionResult> IR_presentation_doc()
        {
            var data = db.SH_IR_presentation_doc.ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var details = db.SH_IR_presentation_doc_Data.Where(x => x.active_status == 1).OrderByDescending(x => x.id).ToList();
            if (details.Count != 0)
            {
                ViewBag.Body = details;
            }
            return View();
        }
        public async Task<IActionResult> Get_IR_presentation_doc()
        {
            var IR_PWevcast = db.SH_IR_presentation_doc_Data.Where(x => x.active_status == 1).OrderByDescending(x => x.id).AsEnumerable().Select((op, index) => new IR_Presentation_Infor_model.Presentation_doc
            {
                id = op.id,
                titleTH = op.titleTH,
                titleENG = op.titleENG,
                file_name = op.file_name,
                file_name_ENG = op.file_name_ENG,
                document_date = op.document_date,
            }).ToList();

            return Json(new { obj = IR_PWevcast });
        }
        public async Task<IActionResult> IR_presentation_webcast()
        {
            var data =await db.SH_IR_presentation_webcast.ToListAsync();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var details =await db.SH_IR_presentation_webcast_Data.Where(x => x.active_status == 1).OrderByDescending(x => x.id).ToListAsync();
            if (details.Count != 0)
            {
                ViewBag.Body = details;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> Get_IR_presentation_webcast()
        {
            var IR_PWevcast = db.SH_IR_presentation_webcast_Data.Where(x => x.active_status == 1).OrderByDescending(x => x.id).AsEnumerable().Select((op, index) => new IR_Presentation_Infor_model.Presentation_webcast
            {
                id = op.id,
                titleTH = op.titleTH,
                titleENG = op.titleENG,
                file_name = op.file_name,
                file_name_ENG = op.file_name_ENG,
                activity_date = op.activity_date,
                linkVideo = op.linkVideo
            }).ToList();

            return Json(new { obj = IR_PWevcast });

        }
        public async Task<IActionResult> IR_propose_agenda()
        {
            ViewBag.Header = await db.SH_IR_propose_agenda.ToListAsync();

            ViewBag.Body = await db.SH_IR_propose_agenda_DataDetails.Where(x => x.active_status == 1).ToListAsync();

            ViewBag.mailTitles = await db.SH_IR_propose_agenda_mailTitles.Where(x => x.active_status == 1).ToListAsync();
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public IActionResult Get_TypeOfPropose()
        {
            var DB = db.type_of_agenda_Propose.Where(x => x.active_status == 1).ToList();
            return Json(new { DB = DB });
        }
        public async Task<IActionResult> IR_propose_agenda_sentMail(receive_mail_propose_agendas mailReceive)
        {
            try
            {
                if (mailReceive.typeOfPropose == "0" || mailReceive.name == null || mailReceive.name == ""
                    || mailReceive.phone == null || mailReceive.phone == "" || mailReceive.wantProposeTitle == null || mailReceive.wantProposeTitle == ""
                    || mailReceive.details == null || mailReceive.details == "")
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลทั้งหมด" });
                }
                {
                    await SendEmailAsyncCareer(mailReceive);

                    var getdata = db.type_of_agenda_Propose.Where(x => x.id == Convert.ToInt32(mailReceive.typeOfPropose)).FirstOrDefault();
                    mailReceive.typeOfPropose = getdata.titleTH + "(" + getdata.titleENG + ")";
                    mailReceive.created_at = DateTime.Now;
                    mailReceive.updated_at = DateTime.Now;
                    db.receive_mail_propose_agendas.Add(mailReceive);
                    db.SaveChanges();
                    return Json(new { status = "success", message = "งเมลล์สำเร็จ" });
                }
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = "ส่งเมลล์ไม่สำเร็จ", inner = e.InnerException });
            }
        }
        public async Task SendEmailAsyncCareer(receive_mail_propose_agendas mailRequest)
        {

            //string Email = System.Configuration.ConfigurationManager.AppSettings["EmailSender"];
            //string Password = System.Configuration.ConfigurationManager.AppSettings["EmailPassswordSender"];
            //string Smtp = System.Configuration.ConfigurationManager.AppSettings["EmailSmtpSender"];
            //string SmtpPort = System.Configuration.ConfigurationManager.AppSettings["EmailSmtpPort"];

            string Email = "saimonnlaing1500@gmail.com";
            string Password = "ffrpojpekljhdqnb";
            string Smtp = "smtp.gmail.com";
            string SmtpPort = "587";

            var to_mail = db.receive_agenda_mail_accounts.FirstOrDefault().account;
            var tomails = to_mail.Split(',', ' ');
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(Email);
            foreach (var tomail in tomails)
            {
                email.To.Add(MailboxAddress.Parse(tomail));
            }

            var getdata = db.type_of_agenda_Propose.Where(x => x.id == Convert.ToInt32(mailRequest.typeOfPropose)).FirstOrDefault();
            var builder = new BodyBuilder();
            string Data_head = "ข้อมูลสำหรับผู้ถือหุ้น";
            string DataBody = "เสนอวาระ/กรรมการ/คำถามล่วงหน้า" +
                              "ชื่อผู้ติดต่อ      : " + mailRequest.name + "<br/>" +
                              "เบอร์โทรศัพท์   : " + mailRequest.phone + "<br/>" +
                              "อีเมล         : " + mailRequest.email + "<br/>" +
                              "หัวข้อที่ต้องการเสนอ    : " + getdata.titleTH + "(" + getdata.titleENG + ")" + "<br/>" +
                              "ชื่อหัวข้อที่ต้องการเสนอ : " + mailRequest.wantProposeTitle + "<br/>" +
                              "รายละเอียด        : " + mailRequest.details;

            builder.HtmlBody = DataBody;

            email.Body = builder.ToMessageBody();
            email.Subject = Data_head;
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                await smtp.ConnectAsync(Smtp, int.Parse(SmtpPort), SecureSocketOptions.Auto);
                await smtp.AuthenticateAsync(Email, Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }

        public async Task<IActionResult> IR_public_relation()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_MassMedia = await db.IR_MassMedia.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_MassMediaDetail = await db.IR_MassMediaDetail.Where(x => x.Status == 1).OrderByDescending(o => o.NewDate).ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get_IR_public_relation()
        {
            var DB = await db.IR_MassMediaDetail.Where(x => x.Status == 1).OrderByDescending(o=>o.NewDate).ToListAsync();
            return Json(new { obj = DB });
        }

        public async Task<IActionResult> IR_public_relation_detail(int? Id)
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_MassMedia = await db.IR_MassMedia.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_MassMediaDetail = await db.IR_MassMediaDetail.Where(x => x.Status == 1 && x.Id == Id).OrderByDescending(o=>o.NewDate).ToListAsync();
            return View();
        }

        public async Task<IActionResult> IR_report_general_meeting()
        {
            var data = db.SH_IR_Report_Meeting.ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var details = db.SH_IR_Report_MeetingData.Where(x => x.active_status == 1).OrderByDescending(x => x.year).ToList();
            if (details.Count != 0)
            {
                ViewBag.Body = details;
            }

            var datadetails = db.SH_IR_Report_Meeting_DataDetails.Where(x => x.active_status == 1).ToList();
            if (datadetails.Count != 0)
            {
                ViewBag.Content = datadetails;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }

        public async Task<IActionResult> IR_request_inquiry()
        {
            ViewBag.IR_Request_Inquiry = await db.IR_Request_Inquiry.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }

        public async Task<IActionResult> IR_set_announcement()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.GetIR_Stock_Market = await db.IR_Stock_Market.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_NewDetail = await db.IR_NewDetail.Where(x => x.Status == 1).OrderByDescending(o => o.NewDate).ToListAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get_IR_NewDetail()
        {
            var DB = await db.IR_NewDetail.Where(x => x.Status == 1).OrderByDescending(o => o.NewDate).ToListAsync();
            return Json(new { obj = DB });
        }

        public async Task<IActionResult> IR_set_announcement_detail(int? Id)
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.GetIR_Stock_Market = await db.IR_Stock_Market.Where(x => x.Status == 1).ToListAsync();
            ViewBag.IR_NewDetail = await db.IR_NewDetail.Where(x => x.Status == 1 && x.Id == Id).OrderByDescending(o => o.NewDate).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_shareholding()
        {
            var data = db.ShareHolder.ToList();
            if (data.Count != 0)
            {
                ViewBag.Header = data;
            }

            var details = db.ShareHolder_DataDetails.ToList();
            if (details.Count != 0)
            {
                ViewBag.Body = details;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_stock_quote()
        {
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.IR_Stock_Quote = await db.IR_Stock_Quote.Where(x=>x.Status == 1).ToListAsync();
            ViewBag.IR_Stock_QuoteDetail = await db.IR_Stock_QuoteDetail.Where(x => x.Status == 1).ToListAsync();
            return View();
        }
        public async Task<IActionResult> IR_summary()
        {
            var getData = db.Company_Overview.Where(x => x.use_status == 1).ToList();
            var count = 0;
            if (getData.Count > 0)
            {
                count = 1;
            }
            ViewBag.IR_Stock_LinkDetail = await db.IR_Stock_LinkDetail.Where(x => x.Status == 1).OrderByDescending(x => x.Id).ToListAsync();
            var model = new model_input { list_companyOverview = getData, count_list_companyOverview = count };
            return View(model);
        }
        public IActionResult get_Sustainability_Report()
        {
            var getdata = db.Sustainability_Report.FirstOrDefault();
            return Json(new { status = "success", message = "", data = getdata });
        }
    }
}
