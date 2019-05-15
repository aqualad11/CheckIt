<template>
  <div class="watchlist">

    <v-container>

      <v-toolbar-title>My Watchlist</v-toolbar-title>
      <br>

    <v-flex xs2 sm4 md8>

      <v-card flat v-for="item in watchlist" :key="item.name">
        
        <v-layout row wrap :class="`pa-3 user`">

          <v-flex xs2 sm2 md6>
            <div class="caption grey--text">Item</div>
            <div>{{ item.ItemName }}</div>
          </v-flex>

          <v-flex xs4 sm4 md2>
            <div class="caption grey--text">Price</div>
            <div>${{ item.price }}</div>
          </v-flex>

         
  
            <!--Make Delete method-->
            <v-btn fab dark small color="error" @click="deleteItem(item)">
              <v-icon dark>remove</v-icon>
            </v-btn>

        </v-layout>
        <v-divider></v-divider>
      </v-card>
    </v-flex>

    </v-container>
   
  </div>
</template>

<script>
import axios from "axios";
const API_URL = 'Backend';

export default {
  name: "watchlist",
  data() {
    return {
      watchlist: [],
      token: this.$route.params.token
    }
  },
  methods: {
    deleteItem(item) {
      axios.post(API_URL + "/api/user/deleteitemfromlist", {
          "itemName": item.ItemName,
          "price": item.price,
          "url": item.url,
          "picKey": item.picKey,
          "jwt": this.token
      })
      .then(response => {
        this.token = response.data,
        console.log("Statuscode = " + response.status)
      })
      .catch(err => {
        console.log("error = " + err)
        console.log("error content = " + err.response.data)
      })
    }
  },
  beforeMount() {
    if(this.token === undefined){
      this.token = localStorage.getItem("token")
    }
    axios.get(API_URL + "/api/user/getwatchlist", {
      headers: {
        token: this.token
      }
    })
    .then(response => {
      this.watchlist = response.data.items,
      this.token = response.data.jwt,
      localStorage.setItem("token", this.token)
    })
    .catch(err => {
      if(err.response.status == 301)
      {
        alert("Your session has expired you will be send to kft-sso.com to sign back in.")
        window.location.assign(err.response.data)
      }
      this.token = undefined,
      localStorage.removeItem("token")
    })
  }
}
</script>

