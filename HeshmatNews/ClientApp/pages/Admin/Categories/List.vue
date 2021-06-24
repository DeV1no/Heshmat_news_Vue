<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container-fluid">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto mt-3" dir="rtl">
            <div class="card-custom">
              <div class="card-header-custom">
                <div class="">
                  <i class="fa fa-list-alt"></i>
                  لیست گروه ها

                  <nuxt-link
                    to="/admin/categories/form"
                    class="btn btn-primary btn-sm float-left"
                  >
                    <i class="fa fa-plus"></i>
                    افزودن
                  </nuxt-link>
                </div>
              </div>
              <div class="card-body">
                <div>
                  <vue-good-table
                    :columns="columns"
                    :rows="categories"
                    :sort-options="{ enabled: true }"
                    :lineNumbers="true"
                    :pagination-options="{
                      enabled: true,
                      prevLabel: 'قبل',
                      nextLabel: 'بعد',
                      rowsPerPageLabel: 'تعداد رکورد'
                    }"
                    :search-options="{ enabled: true }"
                  >
                    <template slot="table-row" slot-scope="props">
                      <span v-if="props.column.field == 'actions'">
                        <nuxt-link
                          :to="{
                            name: 'Admin-Categories-Form-id',
                            params: { id: props.row.categoryId }
                          }"
                        >
                          <span class="text-primary fs-13">
                            <i class="fa fa-edit"></i>
                            ویرایش
                          </span>
                        </nuxt-link>

                        <a
                          class="text-danger fs-13 mr-2"
                          @click.prevent="deleteRecord(props.row.categoryId)"
                          href=""
                        >
                          <i class="fa fa-remove"></i>
                          حذف
                        </a>
                      </span>
                      <span v-else>
                        {{ props.formattedRow[props.column.field] }}
                      </span>
                    </template>

                    <div slot="emptystate">
                      <p class="text-center">
                        هیچگونه داده ای وجود ندارد :)
                      </p>
                    </div>
                  </vue-good-table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      columns: [
        {
          label: 'نام گروه',
          field: 'cateGoryName'
        },

        {
          label: '',
          field: 'actions',
          sortable: false
        }
      ],
      categories: []
    };
  },
  methods: {
    getCategoriesList() {
      axios.get('/api/categories').then(res => (this.categories = res.data));
    },

    deleteRecord(id) {
      axios.delete(`/api/categories/${id}`).then(res => {
        if (res.data > 0) {
          this.$toast.success('گروه موردنظر با موفقیت حذف شد').goAway(4500);
          this.getCategoriesList();
        }
        if (res.data == -2)
          this.$toast
            .error('امکان حذف این رکورد به دلیل وجود زیر گروه نمیباشد')
            .goAway(4500);
        if (res.data == -1) {
          this.$toast.error('خطای پیشبینی نشده ای رخ داده است').goAway(4500);
        }
      });
    }
  },
  mounted() {
    this.getCategoriesList();
  }
};
</script>

<style scoped>
body {
  background-color: gray !important;
}

.bg-danger {
  background-color: brown;
}
</style>
