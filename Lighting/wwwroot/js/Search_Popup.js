var SEARCH_LIST_PRODUCT = [];
const showSubcategory = (id) => {
    if ($("#" + id).next(".search-subcategory-container").css("height") === "0px") {
        $("#" + id).next(".search-subcategory-container").css("height", "auto");
    } else {
        $("#" + id).next(".search-subcategory-container").css("height", "0px");
    }
};

const powerChange_ipRatingChange = () => {
    let power = $("#power").val();
    let ip_rating = $("#ip_rating").val();
    if (!SEARCH_LIST_PRODUCT) return;
    let product_ar = SEARCH_LIST_PRODUCT.map(x => x);
    if (power != -1) {
        product_ar = product_ar.filter(x => x.power == power);
    }
    if (ip_rating != -1) {
        product_ar = product_ar.filter(x => x.ipRating == ip_rating);
    }
    let html = product_ar.reduce((prev, curr) => prev += `
                                        <a href="/Product/Product_Detail?category=${curr?.category}&sub_category=${curr?.subCategory}&model=${curr?.name}" target="_blank">
                                                <div class="search-card">
                                                    <img src="/${curr?.img}" class="search-card-img" />
                                                    <div class="searc-card-model">${curr?.name}</div>
                                                    <div class="search-card-power-rating-iprating">
                                                    Power  ${curr?.power}<br />
                                                    IP Rating ${curr?.ipRating}<br />
                                                    Dimention ${curr?.dimention}
                                                    </div>
                                                </div>
                                                </a>`, "");
    $("#search_resault").html(html);
    let width = window.innerWidth;
    if (width < 820) { //mobile
        $("#show_search_container").css("display", "block");
    }
}

const selectSubCategory = (subcategory_id) => {
    let width = window.innerWidth;
    if (width < 820) { //mobile
        $("#show_search_container").css("display", "block");
    }

    fetch("/Product/LoadProduct?subcategoryId=" + subcategory_id, { method: "POST" }).then(x => x.json()).then(x => {
        SEARCH_LIST_PRODUCT = [...x];

        let power_ar = SEARCH_LIST_PRODUCT.map(x => x.power);
        let ip_rating_ar = SEARCH_LIST_PRODUCT.map(x => x.ipRating);
        let power_set = new Set(power_ar);
        let ip_rating_set = new Set(ip_rating_ar);
        let power_sHTML = "<option selected  value='-1'>IP Rating</option>";
        let ip_rating_sHTML = "<option selected  value='-1' >IP Rating</option>";
        for (const p of power_set) {
            power_sHTML += `<option  value='${p}'>${p}</option>`;
        }
        $("#power").html(power_sHTML);
        for (const ip of ip_rating_set) {
            ip_rating_sHTML += `<option  value='${ip}'>${ip}</option>`;
        }
        $("#ip_rating").html(ip_rating_sHTML);



        let html = "";
        html = x.reduce((prev, curr) => prev += `
                                    <a href="/Product/Product_Detail?category=${curr?.category}&sub_category=${curr?.subCategory}&model=${curr?.name}" target="_blank">
                                        <div class="search-card">
                                            <img src="/${curr?.img}" class="search-card-img" />
                                            <div class="searc-card-model">${curr?.name}</div>
                                            <div class="search-card-power-rating-iprating">
                                            Power  ${curr?.power}<br />
                                            IP Rating ${curr?.ipRating}<br />
                                            Dimention ${curr?.dimention}
                                            </div>
                                        </div>
                                        </a>`, "");
        $("#search_resault").html(html);
    });

}

const closeNav = () => {
    let width = window.innerWidth;
    if (width < 820) { //mobile
        $("#search_nav").css("display", "none");
    } else { //pc
        $("#search_nav").css("display", "none");
        $("#show_search_container").css("display", "none");
    }
}

const closeSearchContainer = () => {
    $("#show_search_container").css("display", "none");
}

const showNav = () => {
    let width = window.innerWidth;
    if (width < 820) { //mobile
        $("#search_nav").css("display", "block");
    } else { //pc
        $("#search_nav").css("display", "block");
        $("#show_search_container").css("display", "block");
    }

    if (SEARCH_LIST_PRODUCT.length === 0) {
        fetch("/product/NavBarSearchListJson", { method: "POST" }).then(x => x.json()).then(x => {
            let html = "";
            let i = 0;
            html = x.reduce((prev, curr) => prev += `
                                                    <div class="search-category-item">
                                                        <div class="category-btn" id="show_subcategory${i}" onclick="showSubcategory('show_subcategory${i++}')">${curr?.categoryName}</div>
                                                                <div class="search-subcategory-container">`
                +
                (curr.subCategory.reduce((prevSub, currSub) => prevSub += `<div class= "search-subcategory-item" onclick = "selectSubCategory(${currSub?.id})" > ${currSub?.name} </div>`, ""))
                +
                `</div>
                                                    </div>`, "");

            $("#search_nav").append(html);
        });
    }

}