<template>
  <section id="about" v-if="post">
    <div class="container">
      <div class="page-container">
        <article class="card">
          <img :src="post.img" alt="" />
          <h1 class="l-heading">
            {{ post.title }}
          </h1>

          <div class="meta">
            <small> <i class="fas fa-user"></i> نوشته شده توسط آقا حشمت </small>
            <div class="category category-ent">
              {{ post.badge }}
            </div>
            <h5>{{ post.shortPara }}</h5>
            <p>
              {{ post.longPara }}
            </p>
          </div>
        </article>
        <aside id="categories" class="card">
          <h2>دسته بندی ها</h2>
          <ul class="list">
            <li v-for="group in Groups" :key="group">
              <router-link :to="{ name: 'Group', params: { Group: group.id } }"
                ><i class="fas fa-chevron-left">{{
                  group.title
                }}</i></router-link
              >
            </li>
          </ul>
        </aside>
        <aside class="card bg-secondary">
          <h2>به ما بپیوندید</h2>
          <p>با عضویت در باشگاه اطلاع رسانی ما همواره به روز باشید</p>
          <a href="#" class="btn btn-dark btn-block "
            >همین حالا ثبت نام کنید !</a
          >
        </aside>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      Groups: this.$store.state.groups.Groups
      // this.$store.state.post.PostData
    };
  },
  computed: {
    post() {
      return this.$store.getters.post(parseInt(this.$route.params.id));
    }
  }
};
</script>

<style></style>
