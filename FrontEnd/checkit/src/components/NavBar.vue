<template>
  <v-toolbar app>
    <img src="@/assets/SpyderzLogo.png" alt="" width = 75 height = 65>
    <v-toolbar-title class="headline text-uppercase">
      <v-btn to="/" flat>CHECKIT</v-btn>
      <!--span>CHECKIT</span-->
    </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-btn to="/" flat>Home</v-btn>
    <v-btn to="hotdeals" flat>Hot Deals!</v-btn>
    <v-btn to="about" flat>About</v-btn>
    <v-btn v-on:click="login">Login</v-btn>
    <v-btn v-on:click="register">Register</v-btn>
    <v-btn to="playground" flat>Playground</v-btn>
  </v-toolbar>
</template>
<script>
import axios from "axios";
const API_URL = 'Backend';

export default {
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