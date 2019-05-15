<template>
  <div id="home">
    
      <v-containerfluid grid-list-md>
        
          <v-layout class="home" align-center column justify-center>
            
            <h1 class="display-3 font-weight-thin mb-3">CheckIt</h1>
            <h4 class="subheading">Where you can keep track of your shopping prices!</h4>
           
           <!--Call search bar component-->
            <SearchBar />


            <!--Eventually use this div, this removes the buttons if user is logged in
            <div v-if="!User.token" style="margin: 4em 1em"> -->
            <div style="margin: 4em 1em">
              <br>
              <v-btn href="https://kfc-sso.com/#/register" round >Register</v-btn>
              
              <v-btn href="https://kfc-sso.com/#/login" round>Sign In</v-btn>
            <v-divider></v-divider>
            </div>

            <!--TODO: SHOW THIS BUTTON AFTER LOG IN-->
            <v-btn router to="/watchlist" round>View My Watchlist</v-btn>
          <v-divider></v-divider>

          </v-layout>
       
      </v-containerfluid>
    
  </div>
</template>

<script>

import SearchBar from "@/components/SearchBar.vue";
export default {
  name: "home",
  components: {
    SearchBar
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