using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyJobImgContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefit_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_pdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefit_pdf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyJobImgContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplyJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionName_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPlace_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPlace_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Respondsibility_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Respondsibility_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCodeInt = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isactive = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceptionistFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuarantorIdentificationCardFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author_secretary_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author_secretary_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AwardsDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardsDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Board_of_Directors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_nameTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_nameEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_board = table.Column<int>(type: "int", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    sort_number = table.Column<int>(type: "int", nullable: true),
                    position_company_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position_company_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationality_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationality_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    study_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    study_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expertise_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expertise_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_appointment_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_appointment_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shares_held_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shares_held_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    training_course_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    training_course_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    work_history_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    work_history_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    holding_position_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    holding_position_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Illegal_history_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Illegal_history_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board_of_Directors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Category_Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_Path_Nav = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company_Overview",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Overview", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Companyprofile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companyprofile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sub_Factory_Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sub_Factory_Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceName_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceName_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePathEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMaps_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTube_Url_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTube_Url_TH = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cookies_policy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    headTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    headTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cookies_policy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateGovernance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateGovernance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateGovernance_Cate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateGovernance_Cate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateGovernance_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateGovernance_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DownloadHeads",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadHeads", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Downloads",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DownloadType_id = table.Column<int>(type: "int", nullable: true),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L_AND_BIM_Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    ShowItem = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Downloads", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DownloadTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DownloadType_name_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownloadType_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryDataDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeData = table.Column<int>(type: "int", nullable: true),
                    ImageTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileVideoTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileVideoEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryDataDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileCompany_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileCompany_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Import_Info_ShareHolder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Import_Info_ShareHolder", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ImportInfo_ShareHolderData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportInfo_ShareHolderData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Analyst_Chapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Analyst_Chapter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Analysts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Analysts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageBanner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Button_Below_Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Button_Below_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Cancel_Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input_Text_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input_Text_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Cancel_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeContactUS_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeContactUS_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input_Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input_Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_File_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_File_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Description_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Description_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_Title_UploadFile_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_Title_UploadFile_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TypeContact_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TypeContact_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Email_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Email_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Tel_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Tel_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Other_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Other_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Note_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Contact_Note_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Complaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Email_Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text_Register_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text_Register_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text_Input_Email_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text_Input_Email_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Policy_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Policy_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Email_Alerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_faq",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_faq", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_faq_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_faq_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Hightlight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Hightlight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_HightlightDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetType = table.Column<int>(type: "int", nullable: false),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_HightlightDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_InvestorCalendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_InvestorCalendar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_InvestorCalendarDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activity_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNameTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNameEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_InvestorCalendarDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Investor_Relations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Investor_Relations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Investor_RelationsDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Investor_RelationsDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Latest_NewDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Latest_NewDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Latest_News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Latest_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_LIGHTING_EQUIPMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_LIGHTING_EQUIPMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_MassMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_MassMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_MassMediaDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUs_Name1_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUs_Name1_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUs_Name2_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUs_Name2_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUs_Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUs_Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUs_Mail1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUs_Mail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_MassMediaDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_NewDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_NewDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Print_Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Print_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Print_MediaDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image_Newssource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNameTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNameEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Print_MediaDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetType = table.Column<int>(type: "int", nullable: false),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Request_Inquiry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleText_Input_Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleText_Input_Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleText_Input_Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text_Input_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Policy_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Policy_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Button_Submit_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Request_Inquiry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Stock_Chart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Stock_Chart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Stock_ChartDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link_IR_Stock_Chart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Stock_ChartDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Stock_LinkDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link_IR_Stock_Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Stock_LinkDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Stock_Market",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Stock_Market", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Stock_Quote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Stock_Quote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Stock_QuoteDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STOCK_PRICE_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STOCK_PRICE_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_STOCK_PRICE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_STOCK_PRICE_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SET_INDEX_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SET_INDEX_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_SET_INDEX_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_SET_INDEX_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Stock_QuoteDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Summary_Financial_Highlight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Summary_Financial_Highlight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_Summary_Financial_HighlightsDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Summary_Financial_HighlightsDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleName_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleName_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEMail1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEMail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img_File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img_FileEN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_chairman",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_chairman", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "M_message_chairman",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vision_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vision_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_message_chairman", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate_TH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate_EN = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "O_Anti_fraud",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Anti_fraud", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Anti_fraud_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Anti_fraud_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_audit_committee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_audit_committee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_audit_committee_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_audit_committee_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_board_director",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_board_director", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_board_director_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_board_director_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_cg",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_cg", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_cg_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_cg_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_chairman",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_chairman", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_chairman_executive",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_chairman_executive", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_chairman_executive_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_chairman_executive_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_chairman_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_chairman_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_executive_board",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_executive_board", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_executive_board_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_executive_board_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_secretary",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_secretary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Author_secretary_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Author_secretary_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_business_ethics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_business_ethics", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_business_ethics_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_business_ethics_details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_business_ethics_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_business_ethics_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Channel_clue",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Channel_clue", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Channel_clue_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Channel_clue_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_CRS_policy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_CRS_policy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_CRS_policy_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_CRS_policy_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Gift_entertainment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleDetails_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Gift_entertainment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "O_Gift_entertainment_File",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O_Gift_entertainment_File", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalStructure",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_nameTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_nameEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    num_order = table.Column<int>(type: "int", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalStructure", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Organization_Chart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Chart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization_ChartDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_ChartDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "P_philosophy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    num_order = table.Column<int>(type: "int", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_philosophy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "privacy_Policys",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    typeOfPolicy_id = table.Column<int>(type: "int", nullable: true),
                    typeOfPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_privacy_Policys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "privacy_PolicyTitles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    headTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    headTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privacy_TitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privacy_TitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privacy_NoticeTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privacy_NoticeTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cctv_privacyTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cctv_privacyTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_privacy_PolicyTitles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowItem = table.Column<int>(type: "int", nullable: true),
                    ShowImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_CategoryId = table.Column<int>(type: "int", nullable: false),
                    Product_ModelId = table.Column<int>(type: "int", nullable: false),
                    Folder_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preview_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preview_Image_Index = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUB_IMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUTSHEET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IESFILE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CATALOGUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MORE_INFORMATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Application = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Technical_Drawing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Technical_Drawing_Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP_Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LIGHT_DISTRIBUTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowItem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRef_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRef_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "receive_agenda_mail_accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receive_agenda_mail_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "receive_mail_propose_agendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wantProposeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeOfPropose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receive_mail_propose_agendas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Assembly_Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Assembly_Services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Assembly_Services_Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upload_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Assembly_Services_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Innovation_Center_Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upload_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Innovation_Center_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Innovation_Centers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Innovation_Centers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Manufacturing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Manufacturing", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Manufacturing_Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upload_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Manufacturing_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Oversea_Offices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Oversea_Offices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Oversea_Offices_Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upload_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Oversea_Offices_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Philosophy_Vision_Mission",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Philosophy_Vision_Mission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Philosophy_Vision_Mission_Details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Philosophy_Vision_Mission_Details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Solid_States",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Solid_States", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Solid_States_Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upload_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Solid_States_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Solution_Centers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Solution_Centers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Solution_Centers_Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upload_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Solution_Centers_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Warehouse_Logistics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Warehouse_Logistics", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RF_Warehouse_Logistics_Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upload_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RF_Warehouse_Logistics_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Setting_Index",
                columns: table => new
                {
                    id_setting = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleTH2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titlesubTH2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titlesubENG2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptTH2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptENG2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleTH3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptTH3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptENG3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleTH4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titlesubTH4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titlesubENG4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting_Index", x => x.id_setting);
                });

            migrationBuilder.CreateTable(
                name: "SH_annual_Report",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_annual_Report", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_annual_ReportData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upload_image_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_annual_ReportData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShareHolder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amountTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amountTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareHolder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShareHolder_DataDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentPerAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareHolder_DataDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SH_dividen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    securityTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    securityTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBoardTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBoardTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateMakingTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateMakingTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paymentDateTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paymentDateTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dividenTypetitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dividenTypetitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amountTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amountTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    earningDayTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    earningDayTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_dividen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_dividen_Data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBoard = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dateMaking = table.Column<DateTime>(type: "datetime2", nullable: true),
                    paymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dividenTypeTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dividenTypeTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    earningDayTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    earningDayTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_dividen_Data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_generalMeeting",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    meetingTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    meetingTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_generalMeeting", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_generalMeeting_Data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    use_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_generalMeeting_Data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_cashFlow_statements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentProfit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_cashFlow_statements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_download_financial_statements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inputDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_download_financial_statements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_Finance_Statement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    linkTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_Finance_Statement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_financial_highlight",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profitTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profitTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date1Title = table.Column<DateTime>(type: "datetime2", nullable: true),
                    date2Title = table.Column<DateTime>(type: "datetime2", nullable: true),
                    date3Title = table.Column<DateTime>(type: "datetime2", nullable: true),
                    detailsTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_highlight", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_financial_highlight_Data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profitTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profitTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_highlight_Data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_financial_highlight_DataDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fH_Data_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_highlight_DataDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_financial_highlight_Details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_highlight_Details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_financial_highlight_DetailsData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profitTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profitTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    financial_hilight_id = table.Column<int>(type: "int", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_highlight_DetailsData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_financial_highlight_DetailsData_Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fH_Details_id = table.Column<int>(type: "int", nullable: true),
                    fH_DetailsData_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_highlight_DetailsData_Items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_financial_position",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_position", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_financial_position_DataDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    financialPosition_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_position_DataDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_Form",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yearTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yearTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateConfrimTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateConfrimTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_Form", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_FormData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    confrimDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_FormData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_important_financial",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    financial_positionTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    financial_positionTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profitLoseTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profitLoseTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comprehensive_IncomeTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comprehensive_IncomeTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cash_flowTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cash_flowTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    download_financialTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    download_financialTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    listTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    listTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amountTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amountTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dayTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dayTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_important_financial", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_MDA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_MDA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_MDA_Data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_MDA_Data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_MDA_DataDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_MDA_DataDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_presentation_doc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    present_documentTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    present_documentTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_presentation_doc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_presentation_doc_Data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    document_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_presentation_doc_Data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_presentation_webcast",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activitytitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activitytitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    webcastTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    webcastTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadtitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadtitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_presentation_webcast", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_presentation_webcast_Data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activity_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    linkVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_presentation_webcast_Data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_Profit_Lose",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentProfit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_Profit_Lose", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_Profit_Lose_others",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentProfit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_Profit_Lose_others", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_propose_agenda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_propose_agenda", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_propose_agenda_DataDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_propose_agenda_DataDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_propose_agenda_mailTitles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitlePlaceholderTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameTitlePlaceholderENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailTitlePlaceholderTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailTitlePlaceholderENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneTitlePlaceholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    proposeTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    proposeTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wantProposeTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wantProposeTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wantProposePlaceholderTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wantProposePlaceholderTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsPlaceholderTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsPlaceholderTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarkTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarkENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_propose_agenda_mailTitles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_propose_agenda_receive_mails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receiveMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_propose_agenda_receive_mails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_prospectus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_prospectus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_Report_Meeting",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_Report_Meeting", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_Report_MeetingData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_Report_MeetingData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SH_IR_Report_Meeting_DataDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reportMeeting_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_Report_Meeting_DataDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Slide_Image_Index",
                columns: table => new
                {
                    id_slideimg_index = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    sort = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide_Image_Index", x => x.id_slideimg_index);
                });

            migrationBuilder.CreateTable(
                name: "Smart_Solutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleName_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviewImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explanation_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explanation_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smart_Solutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sustainability_Report",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sustainability_Report", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_of_agenda_Propose",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_of_agenda_Propose", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Folder_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Design_Solution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo_Credit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pdf_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pdf_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowItem = table.Column<int>(type: "int", nullable: true),
                    ProjectRef_CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectRefs_Category_Projects_ProjectRef_CategoryId",
                        column: x => x.ProjectRef_CategoryId,
                        principalTable: "Category_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Spects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Spects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Spects_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smart_Solution_Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smart_SolutionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smart_Solution_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smart_Solution_Links_Smart_Solutions_Smart_SolutionId",
                        column: x => x.Smart_SolutionId,
                        principalTable: "Smart_Solutions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "06ff08ef-7151-478c-8a5d-e9411c014bea", "0f0ce5c1-445f-43cf-bf6f-181514419e5b", "Admin", "Admin", "Admin", new DateTime(2023, 9, 7, 3, 17, 31, 289, DateTimeKind.Utc).AddTicks(7031), new DateTime(2023, 9, 7, 3, 17, 31, 289, DateTimeKind.Utc).AddTicks(7034) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "a5d47453-01f2-487b-8c15-73a90061f53f", 0, null, null, "f3420f63-c512-46e7-aed7-a626c24b0c63", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAECQ8huwMZaUCiEbnGtssAdzWeKHmcJKUItYtf+yDEJN5V8g9DDwDYU6cbCIVigj0tw==", null, false, null, null, "41a55015-6bc1-45db-8a93-94f38b3e983c", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "DownloadTypes",
                columns: new[] { "id", "DownloadType_name_ENG", "DownloadType_name_TH", "created_at", "updated_at" },
                values: new object[,]
                {
                    { 1, "L&E BIM OBJECTS", "L&E BIM OBJECTS", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9757), new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9759) },
                    { 2, "CATALOGUE", "CATALOGUE", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9765), new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9765) },
                    { 3, "COMPANY PROFILE", "COMPANY PROFILE", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9766), new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9767) },
                    { 4, "IES FILE", "IES FILE", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9768), new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9768) },
                    { 5, "LEAFLET", "LEAFLET", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9769), new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9770) }
                });

            migrationBuilder.InsertData(
                table: "SH_IR_propose_agenda_mailTitles",
                columns: new[] { "id", "active_status", "created_at", "detailsENG", "detailsPlaceholderTitleENG", "detailsPlaceholderTitleTH", "detailsTH", "detailsTitleENG", "detailsTitleTH", "emailTitleENG", "emailTitlePlaceholderENG", "emailTitlePlaceholderTH", "emailTitleTH", "nameTitleENG", "nameTitlePlaceholderENG", "nameTitlePlaceholderTH", "nameTitleTH", "phoneENG", "phoneTH", "phoneTitlePlaceholder", "proposeTitleENG", "proposeTitleTH", "remarkENG", "remarkTH", "titleENG", "titleTH", "updated_at", "wantProposePlaceholderTitleENG", "wantProposePlaceholderTitleTH", "wantProposeTitleENG", "wantProposeTitleTH" },
                values: new object[] { 1, 1, new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9863), "ฉันได้อ่านและยอมรับข้อกำหนดและเงื่อนไขที่ระบุไว้ใน <a href=\"\">นโยบายความเป็นส่วนตัว</a> และยินยอมให้รวบรวมประมวลผลและ / หรือเปิดเผยข้อมูลส่วนบุคคลที่ฉันให้ไว้เพื่อบรรลุวัตถุประสงค์ดังกล่าวข้างต้น", "โปรดกรอกรายละเอียดที่ต้องการเสนอ", "โปรดกรอกรายละเอียดที่ต้องการเสนอ", "ฉันได้อ่านและยอมรับข้อกำหนดและเงื่อนไขที่ระบุไว้ใน <a href=\"\">นโยบายความเป็นส่วนตัว</a> และยินยอมให้รวบรวมประมวลผลและ / หรือเปิดเผยข้อมูลส่วนบุคคลที่ฉันให้ไว้เพื่อบรรลุวัตถุประสงค์ดังกล่าวข้างต้น", "รายละเอียด", "รายละเอียด", "e-mail", "example@mail.com", "example@mail.com", "e-mail", "ชื่อ-นามสกุล*", "โปรดระบุทั้งชื่อและนามสกุลให้ชัดเจน", "โปรดระบุทั้งชื่อและนามสกุลให้ชัดเจน", "ชื่อ-นามสกุล*", "โทรศัพท์*", "โทรศัพท์*", "xxx-xxx-xxxx", "หัวข้อที่ต้องการเสนอ*", "หัวข้อที่ต้องการเสนอ*", "หมายเหตุ : * จำเป็นต้องกรอกข้อมูล", "หมายเหตุ : * จำเป็นต้องกรอกข้อมูล", "เชิญผู้ถือหุ้นเสนอวาระ กรรมการ และส่งคำถามล่วงหน้าสำหรับการประชุมสามัญผู้ถือหุ้นประจำปี โดยกรอกแบบฟอร์มด้านล่างให้ครบถ้วน", "เชิญผู้ถือหุ้นเสนอวาระ กรรมการ และส่งคำถามล่วงหน้าสำหรับการประชุมสามัญผู้ถือหุ้นประจำปี โดยกรอกแบบฟอร์มด้านล่างให้ครบถ้วน", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9864), "โปรดระบุหัวข้อที่ต้องการเสนอ", "โปรดระบุหัวข้อที่ต้องการเสนอ", "ชื่อหัวข้อที่ต้องการเสนอ", "ชื่อหัวข้อที่ต้องการเสนอ" });

            migrationBuilder.InsertData(
                table: "receive_agenda_mail_accounts",
                columns: new[] { "id", "account", "created_at", "updated_at" },
                values: new object[] { 1, "mizaogz03@gmail.com", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9802), new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9803) });

            migrationBuilder.InsertData(
                table: "type_of_agenda_Propose",
                columns: new[] { "id", "active_status", "created_at", "titleENG", "titleTH", "updated_at" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9830), "เสนอวาระการประชุม​", "เสนอวาระการประชุม​", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9831) },
                    { 2, 1, new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9833), "เสนอกรรมการเพื่อเข้าดำรงตำแหน่ง​", "เสนอกรรมการเพื่อเข้าดำรงตำแหน่ง​", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9834) },
                    { 3, 1, new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9835), "ฝากคำถาม / ข้อเสนอแนะ / อื่นๆ​", "ฝากคำถาม / ข้อเสนอแนะ / อื่นๆ​", new DateTime(2023, 9, 7, 3, 17, 31, 290, DateTimeKind.Utc).AddTicks(9835) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "06ff08ef-7151-478c-8a5d-e9411c014bea", "a5d47453-01f2-487b-8c15-73a90061f53f" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Spects_ProductId",
                table: "Product_Spects",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRefs_ProjectRef_CategoryId",
                table: "ProjectRefs",
                column: "ProjectRef_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Smart_Solution_Links_Smart_SolutionId",
                table: "Smart_Solution_Links",
                column: "Smart_SolutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyJobImgContents");

            migrationBuilder.DropTable(
                name: "ApplyJobs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Author_secretary_File");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "AwardsDetail");

            migrationBuilder.DropTable(
                name: "Board_of_Directors");

            migrationBuilder.DropTable(
                name: "Company_Overview");

            migrationBuilder.DropTable(
                name: "Companyprofile");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "cookies_policy");

            migrationBuilder.DropTable(
                name: "CorporateGovernance");

            migrationBuilder.DropTable(
                name: "CorporateGovernance_Cate");

            migrationBuilder.DropTable(
                name: "CorporateGovernance_File");

            migrationBuilder.DropTable(
                name: "DownloadHeads");

            migrationBuilder.DropTable(
                name: "Downloads");

            migrationBuilder.DropTable(
                name: "DownloadTypes");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "HistoryDataDetail");

            migrationBuilder.DropTable(
                name: "HistoryDetail");

            migrationBuilder.DropTable(
                name: "Import_Info_ShareHolder");

            migrationBuilder.DropTable(
                name: "ImportInfo_ShareHolderData");

            migrationBuilder.DropTable(
                name: "IR_Analyst_Chapter");

            migrationBuilder.DropTable(
                name: "IR_Analysts");

            migrationBuilder.DropTable(
                name: "IR_Banner");

            migrationBuilder.DropTable(
                name: "IR_Button_Below_Banner");

            migrationBuilder.DropTable(
                name: "IR_Cancel_Email");

            migrationBuilder.DropTable(
                name: "IR_Complaints");

            migrationBuilder.DropTable(
                name: "IR_Contact");

            migrationBuilder.DropTable(
                name: "IR_Email_Alerts");

            migrationBuilder.DropTable(
                name: "IR_faq");

            migrationBuilder.DropTable(
                name: "IR_faq_Detail");

            migrationBuilder.DropTable(
                name: "IR_Hightlight");

            migrationBuilder.DropTable(
                name: "IR_HightlightDetail");

            migrationBuilder.DropTable(
                name: "IR_InvestorCalendar");

            migrationBuilder.DropTable(
                name: "IR_InvestorCalendarDetail");

            migrationBuilder.DropTable(
                name: "IR_Investor_Relations");

            migrationBuilder.DropTable(
                name: "IR_Investor_RelationsDetail");

            migrationBuilder.DropTable(
                name: "IR_Latest_NewDetail");

            migrationBuilder.DropTable(
                name: "IR_Latest_News");

            migrationBuilder.DropTable(
                name: "IR_LIGHTING_EQUIPMENT");

            migrationBuilder.DropTable(
                name: "IR_MassMedia");

            migrationBuilder.DropTable(
                name: "IR_MassMediaDetail");

            migrationBuilder.DropTable(
                name: "IR_NewDetail");

            migrationBuilder.DropTable(
                name: "IR_Print_Media");

            migrationBuilder.DropTable(
                name: "IR_Print_MediaDetail");

            migrationBuilder.DropTable(
                name: "IR_Report");

            migrationBuilder.DropTable(
                name: "IR_Request_Inquiry");

            migrationBuilder.DropTable(
                name: "IR_Stock_Chart");

            migrationBuilder.DropTable(
                name: "IR_Stock_ChartDetails");

            migrationBuilder.DropTable(
                name: "IR_Stock_LinkDetail");

            migrationBuilder.DropTable(
                name: "IR_Stock_Market");

            migrationBuilder.DropTable(
                name: "IR_Stock_Quote");

            migrationBuilder.DropTable(
                name: "IR_Stock_QuoteDetail");

            migrationBuilder.DropTable(
                name: "IR_Summary_Financial_Highlight");

            migrationBuilder.DropTable(
                name: "IR_Summary_Financial_HighlightsDetail");

            migrationBuilder.DropTable(
                name: "MainContacts");

            migrationBuilder.DropTable(
                name: "M_chairman");

            migrationBuilder.DropTable(
                name: "M_message_chairman");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "O_Anti_fraud");

            migrationBuilder.DropTable(
                name: "O_Anti_fraud_File");

            migrationBuilder.DropTable(
                name: "O_Author_audit_committee");

            migrationBuilder.DropTable(
                name: "O_Author_audit_committee_File");

            migrationBuilder.DropTable(
                name: "O_Author_board_director");

            migrationBuilder.DropTable(
                name: "O_Author_board_director_File");

            migrationBuilder.DropTable(
                name: "O_Author_cg");

            migrationBuilder.DropTable(
                name: "O_Author_cg_File");

            migrationBuilder.DropTable(
                name: "O_Author_chairman");

            migrationBuilder.DropTable(
                name: "O_Author_chairman_executive");

            migrationBuilder.DropTable(
                name: "O_Author_chairman_executive_File");

            migrationBuilder.DropTable(
                name: "O_Author_chairman_File");

            migrationBuilder.DropTable(
                name: "O_Author_executive_board");

            migrationBuilder.DropTable(
                name: "O_Author_executive_board_File");

            migrationBuilder.DropTable(
                name: "O_Author_secretary");

            migrationBuilder.DropTable(
                name: "O_Author_secretary_File");

            migrationBuilder.DropTable(
                name: "O_business_ethics");

            migrationBuilder.DropTable(
                name: "O_business_ethics_details");

            migrationBuilder.DropTable(
                name: "O_business_ethics_File");

            migrationBuilder.DropTable(
                name: "O_Channel_clue");

            migrationBuilder.DropTable(
                name: "O_Channel_clue_File");

            migrationBuilder.DropTable(
                name: "O_CRS_policy");

            migrationBuilder.DropTable(
                name: "O_CRS_policy_File");

            migrationBuilder.DropTable(
                name: "O_Gift_entertainment");

            migrationBuilder.DropTable(
                name: "O_Gift_entertainment_File");

            migrationBuilder.DropTable(
                name: "OrganizationalStructure");

            migrationBuilder.DropTable(
                name: "Organization_Chart");

            migrationBuilder.DropTable(
                name: "Organization_ChartDetail");

            migrationBuilder.DropTable(
                name: "P_philosophy");

            migrationBuilder.DropTable(
                name: "privacy_Policys");

            migrationBuilder.DropTable(
                name: "privacy_PolicyTitles");

            migrationBuilder.DropTable(
                name: "Product_Categorys");

            migrationBuilder.DropTable(
                name: "Product_Models");

            migrationBuilder.DropTable(
                name: "Product_Spects");

            migrationBuilder.DropTable(
                name: "ProjectRef_Products");

            migrationBuilder.DropTable(
                name: "ProjectRefs");

            migrationBuilder.DropTable(
                name: "receive_agenda_mail_accounts");

            migrationBuilder.DropTable(
                name: "receive_mail_propose_agendas");

            migrationBuilder.DropTable(
                name: "RF_Assembly_Services");

            migrationBuilder.DropTable(
                name: "RF_Assembly_Services_Images");

            migrationBuilder.DropTable(
                name: "RF_Innovation_Center_Images");

            migrationBuilder.DropTable(
                name: "RF_Innovation_Centers");

            migrationBuilder.DropTable(
                name: "RF_Manufacturing");

            migrationBuilder.DropTable(
                name: "RF_Manufacturing_Images");

            migrationBuilder.DropTable(
                name: "RF_Oversea_Offices");

            migrationBuilder.DropTable(
                name: "RF_Oversea_Offices_Images");

            migrationBuilder.DropTable(
                name: "RF_Philosophy_Vision_Mission");

            migrationBuilder.DropTable(
                name: "RF_Philosophy_Vision_Mission_Details");

            migrationBuilder.DropTable(
                name: "RF_Solid_States");

            migrationBuilder.DropTable(
                name: "RF_Solid_States_Images");

            migrationBuilder.DropTable(
                name: "RF_Solution_Centers");

            migrationBuilder.DropTable(
                name: "RF_Solution_Centers_Images");

            migrationBuilder.DropTable(
                name: "RF_Warehouse_Logistics");

            migrationBuilder.DropTable(
                name: "RF_Warehouse_Logistics_Images");

            migrationBuilder.DropTable(
                name: "Setting_Index");

            migrationBuilder.DropTable(
                name: "SH_annual_Report");

            migrationBuilder.DropTable(
                name: "SH_annual_ReportData");

            migrationBuilder.DropTable(
                name: "ShareHolder");

            migrationBuilder.DropTable(
                name: "ShareHolder_DataDetails");

            migrationBuilder.DropTable(
                name: "SH_dividen");

            migrationBuilder.DropTable(
                name: "SH_dividen_Data");

            migrationBuilder.DropTable(
                name: "SH_generalMeeting");

            migrationBuilder.DropTable(
                name: "SH_generalMeeting_Data");

            migrationBuilder.DropTable(
                name: "SH_IR_cashFlow_statements");

            migrationBuilder.DropTable(
                name: "SH_IR_download_financial_statements");

            migrationBuilder.DropTable(
                name: "SH_IR_Finance_Statement");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_highlight");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_highlight_Data");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_highlight_DataDetails");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_highlight_Details");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_highlight_DetailsData");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_highlight_DetailsData_Items");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_position");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_position_DataDetails");

            migrationBuilder.DropTable(
                name: "SH_IR_Form");

            migrationBuilder.DropTable(
                name: "SH_IR_FormData");

            migrationBuilder.DropTable(
                name: "SH_IR_important_financial");

            migrationBuilder.DropTable(
                name: "SH_IR_MDA");

            migrationBuilder.DropTable(
                name: "SH_IR_MDA_Data");

            migrationBuilder.DropTable(
                name: "SH_IR_MDA_DataDetails");

            migrationBuilder.DropTable(
                name: "SH_IR_presentation_doc");

            migrationBuilder.DropTable(
                name: "SH_IR_presentation_doc_Data");

            migrationBuilder.DropTable(
                name: "SH_IR_presentation_webcast");

            migrationBuilder.DropTable(
                name: "SH_IR_presentation_webcast_Data");

            migrationBuilder.DropTable(
                name: "SH_IR_Profit_Lose");

            migrationBuilder.DropTable(
                name: "SH_IR_Profit_Lose_others");

            migrationBuilder.DropTable(
                name: "SH_IR_propose_agenda");

            migrationBuilder.DropTable(
                name: "SH_IR_propose_agenda_DataDetails");

            migrationBuilder.DropTable(
                name: "SH_IR_propose_agenda_mailTitles");

            migrationBuilder.DropTable(
                name: "SH_IR_propose_agenda_receive_mails");

            migrationBuilder.DropTable(
                name: "SH_IR_prospectus");

            migrationBuilder.DropTable(
                name: "SH_IR_Report_Meeting");

            migrationBuilder.DropTable(
                name: "SH_IR_Report_MeetingData");

            migrationBuilder.DropTable(
                name: "SH_IR_Report_Meeting_DataDetails");

            migrationBuilder.DropTable(
                name: "Slide_Image_Index");

            migrationBuilder.DropTable(
                name: "Smart_Solution_Links");

            migrationBuilder.DropTable(
                name: "Sustainability_Report");

            migrationBuilder.DropTable(
                name: "type_of_agenda_Propose");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category_Projects");

            migrationBuilder.DropTable(
                name: "Smart_Solutions");
        }
    }
}
