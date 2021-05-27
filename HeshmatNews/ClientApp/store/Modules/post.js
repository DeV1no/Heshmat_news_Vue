// import Vue from 'vue'
import axios from "axios";
const state = {
    Posts: [],
};


const getters = {
    GetPosts(state) {
        return state.Posts;
    }
    /* group: state => id => {
         return state.Groups.find(group => group.id === id)
     },*/


};

const mutations = {
    SET_POST(state, Posts) {
        state.Posts = Posts.items
    }

};


const actions = {
    GetPostAction({ commit }) {
        axios.get('/api/news')
            .then(response => {
                commit('SET_POST', response.data)
            })
    },
}

export default {
    state,
    getters,
    mutations,
    actions,
}