<template>
  <nav id="main-nav">
    <div>
      <div class="container">
        <ul>
          <li>
            <router-link
              tag="button"
              to="/"
              active-class="corrent"
              exact
              class="btn btn-danger mx-1"
              >خانه</router-link
            >
          </li>
          <li>
            <router-link
              to="/AboutUs"
              active-class="corrent"
              class="btn btn-danger mx-1"
              >درباره ما</router-link
            >
          </li>
          <li v-if="!this.$store.state.auth.isAuth">
            <router-link
              to="/SignIn"
              active-class="corrent"
              class="btn btn-danger mx-1"
              >ورود/ثبت نام</router-link
            >
          </li>
          <li v-if="this.$store.state.auth.isAuth">
            <div class="dropdown">
              <button
                class="btn btn-danger dropdown-toggle"
                type="button"
                id="dropdownMenuMenu"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >
                پنل مدیریت
              </button>
              <div class="dropdown-menu" aria-labelledby="dropdownMenuMenu">
                <button class="dropdown-item" type="button">
                  <router-link to="/UserPanel">
                    مدیریت کاربران
                  </router-link>
                </button>
                <button class="dropdown-item" type="button">
                  <router-link to="/SliderPanel">
                    مدیریت اسلایدر
                  </router-link>
                </button>
                <button class="dropdown-item" type="button">
                  <router-link to="/PostPanel">
                    مدیریت پست ها
                  </router-link>
                </button>

                <button class="dropdown-item" type="button">
                  <router-link to="/GroupPanel">
                    مدیریت دسته بندی ها
                  </router-link>
                </button>

                <button
                  class="dropdown-item"
                  type="button"
                  @click.prevent="logOut"
                >
                  خروج
                </button>
              </div>
            </div>
          </li>
        </ul>

        <div class="social">
          <a href="facebook.com" target="_blank"
            ><i class="fab fa-facebook fa-2x"></i
          ></a>
          <a href="twitter.com" target="_blank"
            ><i class="fab fa-twitter fa-2x"></i
          ></a>
          <a href="instagram.com" target="_blank"
            ><i class="fab fa-instagram fa-2x"></i
          ></a>
          <a href="youtube.com" target="_blank"
            ><i class="fab fa-youtube fa-2x"></i
          ></a>
        </div>
        <img src="img/logo.png" alt="حشمت نیوز" class="logo" />
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  methods: {
    logOut() {
      this.$store.dispatch('logOut');
      this.$store.state.auth.isAuth = false;
      this.$router.replace('/');
      console.log(this.$store.state.auth.isAuth);
    }
  }
};
</script>

<style scoped>
.dropdown-menu.show {
  z-index: 999999;
  position: relative !important;
  display: contents;
}
</style>
