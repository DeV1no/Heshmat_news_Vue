<template>
  <div class="container">
    <form @submit.prevent="handleSubmit">
      <div class="form-group">
        <label>
          <h4>موضوع</h4>
        </label>
        <input v-model="postData.title" type="text" class="form-control" />
      </div>
      <div>
        <select
          class="mdb-select md-form form-group w-75 py-2"
          v-model="postData.badge"
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
        <textarea v-model="postData.shortPara" class="form-control" />
      </div>
      <div class="form-group">
        <label>
          <h4>شرح</h4>
        </label>
        <textarea v-model="postData.longPara" class="form-control" />
      </div>
      <div class="form-group">
        <label>
          <h4>لینک عکس</h4>
        </label>
        <input v-model="postData.img" type="text" class="form-control" />
      </div>
      <button class="btn btn-success btn-lg my-4" type="submit">ثبت</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      postData: {
        id: this.$store.state.post.id,
        title: '',
        shortPara: '',
        longPara: '',
        badge: '',
        img: ''
      },
      groupData: this.$store.state.groups.Groups
    };
  },

  methods: {
    handleSubmit() {
      this.$store.state.post.id += this.$store.state.post.id;
      console.log(this.postData);
      console.log(this.$store.state.post.PostData);
      // this.$store.state.post.PostData.push(this.postData);
      this.$store.dispatch('AddPostAsync', this.postData);
    }
  }
};
</script>
<style scoped>
.red-border {
  border-color: red;
}
</style>
