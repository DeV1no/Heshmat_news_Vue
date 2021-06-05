import Vuex from 'vuex';
import Auth from './Modules/Auth';

const createStore = () => {
  return new Vuex.Store({
    namespaced: true,
    modules: {
      Auth
    }
  });
};

export default createStore;
