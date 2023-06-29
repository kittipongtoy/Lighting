<div class="thetop"></div>
<!--------------- HEADER --------------->
<header>
	<div class="container-fluid">
		<div class="wrap-pad more-w">
			<div class="row">
				<div class="col-lg-2 col-md-2 col-4">
					<a class="mainlogo" href=""><img src="images/L&E-logo.svg"></a>
				</div>
				<div class="col-lg-10 col-md-10 col-8">
					<div class="row">
						<div class="col">
							<!-- MAIN - MENU :: IPAD & MOBILE -->
							<div class="d-block d-md-block d-lg-none">
								<!-- HAMBURGER - MENU -->
								<button type="button" class="btn nav-menu" data-toggle="modal" data-target="#menu-mobile">
									<i class="fas fa-bars"></i>
								</button>

								<!-- Modal -->
								<div class="modal left fade" id="menu-mobile" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
									<div class="modal-dialog" role="document">
										<div class="modal-header">
											<a class="mainlogo" href="index.php"><img src="images/L&E-logo.svg"></a>
											<button type="button" class="close btn " data-dismiss="modal" aria-label="Close">
												<i class="fas fa-times"></i>
											</button>
										</div>

										<div class="modal-content pt-0">
											<!-- MAINMENU -->
											<div class="modal-body">
												<div id="menu">
													<div class="menu-box">
														<div class="menu-wrapper-inner">
															<div class="menu-wrapper">
																<div class="menu-slider">
																	<div class="menu">
																		<ul>
																			<li data-page="home">
																				<div class="menu-item"><a href="">หน้าหลัก</a></div>
																			</li>
																			<li data-page="about">
																				<div class="menu-item"><a href="">ข้อมูลองค์กร</a></div>
																			</li>
																			<li data-page="solution">
																				<div class="menu-item"><a href="">สมาร์ท โซลูชั่น</a></div>
																			</li>
																			<li data-page="product">
																				<div class="menu-item"><a href="">สินค้า</a></div>
																			</li>
																			<li data-page="portfolio">
																				<div class="menu-item"><a href="">ผลงาน</a></div>
																			</li>
																			<li data-page="download">
																				<div class="menu-item"><a href="">ดาวน์โหลด</a></div>
																			</li>
																			<li data-page="news">
																				<div class="menu-item"><a href="">ข่าวสาร</a></div>
																			</li>
																			<li data-page="ir">
																				<div class="menu-item"><a href="IR_index.php">นักลงทุนสัมพันธ์</a></div>
																			</li>
																			<li data-page="job">
																				<div class="menu-item"><a href="">สมัครงาน</a></div>
																			</li>
																			<li data-page="contact">
																				<div class="menu-item"><a href="">ติดต่อเรา</a></div>
																			</li>
																			
																			<li>
																				<div class="menu-item lang-menu">
																					<a href="#" class="menu-anchor pt-3" data-menu="1">
																						<img class="flag" src="images/icon/flag-th.svg">TH
																						<img class="detail" src="images/icon/icon-chevronR.svg">
																					</a>
																				</div>
																			</li>
																		</ul>
																	</div>
																	
																	<!-- LANG -->
																	<div class="submenu menu" data-menu="1">
																		<div class="submenu-back">
																			<div class="menu-item">
																				<a href="#" class="menu-back">ย้อนกลับ
																					<img class="detail back" src="images/icon/icon-chevronL.svg">
																				</a>
																			</div>
																		</div>
																		<ul class="lang-menu">
																			<li>
																				<div class="menu-item">
																					<a href=""><img class="flag" src="images/icon/flag-th.svg">TH</a>
																				</div>
																			</li>
																			<li>
																				<div class="menu-item">
																					<a href=""><img class="flag" src="images/icon/flag-en.svg">EN</a>
																				</div>
																			</li>
																		</ul>
																	</div>
																	
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
								
							</div>

							<!-- LANG :: PC & IPAD PRO -->
							<div class="d-none d-lg-block">
								<ul class="lang">
									<li class="active">
										<button>TH</button>
									</li>
									<li>
										<button>EN</button>
									</li>
								</ul>
							</div>

							<ul class="top-menu">
								<!-- SEARCH -->
								<li>
									<div class="search-container">
										<div class="search-icon-btn">
											<i class="fa fa-search"></i>
										</div>
										<div class="search-input">
											<input type="search" class="search-bar" placeholder="search">
										</div>
									</div>
								</li>
								<!-- CART -->
								<li>
									<a href="https://www.lightingshoponline.com/" target="_blank"><i class="fas fa-shopping-cart"></i></a>
								</li>
							</ul>

						</div>
					</div>

					<!-- MAIN - MENU :: PC & IPAD PRO -->
					<div class="row d-none d-lg-block">
						<div class="col">
							<ul class="mainmenu">
								<li data-page="about"><a href="">ข้อมูลองค์กร</a></li>
								<li data-page="solution"><a href="">สมาร์ท โซลูชั่น</a></li>
								<li data-page="product"><a href="">สินค้า</a></li>
								<li data-page="portfolio"><a href="">ผลงาน</a></li>
								<li data-page="download"><a href="">ดาวน์โหลด</a></li>
								<li data-page="news"><a href="">ข่าวสาร</a></li>
								<li data-page="ir"><a href="IR_index.php">นักลงทุนสัมพันธ์</a></li>
								<li data-page="job"><a href="">สมัครงาน</a></li>
								<li data-page="contact"><a href="">ติดต่อเรา</a></li>
							</ul>
						</div>
					</div>

				</div>
			</div>
		</div>
	</div>
</header>


<script type="text/javascript">
    var menu_width;
    jQuery(document).ready(
        function() {
            initMenu();
        });
    function initMenu() {
        menu_width = $("#menu .menu").width();
        $("#menu .menu-back").click(function() {
            var _pos = $("#menu .menu-slider").position().left + menu_width;
            var _obj = $("#menu .submenu");
            $("#menu .menu-slider").stop().animate({
                left: _pos
            }, 300, function() {
                _obj.hide();
            });
            return false;
        });
        
        $("#menu .menu-anchor").click(function() {
            var _d = $(this).data('menu');
            $("#menu .submenu").each(function() {
                var _d_check = $(this).data('menu');
                if (_d_check == _d) {
                    $(this).show();
                    var _pos = $("#menu .menu-slider").position().left - menu_width;
                    
                    $("#menu .menu-slider").stop(true, true).animate({
                        left: _pos
                    }, 300);
                    return false;
                }
            });
            return false;
        });
    }
    
</script>

<script type="text/javascript">
    // ACTIVE MENU //
    $(function () {
		var getPage = '<?php echo($pageName); ?>';
		$(".mainmenu li").each(function () {
			var getMenu = $(this).attr("data-page");
			if (getPage == getMenu) {
				$(this).addClass('active');
			}
		});
	});
</script>