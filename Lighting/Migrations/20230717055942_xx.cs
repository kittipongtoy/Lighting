using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionName_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPlace_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPlace_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respondsibility_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Respondsibility_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceName_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceName_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMaps_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTube_Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
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
                name: "Downloads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DownloadType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File_Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Downloads", x => x.Id);
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
                    CreateDate_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate_EN = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    title_file_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_file_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    amount1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_highlight_Data", x => x.id);
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
                    amount1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    financial_hilight_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_IR_financial_highlight_DetailsData", x => x.id);
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
                name: "Sustainability_Report",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sustainability_Report", x => x.id);
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "568a0940-446d-4807-8d13-e51a08862bdb", "3e9183d6-0833-4973-a540-1bb1622f2929", "Admin", "Admin", "Admin", new DateTime(2023, 7, 17, 5, 59, 42, 190, DateTimeKind.Utc).AddTicks(5597), new DateTime(2023, 7, 17, 5, 59, 42, 190, DateTimeKind.Utc).AddTicks(5610) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "e1f4f096-8d65-4675-870c-136df3f72c27", 0, null, null, "8f96ee2f-46e4-4f83-8eb7-3ead4531b3a0", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEFw40PZSWLeyGO/DaeH0HKydv/NG3n05NOxF1TVdUbfxE/AxN6V4F/zYDeDUpdqdtA==", null, false, null, null, "5c49b4e2-ed58-49f2-94ad-1055e3c86bed", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "568a0940-446d-4807-8d13-e51a08862bdb", "e1f4f096-8d65-4675-870c-136df3f72c27" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Board_of_Directors");

            migrationBuilder.DropTable(
                name: "Company_Overview");

            migrationBuilder.DropTable(
                name: "Companyprofile");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CorporateGovernance");

            migrationBuilder.DropTable(
                name: "CorporateGovernance_Cate");

            migrationBuilder.DropTable(
                name: "CorporateGovernance_File");

            migrationBuilder.DropTable(
                name: "Downloads");

            migrationBuilder.DropTable(
                name: "Import_Info_ShareHolder");

            migrationBuilder.DropTable(
                name: "ImportInfo_ShareHolderData");

            migrationBuilder.DropTable(
                name: "IR_Analyst_Chapter");

            migrationBuilder.DropTable(
                name: "IR_Analysts");

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
                name: "IR_InvestorCalendar");

            migrationBuilder.DropTable(
                name: "IR_InvestorCalendarDetail");

            migrationBuilder.DropTable(
                name: "IR_Latest_NewDetail");

            migrationBuilder.DropTable(
                name: "IR_Latest_News");

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
                name: "IR_Request_Inquiry");

            migrationBuilder.DropTable(
                name: "IR_Stock_Market");

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
                name: "P_philosophy");

            migrationBuilder.DropTable(
                name: "SH_annual_Report");

            migrationBuilder.DropTable(
                name: "SH_annual_ReportData");

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
                name: "SH_IR_financial_highlight");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_highlight_Data");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_highlight_Details");

            migrationBuilder.DropTable(
                name: "SH_IR_financial_highlight_DetailsData");

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
                name: "SH_IR_prospectus");

            migrationBuilder.DropTable(
                name: "SH_IR_Report_Meeting");

            migrationBuilder.DropTable(
                name: "SH_IR_Report_Meeting_DataDetails");

            migrationBuilder.DropTable(
                name: "SH_IR_Report_MeetingData");

            migrationBuilder.DropTable(
                name: "ShareHolder");

            migrationBuilder.DropTable(
                name: "ShareHolder_DataDetails");

            migrationBuilder.DropTable(
                name: "Sustainability_Report");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
