using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Lighting.Extension
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var pwd = "1234";
            var passwordHasher = new PasswordHasher<LightingUser>();

            List<Role> roles = new List<Role>()
            {
                new Role
                {
                    Name = "Admin",
                    NameThai = "Admin",
                    NormalizedName = "Admin",
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow
                }
            };

            builder.Entity<Role>().HasData(roles);

            var user = new LightingUser
            {
                UserName = "Admin@Lighting.com",
                Email = "Admin@Lighting.com",
                EmailConfirmed = false,
                Firstname = "Admin",
                Lastname = "Admin",
            };
            user.EmployeeCode = "Admin";
            user.EmployeeCodeInt = 1;
            user.NormalizedUserName = user.UserName.ToLower();
            user.NormalizedEmail = "";
            user.PasswordHash = passwordHasher.HashPassword(user, pwd);
            builder.Entity<LightingUser>().HasData(user);

            List<LightingUser> LightingUser = new List<LightingUser>() {
                user
            };

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = LightingUser[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            // add Download type 
            List<DownloadTypes> downloadTypes = new List<DownloadTypes>()
            {
                new DownloadTypes
                {
                    DownloadType_name_ENG = "L&E BIM OBJECTS",
                    DownloadType_name_TH = "L&E BIM OBJECTS",
                    id=1,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                },

                new DownloadTypes
                {
                    DownloadType_name_ENG = "CATALOGUE",
                    DownloadType_name_TH = "CATALOGUE",
                    id=2,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                },

                new DownloadTypes
                {
                    DownloadType_name_ENG = "COMPANY PROFILE",
                    DownloadType_name_TH = "COMPANY PROFILE",
                    id=3,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                },

                new DownloadTypes
                {
                    DownloadType_name_ENG = "IES FILE",
                    DownloadType_name_TH = "IES FILE",
                    id=4,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                },

                new DownloadTypes
                {
                    DownloadType_name_ENG = "LEAFLET",
                    DownloadType_name_TH = "LEAFLET",
                    id=5,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                }

            };
            builder.Entity<DownloadTypes>().HasData(downloadTypes);

            //mailcontact
            List<receive_agenda_mail_accounts> mailContact = new List<receive_agenda_mail_accounts>()
            {
                new receive_agenda_mail_accounts
                {
                    account = "mizaogz03@gmail.com",
                    id=1,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                }
            };
            builder.Entity<receive_agenda_mail_accounts>().HasData(mailContact);

            //type of angenda
            List<type_of_agenda_Propose> type_of_agenda_Propose = new List<type_of_agenda_Propose>()
            {
                new type_of_agenda_Propose
                {
                    titleTH = "เสนอวาระการประชุม​",
                    titleENG = "เสนอวาระการประชุม​",
                    active_status=1,
                    id=1,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                },

                 new type_of_agenda_Propose
                {
                    titleTH = "เสนอกรรมการเพื่อเข้าดำรงตำแหน่ง​",
                    titleENG = "เสนอกรรมการเพื่อเข้าดำรงตำแหน่ง​",
                    active_status=1,
                    id=2,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                },

                  new type_of_agenda_Propose
                {
                    titleTH = "ฝากคำถาม / ข้อเสนอแนะ / อื่นๆ​",
                    titleENG = "ฝากคำถาม / ข้อเสนอแนะ / อื่นๆ​",
                    active_status=1,
                    id=3,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                }

            };
            builder.Entity<type_of_agenda_Propose>().HasData(type_of_agenda_Propose);

            //mail title
            List<SH_IR_propose_agenda_mailTitles> mailTitle = new List<SH_IR_propose_agenda_mailTitles>()
            {
                new SH_IR_propose_agenda_mailTitles
                {
                    titleTH = "เชิญผู้ถือหุ้นเสนอวาระ กรรมการ และส่งคำถามล่วงหน้าสำหรับการประชุมสามัญผู้ถือหุ้นประจำปี โดยกรอกแบบฟอร์มด้านล่างให้ครบถ้วน",
                    titleENG = "เชิญผู้ถือหุ้นเสนอวาระ กรรมการ และส่งคำถามล่วงหน้าสำหรับการประชุมสามัญผู้ถือหุ้นประจำปี โดยกรอกแบบฟอร์มด้านล่างให้ครบถ้วน",
                    nameTitleTH = "ชื่อ-นามสกุล*",
                    nameTitleENG ="ชื่อ-นามสกุล*",
                    nameTitlePlaceholderTH = "โปรดระบุทั้งชื่อและนามสกุลให้ชัดเจน",
                    nameTitlePlaceholderENG = "โปรดระบุทั้งชื่อและนามสกุลให้ชัดเจน",
                    emailTitleTH = "e-mail",
                    emailTitleENG = "e-mail",
                    emailTitlePlaceholderTH = "example@mail.com",
                    emailTitlePlaceholderENG = "example@mail.com",
                    phoneTH = "โทรศัพท์*",
                    phoneENG = "โทรศัพท์*",
                    phoneTitlePlaceholder = "xxx-xxx-xxxx",
                    proposeTitleTH = "หัวข้อที่ต้องการเสนอ*",
                    proposeTitleENG = "หัวข้อที่ต้องการเสนอ*",
                    wantProposeTitleTH = "ชื่อหัวข้อที่ต้องการเสนอ",
                    wantProposeTitleENG = "ชื่อหัวข้อที่ต้องการเสนอ",
                    wantProposePlaceholderTitleTH = "โปรดระบุหัวข้อที่ต้องการเสนอ",
                    wantProposePlaceholderTitleENG = "โปรดระบุหัวข้อที่ต้องการเสนอ",
                    detailsTitleTH = "รายละเอียด",
                    detailsTitleENG = "รายละเอียด",
                    detailsPlaceholderTitleTH = "โปรดกรอกรายละเอียดที่ต้องการเสนอ",
                    detailsPlaceholderTitleENG = "โปรดกรอกรายละเอียดที่ต้องการเสนอ",
                    detailsTH = "ฉันได้อ่านและยอมรับข้อกำหนดและเงื่อนไขที่ระบุไว้ใน <a href=\"\">นโยบายความเป็นส่วนตัว</a> และยินยอมให้รวบรวมประมวลผลและ / หรือเปิดเผยข้อมูลส่วนบุคคลที่ฉันให้ไว้เพื่อบรรลุวัตถุประสงค์ดังกล่าวข้างต้น",
                    detailsENG = "ฉันได้อ่านและยอมรับข้อกำหนดและเงื่อนไขที่ระบุไว้ใน <a href=\"\">นโยบายความเป็นส่วนตัว</a> และยินยอมให้รวบรวมประมวลผลและ / หรือเปิดเผยข้อมูลส่วนบุคคลที่ฉันให้ไว้เพื่อบรรลุวัตถุประสงค์ดังกล่าวข้างต้น",
                    remarkTH = "หมายเหตุ : * จำเป็นต้องกรอกข้อมูล",
                    remarkENG = "หมายเหตุ : * จำเป็นต้องกรอกข้อมูล",
                    id = 1,
                    active_status=1,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                }
    };
            builder.Entity<SH_IR_propose_agenda_mailTitles>().HasData(mailTitle);


        }
    }
}
