<template>
  <div id="home">
    
      <v-containerfluid grid-list-md>
        
          <v-layout class="home" align-center column justify-center>
            
            <h1 class="display-3 font-weight-thin mb-3">CheckIt</h1>
            <h4 class="subheading">Where you can keep track of your shopping prices!</h4>
           
           <!--Call search bar component-->
            <SearchBar />


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
const API_URL = 'http://localhost:58881';

export default {
  name: "home",
  props:['token'],
  data() {
    return {
      //token: "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySUQiOiJhNGQ1ODVkMC05NTc0LWU5MTEtYWEwMy0wMjE1OThlOWVjOWUiLCJlbWFpbCI6ImpvbmF0aGFuYXNjZW5jaW8uamFAZ21haWwuY29tIiwiY2xpZW50IjoiIiwiaGVpZ2h0IjoiMiIsImV4cCI6MTU1NzkwMTkxMiwiaXNzIjoiQ2hlY2tJdC5ncSJ9.yqAfEwpjdXoec5E3n1X9vShmVp2ZgfQBQX7nkFxSD-Y",
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
    console.log("before if. token = " + this.token);
    if(this.token !== undefined)
    {
      var str = this.token.split('.');
      console.log("in before mount. str = " + str);
      if(str.length !== 3)
      {
        this.token = undefined;
      }
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