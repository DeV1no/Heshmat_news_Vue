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
                  <i class="fa fa-universal-access"></i>
                  مدیریت خبر
                </div>
                <div class="card-body">
                  <form class="mr-2">
                    <div class="row ">
                      <div class="col-md-12">
                        <div class="input-group mb-3">
                          <input
                            type="text"
                            class="form-control"
                            placeholder="عنوان خبر"
                            aria-label="عنوان خبر"
                            aria-describedby="basic-addon1"
                            v-model="mdl.NewsTitle"
                          />
                        </div>
                      </div>

                      <div class="col-md-6">
                        <div>
                          <label class="typo__label"> </label>
                          <multiselect
                            v-model="groupValue"
                            :options="groupOptions"
                            :custom-label="nameWithLang"
                            :multiple="true"
                            :close-on-select="false"
                            :clear-on-select="false"
                            :preserve-search="true"
                            :preselect-first="true"
                            @tag="addTag"
                            :taggable="true"
                            placeholder=" گروه را انتخاب کنید"
                            label="groupValue"
                            track-by="name"
                            @update="updateMultiValue"
                          ></multiselect>
                          {{ groupValue }}
                        </div>
                      </div>
                      <div class="col-md-6">
                        <div>
                          <label class="typo__label"> </label>
                          <multiselect
                            v-model="tagValue"
                            :options="tagOptions"
                            :custom-label="tagWithLang"
                            :multiple="true"
                            :close-on-select="false"
                            :clear-on-select="false"
                            :preserve-search="true"
                            :preselect-first="true"
                            @tag="addTag"
                            :taggable="true"
                            placeholder=" برچسب را انتخاب کنید"
                            label="tag"
                            track-by="name"
                            @update="updateMultiValue"
                          ></multiselect>
                          {{ tagValue }}
                        </div>
                      </div>
                      <div class="col-md-12">
                        <div class="form-group">
                          <label for="exampleFormControlTextarea1"
                            >متن خبر</label
                          >
                          <textarea
                            v-model="mdl.NewsBody"
                            class="form-control"
                            id="exampleFormControlTextarea1"
                            rows="3"
                          ></textarea>
                        </div>
                      </div>

                      <div class="custom-file mb-2">
                        <label class="custom-file-label " for="customFile"
                          >تصویر را انتخاب کنید</label
                        >
                        <input
                          type="file"
                          class="custom-file-input"
                          id="customFile"
                          @change="onFileSelected"
                        />
                      </div>
                    </div>

                    <nuxt-link
                      class="btn btn-danger float-left ml-1"
                      to="/admin/news"
                      >بازگشت</nuxt-link
                    >
                    <button
                      class="btn btn-success float-left "
                      @click.prevent="SubData"
                    >
                      ثبت اطلاعات
                    </button>
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
      subValue: [],
      subOptions: [],
      groupValue: [],
      tagValue: [],
      tagOptions: [],
      groupOptions: [],
      mdl: {
        NewsTitle: '',
        NewsBody: '',
        Poster: ''
      },
      TagsId: [],
      CategoriesId: []
    };
  },
  methods: {
    updateMultiValue(value) {
      this.roleArray = value;
    },
    addTag(newTag) {
      const tag = {
        name: newTag,
        code: newTag.substring(0, 2) + Math.floor(Math.random() * 10000000)
      };
      this.roleOptions.push(tag);
      this.roleArray.push(tag);
    },
    getSubGroups() {
      axios.get('/api/categories/getSubCategories').then(res => {
        this.groupOptions = res.data;
      });
    },
    getTags() {
      axios.get('/api/Tag/TagsList').then(res => (this.tagOptions = res.data));
    },
    nameWithLang({ cateGoryName }) {
      return `${cateGoryName}`;
    },
    tagWithLang({ tagName }) {
      return `${tagName}`;
    },
    onFileSelected(event) {
      this.mdl.Poster = event.target.files[0];
    },
    categoryIdMaker() {
      this.groupValue.forEach(q => {
        this.CategoriesId.push(q.categoryId);
      });
    },
    tagIdMaker() {
      this.tagValue.forEach(q => {
        this.TagsId.push(q.id);
      });
    },

    SubData() {
      this.tagIdMaker();
      this.categoryIdMaker();
      console.log(this.mdl);
      const form = new FormData();
      form.append('CategoriesId', this.CategoriesId);
      form.append('TagsId', this.TagsId);
      for (const property in this.mdl) {
        form.append(`${property}`, this.mdl[property]);
      }

      try {
        axios
          .post('/api/news/AddNews', form, {
            headers: {
              Authorization: ` Bearer ${this.token}`
            }
          })
          .then(res => {
            if (res.data > 0) {
              this.$toast.success('اطلاعات با موفقیت ثبت شد').goAway(4500);

              this.$router.push('/admin/news/list');
            } else {
              this.$toast
                .danger('خطای پیشبینی نشده ای رخ داده است ')
                .goAway(4500);
            }
          });
      } catch (err) {
        console.log(err);
      }
    }
  },
  mounted() {
    this.token = localStorage.getItem('token');
    this.getSubGroups();
    this.getTags();
  }
};
</script>

<style scoped></style>
