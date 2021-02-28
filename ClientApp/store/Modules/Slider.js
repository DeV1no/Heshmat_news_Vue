// import Vue from 'vue'
const state = {
    sliderData: [{
            title: 'مقاله های ورزشی',
            para: 'به گزارش خبرورزشی، تیم فوتبال استقلال از ساعت ۱۷:۴۰ ، در دیداری دوستانه و در زمین شماره دو ورزشگاه آزادی به مصاف تیم دسته اولی هوادار رفت که این دیدار با پیروزی ۳ بر یک استقلال به پایان رسید. ',
            img: 'https://kurdistan24.blob.core.windows.net/filemanager/resources/files/Sport/messi-maradona.jpg'
        },
        {
            title: '2مقاله های ورزشی',
            para: 'ورزش چیز خوبیه زیاد ورزش کنید  ',
            img: 'https://static2.farakav.com/files/pictures/01544350.jpg'
        }

    ]
};


const getters = {
    GetSliders(state) {
        return state.sliderData;
    },
    GetSliderImageAddress(state) {
        return state.SliderImageAddress;
    }
};

const mutations = {
    SetSliders(state, sliders) {
        state.sliders = sliders;
    }
};


const actions = {
    // GetSlidersFromServer(context) {
    //     Vue.http.get('http://localhost:5000/api/slider/GetSliders')
    //         .then(response => {
    //             return response.json();
    //         }).then(data => {
    //             context.commit("SetSliders", data);
    //         });
    // }
}

export default {
    state,
    getters,
    mutations,
    actions,
}