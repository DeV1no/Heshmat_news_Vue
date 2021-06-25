<template>
  <div dir="rtl">
    <nav class="navbar navbar-expand-sm navbar-dark bg-dark p-0">
      <div class="container-fluid">
        <nuxt-link
          to="/home"
          class="nav-link  nav-title"
          exact-active-class="active"
          >حشمت نیوز</nuxt-link
        >
        <button
          class="navbar-toggler"
          data-toggle="collapse"
          data-target="#navbarCollapse"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
          <ul class="navbar-nav">
            <li class="nav-item px-2">
              <nuxt-link
                to="/admin"
                class="nav-link"
                exact-active-class="active"
                >داشبورد</nuxt-link
              >
            </li>
            <li class="nav-item px-2">
              <nuxt-link
                to="/admin/news/list"
                class="nav-link"
                exact-active-class="active"
                >اخبار</nuxt-link
              >
            </li>
            <li class="nav-item px-2">
              <nuxt-link
                to="/admin/tags/list"
                class="nav-link"
                exact-active-class="active"
                >برچسب ها</nuxt-link
              >
            </li>

            <li class="nav-item px-2">
              <nuxt-link
                to="/admin/requestpanel"
                class="nav-link"
                exact-active-class="active"
                >درخواست‌ها</nuxt-link
              >
            </li>
          </ul>

          <ul class="navbar-nav mr-auto">
            <li class="nav-item ">
              <a href="login.html" class="nav-link">
                خوش آمدی
                {{ currentUser.name }} {{ currentUser.family }}
                !
              </a>
            </li>
            <li class="nav-item">
              <a href="login.html" class="nav-link">
                تاریخ آخرین ورود : 23/7/1399
              </a>
            </li>
            <li class="nav-item">
              <a href="/home" class="nav-link" @click="logOut">
                خروج
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
    <header id="main-header" class="py-2 bg-primary text-white">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-6">
            <h1><i class="fa fa-cog ml-1"></i>داشبورد مدیریت</h1>
          </div>
        </div>
      </div>
    </header>
    <section id="actions" class="py-4 mb-1 bg-light">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-md-3">
            <nuxt-link to="/admin/news/add" class="btn btn-primary btn-block">
              <i class="fa fa-plus"></i> افزودن خبر
            </nuxt-link>
          </div>
          <div class="col-md-3">
            <nuxt-link to="/admin/people/add" class="btn btn-success btn-block">
              <i class="fa fa-plus"></i> افزودن هنرمند
            </nuxt-link>
          </div>
          <div class="col-md-3">
            <nuxt-link to="/admin/news/add" class="btn btn-warning btn-block">
              <i class="fa fa-plus"></i> افزودن اخبار
            </nuxt-link>
          </div>
          <div class="col-md-3">
            <a href="#" class="btn btn-danger btn-block" v-b-modal.tagModal>
              <i class="fa fa-plus"></i>

              افزودن برچسب
            </a>
          </div>
        </div>
      </div>
    </section>
    <!-- Tag Modal -->

    <b-modal
      id="tagModal"
      ref="tagModal"
      title="افزودن برچسب"
      @show="resetModal"
      @hidden="resetModal"
      @ok="addTag"
    >
      <form class="mr-2">
        <div class="row">
          <div class="col-md-12">
            <label for="basic-url">عنوان برچسب</label>
            <div class="input-group mb-3">
              <div class="input-group-prepend"></div>
              <input
                type="text"
                class="form-control"
                name="cateGoryName"
                v-model="mdl.tagName"
              />
            </div>
          </div>
        </div>
      </form>
    </b-modal>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      currentUser: {
        id: null,
        isActive: null,
        name: null,
        family: null,
        role: null,
        userName: null
      },
      isLogin: false,
      tokenId: this.$store.getters.isAuthGet,
      token: '',
      isAdmin: false,
      mdl: {
        tagName: null
      }
    };
  },
  methods: {
    autoLog() {
      this.$store.dispatch('autoLog');
    },
    logCheck() {
      if (this.token != null) {
        this.isLogin = true;
      }
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
    },
    addTag() {
      axios.post('/api/Tag/AddTag', this.mdl).then(res => {
        if (res.data > 0) {
          this.$toast.success('اطلاعات با موفقیت ثبت شد').goAway(4500);
          this.$refs.tagModal.hide();
        } else this.$toast.error('لطفا نام برچسب را وارد نمایید').goAway(4500);
      });
    },
    resetModal() {
      this.mdl.tagName = null;
    }
  },
  async created() {
    this.token = localStorage.getItem('token');
    this.logCheck();
    await this.autoLog();
    await this.getCurrentUser();
    // await this.activeChecker();
    //this.adminChecker();
  }
};
</script>

<style scoped>
.nav-title {
  font-size: 20px;
  color: #f5c518;
  text-shadow: 2px 2px #8f0202;
}
.btn-block {
  box-shadow: 5px 5px 5px 5px #888888;
}
</style>
