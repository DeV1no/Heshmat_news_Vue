<template>
  <div class="container">
    <table class="table mt-5">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">نام کاربری</th>
          <th scope="col">نام</th>
          <th scope="col">نام خانوادگی</th>
          <th scope="col">پست الکترونیکی</th>
        </tr>
      </thead>
      <tbody v-for="(user, index) in Users" :key="user">
        <tr>
          <th scope="row">{{ index + 1 }}</th>
          <td>{{ user.id }}</td>
          <td>{{ user.name }}</td>
          <td>{{ user.lastname }}</td>
          <td>{{ user.email }}</td>
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

    <form @submit.prevent="handleEdit(index)" v-show="isEditMode">
      <input
        type="text"
        class=" form-group mr-3 form-control"
        placeholder=" نام کاربری"
        v-model="editData.id"
      />
      <input
        type="text"
        class=" form-group mr-3 form-control"
        placeholder=" نام"
        v-model="editData.name"
      />
      <input
        type="text"
        class=" form-group mr-3 form-control"
        placeholder=" نام خانوادگی"
        v-model="editData.lastname"
      />
      <input
        type="text"
        class=" form-group mr-3 form-control"
        placeholder=" پست"
        v-model="editData.email"
      />
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
        id: '',
        name: '',
        lastname: '',
        email: '',
        password: ''
      },
      id: null
    };
  },
  methods: {
    deleteRecipe(index) {
      console.log(index);
      this.$store.state.user.userData.splice(index, 1);
    },
    editor(index) {
      console.log(index);
      this.id = index;
      this.isEditMode = true;
      this.editData.id = this.Users[index].id;
      this.editData.name = this.Users[index].name;
      this.editData.lastname = this.Users[index].lastname;
      this.editData.email = this.Users[index].email;
      this.editData.password = this.Users[index].password;
    },
    handleEdit() {
      this.$store.state.user.userData.splice(this.id, 1, this.editData);
    }
  },
  computed: {
    Users() {
      return this.$store.getters.GetUser;
    }
  }
};
</script>

<style></style>
