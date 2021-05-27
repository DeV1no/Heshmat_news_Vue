<template>
  <div class="home">
    <nav-bar />
    <home-slide />
    <chose-clerk />
    <home-main />
  </div>
</template>

<script>
import FooterApp from '../../components/Home/footer-app.vue';
import NavBar from '../../components/Home/nav-bar.vue';
import ChoseClerk from '@/pages/Home/ChoseClerk';
import HomeSlide from './Home-slide.vue';
import HomeMain from './HomeMain.vue';

export default {
  components: {
    ChoseClerk,
    NavBar,
    FooterApp,

    HomeSlide,
    HomeMain
  }
};
</script>

<style scoped></style>
