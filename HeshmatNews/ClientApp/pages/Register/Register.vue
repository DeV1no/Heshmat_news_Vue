<template>
  <div class="container-fluid">
    <nav-bar />
    <div class="submit-mainform">
      <div class="grid-container">
        <div class=" register-right-card"></div>
        <div class=" register-card">
          <h3 class="red-color">
            ثبت نام
          </h3>
          <hr />

          <p class="explain-text">
            با ثبت نام در حشمت نیوز به خانواده چندصد ملیونی ما بپیوندید
          </p>
          <form class="row p-2 mt-4">
            <div class="form-group col-md-12">
              <label for="Name">
                <i class="fa fa-address-card" aria-hidden="true"></i>

                نام کاربری</label
              >
              <input
                type="text"
                class="form-control"
                id="Name"
                aria-describedby="emailHelp"
                placeholder="نام کاربری خود را وارد نمایید"
                v-model="mdl.userName"
              />
            </div>
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
                v-model="mdl.email"
              />
            </div>
            <div class="form-group col-md-12">
              <label for="Name">
                <i class="fa fa-address-card" aria-hidden="true"></i>

                نام </label
              >
              <input
                type="text"
                class="form-control"
                id="Name"
                aria-describedby="emailHelp"
                placeholder="نام  خود را وارد نمایید"
                v-model="mdl.name"
              />
            </div>
            <div class="form-group col-md-12">
              <label for="Name">
                <i class="fa fa-address-card" aria-hidden="true"></i>

                 نام خانوادگی</label
              >
              <input
                  type="text"
                  class="form-control"
                  id="Family"
                  aria-describedby="emailHelp"
                  placeholder=" نام خانوادگی خود را وارد نمایید"
                  v-model="mdl.family"
              />
            </div>
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
              <label for="exampleInputPassword2">
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
            </div>
            <small v-if="!passChecker" class="text-danger mr-4">
              کلمه عبور و تکرار آن باید یکسان باشد
            </small>

            <div class="form-check col-md-12 mt-2">
              <label class="form-check-label ml-2" for="exampleCheck1"
                >با قوانین و شرایط حشمت نیوز مواقم</label
              >
              <input
                type="checkbox"
                class="form-check-input"
                id="exampleCheck1"
                v-model="isAgreeTerm"
              />
            </div>
            <button
              type="submit"
              class="btn light-brown-background btn-lg mr-auto ml-4 mt-2"
              @click.prevent="register"
              :disabled="isSaving || isRegisterSucced"
            >
              <i class="fa fa-send"></i>
              ثبت نام
            </button>
          </form>
        </div>
      </div>
    </div>
    <!-- Loading Componnet -->
    <loading v-if="isSaving" />
    <!-- Register Succeed Modal -->
    <div>
      <b-modal id="succeed-register-modal" hide-footer>
        <template #modal-title>
          <h6 class="text-success">
            <i class="fa fa-check"></i>
            ثبت نام با موفقیت انجام شد !
          </h6>
        </template>
        <div class="d-block text-center">
          <p>
            ایمیل حاوی لینک فعال سازی حساب شما به آدرس

            {{ mdl.email }}
            ارسال گردید
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
      mdl: {
        userName: null,
        email: null,
        nameFamily: null,
        password: null
      },
      valMdl: {
        isAgreeTerm: false
      },
      isSaving: false,
      isRegisterSucced: false,
      isAgreeTerm: false,
      rePassword: null
    };
  },
  methods: {
    async register() {
      try {
        this.isSaving = true;
        await axios.post('/api/User/Register', this.mdl).then(res => {
          if (res) {
            this.isRegisterSucced = true;
            this.$bvModal.show('succeed-register-modal');
          }
        });
      } catch (err) {
        console.log(err);
        this.$toast
          .error('خطا! لطفا تمامی اطلاعات را وارد نمایید')
          .goAway(3000);
      } finally {
        this.isSaving = false;
      }
    }
  },
  computed: {
    passChecker: function() {
      if (this.mdl.password == this.rePassword || this.rePassword == null)
        return true;
      else return false;
    }
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
