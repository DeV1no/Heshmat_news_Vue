<template>
  <app-header></app-header>
  <transition name="slide" mode="out-in">
    <router-view></router-view>
  </transition>
  <app-footer></app-footer>
</template>

<script>
import appHeader from './components/Header.vue';
import appFooter from './components/Footer.vue';

export default {
  name: 'App',
  components: {
    appHeader,
    appFooter
  }
};
</script>

<style>
a {
  text-decoration: none;
  color: black;
}
.slide-enter-active {
  animation: slide-in 200ms ease-out forwards;
}

.slide-leave-active {
  animation: slide-out 200ms ease-out forwards;
}

@keyframes slide-in {
  from {
    transform: translateY(-30px);
    opacity: 0;
  }
  to {
    transform: translateY(0);
    opacity: 1;
  }
}

@keyframes slide-out {
  from {
    transform: translateY(0);
    opacity: 1;
  }
  to {
    transform: translateY(-30px);
    opacity: 0;
  }
}
</style>
