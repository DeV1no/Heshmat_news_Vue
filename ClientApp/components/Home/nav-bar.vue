<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light" dir="rtl">
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
      <ul class="navbar-nav mr-5 ml-auto">
        <li class="nav-item active">
          <nuxt-link class="nav-link" active-class="active" to="/home"
            >خانه
          </nuxt-link>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">داغ ترین ها </a>
        </li>
        <li class="nav-item dropdown">
          <a
            class="nav-link dropdown-toggle"
            href="#"
            id="navbarDropdown"
            role="button"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >
            ویدئوها
          </a>
          <div class="dropdown-menu" aria-labelledby="navbarDropdown">
            <a class="dropdown-item" href="#">Action</a>
            <a class="dropdown-item" href="#">Another action</a>
            <div class="dropdown-divider"></div>
            <a class="dropdown-item" href="#">Something else here</a>
          </div>
        </li>
        <li class="nav-item dropdown">
          <a
            class="nav-link dropdown-toggle"
            href="#"
            id="navbarDropdown"
            role="button"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >
            سیاسی
          </a>
          <div class="dropdown-menu" aria-labelledby="navbarDropdown">
            <a class="dropdown-item" href="#">Action</a>
            <a class="dropdown-item" href="#">Another action</a>
            <div class="dropdown-divider"></div>
            <a class="dropdown-item" href="#">Something else here</a>
          </div>
        </li>
        <li class="nav-item dropdown">
          <a
            class="nav-link dropdown-toggle"
            href="#"
            id="navbarDropdown"
            role="button"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >
            فناوری
          </a>
          <div class="dropdown-menu" aria-labelledby="navbarDropdown">
            <a class="dropdown-item" href="#">Action</a>
            <a class="dropdown-item" href="#">Another action</a>
            <div class="dropdown-divider"></div>
            <a class="dropdown-item" href="#">Something else here</a>
          </div>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled" href="#">Disabled</a>
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
