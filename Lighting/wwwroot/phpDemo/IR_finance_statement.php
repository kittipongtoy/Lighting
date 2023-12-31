<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <?php require('inc_header.php'); $pageName="ir"; ?>
</head>
<body>
    <?php require('inc_topmenu.php'); ?>
    <?php require('IR_inc_topmenu.php'); ?>
    <?php require('inc_sidemenu.php'); ?>

    <!---------- IR 03 FINANCIAL INFORMATION :: FINANCE STATEMENT ---------->
    <div class="content-padding foot-pad minH">
        <div class="container-fluid">
            <div class="wrap-pad">
                <div class="row">
                    <div class="col">
                        <div class="header-twoline">
                            <h5>ข้อมูลสำคัญทางการเงิน</h5>
                            <h1>งบการเงิน</h1>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-lg-9 col-md-11 col-12">
                        <div class="blueBox input-form three-colPad more-mb">
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-12">
                                    <select class="form-select">
                                        <option selected>เลือกปี</option>
                                        <option value="1">2565</option>
                                        <option value="2">2564</option>
                                        <option value="3">2563</option>
                                        <option value="4">2562</option>
                                    </select>
                                </div>
                                <div class="col-lg-4 col-md-4 col-12">
                                    <select class="form-select">
                                        <option selected>เลือกไตรมาส</option>
                                        <option value="1">ไตรมาส 1</option>
                                        <option value="2">ไตรมาส 2</option>
                                        <option value="3">ไตรมาส 3</option>
                                        <option value="4">ไตรมาส 4</option>
                                        <option value="5">ตลอดทั้งปี</option>
                                    </select>
                                </div>
                                <div class="col-lg-4 col-md-4 col-12">
                                    <select class="form-select">
                                        <option selected>เลือกประเภท</option>
                                        <option value="1">งบการเงินบริษัท</option>
                                        <option value="2">งบการเงินรวม</option>
                                    </select>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="content-center">
                                        <a class="buttonB m-size" href=""><i class="fas fa-search"></i>ค้นหา</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <ul class="display-tab center financial-page">
                            <li class="active" rel="1">
                                <a href="javascript:void(0)">
                                    <div class="cate-txtBox">
                                        <div>งบแสดงฐานะการเงิน</div>
                                    </div>
                                </a>
                            </li>
                            <li rel="2">
                                <a href="javascript:void(0)">
                                    <div class="cate-txtBox">
                                        <div>งบกำไรขาดทุน</div>
                                    </div>
                                </a>
                            </li>
                            <li rel="3">
                                <a href="javascript:void(0)">
                                    <div class="cate-txtBox">
                                        <div>งบกำไรขาดทุนเบ็ดเสร็จอื่น</div>
                                    </div>
                                </a>
                            </li>
                            <li rel="4">
                                <a href="javascript:void(0)">
                                    <div class="cate-txtBox">
                                        <div>งบกระแสเงินสด</div>
                                    </div>
                                </a>
                            </li>
                            <li rel="5">
                                <a href="javascript:void(0)">
                                    <div class="cate-txtBox">
                                        <div>ดาว์นโหลดงบการเงิน</div>
                                    </div>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="display-group">
                            <!---------- 01 STATEMENT FINANCIAL ---------->
                            <div class="display-info" rel="1">
                                <div class="row justify-content-center">
                                    <div class="col-xl-10 col-lg-11 col-12">
                                        <div class="blueTB finance-statementTB">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th>รายการ</th>
                                                        <th>ล้านบาท</th>
                                                        <th>%</th>
                                                    </tr>
                                                </thead>
                                                <thead class="sub-thead">
                                                    <tr>
                                                        <th colspan="3">สินทรัพย์</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>เงินสดและรายการเทียบเท่าเงินสด</td>
                                                        <td>29.76</td>
                                                        <td>1.04</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ลูกหนี้การค้าและลูกหนี้หมุนเวียนอื่น-สุทธิ</td>
                                                        <td>772.19</td>
                                                        <td>27.12</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>บุคคลหรือกิจการอื่น</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>ลูกหนี้หมุนเวียนอื่น</td>
                                                        <td>43.96</td>
                                                        <td>1.54</td>
                                                    </tr>
                                                    <tr>
                                                        <td>สินค้าคงเหลือ-สุทธิ</td>
                                                        <td>937.00</td>
                                                        <td>32.90</td>
                                                    </tr>
                                                    <tr>
                                                        <td>สินทรัพย์หมุนเวียนอื่น</td>
                                                        <td>8.83</td>
                                                        <td>0.31</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>สินทรัพย์หมุนเวียนอื่น-อื่นๆ</td>
                                                        <td>8.83</td>
                                                        <td>0.31</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมสินทรัพย์หมุนเวียน</td>
                                                        <td>1,747.77</td>
                                                        <td>61.38</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินฝากสถาบันการเงินที่มีข้อจำกัดในการใช้-ไม่หมุนเวียน</td>
                                                        <td>10.55</td>
                                                        <td>0.37</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ลูกหนี้การค้าและลูกหนี้ไม่หมุนเวียนอื่น-สุทธิ</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>บุคคลหรือกิจการอื่น</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินลงทุนในบริษัทย่อย บริษัทร่วม และการร่วมค้าที่บันทึกด้วยวิธีอื่น-สุทธิ</td>
                                                        <td>272.04</td>
                                                        <td>9.55</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>เงินลงทุนในบริษัทย่อย</td>
                                                        <td>272.04</td>
                                                        <td>9.55</td>
                                                    </tr>
                                                    <tr>
                                                        <td>อสังหาริมทรัพย์เพื่อการลงทุน-สุทธิ</td>
                                                        <td>165.13</td>
                                                        <td>5.80</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ที่ดิน อาคาร และอุปกรณ์-สุทธิ</td>
                                                        <td>508.22</td>
                                                        <td>17.85</td>
                                                    </tr>
                                                    <tr>
                                                        <td>สินทรัพย์สิทธิการใช้-สุทธิ</td>
                                                        <td>69.02</td>
                                                        <td>2.42</td>
                                                    </tr>
                                                    <tr>
                                                        <td>สินทรัพย์ไม่มีตัวตน-สุทธิ</td>
                                                        <td>20.27</td>
                                                        <td>0.71</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>สินทรัพย์ไม่มีตัวตน-อื่นๆ</td>
                                                        <td>272.04</td>
                                                        <td>9.55</td>
                                                    </tr>
                                                    <tr>
                                                        <td>สินทรัพย์ภาษีเงินได้รอตัดบัญชี</td>
                                                        <td>40.03</td>
                                                        <td>1.41</td>
                                                    </tr>
                                                    <tr>
                                                        <td>สินทรัพย์ไม่หมุนเวียนอื่น</td>
                                                        <td>14.65</td>
                                                        <td>0.51</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>สินทรัพย์ไม่หมุนเวียนอื่น-อื่นๆ</td>
                                                        <td>14.65</td>
                                                        <td>0.51</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมสินทรัพย์ไม่หมุนเวียน</td>
                                                        <td>1,099.91</td>
                                                        <td>38.62</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมสินทรัพย์</td>
                                                        <td>2,847.68</td>
                                                        <td>100.00</td>
                                                    </tr>
                                                    <thead class="sub-thead">
                                                        <tr>
                                                            <th colspan="3">หนี้สิน</th>
                                                        </tr>
                                                    </thead>
                                                    <tr>
                                                        <td>เงินเบิกเกินบัญชีและเงินกู้ยืมระยะสั้นจากสถาบันการเงิน</td>
                                                        <td>1,126.76</td>
                                                        <td>39.57</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เจ้าหนี้การค้าและเจ้าหนี้หมุนเวียนอื่น</td>
                                                        <td>441.42</td>
                                                        <td>15.50</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>บุคคลหรือกิจการอื่น</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>เจ้าหนี้หมุนเวียนอื่น</td>
                                                        <td>122.75</td>
                                                        <td>4.31</td>
                                                    </tr>
                                                    <tr>
                                                        <td>หนี้สินที่เกิดจากสัญญาและค่าเช่ารับล่วงหน้า-หมุนเวียน</td>
                                                        <td>7.75</td>
                                                        <td>0.27</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>หนี้สินที่เกิดจากสัญญาและค่าเช่ารับล่วงหน้า-อื่นๆ</td>
                                                        <td>7.75</td>
                                                        <td>0.27</td>
                                                    </tr>
                                                    <tr>
                                                        <td>หนี้สินตามสัญญาเช่า-ส่วนที่ถึงกำหนดชำระภายในหนึ่งปี</td>
                                                        <td>33.68</td>
                                                        <td>1.18</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ภาษีเงินได้นิติบุคคลค้างจ่าย</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>หนี้สินหมุนเวียนอื่น</td>
                                                        <td>11.41</td>
                                                        <td>0.40</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมหนี้สินหมุนเวียน</td>
                                                        <td>1,621.01</td>
                                                        <td>56.92</td>
                                                    </tr>
                                                    <tr>
                                                        <td>หนี้สินตามสัญญาเช่า-ส่วนที่ถึงกำหนดชำระเกินกว่าหนึ่งปี</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>หนี้สินที่เกิดจากสัญญาและค่าเช่ารับล่วงหน้า-ไม่หมุนเวียน</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>หนี้สินที่เกิดจากสัญญาและค่าเช่ารับล่วงหน้า-อื่นๆ</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ประมาณการหนี้สินระยะยาว</td>
                                                        <td>4.10</td>
                                                        <td>0.14</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ประมาณการหนี้สินผลประโยชน์พนักงาน-ไม่หมุนเวียน</td>
                                                        <td>89.40</td>
                                                        <td>3.14</td>
                                                    </tr>
                                                    <tr>
                                                        <td>หนี้สินไม่หมุนเวียนอื่น</td>
                                                        <td>57.66</td>
                                                        <td>2.02</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมหนี้สินไม่หมุนเวียน</td>
                                                        <td>151.16</td>
                                                        <td>5.31</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมหนี้สิน</td>
                                                        <td>1,772.17</td>
                                                        <td>62.23</td>
                                                    </tr>
                                                    <thead class="sub-thead">
                                                        <tr>
                                                            <th colspan="3">ส่วนของผู้ถือหุ้น</th>
                                                        </tr>
                                                    </thead>
                                                    <tr>
                                                        <td>ทุนจดทะเบียน</td>
                                                        <td>492.04</td>
                                                        <td>17.28</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>หุ้นสามัญจดทะเบียน</td>
                                                        <td>492.04</td>
                                                        <td>17.28</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ทุนที่ออกและชำระแล้ว</td>
                                                        <td>492.04</td>
                                                        <td>17.28</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>หุ้นสามัญชำระแล้ว</td>
                                                        <td>492.04</td>
                                                        <td>17.28</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ใบสำคัญแสดงสิทธิ สิทธิซื้อหุ้น และสิทธิในการเลือกซื้อหุ้น</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ส่วนเกิน (ต่ำกว่า) มูลค่าหุ้น</td>
                                                        <td>229.56</td>
                                                        <td>8.06</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>ส่วนเกิน (ต่ำกว่า) มูลค่าหุ้นสามัญ</td>
                                                        <td>229.56</td>
                                                        <td>8.06</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) สะสม</td>
                                                        <td>353.92</td>
                                                        <td>12.43</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>กำไรสะสม-จัดสรรแล้ว</td>
                                                        <td>49.20</td>
                                                        <td>1.73</td>
                                                    </tr>
                                                    <tr class="sub-sub-topic">
                                                        <td>สำรองตามกฎหมาย</td>
                                                        <td>49.20</td>
                                                        <td>1.73</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>กำไร (ขาดทุน) สะสม-ยังไม่ได้จัดสรร</td>
                                                        <td>304.71</td>
                                                        <td>10.70</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมส่วนของผู้ถือหุ้นของบริษัทใหญ่</td>
                                                        <td>1,075.51</td>
                                                        <td>37.77</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมส่วนของผู้ถือหุ้น</td>
                                                        <td>1,075.51</td>
                                                        <td>37.77</td>
                                                    </tr>
                                                    <tr class="summary">
                                                        <td>รวมหนี้สินและส่วนของผู้ถือหุ้น</td>
                                                        <td>2,847.68</td>
                                                        <td>100.00</td>
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div><!-- END/01 STATEMENT FINANCIAL -->

                            <!---------- 02 INCOME STATEMENT ---------->
                            <div class="display-info" rel="2">
                                <div class="row justify-content-center">
                                    <div class="col-xl-10 col-lg-11 col-12">
                                        <div class="blueTB finance-statementTB">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th>รายการ</th>
                                                        <th>ล้านบาท</th>
                                                        <th>%</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>รายได้จากการดำเนินธุรกิจ</td>
                                                        <td>2,534.29</td>
                                                        <td>98.65</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>รายได้จากการขายและให้บริการ</td>
                                                        <td>2,534.29</td>
                                                        <td>98.65</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รายได้อื่น</td>
                                                        <td>34.71</td>
                                                        <td>1.35</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมรายได้</td>
                                                        <td>2,569.00</td>
                                                        <td>100.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ต้นทุน</td>
                                                        <td>1,866.61</td>
                                                        <td>72.66</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ค่าใช้จ่ายในการขายและบริหาร</td>
                                                        <td>651.22</td>
                                                        <td>25.35</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>ค่าใช้จ่ายในการขาย</td>
                                                        <td>288.13</td>
                                                        <td>11.22</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>ค่าใช้จ่ายในการบริหาร</td>
                                                        <td>363.09</td>
                                                        <td>14.13</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รวมต้นทุนและค่าใช้จ่าย</td>
                                                        <td>2,517.83</td>
                                                        <td>98.01</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) อื่น</td>
                                                        <td>0.68</td>
                                                        <td>0.03</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>กำไร (ขาดทุน) จากอัตราแลกเปลี่ยน</td>
                                                        <td>0.68</td>
                                                        <td>0.03</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) ก่อนต้นทุนทางการเงิน และภาษีเงินได้</td>
                                                        <td>51.85</td>
                                                        <td>2.02</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ต้นทุนทางการเงิน</td>
                                                        <td>31.26</td>
                                                        <td>1.22</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ภาษีเงินได้</td>
                                                        <td>6.94</td>
                                                        <td>0.27</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) จากการดำเนินงานต่อเนื่อง</td>
                                                        <td>13.65</td>
                                                        <td>0.53</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) สุทธิ สำหรับงวด</td>
                                                        <td>13.65</td>
                                                        <td>0.53</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) สุทธิ สำหรับงวด / กำไร (ขาดทุน) จากการดำเนินงานต่อเนื่อง</td>
                                                        <td>13.65</td>
                                                        <td>0.53</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) จากการประมาณการตามหลักคณิตศาสตร์ประกันภัยสำหรับโครงการผลประโยชน์พนักงาน</td>
                                                        <td>6.01</td>
                                                        <td>0.23</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) เบ็ดเสร็จอื่น-สุทธิจากภาษี</td>
                                                        <td>6.01</td>
                                                        <td>0.23</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) เบ็ดเสร็จรวม สำหรับงวด</td>
                                                        <td>19.66</td>
                                                        <td>0.77</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>การแบ่งปันกำไร (ขาดทุน) สุทธิ : ผู้ถือหุ้นบริษัทใหญ่</td>
                                                        <td>13.65</td>
                                                        <td>0.53</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>การแบ่งปันกำไร (ขาดทุน) เบ็ดเสร็จรวม : ผู้ถือหุ้นบริษัทใหญ่</td>
                                                        <td>19.66</td>
                                                        <td>0.77</td>
                                                    </tr>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) ต่อหุ้นขั้นพื้นฐาน (บาท/หุ้น)</td>
                                                        <td>0.03</td>
                                                        <td>-</td>
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div><!-- END/02 INCOME STATEMENT -->

                            <!---------- 03 STATEMENT OTHER COMPREHENSIVE INCOME ---------->
                            <div class="display-info" rel="3">
                                <div class="row">
                                    <div class="col">
                                        <div class="txt-content text-center f-17">
                                            <p>ไม่มีข้อมูล ณ ขณะนี้</p>
                                        </div>
                                    </div>
                                </div>
                            </div><!-- END/03 STATEMENT OTHER COMPREHENSIVE INCOME -->

                            <!---------- 04 CASH FLOW STATEMENT ---------->
                            <div class="display-info" rel="4">
                                <div class="row justify-content-center">
                                    <div class="col-xl-10 col-lg-11 col-12">
                                        <div class="blueTB finance-statementTB">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th>รายการ</th>
                                                        <th>ล้านบาท</th>
                                                        <th>%</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>กำไร (ขาดทุน) สุทธิสำหรับงวด / ของบริษัทใหญ่</td>
                                                        <td>13.65</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ค่าเสื่อมราคาและค่าตัดจำหน่าย</td>
                                                        <td>87.40</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>(โอนกลับ) ผลขาดทุนด้านเครดิตที่คาดว่าจะเกิดขึ้น</td>
                                                        <td>7.28</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>(โอนกลับ) ขาดทุนจากการลดมูลค่าของสินค้าคงเหลือ</td>
                                                        <td>-4.56</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>(กำไร) ขาดทุนจากอัตราแลกเปลี่ยน</td>
                                                        <td>-1.07</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>(กำไร) ขาดทุนจากการขายและตัดจำหน่ายสินทรัพย์ถาวร</td>
                                                        <td>-0.02</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>(กำไร) ขาดทุนจากการขายสินทรัพย์ถาวร</td>
                                                        <td>-0.02</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>(โอนกลับ) ขาดทุนจากการด้อยค่าของสินทรัพย์อื่น</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินปันผลและดอกเบี้ยรับ</td>
                                                        <td>-2.71</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>รายได้เงินปันผล</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>รายได้ดอกเบี้ย</td>
                                                        <td>-2.71</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ต้นทุนทางการเงิน</td>
                                                        <td>31.26</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ภาษีเงินได้</td>
                                                        <td>6.94</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ค่าใช้จ่ายผลประโยชน์พนักงาน</td>
                                                        <td>8.36</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>(กลับรายการ) ประมาณการหนี้สิน</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รายการปรับปรุงอื่นๆ</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดได้มาจาก (ใช้ไปใน) การดำเนินงานก่อนการเปลี่ยนแปลงในสินทรัพย์และหนี้สินดำเนินงาน</td>
                                                        <td>146.54</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ลูกหนี้การค้าและลูกหนี้อื่น (เพิ่มขึ้น) ลดลง</td>
                                                        <td>31.63</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>สินค้าคงเหลือ (เพิ่มขึ้น) ลดลง</td>
                                                        <td>-181.70</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>สินทรัพย์ดำเนินงานอื่น (เพิ่มขึ้น) ลดลง</td>
                                                        <td>-1.22</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เจ้าหนี้การค้าและเจ้าหนี้อื่น เพิ่มขึ้น (ลดลง)</td>
                                                        <td>26.71</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ประมาณการหนี้สินผลประโยชน์พนักงาน เพิ่มขึ้น (ลดลง)</td>
                                                        <td>-2.30</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>หนี้สินดำเนินงานอื่น เพิ่มขึ้น (ลดลง)</td>
                                                        <td>5.77</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดรับ (จ่าย) จากการดำเนินงาน</td>
                                                        <td>25.42</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>(จ่าย) คืนภาษีเงินได้</td>
                                                        <td>-12.33</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดสุทธิได้มาจาก (ใช้ไปใน) กิจกรรมดำเนินงาน</td>
                                                        <td>13.08</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดจ่ายซื้อเงินลงทุนในบริษัทย่อย บริษัทร่วม และการร่วมค้า</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดรับจากการขายสินทรัพย์ถาวร</td>
                                                        <td>1.25</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>ที่ดิน อาคาร และอุปกรณ์</td>
                                                        <td>1.25</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดรับจากการขายสินทรัพย์ถาวร</td>
                                                        <td>-29.08</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>ที่ดิน อาคาร และอุปกรณ์</td>
                                                        <td>-19.82</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>สินทรัพย์ไม่มีตัวตน</td>
                                                        <td>-9.26</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>อสังหาริมทรัพย์เพื่อการลงทุน</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รับดอกเบี้ย</td>
                                                        <td>0.03</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>รายการอื่น ๆ (กิจกรรมลงทุน)</td>
                                                        <td>-8.83</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดสุทธิได้มาจาก (ใช้ไปใน) กิจกรรมลงทุน</td>
                                                        <td>-36.63</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินเบิกเกินบัญชีและเงินกู้ยืมระยะสั้น - สถาบันการเงิน เพิ่มขึ้น (ลดลง)</td>
                                                        <td>132.67</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดจ่ายชำระเงินกู้ยืม</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>เงินสดจ่ายชำระเงินกู้ยืมระยะสั้น</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-sub-topic">
                                                        <td>เงินสดจ่ายชำระเงินกู้ยืมระยะสั้น-สถาบันการเงิน</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr class="sub-topic">
                                                        <td>เงินสดจ่ายชำระเงินกู้ยืม (มาตรฐานเดิม)</td>
                                                        <td>0.00</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดจ่ายชำระหนี้สินตามสัญญาเช่า</td>
                                                        <td>-40.60</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>จ่ายเงินปันผล</td>
                                                        <td>-41.82</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>จ่ายดอกเบี้ย</td>
                                                        <td>-31.34</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดสุทธิได้มาจาก (ใช้ไปใน) กิจกรรมจัดหาเงิน</td>
                                                        <td>18.91</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดและรายการเทียบเท่าเงินสด เพิ่มขึ้น (ลดลง) สุทธิ</td>
                                                        <td>-4.64</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>ผลกระทบจากอัตราแลกเปลี่ยนในเงินสดและรายการเทียบเท่าเงินสด</td>
                                                        <td>-0.27</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดและรายการเทียบเท่าเงินสด ต้นงวด</td>
                                                        <td>34.67</td>
                                                        <td>0.00</td>
                                                    </tr>
                                                    <tr>
                                                        <td>เงินสดและรายการเทียบเท่าเงินสด สิ้นงวด</td>
                                                        <td>29.76	</td>
                                                        <td>0.00</td>
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div><!-- END/04 CASH FLOW STATEMENT -->

                            <!---------- 05 DOWNLOAD FINANCIAL STATEMENT ---------->
                            <div class="display-info" rel="5">
                                <div class="row justify-content-center">
                                    <div class="col-xl-9 col-lg-10 col-12">
                                        <div class="blueTB financial-downloadTB">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th>งบการเงิน</th>
                                                        <th>วันที่</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ประจำปี 2565 (ตรวจสอบแล้ว)</a>
                                                        </td>
                                                        <td>21 ก.พ. 2566</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ไตรมาสที่ 3/2565 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>08 พ.ย. 2565</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ไตรมาสที่ 2/2565 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>09 ส.ค. 2565</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ไตรมาสที่ 1/2565 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>10 พ.ค. 2565</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ประจำปี 2564 (ตรวจสอบแล้ว)</a>
                                                        </td>
                                                        <td>22 ก.พ. 2565</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ไตรมาสที่ 3/2564 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>10 พ.ย. 2564</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ไตรมาสที่ 2/2564 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>10 ส.ค. 2564</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ไตรมาสที่ 1/2564 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>11 พ.ค. 2564</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ประจำปี 2563 (ตรวจสอบแล้ว)</a>
                                                        </td>
                                                        <td>23 ก.พ. 2564</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ไตรมาสที่ 3/2563 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>10 พ.ย. 2563</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงิน ไตรมาสที่ 2/2563 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>11 ส.ค. 2563</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงินไตรมาสที่ 1/2563 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>12 พ.ค. 2563</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงินรายปี 2562 (ตรวจสอบแล้ว)</a>
                                                        </td>
                                                        <td>18 ก.พ. 2563</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงินไตรมาสที่ 3/2562 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>13 พ.ย. 2562</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href="images/testPDF.pdf" target="_blank">งบการเงินไตรมาสที่ 2/2562 (สอบทานแล้ว)</a>
                                                        </td>
                                                        <td>07 ส.ค. 2562</td>
                                                    </tr>
                                                </tbody>
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
                                
                            </div><!-- END/05 DOWNLOAD FINANCIAL STATEMENT -->

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    
    <?php require('IR_inc_footer.php'); ?>

    <script type="text/javascript">
        $(document).ready(function() {
            $(".display-tab > li").click(function() {
                var rel = $(this).attr("rel");
                console.log(rel);
                $('.display-info').hide();
                $('.display-info[rel=' + rel + ']').fadeIn();
                $(".display-tab > li").removeClass("active");
                $(this).addClass("active");
            });
        });
    </script>

</body>
</html>