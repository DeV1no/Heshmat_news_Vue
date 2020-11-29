<template>
  <div class="container">
    <table class="table mt-5">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">عنوان</th>
          <th scope="col">دسته بندی</th>
        </tr>
      </thead>
      <tbody v-for="(post, index) in Posts" :key="post">
        <tr>
          <th scope="row">{{ index + 1 }}</th>
          <td>{{ post.title }}</td>
          <td>{{ post.badge }}</td>
          <td>
            <button class="btn btn-warning" @click="editor(index)">
              ویراش
            </button>
          </td>
          <td>
            <button class="btn btn-danger" @click="deleteRecipe(index)">
              حذف
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <button class="btn btn-success btn-lg my-2 mr-3">
      <router-link to="/PostData">افزودن پست جدید</router-link>
    </button>
    <form @submit.prevent="handleEdit" v-show="isEditMode">
      <div class="form-group">
        <label>
          <h4>ID</h4>
        </label>
        <input
          v-model="editData.id"
          type="text"
          class="form-control"
          readonly
        />
      </div>
      <div class="form-group">
        <label>
          <h4>موضوع</h4>
        </label>
        <input v-model="editData.title" type="text" class="form-control" />
      </div>
      <div>
        <select
          class="mdb-select md-form form-group w-75 py-2"
          v-model="editData.badge"
        >
          <option value="" disabled selected>یک دسته را انتخاب کنید </option>

          <option
            v-for="group in groupData"
            :key="group"
            :value="group.title"
            >{{ group.title }}</option
          >
        </select>
      </div>
      <div class="form-group">
        <label>
          <h4>توضیخ کوتاه</h4>
        </label>
        <textarea v-model="editData.shortPara" class="form-control" />
      </div>
      <div class="form-group">
        <label>
          <h4>شرح</h4>
        </label>
        <textarea v-model="editData.longPara" class="form-control" />
      </div>
      <div class="form-group">
        <label>
          <h4>لینک عکس</h4>
        </label>
        <input v-model="editData.img" type="text" class="form-control" />
      </div>
      <button class="btn btn-success btn-lg my-4" type="submit">ثبت</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isEditMode: false,
      PostData: this.$store.state,
      editData: {
        id: '',
        title: '',
        shortpara: '',
        longPara: '',
        badge: '',
        img: ''
      },
      id: null
    };
  },
  methods: {
    deleteRecipe(index) {
      console.log(index);
      this.$store.state.post.PostData.splice(index, 1);
    },
    editor(index) {
      console.log(index);
      this.id = index;
      this.isEditMode = true;
      this.editData.title = this.Posts[index].title;
      this.editData.shortPara = this.Posts[index].shortPara;
      this.editData.longPara = this.Posts[index].longPara;
      this.editData.img = this.Posts[index].img;
      this.editData.id = this.Posts[index].id;
    },
    handleEdit() {
      this.$store.state.post.PostData.splice(this.id, 1, this.editData);
    }
  },
  computed: {
    Posts() {
      return this.$store.getters.GetPosts;
    }
  }
};
</script>

<style></style>
