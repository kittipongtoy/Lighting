<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <?php require('inc_header.php'); $pageName="ir"; ?>
</head>
<body>
    <?php require('inc_topmenu.php'); ?>
    <?php require('IR_inc_topmenu.php'); ?>
    <?php require('inc_sidemenu.php'); ?>

    <!---------- IR 04 SHAREHOLDER INFORMATION :: PROPOSE AGENDA ---------->
    <div class="content-padding foot-pad">
        <div class="container-fluid">
            <div class="wrap-pad">
                <div class="row">
                    <div class="col">
                        <div class="header-twoline">
                            <h5>ข้อมูลสำหรับผู้ถือหุ้น</h5>
                            <h1>เสนอวาระ/กรรมการ/คำถามล่วงหน้า</h1>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-xl-10 col-lg-11 col-md-11 col-12">
                        <div class="blueTB proposeTB more-mb">
                            <table>
                                <tbody>
                                    <tr>
                                        <td>การให้สิทธิแก่ผู้ถือหุ้นในการเสนอวาระการประชุมผู้ถือหุ้นประจำปี 2566 ส่งคำถาม และการเสนอชื่อบุคคลเพื่อพิจารณาเข้าดำรงตำแหน่งกรรมการล่วงหน้า</td>
                                        <td>
                                            <a class="download-button" href="images/testPDF.pdf" target="_blank"><span>ดาวน์โหลด</span></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>วิธีปฏิบัติ</td>
                                        <td>
                                            <a class="download-button" href="images/testPDF.pdf" target="_blank"><span>ดาวน์โหลด</span></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>แบบเสนอวาระการประชุมสามัญผู้ถือหุ้นประจำปี</td>
                                        <td>
                                            <a class="download-button" href="images/testPDF.pdf" target="_blank"><span>ดาวน์โหลด</span></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>แบบเสนอชื่อบุคคลเพื่อเข้ารับการคัดเลือกดำรงตำแหน่งเป็น กรรมการบริษัท</td>
                                        <td>
                                            <a class="download-button" href="images/testPDF.pdf" target="_blank"><span>ดาวน์โหลด</span></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>แบบส่งคำถามล่วงหน้าการประชุมผู้ถือหุ้นประจำปี</td>
                                        <td>
                                            <a class="download-button" href="images/testPDF.pdf" target="_blank"><span>ดาวน์โหลด</span></a>
                                        </td>
                                    </tr>
                                </tbody>

                            </table>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-xl-10 col-lg-11 col-md-11 col-12">
                        <div class="formBG input-form">
                            <div class="row">
                                <div class="col">
                                    <h5>เชิญผู้ถือหุ้นเสนอวาระ กรรมการ และส่งคำถามล่วงหน้าสำหรับการประชุมสามัญผู้ถือหุ้นประจำปี <br>โดยกรอกแบบฟอร์มด้านล่างให้ครบถ้วน</h5>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <p>ชื่อ-นามสกุล<span>*</span></p>
                                    <input type="text" class="form-control" placeholder="โปรดระบุทั้งชื่อและนามสกุลให้ชัดเจน">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-12">
                                    <p>โทรศัพท์<span>*</span></p>
                                    <input type="text" class="form-control" placeholder="xxx-xxx-xxxx">
                                </div>
                                <div class="col-lg-6 col-md-6 col-12">
                                    <p>หัวข้อที่ต้องการเสนอ<span>*</span></p>
                                    <select class="form-select">
                                        <option selected>เลือกหัวข้อ</option>
                                        <option value="1">เสนอวาระการประชุม​</option>
                                        <option value="2">เสนอกรรมการเพื่อเข้าดำรงตำแหน่ง</option>
                                        <option value="3">ฝากคำถาม / ข้อเสนอแนะ / อื่นๆ​</option>
                                    </select>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <p>ชื่อหัวข้อที่ต้องการเสนอ</p>
                                    <input type="text" class="form-control" placeholder="โปรดระบุหัวข้อที่ต้องการเสนอ">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <p>รายละเอียด</p>
                                    <textarea class="form-control" placeholder="โปรดกรอกรายละเอียดที่ต้องการเสนอ"></textarea>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value="" id="accept-term">
                                        <label class="form-check-label" for="accept-term">
                                        ฉันได้อ่านและยอมรับข้อกำหนดและเงื่อนไขที่ระบุไว้ใน <a href="">นโยบายความเป็นส่วนตัว</a> และยินยอมให้รวบรวมประมวลผลและ / หรือเปิดเผยข้อมูลส่วนบุคคลที่ฉันให้ไว้เพื่อบรรลุวัตถุประสงค์ดังกล่าวข้างต้น
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="note mb-5">หมายเหตุ : * จำเป็นต้องกรอกข้อมูล</div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="content-center">
                                        <a class="buttonB m-size" href="">ส่งข้อมูล<i class="fas fa-paper-plane"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
    <?php require('IR_inc_footer.php'); ?>


</body>
</html>