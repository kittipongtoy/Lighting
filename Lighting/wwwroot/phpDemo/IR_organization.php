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

    <!---------- IR 01 CORPORATE INFO :: ORGANIZATION ---------->
    <div class="content-padding foot-pad">
        <div class="container-fluid">
            <div class="wrap-pad">
                <div class="row">
                    <div class="col">
                        <div class="header-twoline">
                            <h5>ข้อมูลบริษัท</h5>
                            <h1>โครงสร้างองค์กร</h1>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-lg-10 col-md-11 col-12">
                        <a class="img-width hover-img" data-fancybox data-caption="โครงสร้างองค์กร" href="images/ir/oranization_2018.jpg">
                            <img src="images/ir/oranization_2018.jpg">
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
    <?php require('IR_inc_footer.php'); ?>

    <!-- FANCYBOX -->
    <script src="https://cdn.jsdelivr.net/npm/@fancyapps/ui@4.0/dist/fancybox.umd.js"></script>

    <script type="text/javascript">
        Fancybox.bind('[data-fancybox]', {
        Toolbar: {
            display: [
            { id: "prev", position: "center" },
            { id: "counter", position: "center" },
            { id: "next", position: "center" },
            "zoom",
            "fullscreen",
            "download",
            "close",
            ],
        },
        });
    </script>

</body>
</html>