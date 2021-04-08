<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container">
        <div class="row">
          <admin-side />
          <div class="col-md-8 ml-auto" dir="rtl">
            <news-form />
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>

<script>
import AdminFooter from '../../../components/Admin/AdminFooter';
import AdminNav from '../../../components/Admin/AdminNav';
import AdminSide from '../../../components/Admin/AdminAside';
import NewsForm from '../../../components/Form/NewsForm.vue';
export default {
  components: { AdminNav, AdminFooter, AdminSide, NewsForm }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}
</style>
