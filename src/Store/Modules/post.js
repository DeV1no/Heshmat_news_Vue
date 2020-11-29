// import Vue from 'vue'
const state = {
    PostData: [{
            id: 99999,
            title: 'جدید ترین اخبار تکنولوژی و غیره',
            shortPara: 'سونی بعد از مدت‌ها حدس و گمان، شب گذشته از ظاهر و طراحی جدید پلی استیشن 5 و پلی استیشن 5 دیجیتال در رویداد آنلاین رونمایی از بازی‌های PS5‌ پرده برداشت.',
            longPara: '',
            badge: 'ورزشی',
            img: 'http://localhost:8080/img/ent1.7c30596c.jpg'
        },
        {
            id: 999999,
            title: 'DXOMARK نتایج دوربین سلفی آیفون ۱۲ پرو را منتشر کرد',
            shortPara: 'دوربین سلفی ۱۲ مگاپیکسلی آیفون ۱۲ پرو در آزمون‌های DXOMARK با کسب ۹۸ امتیاز در رتبه‌ی هفتم برترین دوربین‌های این وب‌سایت قرار گرفت.',
            longPara: '',
            badge: 'سرگرمی',
            img: 'https://cdn01.zoomit.ir/2020/11/apple-iphone-12-and-12-pro-side-buttons-mute.jpg?w=1300'
        },

    ],
    id: 1
};


const getters = {
    GetPosts(state) {
        return state.PostData;
    },
    GetPostImageAddress(state) {
        return state.SliderImageAddress;
    },
    postList: state => {
        return state.PostData
    },
    post: state => id => {
        return state.PostData.find(post => post.id === id)
    },
    groupSort: state => badge => {
        return state.PostData.find(groupSort => groupSort.badge === badge)
    }
};

const mutations = {
    // SetPost(state, post) {
    //     state.post = post;
    // }
    AddPost(state, newPost) {
        state.PostData.push(newPost)
            // state.refreshToken = userData.refreshToken
    }
};


const actions = {
    AddPostAsync({
        commit
    }, newPost) {
        commit('AddPost',
            newPost
        )
    }
}

export default {
    state,
    getters,
    mutations,
    actions,
}