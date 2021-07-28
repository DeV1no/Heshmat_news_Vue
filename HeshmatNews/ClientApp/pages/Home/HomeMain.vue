<template>
  <div class="container-fluid">
    <div class="row p-3">
      <div class="col-md-2">
        <top-post />
      </div>
      <div class="col-md-7">
        <transition name="fade">
          <newst-post id="newst-post" />
        </transition>
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

<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
</style>
