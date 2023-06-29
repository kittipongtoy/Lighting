<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <?php require('inc_header.php'); $pageName="ir"; ?>
</head>
<body>
    <?php require('inc_topmenu.php'); ?>
    <?php require('IR_inc_topmenu.php'); ?>
    <?php require('inc_sidemenu.php'); ?>

    <!---------- IR 08 NEWS ROOM :: CALENDAR ---------->
    <div class="content-padding foot-pad minH">
        <div class="container-fluid">
            <div class="wrap-pad">
                <div class="row">
                    <div class="col">
                        <div class="header-twoline">
                            <h5>ห้องข่าว</h5>
                            <h1>ปฎิทินนักลงทุน</h1>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-lg-3 col-md-4 col-8">
                        <div class="input-form">
                            <select class="form-select more-BD">
                                <option selected>เลือกปี</option>
                                <option value="1">2566</option>
                                <option value="2">2565</option>
                                <option value="3">2564</option>
                                <option value="4">2563</option>
                                <option value="5">2562</option>
                                <option value="6">2561</option>
                                <option value="7">2560</option>
                                <option value="8">2559</option>
                                <option value="9">2558</option>
                                <option value="10">2557</option>
                                <option value="11">2556</option>
                                <option value="12">2555</option>
                                <option value="13">2554</option>
                                <option value="14">2553</option>
                                <option value="15">2552</option>
                                <option value="16">2551</option>
                                <option value="17">2550</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="blueTB calendarTB">
                            <table>
                                <thead>
                                    <tr>
                                        <th>วันและเวลา</th>
                                        <th>กิจกรรม</th>
                                        <th>สถานที่</th>
                                        <th>เอกสารประกอบ</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <ul class="date-time">
                                                <li>15 พฤศจิกายน 2565</li>
                                                <li>15:15 - 16:00</li>
                                            </ul>
                                        </td>
                                        <td>บริษัทจดทะเบียนพบผู้ลงทุนสำหรับผลประกอบการไตรมาส 3/2565</td>
                                        <td>รับชมผ่านช่องทางออนไลน์</td>
                                        <td>
                                            <a class="download-button" href="images/testPDF.pdf" target="_blank"><span>ดาวน์โหลด</span></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ul class="date-time">
                                                <li>20 เมษายน 2565</li>
                                                <li>10:00</li>
                                            </ul>
                                        </td>
                                        <td>การประชุมสามัญผู้ถือหุ้นประจำปี 2565</td>
                                        <td>การประชุมผ่านสื่ออิเล็กทรอนิกส์ (e-AGM)</td>
                                        <td>-</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ul class="date-time">
                                                <li>14 มีนาคม 2565</li>
                                                <li>15:15 - 16:00</li>
                                            </ul>
                                        </td>
                                        <td>บริษัทจดทะเบียนพบผู้ลงทุนสำหรับผลประกอบการไตรมาส 4/2564</td>
                                        <td>รับชมผ่านช่องทางออนไลน์</td>
                                        <td>
                                            <a class="download-button" href="images/testPDF.pdf" target="_blank"><span>ดาวน์โหลด</span></a>
                                        </td>
                                    </tr>
                                </tobody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <div class="content-center">
                            <nav aria-label="Page navigation example">
                                <ul class="pagination">
                                    <li class="page-item">
                                        <a class="page-link" href="#" aria-label="Previous">
                                            <i class="fas fa-arrow-left"></i>
                                        </a>
                                    </li>
                                    <li class="page-item active"><a class="page-link" href="#">1</a></li>
                                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item"><a class="page-link" href="#">4</a></li>
                                    <li class="page-item">
                                        <a class="page-link" href="#" aria-label="Next">
                                            <i class="fas fa-arrow-right"></i>
                                        </a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    
    <?php require('IR_inc_footer.php'); ?>


</body>
</html>