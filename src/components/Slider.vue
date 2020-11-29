<template>
  <header
    id="showcase"
    v-bind:style="{ 'background-image': 'url(' + Sliders[i].img + ') ' }"
  >
    <div class="container">
      <div class="showcase-container">
        <div class="showcase-content" dir="rtl">
          <div class="category category-sports">ورزشی</div>
          <h3>{{ Sliders[i].title }}</h3>
          <p>
            {{ Sliders[i].para }}
          </p>

          <button class="btn btn-primary m-1" @click="i++">
            بعدی
          </button>
          <button class="btn btn-primary" @click="i--">
            قبلی
          </button>
        </div>
      </div>
    </div>
  </header>
</template>

<script>
export default {
  data() {
    return {
      i: 0,
      sliderData: this.$store.state
    };
  },
  methods: {
    iSmaller() {}
  },
  computed: {
    Sliders() {
      return this.$store.getters.GetSliders;
    }
  }
};
</script>

<style>
#showcase:before {
  background: no-repeat center center/cover;
}
</style>
