// import Vue from 'vue'
import axios from "axios";
const state = {
    subCategory: [],
};


const getters = {
    GetSubCategory(state) {
        return state.subCategory;
    }
    /* group: state => id => {
         return state.Groups.find(group => group.id === id)
     },*/


};

const mutations = {
    SET_SUBCATEGORY(state, SubCategory) {
        state.subCategory = SubCategory
    }

};


const actions = {
    GetSubcategoryAction({commit}) {
        axios.get('/api/SubCategory')
            .then(response => {
                commit('SET_SUBCATEGORY', response.data)
            })
    },
}

export default {
    state,
    getters,
    mutations,
    actions,
}