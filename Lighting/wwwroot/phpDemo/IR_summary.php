<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <?php require('inc_header.php'); $pageName="ir"; ?>
    <!-- FANCYBOX -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fancyapps/ui@4.0/dist/fancybox.css"/>
</head>
<body>
    <?php require('inc_topmenu.php'); ?>
    <?php require('IR_inc_topmenu.php'); ?>
    <?php require('inc_sidemenu.php'); ?>

    <!---------- IR 01 CORPORATE INFO :: SUMMARY ---------->
    <div class="content-padding foot-pad">
        <div class="container-fluid">
            <div class="wrap-pad">
                <div class="row">
                    <div class="col">
                        <div class="header-twoline">
                            <h5>ข้อมูลบริษัท</h5>
                            <h1>สรุปภาพรวมบริษัท</h1>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <ul class="img-gallery">
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary01.jpg"><img src="images/ir/summary01.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary02.jpg"><img src="images/ir/summary02.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary03.jpg"><img src="images/ir/summary03.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary04.jpg"><img src="images/ir/summary04.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary05.jpg"><img src="images/ir/summary05.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary06.jpg"><img src="images/ir/summary06.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary07.jpg"><img src="images/ir/summary07.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary08.jpg"><img src="images/ir/summary08.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary09.jpg"><img src="images/ir/summary09.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary10.jpg"><img src="images/ir/summary10.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary11.jpg"><img src="images/ir/summary11.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary12.jpg"><img src="images/ir/summary12.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary13.jpg"><img src="images/ir/summary13.jpg"></a>
                            </li>
                            <li>
                                <a class="img-width" data-fancybox="gallery" href="images/ir/summary14.jpg"><img src="images/ir/summary14.jpg"></a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
    <?php require('IR_inc_footer.php'); ?>

    <!-- FANCYBOX -->
    <script src="https://cdn.jsdelivr.net/npm/@fancyapps/ui@4.0/dist/fancybox.umd.js"></script>

    <script type="text/javascript">
        Fancybox.bind('[data-fancybox="gallery"]', {
        Toolbar: {
            display: [
            { id: "prev", position: "center" },
            { id: "counter", position: "center" },
            { id: "next", position: "center" },
            "zoom",
            "fullscreen",
            "download",
            "thumbs",
            "close",
            ],
        },
        });
    </script>

</body>
</html>