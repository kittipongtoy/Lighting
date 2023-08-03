using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Lighting.Controllers.Frontend
{
    public class Resource_FacilityController : Controller
    {
        //private IConfiguration _config;
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public Resource_FacilityController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }
        public async Task<IActionResult> Profile_History()
        {
            ViewBag.Header = await db.History.ToListAsync(); 
            ViewBag.Body = await db.HistoryDetail.Where(x=>x.Status==1).ToListAsync(); 
            ViewBag.BodyDetailsTimeline = await db.HistoryDataDetail.Where(x=>x.TypeData==2&&x.Status==1).ToListAsync(); 
            ViewBag.BodyDetailsVDO = await db.HistoryDataDetail.Where(x => x.TypeData == 1&&x.Status==1).ToListAsync();

            return View();
        }

        public async Task<IActionResult> Profile_Our_Philosophy_Vision_Misson()
        {
            ViewBag.Header = await db.RF_Philosophy_Vision_Mission.ToListAsync();

            ViewBag.Body = await db.RF_Philosophy_Vision_Mission_Details.Where(x => x.active_status == 1).ToListAsync();
            return View();
        }

        public async Task<IActionResult> Profile_Organization_Chart()
        {
            ViewBag.Header = await db.Organization_Chart.ToListAsync();

            ViewBag.Body = await db.Organization_ChartDetail.Where(x => x.Status == 1).ToListAsync(); 
            return View();
        }

        public async Task<IActionResult> Profile_Awards()
        {
            ViewBag.Header = await db.Awards.ToListAsync();

            ViewBag.Body = await db.AwardsDetail.Where(x => x.Status == 1).ToListAsync();
            return View();
        }

        public IActionResult Subsidiaries_Lighting_Innovation_Center()
        {
            var title_content = new model_input.page_resource_facility_title();
            var image_file = new List<model_input.page_resource_facility_content>();

            var get_image = db.RF_Innovation_Center_Images.Where(x => x.active_status == 1).ToList();
            var getdata = db.RF_Innovation_Centers.FirstOrDefault();
            var count_image = 0;
            var count_title = 0;
            if (get_image.Count > 0)
            {
                count_image = 1;
                foreach (var items in get_image)
                {
                    image_file.Add(new model_input.page_resource_facility_content
                    {
                        active_status = items.active_status,
                        created_at = items.created_at,
                        id = items.id,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_title = 1;
                title_content.id = getdata.id;
                title_content.titleTH = getdata.titleTH;
                title_content.titleENG = getdata.titleENG;
                title_content.detailsTitleTH = getdata.detailsTitleTH;
                title_content.detailsTitleENG = getdata.detailsTitleENG;
                title_content.link = getdata.link;
            }

            var model = new model_input
            {
                count_fod_page_resource_facility_title = count_title,
                fod_page_resource_facility_title = title_content,
                count_list_page_resource_facility_content = count_image,
                list_page_resource_facility_content = image_file,
                path_image = "/upload_image/RF_InnovationCenters/"
            };
            return View(model);
        }

        public IActionResult Subsidiaries_Manufacturing()
        { 
            var title_content = new model_input.page_resource_facility_title();
            var image_file = new List<model_input.page_resource_facility_content>(); 

            var get_image = db.RF_Manufacturing_Images.Where(x => x.active_status == 1).ToList();
            var getdata = db.RF_Manufacturing.FirstOrDefault();
            var count_image = 0;
            var count_title = 0;
            if (get_image.Count > 0)
            {
                count_image = 1;
                foreach (var items in get_image)
                {
                    image_file.Add(new model_input.page_resource_facility_content
                    {
                        active_status = items.active_status,
                        created_at = items.created_at, 
                        id = items.id,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG, 
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_title = 1;
                title_content.id = getdata.id;
                title_content.titleTH = getdata.titleTH;
                title_content.titleENG = getdata.titleENG;
                title_content.detailsTitleTH = getdata.detailsTitleTH;
                title_content.detailsTitleENG = getdata.detailsTitleENG;
                title_content.link = getdata.link; 
            } 

            var model = new model_input
            {
                count_fod_page_resource_facility_title = count_title,
                fod_page_resource_facility_title = title_content,
                count_list_page_resource_facility_content = count_image,
                list_page_resource_facility_content = image_file, 
                path_image = "/upload_image/RF_Manufacturing/"
            };
            return View(model);
             
        }

        public IActionResult Subsidiaries_Warehouse_Logistics()
        {
            var title_content = new model_input.page_resource_facility_title();
            var image_file = new List<model_input.page_resource_facility_content>();

            var get_image = db.RF_Warehouse_Logistics_Images.Where(x => x.active_status == 1).ToList();
            var getdata = db.RF_Warehouse_Logistics.FirstOrDefault();
            var count_image = 0;
            var count_title = 0;
            if (get_image.Count > 0)
            {
                count_image = 1;
                foreach (var items in get_image)
                {
                    image_file.Add(new model_input.page_resource_facility_content
                    {
                        active_status = items.active_status,
                        created_at = items.created_at,
                        id = items.id,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_title = 1;
                title_content.id = getdata.id;
                title_content.titleTH = getdata.titleTH;
                title_content.titleENG = getdata.titleENG;
                title_content.detailsTitleTH = getdata.detailsTitleTH;
                title_content.detailsTitleENG = getdata.detailsTitleENG;
                title_content.link = getdata.link;
            }

            var model = new model_input
            {
                count_fod_page_resource_facility_title = count_title,
                fod_page_resource_facility_title = title_content,
                count_list_page_resource_facility_content = count_image,
                list_page_resource_facility_content = image_file,
                path_image = "/upload_image/RF_Warehouse_Logistics/"
            };
            return View(model);
        }

        public IActionResult Subsidiaries_Overseas_Offices()
        {
            var title_content = new model_input.page_resource_facility_title();
            var image_file = new List<model_input.page_resource_facility_content>();

            var get_image = db.RF_Oversea_Offices_Images.Where(x => x.active_status == 1).ToList();
            var getdata = db.RF_Oversea_Offices.FirstOrDefault();
            var count_image = 0;
            var count_title = 0;
            if (get_image.Count > 0)
            {
                count_image = 1;
                foreach (var items in get_image)
                {
                    image_file.Add(new model_input.page_resource_facility_content
                    {
                        active_status = items.active_status,
                        created_at = items.created_at,
                        id = items.id,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_title = 1;
                title_content.id = getdata.id;
                title_content.titleTH = getdata.titleTH;
                title_content.titleENG = getdata.titleENG;
                title_content.detailsTitleTH = getdata.detailsTitleTH;
                title_content.detailsTitleENG = getdata.detailsTitleENG;
                title_content.link = getdata.link;
            }

            var model = new model_input
            {
                count_fod_page_resource_facility_title = count_title,
                fod_page_resource_facility_title = title_content,
                count_list_page_resource_facility_content = count_image,
                list_page_resource_facility_content = image_file,
                path_image = "/upload_image/RF_Oversea_Offices/"
            };
            return View(model);
        }

        public IActionResult Subsidiaries_SolidState()
        {
            var title_content = new model_input.page_resource_facility_title();
            var image_file = new List<model_input.page_resource_facility_content>();

            var get_image = db.RF_Solid_States_Images.Where(x => x.active_status == 1).ToList();
            var getdata = db.RF_Solid_States.FirstOrDefault();
            var count_image = 0;
            var count_title = 0;
            if (get_image.Count > 0)
            {
                count_image = 1;
                foreach (var items in get_image)
                {
                    image_file.Add(new model_input.page_resource_facility_content
                    {
                        active_status = items.active_status,
                        created_at = items.created_at,
                        id = items.id,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_title = 1;
                title_content.id = getdata.id;
                title_content.titleTH = getdata.titleTH;
                title_content.titleENG = getdata.titleENG;
                title_content.detailsTitleTH = getdata.detailsTitleTH;
                title_content.detailsTitleENG = getdata.detailsTitleENG;
                title_content.link = getdata.link;
            }

            var model = new model_input
            {
                count_fod_page_resource_facility_title = count_title,
                fod_page_resource_facility_title = title_content,
                count_list_page_resource_facility_content = count_image,
                list_page_resource_facility_content = image_file,
                path_image = "/upload_image/RF_Solid_States/"
            };
            return View(model);
        }

        public IActionResult Subsidiaries_AssemblyService()
        {
            var title_content = new model_input.page_resource_facility_title();
            var image_file = new List<model_input.page_resource_facility_content>();

            var get_image = db.RF_Assembly_Services_Images.Where(x => x.active_status == 1).ToList();
            var getdata = db.RF_Assembly_Services.FirstOrDefault();
            var count_image = 0;
            var count_title = 0;
            if (get_image.Count > 0)
            {
                count_image = 1;
                foreach (var items in get_image)
                {
                    image_file.Add(new model_input.page_resource_facility_content
                    {
                        active_status = items.active_status,
                        created_at = items.created_at,
                        id = items.id,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_title = 1;
                title_content.id = getdata.id;
                title_content.titleTH = getdata.titleTH;
                title_content.titleENG = getdata.titleENG;
                title_content.detailsTitleTH = getdata.detailsTitleTH;
                title_content.detailsTitleENG = getdata.detailsTitleENG;
                title_content.link = getdata.link;
            }

            var model = new model_input
            {
                count_fod_page_resource_facility_title = count_title,
                fod_page_resource_facility_title = title_content,
                count_list_page_resource_facility_content = count_image,
                list_page_resource_facility_content = image_file,
                path_image = "/upload_image/RF_Assembly_Services/"
            };
            return View(model);
        }

        public IActionResult Subsidiaries_Lighting_Solution_Center()
        {
            var title_content = new model_input.page_resource_facility_title();
            var image_file = new List<model_input.page_resource_facility_content>();

            var get_image = db.RF_Solution_Centers_Images.Where(x => x.active_status == 1).ToList();
            var getdata = db.RF_Solution_Centers.FirstOrDefault();
            var count_image = 0;
            var count_title = 0;
            if (get_image.Count > 0)
            {
                count_image = 1;
                foreach (var items in get_image)
                {
                    image_file.Add(new model_input.page_resource_facility_content
                    {
                        active_status = items.active_status,
                        created_at = items.created_at,
                        id = items.id,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at
                    });
                }
            }
            if (getdata != null)
            {
                count_title = 1;
                title_content.id = getdata.id;
                title_content.titleTH = getdata.titleTH;
                title_content.titleENG = getdata.titleENG;
                title_content.detailsTitleTH = getdata.detailsTitleTH;
                title_content.detailsTitleENG = getdata.detailsTitleENG;
                title_content.link = getdata.link;
            }

            var model = new model_input
            {
                count_fod_page_resource_facility_title = count_title,
                fod_page_resource_facility_title = title_content,
                count_list_page_resource_facility_content = count_image,
                list_page_resource_facility_content = image_file,
                path_image = "/upload_image/RF_Solution_Centers/"
            };
            return View(model);
        }
    }
}
