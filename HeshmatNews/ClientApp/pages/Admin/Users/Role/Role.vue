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
                  مدیریت سطح دسترسی کاربر
                </div>
                <div class="card-body">
                  <form class="mr-2">
                    <div class="row">
                      <div class="col-md-6">
                        <label for="basic-url">نام کاربری</label>
                        <div class="input-group mb-3">
                          <div class="input-group-prepend"></div>
                          <input
                            type="text"
                            class="form-control"
                            name="userName"
                            v-model="userData.userName"
                            readonly
                          />
                        </div>
                      </div>
                      <div class="col-md-6">
                        <label for="basic-url">تاریخ ثبت نام</label>
                        <div class="input-group mb-3">
                          <div class="input-group-prepend"></div>
                          <input
                            type="text"
                            class="form-control"
                            name="registerDate"
                            v-model="userData.registerDate"
                            readonly
                          />
                        </div>
                      </div>
                      <div class="col-md-6">
                        <label for="basic-url">نام</label>
                        <div class="input-group mb-3">
                          <div class="input-group-prepend"></div>
                          <input
                            type="text"
                            class="form-control"
                            name="name"
                            v-model="userData.name"
                            readonly
                          />
                        </div>
                      </div>
                      <div class="col-md-6">
                        <label for="basic-url">نام خانوادگی</label>
                        <div class="input-group mb-3">
                          <div class="input-group-prepend"></div>
                          <input
                            type="text"
                            class="form-control"
                            name="family"
                            v-model="userData.family"
                            readonly
                          />
                        </div>
                      </div>
                      <div class="col-md-6">
                        <label for="basic-url">نقش (ها)</label>
                        <div class="input-group mb-3">
                          <div class="input-group-prepend"></div>
                          <input
                            type="text"
                            class="form-control"
                            name="roleName"
                            v-model="userCurrentRoles"
                            readonly
                          />
                        </div>
                      </div>
                      <div class="col-md-6">
                        <label for="basic-url">وضعیت</label>
                        <div class="input-group mb-3">
                          <div class="input-group-prepend"></div>
                          <input
                            type="text"
                            class="form-control"
                            name="isActive"
                            :placeholder="
                              this.userData.isActive ? 'فعال' : 'غیر فعال'
                            "
                            readonly
                          />
                        </div>
                      </div>
                      <div class="col-md-12">
                        <div>
                          <label class="typo__label"></label>
                          <multiselect
                            v-model="roleArray"
                            :options="roleOptions"
                            :custom-label="nameWithLang"
                            :multiple="true"
                            :close-on-select="false"
                            :clear-on-select="false"
                            :preserve-search="true"
                            :preselect-first="true"
                            @tag="addTag"
                            :taggable="true"
                            placeholder="سر گروه را انتخاب کنید "
                            label="name"
                            track-by="name"
                            @update="updateMultiValue"
                          ></multiselect>
                        </div>
                      </div>
                    </div>
                    <div class="mt-4">
                      <nuxt-link
                        class="btn btn-danger ml-1"
                        to="/admin/users/list"
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
      isSaving: false,

      roleArray: [],
      roleOptions: [],
      mdl: {
        userId: null,
        roleId: []
      },
      userData: {
        id: null,
        userName: null,
        name: null,
        family: null,
        roleId: null,
        registerDate: null,
        isActive: true,
        roleName: null
      },
      dictionary: {
        True: 'فعال',
        False: 'غیر فعال'
      },
      userCurrentRoles: null
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

    SubData() {
      if (!this.roleArray) {
        this.$toast.error('خطا! لطفا تمامی اطلاعات را وارد کنید').goAway(4500);
        return;
      }
      this.mdl.userId = this.id;
      this.rolArrayMaker();
      try {
        this.isSaving = true;
        axios.put('/api/User/addroleToUser', this.mdl).then(res => {
          if (res.data) {
            this.$toast.success('اطلاعات با موفقیت ثبت شد').goAway(4500);
            this.$router.push('/admin/users/list');
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
    }
  },
  async mounted() {
    await this.getRoles();
    await this.getUserData();
  }
};
</script>

<style scoped></style>
