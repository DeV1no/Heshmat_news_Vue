<template>
  <div class="spinner-background">
    <div class="spinner-border " role="status">
      <span class="sr-only">Loading...</span>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.spinner-border {
  position: absolute;
  top: 50%;
  right: 50%;
  width: 4rem;
  height: 4rem;
  color: brown;
}
.spinner-background {
  height: 100%;
  width: 100%;
  background: black;
}
</style>
