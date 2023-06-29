<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <?php require('inc_header.php'); $pageName="ir"; ?>
</head>
<body>
    <?php require('inc_topmenu.php'); ?>
    <?php require('IR_inc_topmenu.php'); ?>
    <?php require('inc_sidemenu.php'); ?>

    <!---------- IR 04 SHAREHOLDER INFORMATION :: ANNUAL REPORT ---------->
    <div class="content-padding foot-pad">
        <div class="container-fluid">
            <div class="wrap-pad">
                <div class="row">
                    <div class="col">
                        <div class="header-twoline">
                            <h5>ข้อมูลสำหรับผู้ถือหุ้น</h5>
                            <h1>รายงานประจำปี / ONE REPORT</h1>
                        </div>
                    </div>
                </div>
                <div class="three-colPad">
                    <div class="row justify-content-center">
                        <?php for($i=0;$i<4;$i++){ ?>
                        <div class="col-lg-4 col-md-4 col-6">
                            <a class="coverBox" href="images/testPDF.pdf" target="_blank">
                                <div class="row">
                                    <div class="col">
                                        <div class="book-cover"><img src="images/ir/annual01.gif"></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="cover-topic">
                                            <p>One Report 2564</p>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-lg-4 col-md-4 col-6">
                            <a class="coverBox" href="images/testPDF.pdf" target="_blank">
                                <div class="row">
                                    <div class="col">
                                        <div class="book-cover"><img src="images/ir/annual02.gif"></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="cover-topic">
                                            <p>รายงานประจำปี 2563</p>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-lg-4 col-md-4 col-6">
                            <a class="coverBox" href="images/testPDF.pdf" target="_blank">
                                <div class="row">
                                    <div class="col">
                                        <div class="book-cover"><img src="images/ir/annual03.gif"></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="cover-topic">
                                            <p>รายงานประจำปี 2562</p>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <?php } ?>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <div class="content-center">
                            <nav aria-label="Page navigation example">
                                <ul class="pagination mt-4">
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