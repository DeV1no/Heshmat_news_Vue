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
        <li class="nav-item dropdown" v-for="s in subCatDetails" :key="s.id">
          <a
            class="nav-link dropdown-toggle"
            href="#"
            id="navbarDropdown"
            role="button"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >
            {{ s.name }}
          </a>

          <div class="dropdown-menu" aria-labelledby="navbarDropdown">
            <a
              v-for="dt in s.category"
              :key="dt.id"
              class="dropdown-item"
              href="#"
              >{{ dt.name }}</a
            >
          </div>
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
      subCatLength: '',
      subCatDetails: []
    };
  },
  methods: {
    async getSubCat() {
      await axios.get(`/api/SubCategory/`).then(res => {
        this.subCatLength = res.data.totalItems;
        console.log(this.subCatLength);
      });

      this.subCatDetail();
    },
    async subCatDetail() {
      for (let i = 2; i <= 4; i++) {
        await axios.get(`/api/SubCategory/${i}`).then(res => {
          this.subCatDetails.push(res.data);
        });
      }
      console.log(this.subCatDetails);
    },
    logOut() {
      this.$store.dispatch('logOut');
      this.$store.state.auth.isAuth = false;
      this.$router.replace('/');
      console.log(this.$store.state.auth.isAuth);
    }
  },
  computed: {
    subCat: function() {
      return this.$store.getters.GetSubCategory;
    }
  },
  async mounted() {
    await this.getSubCat();
    this.$store.dispatch('GetSubcategoryAction');
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
