<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <?php require('inc_header.php'); $pageName="ir"; ?>
</head>
<body>
    <?php require('inc_topmenu.php'); ?>
    <?php require('IR_inc_topmenu.php'); ?>
    <?php require('inc_sidemenu.php'); ?>

    <!---------- IR 08 NEWS ROOM :: PUBLIC RELATION ---------->
    <div class="content-padding foot-pad">
        <div class="container-fluid">
            <div class="wrap-pad">
                <div class="row">
                    <div class="col">
                        <div class="header-twoline">
                            <h5>ห้องข่าว</h5>
                            <h1>ข่าวแจ้งสื่อมวลชน</h1>
                        </div>
                    </div>
                </div>
                <div class="three-colPad">
                    <div class="row">
                        <?php for($i=0;$i<2;$i++){ ?>
                        <div class="col-lg-4 col-md-4 col-6">
                            <a class="news-publicBox" href="IR_public_relation_detail.php">
                                <div class="row">
                                    <div class="col">
                                        <div class="img-width"><img src="images/ir/ir-public01.jpg"></div>
                                    </div>
                                </div>
                                <div class="news-public-info">
                                    <div class="row">
                                        <div class="col">
                                            <div class="news-topic">
                                                <p>หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน</p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="news-date">17 FEB 2023</div>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-lg-4 col-md-4 col-6">
                            <a class="news-publicBox" href="IR_public_relation_detail.php">
                                <div class="row">
                                    <div class="col">
                                        <div class="img-width"><img src="images/ir/ir-public02.jpg"></div>
                                    </div>
                                </div>
                                <div class="news-public-info">
                                    <div class="row">
                                        <div class="col">
                                            <div class="news-topic">
                                                <p>หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน</p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="news-date">09 FEB 2023</div>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-lg-4 col-md-4 col-6">
                            <a class="news-publicBox" href="IR_public_relation_detail.php">
                                <div class="row">
                                    <div class="col">
                                        <div class="img-width"><img src="images/ir/ir-public03.jpg"></div>
                                    </div>
                                </div>
                                <div class="news-public-info">
                                    <div class="row">
                                        <div class="col">
                                            <div class="news-topic">
                                                <p>หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน หัวข้อข่าวแจ้งสื่อมวลชน</p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="news-date">02 FEB 2023</div>
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