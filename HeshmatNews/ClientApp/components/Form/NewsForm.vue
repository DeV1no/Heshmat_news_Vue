<template>
  <div class="mt-3">
    <form class="mr-2">
      <div class="row ">
        <div class="col-md-6">
          <div class="input-group mb-3">
            <input
              type="text"
              class="form-control"
              placeholder="عنوان خبر"
              aria-label="عنوان خبر"
              aria-describedby="basic-addon1"
              v-model="newsData.NewsTitle"
            />
          </div>
        </div>
        <div class="col-md-6">
          <div class="input-group  ">
            <input
              type="text"
              class="form-control"
              placeholder="کلمات کلیدی"
              aria-label="کلمات کلیدی"
              aria-describedby="basic-addon1"
              v-model="newsData.Tags"
            />
          </div>
          <smal class="text-muted fs-11 mb-3 mr-1">
            کلمات کلیدی را با , جدا کنید
          </smal>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div>
            <label class="typo__label"></label>
            <multiselect
              v-model="subValue"
              :options="subOptions"
              :custom-label="nameWithLang"
              placeholder="سر گروه را انتخاب کنید "
              label="name"
              track-by="name"
            ></multiselect>
            <pre class="language-json"><code>{{ subValue  }}</code></pre>
          </div>
        </div>
        <div class="col-md-6">
          <div>
            <label class="typo__label"> </label>
            <multiselect
              v-model="groupValue"
              :options="groupOptions"
              :custom-label="nameWithLang"
              placeholder=" گروه را انتخاب کنید"
              label="name"
              track-by="name"
            ></multiselect>
            <pre class="language-json"><code>{{ groupValue  }}</code></pre>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="form-group">
            <label for="exampleFormControlTextarea1">متن خبر</label>
            <textarea
              v-model="newsData.NewsBody"
              class="form-control"
              id="exampleFormControlTextarea1"
              rows="3"
            ></textarea>
          </div>
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

      <nuxt-link class="btn btn-danger float-left ml-1" to="/admin/news"
        >بازگشت</nuxt-link
      >
      <button class="btn btn-success float-left " @click.prevent="SubData">
        ثبت اطلاعات
      </button>
    </form>
  </div>
</template>

<script>
import Multiselect from 'vue-multiselect';
import axios from 'axios';
export default {
  components: {
    Multiselect
  },
  data() {
    return {
      subValue: '',
      subOptions: [],
      groupValue: '',
      groupOptions: [],
      newsData: {
        NewsTitle: '',
        NewsBody: '',
        Tags: '',
        Poster: '',
        CategoryId: '',
        SubGroup: ''
      }
    };
  },
  methods: {
    GetSubGroups() {
      axios.get('/api/categories/getSubCategories').then(res => {
        res.data.forEach(c => {
          let cItems = {
            categoryId: '',
            categoryName: ''
          };
          cItems.categoryId = c.categoryId;
          cItems.categoryName = c.cateGoryName;
          this.subOptions.push(cItems);
        });
      });
    },
    GetGroups() {
      axios.get('/api/categories').then(res => {
        res.data.forEach(c => {
          let cItems = {
            categoryId: '',
            categoryName: ''
          };
          cItems.categoryId = c.categoryId;
          cItems.categoryName = c.cateGoryName;
          this.groupOptions.push(cItems);
        });
      });
    },
    nameWithLang({ categoryName }) {
      return `${categoryName}`;
    },
    onFileSelected(event) {
      this.newsData.Poster = event.target.files[0];
    },
    SubData() {
      this.newsData.CategoryId = this.groupValue.categoryId;
      this.newsData.SubGroup = this.subValue.categoryId;
      const form = new FormData();
      for (const property in this.newsData) {
        form.append(`${property}`, this.newsData[property]);
      }
      try {
        axios.post('/api/news', form).then(res => {
          console.log(res.data);
          this.$router.push('admin/news');
        });
      } catch (err) {
        console.log(err);
      }
    }
  },
  mounted() {
    this.GetSubGroups();
    this.GetGroups();
  }
};
</script>

<style scoped></style>
