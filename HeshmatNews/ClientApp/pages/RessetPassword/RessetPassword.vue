<template>
  <div class="container-fluid">
    <nav-bar />
    <div class="submit-mainform">
      <div class="grid-container">
        <div class=" register-right-card"></div>
        <div class=" register-card">
          <h4 class="red-color">
            بازگردانی کلمه عبور
          </h4>
          <hr />

          <form class="row p-2 mt-4" v-if="isUserExisted">
            <div class="form-group col-md-12">
              <label for="exampleInputPassword1">
                <i class="fa fa-key" aria-hidden="true"></i>

                کلمه عبور</label
              >
              <input
                type="password"
                class="form-control"
                id="exampleInputPassword1"
                placeholder=" کلمه عبور"
                v-model="mdl.password"
              />
            </div>
            <div class="form-group col-md-12">
              <label for="exampleInputPassword1">
                <i class="fa fa-key" aria-hidden="true"></i>

                تکرار کلمه عبور</label
              >
              <input
                type="password"
                class="form-control"
                id="exampleInputPassword2"
                placeholder="تکرار کلمه عبور"
                v-model="rePassword"
              />
              <small v-if="!passChecker" class="text-danger mr-4">
                کلمه عبور و تکرار آن باید یکسان باشد
              </small>
            </div>

            <button
              type="submit"
              class="btn light-brown-background btn-lg mr-auto ml-4 mt-2"
              @click.prevent="ressetPassword"
              :disabled="isSaving"
            >
              <i class="fa fa-send"></i>
              بازیابی کلمه عبور
            </button>
          </form>
          <div class="" v-else>
            <p class="text-danger">
              خطا ! کاربری یافت نشد
            </p>
            <nuxt-link class="btn btn-primary float-left" to="/home">
              <i class="fa fa-home"></i>
              خانه
            </nuxt-link>
          </div>
        </div>
      </div>
    </div>
    <!-- Loading Componnet -->
    <loading v-if="isSaving" />
    <!-- Repassword Succeed Modal -->
    <div>
      <b-modal id="succeed-rePassword-modal" hide-footer>
        <template #modal-title>
          <h6 class="text-success">
            <i class="fa fa-check"></i>
            پسورد شما با موفقیت بازیابی شد
          </h6>
        </template>
        <div class="d-block text-center">
          <p class="d-flex">
            برای ورود به حساب کاربریتان
            <nuxt-link class="mx-1 text-primary" exact to="/login"
              >اینجا
            </nuxt-link>
            کلیک کنید
          </p>
        </div>
        <nuxt-link to="/home" class="btn btn-success btn-block">
          <div class="home-btn">
            <i class="fa fa-home"></i>
            خانه
          </div>
        </nuxt-link>
      </b-modal>
    </div>
  </div>
</template>

<script>
import NavBar from '../../components/Home/nav-bar.vue';
import Loading from '../../components/Loading';

import axios from 'axios';
export default {
  components: {
    NavBar,
    Loading
  },
  data() {
    return {
      secretKey: this.$route.params.id,
      mdl: {
        password: null
      },
      rePassword: null,
      isSaving: false,
      isUserExisted: null
    };
  },
  methods: {
    async ressetPassword() {
      try {
        this.isSaving = true;
        await axios
          .post(
            `/api/User/ressetPasswordBySecretKey?secretKey=${this.secretKey}&password=${this.mdl.password}`
          )
          .then(res => {
            if (res.data > 0) {
              this.$bvModal.show('succeed-rePassword-modal');
            }
          });
      } catch (err) {
        console.log(err);
        this.$toast.error('خطا! لطفا تمامی اطلاعات را وارد کنید ').goAway(3000);
      } finally {
        this.isSaving = false;
      }
    },
    async checkUserExisted() {
      await axios
        .post(`/api/User/userExistedWithSecretKey?secretKey=${this.secretKey}`)
        .then(res => {
          this.isUserExisted = res.data;
        });
    }
  },
  computed: {
    passChecker: function() {
      if (this.mdl.password == this.rePassword || this.rePassword == null)
        return true;
      else return false;
    }
  },
  mounted() {
    this.checkUserExisted();
  }
};
</script>

<style scoped>
.submit-mainform {
  margin-top: 4rem;
}
.form-check {
  font-size: 13px;
  color: gray;
}
.register-card {
  left: 11px;
  height: 100vh;
  padding: 1rem;
  border-radius: 5px;
  background: #fdfafa;
  box-shadow: rgba(17, 17, 26, 0.05) 0px 1px 0px,
    rgba(17, 17, 26, 0.1) 0px 0px 8px;
}
.explain-text {
  margin-top: 0.5rem;
  font-size: 15px;
}
.register-right-card {
  background-image: url('https://localhost:5001/wallpapers/registerwallpaper.jpg');
}
.grid-container {
  display: grid;
  grid-template-columns: 1fr 2fr;
  grid-gap: 5px;
}
button.btn.light-brown-background.btn-lg.mr-auto.ml-4.mt-2 {
  border: 1px solid rgb(134, 130, 130);
}
.home-btn {
  display: table;

  margin-right: auto;
  margin-left: auto;
}
</style>
