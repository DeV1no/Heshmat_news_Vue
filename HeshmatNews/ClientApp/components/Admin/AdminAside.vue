<template>
  <div dir="rtl">
    <div class="col-md-3 mt-3 mr-4">
      <div class="card text-center bg-primary text-white mb-3">
        <div class="card-body">
          <h3>اخبار</h3>
          <h4 class="display-4 ">
            <span class="d-block">
              <i class="fa fa-pencil "></i> {{ itemsCount.newsCount }}
            </span>
          </h4>
          <nuxt-link to="/admin/news/list" class="btn btn-outline-light btn-sm"
            >مشاهده</nuxt-link
          >
        </div>
      </div>
      <div class="card text-center bg-success text-white mb-3">
        <div class="card-body">
          <h3>گروه ها</h3>
          <h4 class="display-4 ">
            <span class="d-block">
              <i class="fa  fa-list-alt "></i>
              {{ itemsCount.categoryCount }}</span
            >
          </h4>
          <nuxt-link
            to="/admin/categories/list"
            class="btn btn-outline-light btn-sm"
            >مشاهده</nuxt-link
          >
        </div>
      </div>
      <div class="card text-center bg-warning text-white mb-3">
        <div class="card-body">
          <h3>نفش ها</h3>
          <h4 class="display-4 ">
            <span class="d-block">
              <i class="fa fa-universal-access"></i> {{ itemsCount.rolesCount }}
            </span>
          </h4>
          <nuxt-link to="/admin/roles/list" class="btn btn-outline-light btn-sm"
            >مشاهده</nuxt-link
          >
        </div>
      </div>
      <div class="card text-center bg-danger text-white mb-3">
        <div class="card-body">
          <h3>کاربران</h3>
          <h4 class="display-4">
            <i class="fa fa-users"></i> {{ itemsCount.userCount }}
          </h4>
          <nuxt-link to="/admin/users/list" class="btn btn-outline-light btn-sm"
            >مشاهده</nuxt-link
          >
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      itemsCount: {
        newsCount: null,
        categoryCount: null,
        rolesCount: null,
        userCount: null
      }
    };
  },
  methods: {
    async getItemsCount() {
      await axios
        .get('/api/admin/itemCounts')
        .then(res => (this.itemsCount = res.data));
    }
  },
  async mounted() {
    await this.getItemsCount();
  }
};
</script>

<style scoped>
.card {
  width: 200px;
}
.card-body {
  box-shadow: 5px 5px 5px 5px #888888;
  border-radius: 27px 0px 27px 0;
}
.card {
  transition: all 1s;
}
.card:hover {
  transform: scale(1.1);
}
</style>
