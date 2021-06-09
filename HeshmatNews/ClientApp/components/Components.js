import Vue from 'vue';
import AdminFooter from './Admin/AdminFooter';
import AdminNav from './Admin/AdminNav';
import AdminSide from './Admin/AdminAside';
import NavBar from './Home/nav-bar.vue';
import Loading from './Loading';
import Multiselect from 'vue-multiselect';

const components = {
  AdminFooter,
  AdminNav,
  AdminSide,
  NavBar,
  Loading,
  Multiselect
};

Object.entries(components).forEach(([name, component]) => {
  Vue.component(name, component);
});
