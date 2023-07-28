const city = document.getElementById('city');
const citys = ['臺北市','新北市','桃園市','臺中市','臺南市','高雄市','新竹縣','苗栗縣','彰化縣','南投縣','雲林縣','嘉義縣','屏東縣','宜蘭縣','花蓮縣','臺東縣','澎湖縣','金門縣','連江縣','基隆市','新竹市','嘉義市'];

let display_citys='';
for(let i = 0; i<citys.length;i++){
    display_citys+=`<div class="divide-line">
                      <li class="tags t-s controls-display-row">
                        <img id="uncheckbox"class="uncheckbox" src="~/TestCss/icon/uncheckbox.png">
                        <img id="checkbox"class="checkbox" src="~/TestCss/icon/uncheckbox.png">
                        <span>${citys[i]}</span>
                      </li>
                    </div>`;
}
city.innerHTML = display_citys;


const product_category = document.getElementById('product_category');
const categories=['景點門票','活動 & 展覽','戶外活動','舒壓 & 放鬆','工作坊 & 在地文化','觀光行程','住宿']
const product_tag = document.getElementById('product_tag');
const tags_for_id_1 = ['景點門票','主題樂園','博物館&美術館','水族館&動物園','歷史景點'];
const tags_for_id_2 = ['運動賽事','娛樂表演','展覽&美術館'];
const tags_for_id_3 = ['冒險&極限運動','雪地活動','露營','遠足&登山','觀光農場','水上活動'];
const tags_for_id_4 = ['Spa & 按摩','美容 & 沙龍','溫泉'];
const tags_for_id_5 = ['工作坊 & 課程','文化體驗','手作材料包'];
const tags_for_id_6 = ['半/一日遊','多日遊','線上旅遊','單車旅遊','遊船觀光'];
const tags_for_id_7 = ['飯店','渡假村','民宿'];

let display_categories = '';
let display_tags='';

for (let i = 0; i < categories.length; i++) {
    let tags_li = [];
    switch (i) {
      case 0:
        tags_li = tags_for_id_1;
        break;
      case 1:
        tags_li = tags_for_id_2;
        break;
      case 2:
        tags_li = tags_for_id_3;
        break;
      case 3:
        tags_li = tags_for_id_4;
        break;
      case 4:
        tags_li = tags_for_id_5;
        break;
      case 5:
        tags_li = tags_for_id_6;
        break;
      case 6:
        tags_li = tags_for_id_7;
        break;
    }
  
    let tags_html = '';
    for (let j = 0; j < tags_li.length; j++) {
      tags_html += `<div class="divide-line"><li class="tags t-s controls-display-row">
                      <img id="uncheckbox"class="uncheckbox" src="icon/uncheckbox.png">
                      <img id="checkbox"class="checkbox" src="icon/checkbox.png">
                      <span>${tags_li[j]}</span>
                    </li></div>`;
    }
  
    display_categories +=
      `<div class="controls-display-row category-click">
          <label class="t-m lblCategory">${categories[i]}</label>
          <div class="arrow_img_center">
            <img id="arrow_bottom_down" src="icon/arrow_bottom_down_icon.png">
            <img id="arrow_top_up" src="icon/arrow_top_up_icon.png">
          </div>
      </div>
      <div class="filter-block-center">
        <ul class="tags t-s" id="product_tag">
            ${tags_html}
        </ul>
      </div>
      `;
  }
product_category.innerHTML=display_categories;

const product_type = document.getElementById('product_type');
const product_type_list = ['門票','自助行程','旅行團'];
let display_product_type='';
for(let i = 0; i<product_type_list.length;i++){
  display_product_type+=
  `<div class="divide-line">
    <li class="tags t-s controls-display-row">
      <img id="uncheckbox"class="uncheckbox" src="icon/uncheckbox.png">
      <img id="checkbox"class="checkbox" src="icon/checkbox.png">
      <span>${product_type_list[i]}</span>
    </li>
  </div>`;
}
product_type.innerHTML = display_product_type;



  