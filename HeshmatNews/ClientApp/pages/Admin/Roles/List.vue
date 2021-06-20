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
                  <i class="fa fa-universal-access"></i>
                  لیست نقش ها

                  <nuxt-link
                    to="/admin/roles/form"
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
                    :rows="roles"
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
                            name: 'Admin-Roles-Form-id',
                            params: { id: props.row.id }
                          }"
                        >
                          <span class="text-primary fs-13">
                            <i class="fa fa-universal-access"></i>
                            مدیریت سطح دسترسی
                          </span>
                        </nuxt-link>

                        <a
                          class="text-danger fs-13 mr-2"
                          @click.prevent="deleteRecord(props.row.id)"
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
          label: 'نام',
          field: 'roleName'
        },

        {
          label: '',
          field: 'actions',
          sortable: false
        }
      ],
      roles: []
    };
  },
  methods: {
    getRolesList() {
      axios.get('/api/Role').then(res => (this.roles = res.data));
    },
    statusChecker(row) {
      if (row.isActive) return 'فعال';
      return 'غیر فعال';
    },
    statusCheckerClass(row) {
      if (row.isActive) return 'text-success mr-5 mt-2 ';
      return 'text-danger mr-5 mt-2 ';
    },
    deleteRecord(id) {
      axios.delete(`/api/Role/${id}`).then(res => {
        if (res.data) {
          this.$toast.success('نقش موردنظر با موفقیت حذف شد').goAway(4500);
          this.getRolesList();
        } else {
          this.$toast.error('خطای پیشبینی نشده ای رخ داده است').goAway(4500);
        }
      });
    }
  },
  mounted() {
    this.getRolesList();
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
