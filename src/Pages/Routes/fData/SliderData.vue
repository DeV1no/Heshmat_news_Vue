<template>
  <div class="container">
    <form @submit.prevent="handleSubmit">
      <div class="form-group">
        <label>
          <h4>موضوع</h4>
        </label>
        <input v-model="sliderData.title" type="text" class="form-control" />
      </div>
      <div class="form-group">
        <label>
          <h4>شرح</h4>
        </label>
        <textarea v-model="sliderData.para" class="form-control" />
      </div>
      <div class="file-upload-wrapper">
        <input
          type="file"
          id="input-file-now"
          ref="img"
          @change="selectFile"
          class="file-upload"
        />
      </div>
      <button class="btn btn-success btn-lg my-4" type="submit">ثبت</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      sliderData: {
        title: '',
        para: '',
        img: ''
      }
    };
  },

  methods: {
    selectFile() {
      console.log(this.$refs.img.files[0]);
      this.img = this.$refs.img.files[0];
    },
    handleSubmit() {
      console.log(this.sliderData);
      console.log(this.$store.state.slider.sliderData);
      this.$store.state.slider.sliderData.push(this.sliderData);
      // this.$store.state.sliderData.push(this.sliderData);
    }
  }
};
</script>
<style scoped>
.red-border {
  border-color: red;
}
</style>
