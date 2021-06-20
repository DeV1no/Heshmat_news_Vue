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
                  مدیریت نقش
                </div>
                <div class="card-body">
                  <form class="mr-2">
                    <div class="row">
                      <div class="col-md-12">
                        <label for="basic-url">نام نقش</label>
                        <div class="input-group mb-3">
                          <div class="input-group-prepend"></div>
                          <input
                            type="text"
                            class="form-control"
                            name="userName"
                            v-model="mdl.roleName"
                          />
                        </div>
                        <div
                          class="form-check"
                          v-for="item in permissions"
                          :key="item.permissionId"
                        >
                          <label
                            :class="
                              item.parentId == null
                                ? 'text-primary'
                                : 'mr-4 fs-13'
                            "
                            class="form-check-label"
                            for="flexCheckDefault"
                          >
                            {{ item.permissionTitle }}
                          </label>
                          <input
                            class="form-check-input mr-2 "
                            type="checkbox"
                            :value="item.permissionId"
                            :id="`permissionId-${item.permissionId}`"
                            :v-model="mdl.permissionsId"
                            @click="permissionAddRemover(item.permissionId)"
                            :checked="permissionSyncer(item.permissionId)"
                          />
                        </div>
                      </div>
                    </div>
                    <div class="mt-4">
                      <nuxt-link
                        class="btn btn-danger ml-1"
                        to="/admin/roles/list"
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
      id: this.$route.params.id,
      isEditMode: false,
      isSaving: false,
      permissions: [],
      roleArray: [],

      roleOptions: [],
      mdl: {
        id: this.$route.params.id,
        roleName: null,
        permissionsId: []
      },

      dictionary: {
        True: 'فعال',
        False: 'غیر فعال'
      },
      userCurrentRoles: null
    };
  },
  methods: {
    permissionAddRemover(id) {
      let permissionId = this.mdl.permissionsId.find(q => q == id);
      if (permissionId) {
        let index = this.mdl.permissionsId.indexOf(permissionId);
        this.mdl.permissionsId.splice(index, 1);
      } else {
        this.mdl.permissionsId.push(id);
      }
    },
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
    rolArrayMaker() {
      this.roleArray.forEach(q => {
        this.mdl.roleId.push(q.id);
      });
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
          this.roleOptions.push(rItems);
        });
      });
    },

    nameWithLang({ roleName }) {
      return `${roleName}`;
    },
    async getPermissions() {
      await axios
        .get('/api/Role/permissions')
        .then(res => (this.permissions = res.data));
    },
    SubData() {
      let ax;
      try {
        this.isSaving = true;
        if (this.isEditMode) ax = axios.put('/api/Role', this.mdl);
        else ax = axios.post('/api/Role', this.mdl);

        ax.then(res => {
          if (res.data) {
            this.$toast.success('اطلاعات با موفقیت ثبت شد').goAway(4500);
            this.$router.push('/admin/roles/list');
          }
        });
      } catch (err) {
        console.log(err);
        this.$toast.error('خطای پیشبینی نشده ای رخ داده است').goAway(4500);
      } finally {
        this.isSaving = false;
      }
    },
    getUserData() {
      axios.get(`/api/User/getUserDetails/${this.id}`).then(res => {
        this.userData = res.data;
        this.userCurrentRoles = res.data.roleNames.toString();
      });
    },
    checkEditMode() {
      this.id ? (this.isEditMode = true) : (this.isEditMode = false);
    },
    async loadSaveData() {
      await axios.get(`/api/Role/save/${this.id}`).then(res => {
        this.mdl.roleName = res.data.roleName;
        res.data.permissions.forEach(q => {
          this.mdl.permissionsId.push(q.permissionId);
        });
      });
    },
    permissionSyncer(permissionId) {
      let permission = this.mdl.permissionsId.find(q => q == permissionId);
      if (permission) return true;
      return false;
    }
  },
  async mounted() {
    this.checkEditMode();
    await this.getPermissions();
    if (this.isEditMode) {
      await this.loadSaveData();
    }
  }
};
</script>

<style scoped></style>
