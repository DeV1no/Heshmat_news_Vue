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
                  اطلاعات خبر
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
                            v-model="mdl.newsTitle"
                          />
                        </div>
                      </div>
                      <div class="col-md-12">
                        <div class="form-check">
                          <label
                            class="form-check-label"
                            for="flexCheckDefault"
                          >
                            انتخاب سردبیر
                          </label>
                          <input
                            class="form-check-input mr-2"
                            type="checkbox"
                            v-model="mdl.isChoseClerck"
                            id="isChoseClerck"
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
                        </div>
                      </div>
                      <div class="col-md-12">
                        <div class="form-group">
                          <label for="exampleFormControlTextarea1"
                            >متن خبر</label
                          >
                          <textarea
                            v-model="mdl.newsBody"
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
                    <div class="previewImage">
                      <img :src="previewImage" class="img-fluid" />
                    </div>
                    <div class="row">
                      <div class="col-md-12 mt-4">
                        <nuxt-link
                          class="btn btn-danger ml-1"
                          to="/admin/news/List"
                        >
                          <i class="fa fa-undo"></i>
                          بازگشت</nuxt-link
                        >
                        <button
                          class="btn btn-success "
                          @click.prevent="SubData"
                        >
                          <i class="fa fa-save"></i>
                          ثبت اطلاعات
                        </button>
                      </div>
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
      subValue: [],
      subOptions: [],
      groupValue: [],
      tagValue: [],
      tagOptions: [],
      groupOptions: [],
      mdl: {
        newsTitle: '',
        newsBody: '',
        poster: '',
        isChoseClerck: false
      },
      previewImage: null,
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
      this.mdl.poster = event.target.files[0];
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
      const form = new FormData();
      form.append('CategoriesId', this.CategoriesId);
      form.append('TagsId', this.TagsId);
      for (const property in this.mdl) {
        form.append(`${property}`, this.mdl[property]);
      }

      try {
        let ax;
        if (!this.isEditMode)
          ax = axios.post('/api/news/AddNews', form, {
            headers: {
              Authorization: ` Bearer ${this.token}`
            }
          });
        else
          ax = axios.put(`/api/news/${this.id}`, form, {
            headers: {
              Authorization: ` Bearer ${this.token}`
            }
          });
        ax.then(res => {
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
    },
    editModeChecker() {
      if (this.id) this.isEditMode = true;
    },
    getSaveData() {
      axios.get(`/api/news/SaveDTO/${this.id}`).then(res => {
        this.mdl = res.data;
        this.previewImage = res.data.poster;
        this.mdl.poster = '';
      });
    }
  },
  async mounted() {
    this.token = localStorage.getItem('token');
    this.editModeChecker();
    this.getSubGroups();
    this.getTags();
    if (this.isEditMode) {
      await this.getSaveData();
    }
  }
};
</script>

<style scoped>
.previewImage {
  max-height: 480px;
  max-width: 950px;
  margin: 2rem auto 2rem auto;
}
</style>
