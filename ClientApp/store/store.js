import { createStore } from 'vuex'
import slider from './Modules/Slider.js'
import user from './Modules/User.js'
import post from './Modules/post'
import auth from './Modules/Auth.js'
import groups from './Modules/Groups.js'


const store = createStore({
    modules: {
        slider,
        user,
        post,
        auth,
        groups
    }
});

export default store;