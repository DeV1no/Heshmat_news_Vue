// import Vue from 'vue'
const state = {
    Groups: [
        { id: 9999, title: 'ورزشی' },
        { id: 99999, title: 'سرگرمی' },
        { id: 9999999, title: 'تکنولوژی' },
        { id: 999999999, title: 'سیاسی' }
    ],
    id: 1
};


const getters = {
    GetGroups(state) {
        return state.Groups;
    },
    GroupsList: state => {
        return state.Groups
    },
    group: state => id => {
        return state.Groups.find(group => group.id === id)
    },


};

const mutations = {

    AddGroups(state, newGroup) {
        state.Groups.push(newGroup)
    }
};


const actions = {
    AddAysyncGroup({
        commit
    }, newGroup) {
        commit('AddGroups',
            newGroup
        )
    }
}

export default {
    state,
    getters,
    mutations,
    actions,
}