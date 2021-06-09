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
                        <label for="basic-url">نقش</label>
                        <div class="input-group mb-3">
                          <div class="input-group-prepend"></div>
                          <input
                            type="text"
                            class="form-control"
                            name="roleName"
                            v-model="userData.roleName"
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
                            v-model="roleObj"
                            :options="roleOptions"
                            :custom-label="nameWithLang"
                            placeholder="سر گروه را انتخاب کنید "
                            label="name"
                            track-by="name"
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

      roleObj: null,
      roleOptions: [],
      mdl: {
        userId: null,
        roleId: null
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
      }
    };
  },
  methods: {
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
      if (!this.roleObj) {
        this.$toast.error('خطا! لطفا تمامی اطلاعات را وارد کنید').goAway(4500);
        return;
      }
      this.mdl.userId = this.id;
      this.mdl.roleId = this.roleObj.id;
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
