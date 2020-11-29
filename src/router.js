import { createRouter, createWebHistory } from 'vue-router';
import Home from './Pages/Routes/Home.vue';
import AboutUs from './Pages/Routes/AboutUs.vue'
import SliderData from './Pages/Routes/fData/SliderData.vue'
import SliderPanel from './Pages/Routes/SliderPanel.vue'
import SignIn from './Pages/Routes/SignIn.vue'
import SignUp from './Pages/Routes/SignUp.vue'
import UserPanel from './Pages/Routes/UserPanel.vue'
import store from './Store/store.js'
import PostPanel from './Pages/Routes/PostPanel.vue'
import PostData from './Pages/Routes/fData/PostData.vue'
import Article from './Pages/Routes/Article.vue'
import GroupPanel from './Pages/Routes/GroupPanel.vue'
import SortGroup from './Pages/Routes/SortGroup'
const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', redirect: '/Home' },
        { path: '/Home', component: Home },
        { path: '/ArticleGroup/:Group', name: 'Group', component: SortGroup },
        { path: '/Article/:id', name: 'Article', component: Article },
        { path: '/aboutUs', component: AboutUs },
        { path: '/SliderPanel', component: SliderPanel, meta: { requiresAuth: true } },
        { path: '/SliderData', component: SliderData, meta: { requiresAuth: true } },
        { path: '/SignIn', component: SignIn, meta: { requiresUnAuth: true } },
        { path: '/SignUp', component: SignUp },
        { path: '/UserPanel', component: UserPanel, meta: { requiresAuth: true } },
        { path: '/PostPanel', component: PostPanel, meta: { requiresAuth: true } },
        { path: '/PostData', component: PostData, meta: { requiresAuth: true } },
        { path: '/GroupPanel', component: GroupPanel, meta: { requiresAuth: true } }
    ],

});
router.beforeEach(function(to, _, next) {
    if (to.meta.requiresAuth && !store.state.auth.isAuth) {
        next('/');
    } else if (to.meta.requiresUnauth && store.state.auth.isAuth) {
        next('/');
    } else {
        next();
    }
    // if (to.meta.requiresAuth && store.state.auth.isAuth) {
    //     next()
    // }
})

export default router;