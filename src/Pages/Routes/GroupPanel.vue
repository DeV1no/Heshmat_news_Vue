<template>
  <div class="container">
    <table class="table mt-5">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">عنوان</th>
        </tr>
      </thead>
      <tbody v-for="(group, index) in Groups" :key="group">
        <tr>
          <th scope="row">{{ index + 1 }}</th>
          <td>{{ group.title }}</td>
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

    <button class="btn btn-success btn-lg my-2 mr-3" @click="addGroup">
      افزودن گروه جدید
    </button>
    <form @submit.prevent="addGroupHandel" v-show="isAddMode">
      <div class="form-group">
        <label>
          <h4>موضوع</h4>
        </label>
        <input v-model="groupsData.title" type="text" class="form-control" />
      </div>
      <button class="btn btn-success btn-lg my-4" type="submit">ثبت</button>
    </form>

    <form @submit.prevent="handleEdit" v-show="isEditMode">
      <div class="form-group">
        <label>
          <h4>موضوع</h4>
        </label>
        <input v-model="groupData[id]" type="text" class="form-control" />
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
      isAddMode: false,
      groupsData: { title: '', id: 1 },
      groupData: this.$store.state.groups.Groups
    };
  },
  methods: {
    addGroup() {
      this.isAddMode = true;
    },
    addGroupHandel() {
      this.$store.dispatch('AddAysyncGroup', this.groupsData);
      // this.groupsData.title = '';
      this.$store.state.groups.id += this.$store.state.groups.id;
      this.isAddMode = false;
    },
    deleteRecipe(index) {
      console.log(index);
      this.$store.state.groups.Groups.splice(index, 1);
    },
    editor(index) {
      console.log(index);
      this.id = index;
      this.isEditMode = true;
      this.groupsData.group = this.groupData[index];
    },
    handleEdit() {
      //   this.$store.state.groups.Groups.splice(this.id, 1, this.group);
      this.isEditMode = false;
    }
  },
  computed: {
    Groups() {
      return this.$store.getters.GetGroups;
    }
  }
};
</script>

<style></style>
