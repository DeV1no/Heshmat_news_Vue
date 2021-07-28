<template>
  <div class="container-fluid">
    <div class="row p-3">
      <div class="col-md-2">
        <top-post />
      </div>
      <div class="col-md-7">
        <newst-post />
      </div>
      <div class="col-md-3">
        <last-videos />
      </div>
    </div>
    <div class="col-md-12">
      <footer-app />
    </div>
  </div>
</template>

<script>
import NewstPost from '../../components/Home/NewstPost.vue';
import TopPost from '../../components/Home/TopPost.vue';
import LastVideos from '../../components/Home/LastVideos.vue';
import FooterApp from '../../components/Home/footer-app.vue';
export default {
  components: {
    TopPost,
    NewstPost,
    LastVideos,
    FooterApp
  }
};
</script>

<style></style>
