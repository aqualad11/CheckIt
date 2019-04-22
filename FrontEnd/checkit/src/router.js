import Vue from "vue";
import Router from "vue-router";
import Playground from "./views/Playground.vue";
import Home from "./views/Home.vue"
import NotFound from "./views/NotFound.vue"
import HotDeals from "./views/HotDeals.vue"
import Login from "./views/Login.vue"
import Register from "./views/Register.vue"
import AdminDashboard from "./views/AdminDashboard.vue"

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
      path: "/hotdeals",
      name: "hotdeals",
      component: HotDeals
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
      component: AdminDashboard
    }

  ]
});
