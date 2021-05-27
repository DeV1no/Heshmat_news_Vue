// import Vue from 'vue'
const state = {
    state() {
        return {
            userId: null,
            token: null,
            tokenExpiration: null,
            isAuth: false
        }
    },

};


const getters = {
    userId(state) {
        return state.userId
    },
    token(state) {
        return state.token
    }
};

const mutations = {
    setUser(state, payload) {
        state.token = payload.token;
        state.userId = payload.userId;
        state.tokenExpiration = payload.token;
        state.isAuth = true
    },

};


const actions = {
    async login(context, payload) {
        const response = await fetch(
            'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyBdFe6J_9HARP8yPmNEIaW5VY5qH86lhR8', {
                method: 'POST',
                body: JSON.stringify({
                    email: payload.email,
                    password: payload.password,
                    returnSecureToken: true,

                })
            });
        const responseData = await response.json()
        if (!response.ok) {
            console.log(responseData);
            const error = new Error(responseData.message || 'Failed to Authenticate');
            throw error
        }
        console.log(responseData);
        context.commit('setUser', {
            token: responseData.idToken,
            userId: responseData.localId,
            tokenExpiration: responseData.expiresIn,

        })

    },
    async signup(context, payload) {
        const response = await fetch(
            'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyBdFe6J_9HARP8yPmNEIaW5VY5qH86lhR8', {
                method: 'POST',
                body: JSON.stringify({
                    email: payload.email,
                    password: payload.password,
                    returnSecureToken: true
                })
            });
        const responseData = await response.json()
        if (!response.ok) {
            console.log(responseData);
            const error = new Error(responseData.message || 'Failed to Authenticate');
            throw error
        }
        console.log(responseData);
        context.commit('setUser', {
            token: responseData.idToken,
            userId: responseData.localId,
            tokenExpiration: responseData.expiresIn
        })
    },
    logOut(context) {
        context.commit('setUser', {
            token: null,
            userId: null,
            tokenExpiration: null,
            isAuth: false
        })

    }
}

export default {
    state,
    getters,
    mutations,
    actions,
}