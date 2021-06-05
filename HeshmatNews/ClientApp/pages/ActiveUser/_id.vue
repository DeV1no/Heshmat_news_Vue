<template>
  <div>
    <div
      class="card text-white bg-success mt-3 col-md-11 mr-5"
      v-if="activeStatus == 1"
    >
      <div class="card-header">حساب کاربری شما با موفقیت فعال شد</div>
      <div class="card-body">
        <p class="card-tex d-flex">
          برای ورود به حساب کاربریتان
          <nuxt-link class="mx-1" exact to="/login">اینجا </nuxt-link>
          کلیک کنید
        </p>
        <nuxt-link class="btn btn-primary float-left" to="/home">
          <i class="fa fa-home"></i>
          خانه
        </nuxt-link>
      </div>
    </div>
    <div
      class="card text-dark bg-warning mt-3 col-md-11 mr-5"
      v-if="activeStatus == -2"
    >
      <div class="card-header">حساب کاربری شما از پیش فعال شده است</div>
      <div class="card-body">
        <p class="card-tex d-flex">
          برای ورود به حساب کاربریتان
          <nuxt-link class="mx-1 text-white" exact to="/login"
            >اینجا
          </nuxt-link>
          کلیک کنید
        </p>
        <nuxt-link class="btn btn-primary float-left" to="/home">
          <i class="fa fa-home"></i>
          خانه
        </nuxt-link>
      </div>
    </div>
    <div
      class="card text-white bg-danger mt-3 col-md-11 mr-5"
      v-if="activeStatus == -1"
    >
      <div class="card-header">حساب کاربری یافت نشد</div>
      <div class="card-body">
        <p class="card-tex d-flex">
          برای ثبت نام در حشمت نیوز
          <nuxt-link class="mx-1" exact to="/register">اینجا </nuxt-link>
          کلیک کنید
        </p>
        <nuxt-link class="btn btn-primary float-left" to="/home">
          <i class="fa fa-home"></i>
          خانه
        </nuxt-link>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      secretCode: this.$route.params.id,
      activeStatus: null
    };
  },

  methods: {
    async activeUserBySecretCode() {
      await axios
        .post(`/api/User/activeUserBySecretCode?secretCode=${this.secretCode}`)
        .then(res => {
          this.activeStatus = res.data;
        });
    }
  },
  mounted() {
    this.activeUserBySecretCode();
  }
};
</script>

<style></style>
