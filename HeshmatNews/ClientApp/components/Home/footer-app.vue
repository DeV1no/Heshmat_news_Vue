<template>
  <div>
    <footer class="footer ">
      <div class="row px-5">
        <div class="col-sm-3">
          <h4 class="title">درباره حشمت نیوز</h4>
          <p>
            لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با
            استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در
            ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز،
            و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای
            زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و
            متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان
            رایانه ای
          </p>
        </div>
        <div class="col-sm-3">
          <h4 class="title">لیست دلخواه</h4>
          <span class="acount-icon">
            <a href="#"
              ><i class="fa fa-heart " aria-hidden="true"></i> زیر لیست 1</a
            >
            <a href="#"
              ><i class="fa fa-cart-plus" aria-hidden="true"></i> زیر لیست 2</a
            >
            <a href="#"
              ><i class="fa fa-user" aria-hidden="true"></i> زیر لیست 3</a
            >
            <a href="#"
              ><i class="fa fa-globe" aria-hidden="true"></i> زیر لیست 4</a
            >
          </span>
        </div>
        <div class="col-sm-3">
          <h4 class="title">برچسب ها</h4>
          <div class="category">
            <a v-for="item in tagsList" :key="item.id" href="#">{{
              item.tagName
            }}</a>
          </div>
        </div>
        <div class="col-sm-3">
          <h4 class="title">شبکه های اجتماعی</h4>
          <ul class="social-icon">
            <a href="#" class="social"
              ><i class="fa fa-facebook" aria-hidden="true"></i
            ></a>
            <a href="#" class="social"
              ><i class="fa fa-twitter" aria-hidden="true"></i
            ></a>
            <a href="#" class="social"
              ><i class="fa fa-instagram" aria-hidden="true"></i
            ></a>
            <a href="#" class="social"
              ><i class="fa fa-youtube-play" aria-hidden="true"></i
            ></a>
            <a href="#" class="social"
              ><i class="fa fa-google" aria-hidden="true"></i
            ></a>
            <a href="#" class="social"
              ><i class="fa fa-dribbble" aria-hidden="true"></i
            ></a>
          </ul>
        </div>
      </div>
      <hr />

      <div class=" text-center">
        تمامی حقوق مادی و معنوی این وبسایت متعلق به داش حشمت (دانیال شکوه منش)
        میباشد
      </div>
    </footer>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      tagsList: []
    };
  },
  methods: {
    getTagList() {
      axios.get('/api/Tag/TagsList').then(res => (this.tagsList = res.data));
    }
  },
  async mounted() {
    await this.getTagList();
  }
};
</script>

<style scoped>
.footer {
  padding: 50px 0 20px 0;
  background-color: #35404f;
  color: #878c94;
}
.footer .title {
  text-align: left;
  color: #fff;
  font-size: 25px;
}

.footer .social-icon {
  padding: 0px;
  margin: 0px;
}
.footer .social-icon a {
  display: inline-block;
  color: #fff;
  font-size: 25px;
  padding: 5px;
}
.footer .acount-icon a {
  display: block;
  color: #fff;
  font-size: 18px;
  padding: 5px;
  text-decoration: none;
}
.footer .acount-icon .fa {
  margin-right: 25px;
}

.footer .category a {
  text-decoration: none;
  color: #fff;
  display: inline-block;
  padding: 5px 5px;
  margin: 1px;
  border-radius: 4px;
  margin-top: 6px;
  margin-right: 3.5px;
  background-color: black;
  border: solid 1px #fff;
  transition: 0.6s;
}
.footer .category a:hover {
  background-color: rgb(65, 62, 62);
  color: rgb(206, 219, 24);
  box-shadow: 1px 2px 2px 1px #878c94;
}

.footer .payment {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
}
.footer .payment li {
  list-style-type: none;
}
.footer .payment li a {
  text-decoration: none;
  display: inline-block;
  color: #fff;
  float: left;
  font-size: 25px;
  padding: 10px 10px;
}
</style>
