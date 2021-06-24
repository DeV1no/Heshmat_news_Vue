<template>
  <div>
    <admin-nav />
    <section id="posts" class="bg-light">
      <div class="container-fluid">
        <div class="row">
          <admin-side />
          <div class="col-md-9 ml-auto" dir="rtl">
            <div class="mt-3">
              <div class="card-custom">
                <div class="card-header-custom">
                  <i class="fa fa-bars"></i>
                  مدیریت گروه
                </div>
                <div class="card-body">
                  <form class="mr-2">
                    <div class="row">
                      <div class="col-md-6">
                        <label for="basic-url">نام گروه</label>
                        <div class="input-group mb-3">
                          <div class="input-group-prepend"></div>
                          <input
                            type="text"
                            class="form-control"
                            name="cateGoryName"
                            v-model="mdl.cateGoryName"
                          />
                        </div>
                      </div>

                      <div class="col-md-6">
                        <div>
                          <label for="basic-url">نام سرگروه</label>
                          <multiselect
                            v-model="categoryValue"
                            :options="parentCategories"
                            :custom-label="nameWithLang"
                            :multiple="false"
                            :close-on-select="false"
                            :clear-on-select="false"
                            :preserve-search="true"
                            :preselect-first="true"
                            @tag="addTag"
                            :taggable="false"
                            placeholder="سر گروه را انتخاب کنید "
                            label="name"
                            track-by="name"
                            @update="updateMultiValue"
                          ></multiselect>
                        </div>
                      </div>
                    </div>
                    <div class="mt-4">
                      <nuxt-link
                        class="btn btn-danger ml-1"
                        to="/admin/categories/list"
                      >
                        <i class="fa fa-undo"></i>
                        بازگشت</nuxt-link
                      >
                      <button class="btn btn-success " @click.prevent="SubData">
                        <i class="fa fa-save"></i>
                        ثبت اطلاعات
                      </button>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <admin-footer />
    <loading v-if="isSaving" />
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      token: null,
      id: this.$route.params.id,
      isEditMode: false,
      isSaving: false,
      categoryValue: [],
      parentCategories: [],

      mdl: {
        cateGoryName: null,
        parentId: null,
        categoryId: null
      },
      sData: {
        categoryId: null,
        cateGoryName: null,
        parentId: null
      }
    };
  },
  methods: {
    getSaveData() {
      axios.get(`/api/categories/${this.id}`).then(res => {
        this.mdl = res.data;
        this.nameWithLang(res.data.cateGoryName);
      });
    },
    updateMultiValue(value) {
      this.categoryValue = value;
    },
    getParentCategories() {
      axios
        .get('/api/categories/getParentCategories')
        .then(res => (this.parentCategories = res.data));
    },
    addTag(newTag) {
      const tag = {
        name: newTag,
        code: newTag.substring(0, 2) + Math.floor(Math.random() * 10000000)
      };
      this.parentCategories.push(tag);
      this.categoryValue.push(tag);
    },
    parentMaker() {
      if (this.categoryValue.categoryId != null) {
        this.mdl.parentId = this.categoryValue.categoryId;
      }
    },
    getRoles() {
      axios.get('/api/Role').then(res => {
        res.data.forEach(c => {
          let rItems = {
            id: '',
            roleName: ''
          };
          rItems.id = c.id;
          rItems.roleName = c.roleName;
          this.parentCategories.push(rItems);
        });
      });
    },

    nameWithLang({ cateGoryName }) {
      return `${cateGoryName}`;
    },
    editModeChecker() {
      if (this.id != null) this.isEditMode = true;
    },
    SubData() {
      this.parentMaker();
      console.log(this.mdl.parentId);
      try {
        this.isSaving = true;
        let ax;
        if (this.isEditMode)
          ax = axios.put(
            '/api/categories',

            this.mdl,
            {
              headers: {
                Authorization: ` Bearer ${this.token}`
              }
            }
          );
        else
          ax = axios.post(
            '/api/categories',

            this.mdl,
            {
              headers: {
                Authorization: ` Bearer ${this.token}`
              }
            }
          );

        ax.then(res => {
          if (res.data) {
            this.$toast.success('اطلاعات با موفقیت ثبت شد').goAway(4500);
            this.$router.push('/admin/categories/list');
          }
        });
      } catch (err) {
        console.log(err);
        this.$toast.error('خطای پیشبینی نشده ای رخ داده است').goAway(4500);
      } finally {
        this.isSaving = false;
      }
    }
  },
  async mounted() {
    this.token = localStorage.getItem('token');
    this.editModeChecker();
    await this.getParentCategories();
    if (this.isEditMode) {
      this.getSaveData();
    }
  }
};
</script>

<style scoped></style>
