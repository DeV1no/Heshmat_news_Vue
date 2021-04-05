<template>
  <div>
    <nav-bar/>
    <chose-clerk/>
  </div>
</template>

<script>
import FooterApp from '../../components/Home/footer-app.vue';
import NavBar from '../../components/Home/nav-bar.vue';
import HomeGrid from './home-grid.vue';
import ChoseClerk from "@/pages/Home/ChoseClerk";

export default {
  components: {
    ChoseClerk,
    NavBar,
    FooterApp,
    HomeGrid
  },
  
  
};
</script>

<style scoped>

</style>
