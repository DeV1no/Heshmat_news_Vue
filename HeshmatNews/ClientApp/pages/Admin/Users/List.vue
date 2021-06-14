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
                <i class="fa fa-users"></i>
                لیست کاربران
              </div>
              <div class="card-body">
                <div>
                  <vue-good-table
                    :columns="columns"
                    :rows="users"
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
                            name: 'Admin-Users-Role-id',
                            params: { id: props.row.id }
                          }"
                        >
                          <span class="text-primary fs-13">
                            <i class="fa fa-universal-access"></i>
                            مدیریت سطح دسترسی
                          </span>
                        </nuxt-link>
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
          label: 'نام کاربری',
          field: 'name'
        },
        {
          label: 'نام',
          field: 'name'
        },
        {
          label: 'نام خانوادگی',
          field: 'family'
        },
        {
          label: 'تاریخ ثبت نام',
          field: 'registerDate'
        },
        {
          label: 'وضعیت',
          field: this.statusChecker,
          tdClass: this.statusCheckerClass
        },

        {
          label: '',
          field: 'actions',
          sortable: false
        }
      ],
      users: []
    };
  },
  methods: {
    getUsersList() {
      axios.get('/api/User/getUserLsit').then(res => (this.users = res.data));
    },
    statusChecker(row) {
      if (row.isActive) return 'فعال';
      return 'غیر فعال';
    },
    statusCheckerClass(row) {
      if (row.isActive) return 'text-success mr-5 mt-2 ';
      return 'text-danger mr-5 mt-2 ';
    }
  },
  mounted() {
    this.getUsersList();
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
