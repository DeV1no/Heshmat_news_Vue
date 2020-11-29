<template>
  <div class="container">
    <table class="table mt-5">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">عنوان</th>
        </tr>
      </thead>
      <tbody v-for="(slide, index) in Sliders" :key="slide">
        <tr>
          <th scope="row">{{ index + 1 }}</th>
          <td>{{ slide.title }}</td>
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
      <router-link to="/SliderData">افزودن اسلایدر جدید</router-link>
    </button>
    <form @submit.prevent="handleEdit(index)" v-show="isEditMode">
      <div class="form-group">
        <label>
          <h4>موضوع</h4>
        </label>
        <input v-model="editData.title" type="text" class="form-control" />
      </div>
      <div class="form-group">
        <label>
          <h4>شرح</h4>
        </label>
        <textarea v-model="editData.para" class="form-control" />
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
      <button class="btn btn-success btn-lg my-4" type="submit">ویرایش</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isEditMode: false,
      sliderData: this.$store.state,
      editData: {
        title: '',
        para: ''
      },
      id: null
    };
  },
  methods: {
    deleteRecipe(index) {
      console.log(index);
      this.$store.state.slider.sliderData.splice(index, 1);
    },
    editor(index) {
      console.log(index);
      this.id = index;
      this.isEditMode = true;
      this.editData.title = this.Sliders[index].title;
      this.editData.para = this.Sliders[index].para;
    },
    handleEdit() {
      this.$store.state.slider.sliderData.splice(this.id, 1, this.editData);
    }
  },
  computed: {
    Sliders() {
      return this.$store.getters.GetSliders;
    }
  }
};
</script>

<style></style>
