<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container-fluid">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <UserRegisterByDateChart />
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>

<script>
import UserRegisterByDateChart from '../../components/Charts/UserRegisterByDateChart.vue';
export default {
  components: {
    UserRegisterByDateChart
  }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}
</style>
