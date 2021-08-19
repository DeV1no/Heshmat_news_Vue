<template>
  <div class="container-fluid">
    <nav-bar />

    <div>
      <div class="container">
        <div class="main-body">
          <!-- Breadcrumb -->
          <nav aria-label="breadcrumb" class="main-breadcrumb">
            <ol class="breadcrumb">
              <li class="breadcrumb-item"><a href="index.html">Home</a></li>
              <li class="breadcrumb-item">
                <a href="javascript:void(0)">User</a>
              </li>
              <li class="breadcrumb-item active" aria-current="page">
                User Profile
              </li>
            </ol>
          </nav>
          <!-- /Breadcrumb -->

          <div class="row gutters-sm">
            <div class="col-md-4 mb-3">
              <div class="card">
                <div class="card-body">
                  <div
                    class="d-flex flex-column align-items-center text-center"
                  >
                    <img
                      :src="userProfileMdl.preUserAvatar"
                      alt="Admin"
                      class="rounded-circle"
                      width="150"
                    />
                    <div class="custom-file mb-2 col-md-12" v-if="isEditMode">
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
                    <div class="mt-3">
                      <h4>
                        {{ userProfileMdl.name + ' ' + userProfileMdl.family }}
                      </h4>
                      <p class="text-secondary mb-1">
                        تاریخ ثبت نام :
                        {{ userProfileMdl.registerDate }}
                      </p>
                      <!-- Description -->
                      <!-- <p class="text-secondary mb-1">Full Stack Developer</p>
                      <p class="text-muted font-size-sm">
                        Bay Area, San Francisco, CA
                      </p> -->
                    </div>
                  </div>
                </div>
              </div>
              <div class="card mt-3">
                <ul class="list-group list-group-flush">
                  <li
                    class="list-group-item d-flex justify-content-between align-items-center flex-wrap"
                  >
                    <h6 class="mb-0">
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="24"
                        height="24"
                        viewBox="0 0 24 24"
                        fill="none"
                        stroke="currentColor"
                        stroke-width="2"
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        class="feather feather-globe mx-2 icon-inline"
                      >
                        <circle cx="12" cy="12" r="10"></circle>
                        <line x1="2" y1="12" x2="22" y2="12"></line>
                        <path
                          d="M12 2a15.3 15.3 0 0 1 4 10 15.3 15.3 0 0 1-4 10 15.3 15.3 0 0 1-4-10 15.3 15.3 0 0 1 4-10z"
                        ></path></svg
                      >Website
                    </h6>
                    <span class="text-secondary">danial.com</span>
                  </li>

                  <li
                    class="list-group-item d-flex justify-content-between align-items-center flex-wrap"
                  >
                    <h6 class="mb-0">
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="24"
                        height="24"
                        viewBox="0 0 24 24"
                        fill="none"
                        stroke="currentColor"
                        stroke-width="2"
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        class="feather feather-twitter mx-2 icon-inline text-info"
                      >
                        <path
                          d="M23 3a10.9 10.9 0 0 1-3.14 1.53 4.48 4.48 0 0 0-7.86 3v1A10.66 10.66 0 0 1 3 4s-4 9 5 13a11.64 11.64 0 0 1-7 2c9 5 20 0 20-11.5a4.5 4.5 0 0 0-.08-.83A7.72 7.72 0 0 0 23 3z"
                        ></path></svg
                      >Twitter
                    </h6>
                    <span class="text-secondary">@danialshokouh</span>
                  </li>
                  <li
                    class="list-group-item d-flex justify-content-between align-items-center flex-wrap"
                  >
                    <h6 class="mb-0">
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="24"
                        height="24"
                        viewBox="0 0 24 24"
                        fill="none"
                        stroke="currentColor"
                        stroke-width="2"
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        class="feather feather-instagram mx-2 icon-inline text-danger"
                      >
                        <rect
                          x="2"
                          y="2"
                          width="20"
                          height="20"
                          rx="5"
                          ry="5"
                        ></rect>
                        <path
                          d="M16 11.37A4 4 0 1 1 12.63 8 4 4 0 0 1 16 11.37z"
                        ></path>
                        <line
                          x1="17.5"
                          y1="6.5"
                          x2="17.51"
                          y2="6.5"
                        ></line></svg
                      >Instagram
                    </h6>
                    <span class="text-secondary">danial.shokouhmanesh</span>
                  </li>
                </ul>
              </div>
            </div>
            <div class="col-md-8">
              <div class="card mb-3">
                <div class="card-body">
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">نام و نام خانوادگی</h6>
                    </div>

                    <div class="col-sm-9 text-secondary">
                      <div v-if="isEditMode">
                        <div class="group">
                          <input
                            type="text"
                            v-model="userProfileMdl.name"
                          /><span class="highlight"></span
                          ><span class="bar"></span>
                        </div>
                      </div>
                      <div v-else>
                        {{ userProfileMdl.name + ' ' + userProfileMdl.family }}
                      </div>
                    </div>
                  </div>
                  <hr />
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">پست الکترونیکی</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                      <div v-if="isEditMode">
                        <div class="group">
                          <input
                            type="text"
                            v-model="userProfileMdl.email"
                          /><span class="highlight"></span
                          ><span class="bar"></span>
                        </div>
                      </div>
                      <div v-else>
                        {{ userProfileMdl.email }}
                      </div>
                    </div>
                  </div>
                  <hr />

                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">Mobile</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                      09339689095
                    </div>
                  </div>
                  <hr />
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">آدرس</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                      کرج باغستان
                    </div>
                  </div>
                  <hr />
                  <div class="row">
                    <a
                      v-if="!isEditMode"
                      @click="isEditMode = !isEditMode"
                      class="btn btn-info text-white ml-2 mr-3"
                    >
                      <i class="fa fa-edit"></i>
                      ویرایش</a
                    >
                    <a
                      @click="updateUserProfile"
                      v-if="isEditMode"
                      class="btn btn-success text-white  mr-3"
                    >
                      <i class="fa fa-save"></i>
                      ثبت</a
                    >
                  </div>
                </div>
              </div>

              <div class="row gutters-sm">
                <div class="col-sm-12 mb-3">
                  <div class="card h-100">
                    <div class="card-body">
                      <h6 class="d-flex align-items-center mb-3">
                        > علاقه مندی ها
                      </h6>
                      <small>ورزشی</small>
                      <div class="progress mb-3" style="height: 5px">
                        <div
                          class="progress-bar bg-primary"
                          role="progressbar"
                          style="width: 80%"
                          aria-valuenow="80"
                          aria-valuemin="0"
                          aria-valuemax="100"
                        ></div>
                      </div>
                      <small>سیاسی</small>
                      <div class="progress mb-3" style="height: 5px">
                        <div
                          class="progress-bar bg-primary"
                          role="progressbar"
                          style="width: 72%"
                          aria-valuenow="72"
                          aria-valuemin="0"
                          aria-valuemax="100"
                        ></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <footer-app />
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      token: null,
      isEditMode: false,
      userProfileMdl: {
        id: null,
        email: null,
        name: null,
        family: null,
        password: null,
        userAvatar: null,
        preUserAvatar: null,
        registerDate: null
      }
    };
  },
  methods: {
    onFileSelected(event) {
      this.userProfileMdl.userAvatar = event.target.files[0];
    },
    async getUserProfileInfo() {
      await axios
        .get('/api/user/getuserprofileinfo', {
          headers: {
            Authorization: ` Bearer ${this.token}`
          }
        })
        .then(res => (this.userProfileMdl = res.data));
    },
    async updateUserProfile() {
      let spliter = this.userProfileMdl.name.split(' ');
      this.userProfileMdl.name = spliter[0];
      this.userProfileMdl.family = spliter[1];
      const form = new FormData();
      for (const property in this.userProfileMdl) {
        form.append(`${property}`, this.userProfileMdl[property]);
      }
      try {
        await axios.put('/api/user/updateuserinformation', form);
      } catch (err) {
        console.log(err);
      } finally {
        this.isEditMode = false;
        await this.getUserProfileInfo();
      }
    }
  },
  async mounted() {
    this.token = localStorage.getItem('token');
    await this.getUserProfileInfo();
  }
};
</script>

<style scoped>
body {
  margin-top: 20px;
  color: #1a202c;
  text-align: left;
  background-color: #e2e8f0;
}
.main-body {
  padding: 15px;
}
.card {
  box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.1), 0 1px 2px 0 rgba(0, 0, 0, 0.06);
}

.card {
  position: relative;
  display: flex;
  flex-direction: column;
  min-width: 0;
  word-wrap: break-word;
  background-color: #fff;
  background-clip: border-box;
  border: 0 solid rgba(0, 0, 0, 0.125);
  border-radius: 0.25rem;
}

.card-body {
  flex: 1 1 auto;
  min-height: 1px;
  padding: 1rem;
}

.gutters-sm {
  margin-right: -8px;
  margin-left: -8px;
}

.gutters-sm > .col,
.gutters-sm > [class*='col-'] {
  padding-right: 8px;
  padding-left: 8px;
}
.mb-3,
.my-3 {
  margin-bottom: 1rem !important;
}

.bg-gray-300 {
  background-color: #e2e8f0;
}
.h-100 {
  height: 100% !important;
}
.shadow-none {
  box-shadow: none !important;
}
img.rounded-circle {
  height: 246px;
}
group {
  position: relative;
  margin: 45px 0;
}

textarea {
  resize: none;
}

input,
textarea {
  background: none;
  color: #000;
  font-size: 18px;
  display: block;
  width: 320px;
  border: none;
  border-radius: 0;
  border-bottom: 1px solid #000;
}
input:focus,
textarea:focus {
  outline: none;
}
input:focus ~ label,
input:valid ~ label,
textarea:focus ~ label,
textarea:valid ~ label {
  top: -14px;
  font-size: 12px;
  color: #2196f3;
}
input:focus ~ .bar:before,
textarea:focus ~ .bar:before {
  width: 320px;
}

input[type='password'] {
  letter-spacing: 0.3em;
}

label {
  color: #c6c6c6;
  font-size: 16px;
  font-weight: normal;
  position: absolute;
  pointer-events: none;
  left: 5px;
  top: 10px;
  transition: 300ms ease all;
}

.bar {
  position: relative;
  display: block;
  width: 320px;
}
.bar:before {
  content: '';
  height: 2px;
  width: 0;
  bottom: 0px;
  position: absolute;
  background: #2196f3;
  transition: 300ms ease all;
  left: 0%;
}
</style>
