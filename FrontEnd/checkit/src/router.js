import Vue from "vue";
import Router from "vue-router";
import Playground from "./views/Playground.vue";
import Home from "./views/Home.vue"
import NotFound from "./views/NotFound.vue"
import Login from "./views/Login.vue"
import Register from "./views/Register.vue"
import AdminAccount from "./views/AdminAccount.vue"
import AccountSettings from "./views/AccountSettings.vue"
import Watchlist from "./components/Watchlist.vue"
import SignOut from "./views/SignOut.vue"
import UserManual from "./views/UserManual.vue"
import FAQ from "./views/FAQ.vue"
import UserManager from "./components/UserManager.vue"
import ItemList from "./views/ItemList.vue"
import UAD from "./views/UAD.vue"
import Terms from "./views/Terms.vue"
import ContactUs from "./views/ContactUs.vue"
import UserAccount from "./views/UserAccount.vue"
import Privacy from "./views/Privacy.vue"

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
    },
    {
      path: "/about",
      name: "about",
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () =>
        import(/* webpackChunkName: "about" */ "./views/About.vue")
    },
    {
      path: "/ssologin",
      name: "home",
      component: Home,
      props: (route) => ({token: route.query.token})
    },
    {
      path: "/login",
      name: "login",
      component: Login
    },
    {
      path: "/register",
      name: "register",
      component: Register
    },
    {
      path: "*",
      name: "notfound",
      component: NotFound
    },
    {
      path: "/playground",
      name: "playground",
      component: Playground
    },
    {
      path: "/admin",
      name: "admin",
      component: AdminAccount
    },
    {
      path: "/settings",
      name: "settings",
      component: AccountSettings
    },
    {
      path: "/watchlist",
      name: "watchlist",
      component: Watchlist
    },
    {
      path: "/usermanual",
      name: "usermanual",
      component: UserManual
    },
    {
      path: "/faq",
      name: "faq",
      component: FAQ
    },
    {
      path: "/signout",
      name: "signout",
      component: SignOut
    },
    {
      path: "/items",
      name: "items",
      component: ItemList
    },
    {
      path: "/uad",
      name: "uad",
      component: UAD
    },
    {
      path: "/items",
      name: "ItemList",
      component: ItemList
    },
    {
      path: "/terms",
      name: "terms",
      component: Terms
    },
    {
      path: "/contactus",
      name: "contactus",
      component: ContactUs
    },
    {
      path: "/user",
      name: "user",
      component: UserAccount
    },
    {
      path: "/privacy",
      name: "Privacy",
      component: Privacy
    }
  ]
});
