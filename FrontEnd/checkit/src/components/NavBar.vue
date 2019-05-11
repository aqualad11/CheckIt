<template>
  <v-toolbar app>
    <img src="@/assets/SpyderzLogo.png" alt="" width = 75 height = 65>
    <v-toolbar-title class="headline text-uppercase">
      <v-btn to="/" flat>CHECKIT</v-btn>
      <!--span>CHECKIT</span-->
    </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-btn to="/" flat>Home</v-btn>
    <v-btn to="about" flat>About</v-btn>
    <v-btn v-on:click="login">Login</v-btn>
    <v-btn v-on:click="register">Register</v-btn>
    <v-btn to="playground" flat>Playground</v-btn>

          <!-- dropdown menu (user is signed in)-->
      <v-menu offset-y>
        <v-btn flat slot="activator" color="grey">
          <v-icon left>person</v-icon>
          <span>My Account</span>
          <v-icon>expand_more</v-icon>
        </v-btn>
        <v-list>
          <v-list-tile v-for="link in links" :key="link.text" router :to="link.route">
            <v-list-tile-title>{{ link.text }}</v-list-tile-title>
          </v-list-tile>
        </v-list>
      </v-menu>



  </v-toolbar>
</template>
<script>
import axios from "axios";
const API_URL = 'Backend';

export default {
  data() {
    return {
      drawer: false,
      links: [
        { text: 'Watchlist', route: '/watchlist' },
        {  text: 'Settings', route: '/settings' },
        {  text: 'Sign Out', route: '/signout' },
      ]
    }
  },
  name: 'NavBar',
  methods: {
    login(){
      axios.get(API_URL + "/api/user/login")
      .then(response => {
        alert("You will be redirected to kft-sso.com to login.")
        window.location.assign(response.data)
      })
      .catch(err =>{
        console.log(err.data)
      })
    },
    register(){
      axios.get(API_URL + "/api/user/register")
      .then(response => {
        console.log("in then")
        alert("You will be redirected to kft-sso.com to register.")
        window.location.assign(response.data)
      })
      .catch(err => {
        console.log(err)
      })
    }
  }
}
</script>