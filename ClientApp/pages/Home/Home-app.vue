<template>
  <div class="home">
    <nav-bar />
    <home-slide />
    <chose-clerk />
  </div>
</template>

<script>
import FooterApp from '../../components/Home/footer-app.vue';
import NavBar from '../../components/Home/nav-bar.vue';
import HomeGrid from './home-grid.vue';
import ChoseClerk from '@/pages/Home/ChoseClerk';
import HomeSlide from './Home-slide.vue';

export default {
  components: {
    ChoseClerk,
    NavBar,
    FooterApp,
    HomeGrid,
    HomeSlide
  }
};
</script>

<style scoped></style>
