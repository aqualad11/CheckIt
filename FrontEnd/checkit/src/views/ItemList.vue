
<template>
  <v-container fluid grid-list-xl>
   <header>
      <h1 class="text-sm display-3 font-weight-thin " style="text-align:left; display:inline-block" >Amazon</h1>
      <h1 class="text-sm display-3 font-weight-thin " style="position: absolute; text-align:center; left: 50%;transform: translateX(-50%); display:inline-block;">BestBuy</h1>
      <h1 class="text-sm display-3 font-weight-thin " style="text-align:right; float: right; display:inline-block">Target</h1> 
      <hr style="clear:all;"> 
</header>
    <v-layout row wrap justify-space-between >
      <v-flex xs4>
        <v-card dark color="yellow darken-4" v-for="(item,index) in Items[0]" :key="index">
          <div class="ItemName">
            {{ item[2].Value }}
          </div>
          <div>
          <span class ="ItemPrice">
            {{ item[1].Value }}
            </span>
            </div>
         <v-spacer></v-spacer>
        <v-card-actions>    
           <v-spacer></v-spacer>
            <v-btn icon @click="show = !show">
            <v-icon>{{ show ? 'keyboard_arrow_down' : 'keyboard_arrow_up' }}</v-icon>
            </v-btn>
          <v-btn v-if="token !== undefined" flat color="blue"  @click="ItemAmazonItem(item)">Add</v-btn>
          <v-btn flat color="white" @click="goTo(item[3].Value)">Explore</v-btn>
        </v-card-actions>
            <v-slide-y-transition>
              <v-card-text v-show="show">
              {{ item[4].Value }}
                </v-card-text>
            </v-slide-y-transition>
        </v-card>
      </v-flex>

      <v-flex xs4>
        <v-card dark color="blue lighten-3"  v-for="(item,index) in Items[1]" :key="index">
        <div class="ItemName">
            {{ item[1].Value }}
          </div>
          <div>
          <span class ="ItemPrice">
            {{ item[2].Value }}
            </span>
            </div>
         <v-spacer></v-spacer>
        <v-card-actions>    
           <v-spacer></v-spacer>
            <v-btn icon @click="show = !show">
            <v-icon>{{ show ? 'keyboard_arrow_down' : 'keyboard_arrow_up' }}</v-icon>
            </v-btn>
          <v-btn v-if="token !== undefined" flat color="blue"  @click="ItemAdd(item)">Add</v-btn>
          <v-btn flat color="white"  @click="goTo(item[3].Value)">Explore</v-btn>
        </v-card-actions>
            <v-slide-y-transition>
              <v-card-text v-show="show">
              {{ item[4].Value }}
                </v-card-text>
            </v-slide-y-transition>
        </v-card>
      </v-flex>

      <v-flex xs4>
        <v-card dark color="red lighten-1"  v-for="(item,index) in Items[2]" :key="index">
         <div class="ItemName">
            {{ item[1].Value }}
          </div>
          <div>
          <span class ="ItemPrice">
            {{ item[2].Value }}
            </span>
            </div>
         <v-spacer></v-spacer>
        <v-card-actions>    
           <v-spacer></v-spacer>
            <v-btn icon @click="show = !show">
            <v-icon>{{ show ? 'keyboard_arrow_down' : 'keyboard_arrow_up' }}</v-icon>
            </v-btn>
          <v-btn v-if="token !== undefined" flat color="blue"  @click="ItemAdd(item)">Add</v-btn>
          <v-btn flat color="white"  @click="goTo(item[3].Value)">Explore</v-btn>
        </v-card-actions>
            <v-slide-y-transition>
              <v-card-text v-show="show">
              {{ item[4].Value }}
                </v-card-text>
            </v-slide-y-transition>
        </v-card>
      </v-flex>

    </v-layout>
  </v-container>
</template>

<script>
import axios from "axios";
import Vue from "vue"; 
const API_URL = 'Backend';
export default {
  name: "ItemList",
  data() {
    return {
      show: false,
      Items: this.$route.params.Item,
      token : this.$route.params.token
    };
  },
  methods: {
    ItemAdd(item) {
       axios.post(API_URL + "/api/user/additemtolist" ,{
          "itemName": item[1].Value,
          "price": item[2].Value,
          "url": item[3].Value,
          "picKey": null,
          "jwt": this.token
      }).then(response => {
        this.token = response.data
        console.log("added status = " + response.status)
      })
      .catch(err => {
        console.log("error = " + err)
        console.log("error content = " + err.response.data)
      })
    },
    goTo(url){
      window.open(url);
    },
     ItemAmazonItem(item) {
       axios.post(API_URL + "/api/user/additemtolist" ,{
          "itemName": item[2].Value,
          "price": item[1].Value,
          "url": item[3].Value,
          "picKey": null,
          "jwt": this.token
      }).then(response => {
        this.token = response.data
      })
      .catch(err => {
        console.log("error = " + err)
        console.log("error content = " + err.response.data)
      })
    }
  },
  beforeMount() {
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
  <style scoped>
.v-card {
  margin: 1em;
}
#content {
  margin-left: 1em;
}

</style>