<template>
<div>
   <h1 class="text-lg-center font-weight-bold display-3">Search Results
   </h1>
  <v-layout row wrap>
    <v-flex xs12 sm6 offset-sm3 v-for="(item,index) in amazonItems" :key="index">
      <v-card>
          <v-card-title primary-title>
          <div class="ItemName">
            {{ item[2].Value }}
          </div>
          <div>
          <span class ="ItemPrice">
            {{ item[1].Value }}
            </span>
            </div>
            <div>
          <a v-bind:href= "url"> {{item[3].Value}} </a>
          </div>
         <v-spacer></v-spacer>
        <v-card-actions>    
           <v-spacer></v-spacer>
            <v-btn icon @click="show = !show">
            <v-icon>{{ show ? 'keyboard_arrow_down' : 'keyboard_arrow_up' }}</v-icon>
            </v-btn>
          <v-btn flat color="blue"  @click="ItemAdd(item)">Add</v-btn>
          <v-btn flat color="orange">Explore</v-btn>
        </v-card-actions>
          </v-card-title>
            <v-slide-y-transition>
              <v-card-text v-show="show">
              {{ item[4].Value }}
                </v-card-text>
            </v-slide-y-transition>
      </v-card>

    </v-flex>
  </v-layout>
  </div>
</template>

<script>
import axios from "axios";
import Vue from "vue"; 
export default {
  name: "ItemList",
  data() {
    return {
      show: false,
      amazonItems: this.$route.params.amazonItem
    };
  },
  methods: {
    ItemAdd(item) {
      this.$router.push({
        name: "",
        params: {
          name: item[2].Value,
          price: item[1].Value,
          url: item[3].Value
        }
      });
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