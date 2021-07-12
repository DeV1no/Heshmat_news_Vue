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
                  <i class="fa fa-pencil"></i>
                  لیست اخبار

                  <nuxt-link
                    to="/admin/news/form"
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
                    :rows="news"
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
                            name: 'Admin-news-Form-id',
                            params: { id: props.row.id }
                          }"
                        >
                          <span class="text-primary fs-13">
                            <i class="fa fa-eye"></i>
                            مشاهده
                          </span>
                        </nuxt-link>

                        <nuxt-link
                          :to="{
                            name: 'Admin-news-Form-id mr-2',
                            params: { id: props.row.id }
                          }"
                        >
                          <span class="text-warning fs-13">
                            <i class="fa fa-edit"></i>
                            ویرایش
                          </span>
                        </nuxt-link>
                        <a
                          class="text-danger fs-13 mr-2"
                          @click.prevent="deleteRecord(props.row.newsId)"
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
          label: 'نام خبر',
          field: 'newsTitle'
        },
        {
          label: 'تاریخ انتشار',
          field: 'createdDate'
        },
        {
          label: 'نویسنده (نام کاربری)',
          field: 'userName'
        },
        {
          label: '',
          field: 'actions',
          sortable: false
        }
      ],
      news: []
    };
  },
  methods: {
    getNewsList() {
      axios.get('/api/news/NewsList').then(res => (this.news = res.data));
    },

    deleteRecord(id) {
      axios.delete(`/api/News/${id}`).then(res => {
        if (res.data) {
          this.$toast.success('خبر موردنظر با موفقیت حذف شد').goAway(4500);
          this.getNewsList();
        } else {
          this.$toast.error('خطای پیشبینی نشده ای رخ داده است').goAway(4500);
        }
      });
    }
  },
  mounted() {
    this.getNewsList();
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
