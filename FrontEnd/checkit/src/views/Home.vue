<template>

    <v-container fill-height>
      <v-layout align-center>
        <v-flex>
          <v-jumbotron>
          <h3 class="display-3">Welcome to CheckIt!</h3>

          <span class="subheading">Where to can keep track of your prices!</span>

          <v-divider class="my-3"></v-divider>

          <div class="title mb-3">Get Started</div>

              <v-btn class="mx-0" color="primary"  @click="getWatchlist">View My Watchlist</v-btn>
              <br>
              <v-btn class="mx-0" color="primary" large to="/usermanual" >Quick Start</v-btn>
              <br>
              <v-btn class="mx-0" color="primary" large to="/faq" >FAQ</v-btn>
        </v-jumbotron>
        
        <!--search bar-->
        
        <v-text-field
            v-model="message"
            outline
            clearable
            label="Search for your item..."
            type="text"
          >
            <template v-slot:prepend>
              <v-tooltip
                bottom
              >
                <template v-slot:activator="{ on }">
                  <v-icon v-on="on">mdi-help-circle-outline</v-icon>
                </template>
                I'm a tooltip
              </v-tooltip>
            </template>
            <template v-slot:append>
              <v-fade-transition leave-absolute>
                <v-progress-circular
                  v-if="loading"
                  size="24"
                  color="info"
                  indeterminate
                ></v-progress-circular>
                <img v-else width="30" height="30" src="@/assets/SpyderzLogo.png" alt="">
              </v-fade-transition>
            </template>


            <template v-slot:append-outer>
              <v-btn color="primary" @click="clickMe">Search</v-btn>
            </template>


          </v-text-field>
        <!--end search bar-->

        </v-flex>
      </v-layout>
    </v-container>
  
  


  
</template>





<script>
import axios from "axios";
const API_URL = 'http://localhost:58881';

  export default {
    data: () => ({
      loading: false,
      token: "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySUQiOiJhNGQ1ODVkMC05NTc0LWU5MTEtYWEwMy0wMjE1OThlOWVjOWUiLCJlbWFpbCI6ImpvbmF0aGFuYXNjZW5jaW8uamFAZ21haWwuY29tIiwiY2xpZW50IjoiIiwiaGVpZ2h0IjoiMiIsImV4cCI6MTU1NzcyNjU2NywiaXNzIjoiQ2hlY2tJdC5ncSJ9.aZDNy3Cmv73VOa9GLMAohiuEMiFvKe-VwfkqkHtIsD4",
      watchlist: []
    }),

    methods: {
      clickMe () {
        this.loading = true
        setTimeout(() => {
          this.loading = false
        }, 2000)
      },
      getWatchlist()
      {
        axios.get(API_URL + "/api/user/getwatchlist", {
          headers: {
            token: this.token
          }
        })
        .then(response => {
          this.watchlist = response.data.items,
          this.token = response.data.jwt,
          console.log("watchlist = " + this.watchlist[0].itemID)
          console.log("token: " + this.token)
        })
        .catch(err => {
          if(err.response.status == 301)
          {
            alert("Your session has expired you will be send to kft-sso.com to sign back in.")
            window.location.assign(err.response.data)
          }
        })
      }
    }
  }
</script>