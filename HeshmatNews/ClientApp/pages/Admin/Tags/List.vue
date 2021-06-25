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
                  <i class="fa fa-tags"></i>
                  لیست برچسب ها
                </div>
              </div>
              <div class="card-body">
                <div>
                  <vue-good-table
                    :columns="columns"
                    :rows="tags"
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
                        <span
                          class="corsur-pointer"
                          @click="openTagModal(props.row.id)"
                        >
                          <span class="text-primary fs-13">
                            <i class="fa fa-edit"></i>
                            ویرایش
                          </span>
                        </span>

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
    <!-- Edit Modal -->
    <b-modal
      id="tagModal"
      ref="tagModal"
      title="افزودن برچسب"
      @show="resetModal"
      @hidden="resetModal"
      @ok="editTag"
    >
      <form class="mr-2">
        <div class="row">
          <div class="col-md-12">
            <label for="basic-url">عنوان برچسب</label>
            <div class="input-group mb-3">
              <div class="input-group-prepend"></div>
              <input
                type="text"
                class="form-control"
                name="cateGoryName"
                v-model="mdl.tagName"
              />
            </div>
          </div>
        </div>
      </form>
    </b-modal>

    <admin-footer />
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      mdl: {
        id: null,
        tagName: null
      },
      columns: [
        {
          label: 'نام برچسب',
          field: 'tagName'
        },
        {
          label: 'تعداد استفاده',
          field: 'useCount'
        },
        {
          label: '',
          field: 'actions',
          sortable: false
        }
      ],
      tags: []
    };
  },
  methods: {
    getTagsList() {
      axios.get('/api/Tag/TagsList').then(res => (this.tags = res.data));
    },

    deleteRecord(id) {
      axios.delete(`/api/Tag/RemoveTag/${id}`).then(res => {
        if (res.data > 0) {
          this.$toast.success('برچسب موردنظر با موفقیت حذف شد').goAway(4500);
          this.getTagsList();
        }
        if (res.data == -2)
          this.$toast
            .error('امکان حذف این رکورد به دلیل وجود زیر گروه نمیباشد')
            .goAway(4500);
        if (res.data == -1) {
          this.$toast.error('خطای پیشبینی نشده ای رخ داده است').goAway(4500);
        }
      });
    },
    editTag() {
      axios.put('/api/Tag/UpdateTag', this.mdl).then(res => {
        if (res.data > 0) {
          this.$toast.success('اطلاعات با موفقیت ثبت شد').goAway(4500);
          this.$refs.tagModal.hide();
          this.getTagsList();
        } else this.$toast.error('لطفا نام برچسب را وارد نمایید').goAway(4500);
      });
    },
    resetModal() {
      this.mdl.tagName = null;
    },
    openTagModal(id) {
      axios.get(`/api/Tag/GetTag/${id}`).then(res => (this.mdl = res.data));
      this.$refs.tagModal.show();
    }
  },
  mounted() {
    this.getTagsList();
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
