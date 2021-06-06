import axios from 'axios';

const state = {
  token: null,
  tokenExpiration: null,
  isAuth: '',
  username: null,
  userId: null
};
const mutations = {
  setUser(state, payload) {
    state.token = payload.token;
    state.userId = payload.userId;
    state.tokenExpiration = payload.tokenExpiration;
    state.username = payload.username;
    state.isAuth = true;
  }
};
const actions = {
  async login(context, payload) {
    const mdl = {
      username: payload.username,
      password: payload.password
    };
    await axios.post('/api/User/Login', mdl).then(res => {
      if (!res) {
        return false;
      }
      localStorage.setItem('token', res.data.token);
      localStorage.setItem('username', res.data.username);
      localStorage.setItem('userId', res.data.id);
      localStorage.setItem('tokenExpiration', res.data.tokenExpires);
      context.commit('setUser', {
        token: res.data.token,
        username: res.data.username,
        userId: res.data.userId,
        tokenExpiration: res.data.tokenExpires,
        isAuth: true
      });
      return true;
    });
  },
  autoLog(context) {
    const Token = localStorage.getItem('token');
    const Username = localStorage.getItem('username');
    const UserId = localStorage.getItem('userId');
    const TokenExpiration = localStorage.getItem('tokenExpiration');
    if (Token) {
      context.commit('setUser', {
        token: Token,
        tokenExpiration: TokenExpiration,
        username: Username,
        userId: UserId,
        isAuth: true
      });
    }
  },

  logOut(context) {
    localStorage.removeItem('token');
    localStorage.removeItem('tokenExpiration');
    localStorage.removeItem('username');
    localStorage.removeItem('userId');

    context.commit('setUser', {
      token: null,
      userId: null,
      tokenExpiration: null,
      isAuth: false
    });
  }
};
const getters = {
  token(state) {
    return state.token;
  },
  isAuthGet(state) {
    return !!state.token;
  },
  getCurrentUserId(state) {
    return state.userId;
  }
};

export default {
  state,
  actions,
  getters,
  mutations
};
