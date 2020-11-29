<template>
  <section id="home-articles" class="py-2">
    <div class="container">
      <h2>مشاهده نتایج دسته:</h2>
      <h3>{{ Group.title }}</h3>
    </div>
  </section>
</template>

<script>
export default {
  computed: {
    Group() {
      return this.$store.getters.group(parseInt(this.$route.params.Group));
    },

    groupSort() {
      return this.$store.getters.post();
    }
  }
};
</script>

<style>
/* <article class="card" v-for="post in Posts" :key="post">
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
      </article> */
</style>
