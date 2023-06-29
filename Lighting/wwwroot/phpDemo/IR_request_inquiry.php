<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <?php require('inc_header.php'); $pageName="ir"; ?>
</head>
<body>
    <?php require('inc_topmenu.php'); ?>
    <?php require('IR_inc_topmenu.php'); ?>
    <?php require('inc_sidemenu.php'); ?>

    <!---------- IR 09 CORPORATE INFO :: REQUEST INQUIRY ---------->
    <div class="content-padding foot-pad minH">
        <div class="container-fluid">
            <div class="wrap-pad">
                <div class="row">
                    <div class="col">
                        <div class="header-twoline">
                            <h5>สอบถามข้อมูลนักลงทุน</h5>
                            <h1>ฝากคำถาม</h1>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-lg-10 col-md-10 col-12">
                        <div class="formBG input-form">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-12">
                                    <p>ชื่อ-นามสกุล</p>
                                    <input type="text" class="form-control">
                                </div>
                                <div class="col-lg-6 col-md-6 col-12">
                                    <p>โทรศัพท์</p>
                                    <input type="text" class="form-control">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <p>อีเมล</p>
                                    <input type="email" class="form-control">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <p>ข้อความ</p>
                                    <textarea class="form-control"></textarea>
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
                                    <div class="note mb-5">หมายเหตุ : ถ้าท่านต้องการฝากคำถามถึงบริษัทฯ กรุณากรอกข้อมูลเพื่อฝากคำถาม เราจะตอบคำถามของท่านโดยเร็วที่สุด</div>
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