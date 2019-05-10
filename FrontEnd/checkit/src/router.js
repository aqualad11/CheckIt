import Vue from "vue";
import Router from "vue-router";
import Playground from "./views/Playground.vue";
import Home from "./views/Home.vue"
import NotFound from "./views/NotFound.vue"
import Login from "./views/Login.vue"
import Register from "./views/Register.vue"
import AdminDashboard from "./views/AdminDashboard.vue"
import AccountSettings from "./views/AccountSettings.vue"
import Watchlist from "./views/Watchlist.vue"
import SignOut from "./views/SignOut.vue"
import UserManual from "./views/UserManual.vue"
import FAQ from "./views/FAQ.vue"
import AddUser from "./components/AddUser.vue"
import Users from "./components/Users.vue"
import UpdateUser from "./components/UpdateUser.vue"
import DeleteUser from "./components/DeleteUser.vue"
import UACadmin from "./components/UACadmin.vue"
import UACusers from "./components/UACusers.vue"
import LogRead from "./components/LogRead.vue"
import LogDelete from "./components/LogDelete.vue"
import ItemList from "./views/ItemList.vue"


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
      path: "/admin/adduser",
      name: "adduser",
      component: AddUser,
    },
    {
      path: "/admin/users",
      name: "users",
      component: Users
    },
    {
      path: "/admin/updateuser",
      name: "updateuser",
      component: UpdateUser
    },
    {
      path: "/admin/deleteuser",
      name: "deleteuser",
      component: DeleteUser
    },
    {
      path: "/admin/uac/admin",
      name: "uacadmin",
      component: UACadmin
    },
    {
      path: "/admin/uac/users",
      name: "uacusers",
      component: UACusers
    },
    {
      path: "/admin/log/read",
      name: "readlog",
      component: LogRead
    },
    {
      path: "/admin/log/delete'",
      name: "deletelog",
      component: LogDelete
    },
    {
      path: "/items",
      name: "items",
      component: ItemList
    },

  ]
});
