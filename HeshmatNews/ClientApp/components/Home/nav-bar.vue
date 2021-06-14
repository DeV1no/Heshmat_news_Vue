<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" dir="rtl">
    <img
      src="http://localhost:5000/Logo/logo.png"
      alt=""
      class="nav-logo mr-4"
    />
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarSupportedContent"
      aria-controls="navbarSupportedContent"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <!-- right nav items  -->
      <ul class="navbar-nav mr-5 ml-auto">
        <li class="nav-item ">
          <nuxt-link class="nav-link" active-class="active" exact to="/home"
            >خانه
          </nuxt-link>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">داغ ترین ها </a>
        </li>
        <li
          class="nav-item dropdown"
          v-for="sub in subCategory"
          :key="sub.categoryId"
        >
          <a
            class="nav-link dropdown-toggle"
            href="#"
            id="navbarDropdown"
            role="button"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >
            {{ sub.cateGoryName }}
          </a>

          <div class="dropdown-menu" aria-labelledby="navbarDropdown">
            <a
              v-for="cat in sub.categories"
              class="dropdown-item"
              href="#"
              :key="cat"
            >
              {{ cat.cateGoryName }}
            </a>
          </div>
        </li>
        <li class="nav-item">
          <nuxt-link
            class="nav-link"
            active-class="active"
            exact
            to="/admin"
            v-if="isLogin"
            >داشبورد مدیر
          </nuxt-link>
        </li>
      </ul>
      <!-- left nav items  -->
      <ul class="navbar-nav ml-2 mr-auto">
        <li class="nav-item" v-if="!isLogin">
          <nuxt-link
            class="nav-link"
            active-class="active"
            exact
            to="/register"
          >
            ثبت نام
          </nuxt-link>
        </li>
        <li class="nav-item">
          <nuxt-link
            class="nav-link"
            active-class="active"
            exact
            to="/login"
            v-if="!isLogin"
          >
            ورود
          </nuxt-link>
        </li>
        <li class="nav-item">
          <a
            class="nav-link"
            active-class="active"
            exact
            href=""
            v-if="isLogin"
            @click="logOut"
          >
            خروج
          </a>
        </li>
      </ul>
      <form class="form-inline my-2 my-lg-0">
        <input
          class="form-control mr-sm-2"
          type="search"
          placeholder="جست و جو"
          aria-label="Search"
        />
        <button class="btn btn-outline-success my-2 my-sm-0" type="submit">
          جست و جو
        </button>
      </form>
    </div>
    <div>
      <b-modal id="unActive-user-modal" hide-footer>
        <template #modal-title>
          <h6 class="text-danger">
            <i class="fa fa-times"></i>
            حساب کاربری شما فعال نمیباشد
          </h6>
        </template>
        <div class="d-block text-center">
          <p>
            برای فعال سازی حساب کاربریتان پست الکترونیکی خود را بررسی کنید
          </p>
          <p>
            اگر هنوز ایمیلی دریافت نکرده اید درخواست ارستال مجدد را بزنید
          </p>
          <div class="form-group col-md-12">
            <label for="Name">
              <i class="fa fa-envelope" aria-hidden="true"></i>

              پست الکترونیکی</label
            >
            <input
              type="text"
              class="form-control"
              id="Email"
              aria-describedby="emailHelp"
              placeholder="پست الکترونیکی خود را وارد نمایید"
            />
          </div>
        </div>
        <nuxt-link to="/home" class="btn btn-success btn-block">
          <div class="home-btn">
            <i class="fa fa-send"></i>
            ارسال مجدد ایمیل
          </div>
        </nuxt-link>
        <nuxt-link to="/home" class="btn btn-danger btn-block">
          <div class="home-btn">
            <i class="fa fa-home"></i>
            بازگشت
          </div>
        </nuxt-link>
      </b-modal>
    </div>
  </nav>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      subCategory: [],
      isLogin: false,
      tokenId: this.$store.getters.isAuthGet,
      token: '',
      isAdmin: false,
      currentUser: null
    };
  },
  methods: {
    activeChecker() {
      if (this.token) {
        if (!this.currentUser.isActive) {
          this.$store.dispatch('logOut');
          this.$bvModal.show('unActive-user-modal');
        }
      }
    },
    logCheck() {
      if (this.token != null) {
        this.isLogin = true;
      }
    },
    async GetSubCategories() {
      await axios.get(`/api/categories/getSubCategories`).then(res => {
        this.subCategory = res.data;
      });
    },
    autoLog() {
      this.$store.dispatch('autoLog');
    },
    logOut() {
      this.$store.dispatch('logOut');
      this.$store.state.auth.isAuth = false;
      this.$router.replace('/home');
    },
    async getCurrentUser() {
      if (this.token) {
        try {
          await axios
            .get('/api/User/CurrentUser', {
              headers: {
                Authorization: ` Bearer ${this.token}`
              }
            })
            .then(res => {
              this.currentUser = res.data;
            });
        } catch (error) {
          console.log(error);
          this.$store.dispatch('logOut');
        }
      }
    }
  },
  computed: {},
  async mounted() {
    await this.GetSubCategories();
    await this.logCheck();
    await this.autoLog();
    await this.getCurrentUser();
    await this.activeChecker();
  },
  async created() {
    this.token = localStorage.getItem('token');

    //this.adminChecker();
  }
};
</script>

<style scoped>
.nav-logo {
  width: 180px;
}

.active {
  color: brown !important;
}

/* .dropdown-menu.show {
  z-index: 999999;
  position: relative !important;
  display: contents;
} */
</style>
