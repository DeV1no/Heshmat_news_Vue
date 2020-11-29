<template>
  <div class="signup-form">
    <form action="/examples/actions/confirmation.php">
      <h2>ثبت نام</h2>
      <p class="hint-text">
        به طور رایگان حساب کاربری بسازید
      </p>

      <input
        type="text"
        class=" form-group mr-3 form-control"
        :class="{ 'red-border': formIsValid }"
        placeholder=" نام کاربری"
        v-model="user.id"
      />

      <input
        type="text"
        class=" form-group mr-3 form-control"
        v-model="user.name"
        placeholder="نام"
        :class="{ 'red-border': formIsValid }"
      />

      <input
        type="text"
        class="form-group mr-3 form-control"
        placeholder="نام خانوادگی"
        v-model="user.lastname"
        :class="{ 'red-border': formIsValid }"
      />

      <div class="form-group">
        <input
          type="text"
          class="form-control"
          placeholder="پست الکترونیکی"
          v-model="user.email"
          :class="{ 'red-border': formIsValid }"
        />
      </div>

      <div class="form-group">
        <input
          type="password"
          class="form-control"
          v-model="user.password"
          placeholder="رمز عبور"
          :class="{ 'red-border': formIsValid }"
        />
      </div>
      <div class="form-group">
        <input
          type="password"
          class="form-control"
          v-model="user.confirm_password"
          placeholder="تکرار رمز عبور"
          :class="{ 'red-border': formIsValid }"
        />
      </div>
      <div class="form-group">
        <label class="checkbox-inline"
          ><input type="checkbox" v-model="user.isAgree" /> موافقت با
          <a href="#">شرایط</a> و <a href="#">قوانین</a></label
        >
      </div>
      <div class="form-group">
        <p v-show="formIsValid" class="text-danger">
          لطفا تمامی فیلد ها را چک کنید !
        </p>
        <button
          type="submit"
          class="btn btn-success btn-lg btn-block"
          @click.prevent="submitUser"
        >
          ثبت نام
        </button>
      </div>
    </form>
    <div class="text-center">
      حساب کاربری دارید ؟ <router-link to="/SignIn">فرم ورود</router-link>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      formIsValid: false,
      dataNotValid: false,
      user: {
        id: '',
        name: '',
        email: '',
        lastname: '',
        password: '',
        confirm_password: '',
        isAgree: false
      }
    };
  },
  methods: {
    submitUser() {
      this.formIsValid = false;
      this.formValid();
      if (this.dataNotValid) {
        return;
      }
      this.$store.state.user.userData.push(this.user);
      this.$store.dispatch('signup', {
        email: this.user.email,
        password: this.user.password
      });
    },
    formValid() {
      if (
        !this.user.id ||
        !this.user.name ||
        !this.user.email ||
        !this.user.lastname ||
        !this.user.password ||
        !this.user.confirm_password ||
        !this.user.isAgree
      ) {
        this.formIsValid = true;
        this.dataNotValid = true;
        return;
      }
      if (this.user.password !== this.user.confirm_password) {
        this.formIsValid = true;
        this.dataNotValid = true;
      }
    }
  }
};
</script>

<style scoped>
.red-border {
  border-color: red !important;
}

.form-control {
  height: 40px;
  box-shadow: none;
  color: #969fa4;
}
.form-control:focus {
  border-color: #5cb85c;
}
.form-control,
.btn {
  border-radius: 3px;
}
.signup-form {
  width: 400px;
  margin: 0 auto;
  padding: 30px 0;
}
.signup-form h2 {
  color: #636363;
  margin: 0 0 15px;
  position: relative;
  text-align: center;
}
.signup-form h2:before,
.signup-form h2:after {
  content: '';
  height: 2px;
  width: 30%;
  background: #d4d4d4;
  position: absolute;
  top: 50%;
  z-index: 2;
}
.signup-form h2:before {
  left: 0;
}
.signup-form h2:after {
  right: 0;
}
.signup-form .hint-text {
  color: #999;
  margin-bottom: 30px;
  text-align: center;
}
.signup-form form {
  color: #999;
  border-radius: 3px;
  margin-bottom: 15px;
  background: #f2f3f7;
  box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
  padding: 30px;
}
.signup-form .form-group {
  margin-bottom: 20px;
}
.signup-form input[type='checkbox'] {
  margin-top: 3px;
}
.signup-form .btn {
  font-size: 16px;
  font-weight: bold;
  min-width: 140px;
  outline: none !important;
}
.signup-form .row div:first-child {
  padding-right: 10px;
}
.signup-form .row div:last-child {
  padding-left: 10px;
}
.signup-form a {
  color: black;
  text-decoration: underline;
}
.signup-form a:hover {
  text-decoration: none;
}
.signup-form form a {
  color: #5cb85c;
  text-decoration: none;
}
.signup-form form a:hover {
  text-decoration: underline;
}
</style>
