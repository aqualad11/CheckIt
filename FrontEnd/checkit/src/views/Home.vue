<template>
  <div id="home">
    
      <v-containerfluid grid-list-md>
        
          <v-layout class="home" align-center column justify-center>
            
            <h1 class="display-3 font-weight-thin mb-3">CheckIt</h1>
            <h4 class="subheading">Where you can keep track of your shopping prices!</h4>
           
           <!--Call search bar component-->
            <SearchBar :token="token" />


            <!--Eventually use this div, this removes the buttons if user is logged in-->
            <div v-if="token === undefined" style="margin: 4em 1em"> 
              <div style="margin: 4em 1em">
                <br>
                <v-btn @click="register" depressed>Register</v-btn>
                or
                <v-btn @click="login" depressed>Sign In</v-btn>
                            
              <v-divider></v-divider>
              </div>
            </div>
            <div v-else>

              <!--TODO: SHOW THIS BUTTON AFTER LOG IN-->
              <v-btn @click="getWatchlist">View My Watchlist</v-btn>
              
            </div>

          </v-layout>
       
      </v-containerfluid>
    
  </div>
</template>

<script>

import SearchBar from "@/components/SearchBar.vue";
import axios from "axios";
import { constants } from 'fs';
const API_URL = 'Backend';

export default {
  name: "home",
  props:['token'],
  data() {
    return {
      watchlist: []
    }
  },
  components: {
    SearchBar
  },
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
    },
    getWatchlist()
    {
      this.$router.push({
        name: "watchlist",
        params: {
          token: this.token
        }
      })
    }
  },
  beforeMount(){
    console.log("home token: " + this.token)
    if(this.token === undefined)
    {
      var localToken = localStorage.getItem("token");
      if(localToken !== null)
      {
        this.token = localToken
      }
      console.log("home token: " + this.token)
    }

    if(this.token !== undefined && this.token !== null)
    {
      console.log("in if")
      axios.get(API_URL + "/api/user/validatetoken", {
        params: {
          jwt: this.token
        }
      })
      .then(response => {
        this.token = response.data,
        localStorage.setItem("token", this.token),
        console.log("response token = " + this.token)
      })
      .catch(err => {
        this.token = undefined,
        localStorage.removeItem("token")
        console.log("catch err " + err)
      })
    }
  }
};
</script>


<style lang="sass" scoped>
#home
  color: black
  margin: 1em
#welcome
  margin: 0ss
h2
  font-family: Roboto
  font-style: italic
</style>