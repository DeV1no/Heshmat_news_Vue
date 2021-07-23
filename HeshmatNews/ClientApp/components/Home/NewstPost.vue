<template>
  <div class="px-3">
    <h4 class=" mt-4 customTitle">
      جدید ترین اخبار
    </h4>
    <div class="post-card">
      <div class="row">
        <div class="col-12 mt-1">
          <div class="card mt-1" v-for="news in newsPost" :key="news.newsId">
            <div class="card-horizontal">
              <div class="img-square-wrapper">
                <img class="thumbnail-img" :src="news.poster" alt="" />
                <div class="topicCategories">
                  <a
                    href=""
                    v-for="cat in news.categories"
                    :key="cat.categoryId"
                    ><label style="cursor:pointer">
                      {{ cat.cateGoryName }}
                    </label></a
                  >
                </div>
              </div>
              <div class="card-body">
                <h4 class="card-title">{{ news.newsTitle }}</h4>

                <div class="d-flex news-info text-muted">
                  <span>
                    <i class="fa fa-user "></i>
                    {{ news.name + ' ' + news.family }}
                  </span>

                  <span class="mr-2">
                    <i class="fa fa-calendar "></i>
                    {{ news.createdDate }}
                  </span>
                  <span class="mr-auto ml-3">
                    <i class="fa fa-comment"></i>
                    12
                  </span>
                </div>
                <hr />
                <p class="card-text">
                  {{ news.newsBody }}
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="overflow-auto"></div>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      newsPost: []
    };
  },
  methods: {
    GetNewstNews() {
      axios.get('/api/news/NewsHomeList/2/0').then(res => {
        this.newsPost = res.data;
      });
    }
  },
  mounted() {
    this.GetNewstNews();
  }
};
</script>

<style scoped>
.card-horizontal {
  display: flex;
  flex: 1 1 auto;
}
.news-info {
  font-size: 11px;
}
.card-text {
  font-size: 14px;
  text-align: justify;
}
.card {
  box-shadow: rgba(0, 0, 0, 0.15) 1.95px 1.95px 2.6px;
}
.thumbnail-img {
  width: 250px !important;
  height: 250px !important;
}
</style>
