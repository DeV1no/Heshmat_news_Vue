<template>
  <div class="container-fluid">
    <nav-bar />
    <div class="submit-mainform">
      <div class="grid-container">
        <div class=" register-right-card"></div>
        <div class=" register-card">
          <h3 class="red-color">
            ورود
          </h3>
          <hr />

          <form class="row p-2 mt-4">
            <div class="form-group col-md-12">
              <label for="Name">
                <i class="fa fa-address-card" aria-hidden="true"></i>

                نام کاربری یا پست الکترونیکی</label
              >
              <input
                type="text"
                class="form-control"
                id="UserName"
                aria-describedby="emailHelp"
                placeholder=" نام کاربری یا پست الکترونیکی خود را وارد نمایید"
                v-model="mdl.username"
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

            <button
              type="submit"
              class="btn light-brown-background btn-lg mr-auto ml-4 mt-2 "
              @click.prevent="Login"
              :disabled="isSaving"
            >
              <i class="fa fa-send"></i>
              ورود
            </button>
          </form>
          <div class="help-text">
            <p class="text-muted d-block">
              نمیتوانید وارد شوید ؟ اینجا کلیک کنید
            </p>
            <p class="text-muted d-block">
              حساب کاربری ندارید ؟
              <span>
                <nuxt-link to="/register">اینجا</nuxt-link>
              </span>
              کلیک کنید
            </p>
          </div>
        </div>
      </div>
    </div>
    <!-- Loading Componnet -->
    <loading v-if="isSaving" />
  </div>
</template>

<script>
export default {
  data() {
    return {
      mdl: {
        username: null,
        password: null
      },

      isSaving: false
    };
  },
  methods: {
    async Login() {
      try {
        this.isSaving = true;
        await this.$store.dispatch('login', this.mdl);
      } catch (err) {
        console.log(err);
        this.$toast
          .error('خطا! نام کاربری و یا رمز عبور اشتباه میباشد')
          .goAway(3000);
      } finally {
        this.isSaving = false;
      }
      if (this.$store.getters.isAuthGet) {
        this.$toast.success('ورود با موفقیت انجام شد ').goAway(3500);
        this.$router.push('/home');
      }
    }
  }
};
</script>

<style scoped>
.help-text {
  margin-right: 1rem;
  font-size: 14px;
}
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
