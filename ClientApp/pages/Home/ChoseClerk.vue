<template>
  <div>
    <section id="home-articles" class="py-2">
      <div class="container">
        <h4 class="text-info mt-4">انتخاب سردبیر</h4>
        <hr>
        <div class="row mt-5">
          <div
              class="card article-card col-md-4 mx-1"
              v-for="news in clerkNews"
              :key="news.newsId"
          >
            <div class="card-img">
              <img :src="news.poster" height="310px" alt="">
            </div>
            <div class="card-header ">
              <h6 class="text-muted">
                {{ news.newsTitle }}
              </h6>
            </div>
            <div class="cart-body mt-2">
              {{ news.newsBody }}
            </div>
            <button class="btn btn-outline-info text-center my-3">مشاهده خبر</button>
          </div>
        </div>
      </div>
    </section>

  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: "ChoseClerk",
  data() {
    return {
      clerkNews: []
    }
  },
  methods: {
    GetClerkNews() {
      axios.get("/api/news?PageSize=6").then(res => {
        this.clerkNews = res.data;
        console.log(this.clerkNews)
      })
    }
  },
  mounted() {
    this.GetClerkNews();
  }
}
</script>

<style scoped>
.card-header {
  background: inherit;
}

.cart-body {
  text-align: justify !important;
}

.article-card {
  box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
  transition: 0.5s;
}

.article-card:hover {
  box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
  transform: scale(1.01);
}
</style>