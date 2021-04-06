<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark" dir="rtl">
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
          <a class="nav-link" href="#">داشبورد مدیر </a>
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
import axios from 'axios';

export default {
  data() {
    return {
      subCategory: []
    };
  },
  methods: {
    async GetSubCategories() {
      await axios.get(`/api/categories/getSubCategories`).then(res => {
        this.subCategory = res.data;
        console.log(this.subCategory);
      });
    },

    logOut() {
      this.$store.dispatch('logOut');
      this.$store.state.auth.isAuth = false;
      this.$router.replace('/');
      console.log(this.$store.state.auth.isAuth);
    }
  },
  computed: {},
  async mounted() {
    await this.GetSubCategories();
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
