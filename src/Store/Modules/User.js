// import Vue from 'vue'
const state = {
    userData: [{
            id: 'DeV1',
            name: 'Danial',
            lastname: 'Shokouhmanesh',
            email: 'danialshokouhmanesh@gmail.com',
            password: '123456'
        }

    ]
};


const getters = {
    GetUser(state) {
        return state.userData;
    },

};

const mutations = {
    SetUser(state, User) {
        state.User = User;
    }
};


// const actions = {
//     GetSlidersFromServer(context) {
//         Vue.http.get('http://localhost:5000/api/slider/GetSliders')
//             .then(response => {
//                 return response.json();
//             }).then(data => {
//                 context.commit("SetSliders", data);
//             });
//     }
// }

export default {
    state,
    getters,
    mutations,
    // actions,
}