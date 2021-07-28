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
                <nuxt-link
                  :to="{
                    name: 'News-id',
                    params: { id: news.newsId }
                  }"
                >
                  <img class="thumbnail-img" :src="news.poster" alt="" />
                </nuxt-link>
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
                <nuxt-link
                  :to="{
                    name: 'News-id',
                    params: { id: news.newsId }
                  }"
                >
                  <h4 class="card-title">{{ news.newsTitle }}</h4>
                </nuxt-link>
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
                  {{ news.newsBody.substring(0, 500) + '...' }}
                </p>
                <div>
                  <nuxt-link
                    class="text-primary float-left"
                    :to="{
                      name: 'News-id',
                      params: { id: news.newsId }
                    }"
                  >
                    مشاهده
                  </nuxt-link>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-12 mt-3 mb-0">
          <nav aria-label="Page navigation example">
            <ul class="pagination justify-content-center">
              <li class="page-item">
                <a class="page-link" href="#">قبل</a>
              </li>
              <!-- <nuxt-link
                v-for="num in pagination"
                :to="{
                  name: 'Home-id',
                  params: { id: `${num}#newst-post` }
                }"
                class="page-link"
                active-class="active"
                :key="num"
              > -->
              <a
                class="page-link"
                v-for="num in pagination"
                :key="num"
                :href="`/Home/${num}#newst-post`"
              >
                <li class="page-item">
                  {{ num }}
                </li>
              </a>
              <!-- </nuxt-link> -->

              <li class="page-item ">
                <a class="page-link" href="#" tabindex="-1">بعد</a>
              </li>
            </ul>
          </nav>
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
      id: null,
      showItemInpage: 4,
      newsPost: [],
      totallNews: null,
      pagination: []
    };
  },
  methods: {
    GetNewstNews() {
      axios
        .get(`/api/news/NewsHomeList/${this.showItemInpage}/${this.id}`)
        .then(res => {
          this.newsPost = res.data;
        });
    },
    getTotallNews() {
      axios.get('/api/news/count').then(res => {
        this.totallNews = res.data;
        this.totallPageMaker();
      });
    },
    idMaker() {
      if (this.$route.params.id == null || this.$route.params.id == 1)
        this.id = 0;
      else this.id = this.$route.params.id;
    },
    totallPageMaker() {
      let pageNum = Math.ceil(this.totallNews / this.showItemInpage);
      this.pageMaker(pageNum);
    },

    pageMaker(p) {
      this.pagination = [];
      for (let i = 1; i <= p; i++) {
        this.pagination.push(i);
      }
    }
  },
  async mounted() {
    this.idMaker();
    await this.GetNewstNews();
    await this.getTotallNews();
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
.page-link {
  color: #333;
}
.active {
  background-color: rgb(55, 55, 211) !important;
  color: #fff !important;
}
</style>
