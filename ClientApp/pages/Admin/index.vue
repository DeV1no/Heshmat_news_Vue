<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl"></div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>

<script>
import AdminFooter from '../../components/Admin/AdminFooter';
import AdminNav from '../../components/Admin/AdminNav';
import AdminSide from '../../components/Admin/AdminAside';
export default {
  components: { AdminNav, AdminFooter, AdminSide }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}
</style>
