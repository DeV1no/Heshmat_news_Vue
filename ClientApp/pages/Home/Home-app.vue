<template>
  <div>
    <nav-bar />
    <section id="home-articles" class="py-2">
      <div class="container">
        <h3>انتخاب سردبیر</h3>
        <div class="articles-container">
          <div class="row">
            <article class="card col-md-12">
              <img src="" alt="" />
              <div>
                <div class="category category-ent">سرگرمی</div>
                <h3>
                  <a href="Article.html">جدید ترین اخبار تکنولوژی و غیره</a>
                </h3>
                <p>
                  سونی بعد از مدت‌ها حدس و گمان، شب گذشته از ظاهر و طراحی جدید
                  پلی استیشن 5 و پلی استیشن 5 دیجیتال در رویداد آنلاین رونمایی
                  از بازی‌های PS5‌ پرده برداشت.
                </p>
              </div>
            </article>
          </div>

          <article class="card" v-for="post in Posts" :key="post">
            <img :src="post.img" alt="" />
            <div>
              <div class="category category-tech">{{ post.badge }}</div>
              <h3>
                <router-link :to="{ name: 'Article', params: { id: post.id } }"
                  >{{ post.title }}
                </router-link>
              </h3>
              <p>
                {{ post.shortPara }}
              </p>
            </div>
          </article>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import FooterApp from '../../components/Home/footer-app.vue';
import NavBar from '../../components/Home/nav-bar.vue';
import HomeGrid from './home-grid.vue';
export default {
  components: {
    NavBar,
    FooterApp,
    HomeGrid
  },
  computed: {
    Posts() {
      return this.$store.getters.GetPosts;
    }
  }
};
</script>

<style></style>
