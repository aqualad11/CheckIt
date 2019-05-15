
Search or jump to…

Pull requests
Issues
Marketplace
Explore
 
@bbare 
3
1 1 aqualad11/CheckIt
 Code  Issues 0  Pull requests 0  Projects 0  Wiki  Insights
CheckIt/FrontEnd/checkit/src/components/SearchBar.vue
@Aphilay Aphilay Updated Front end
57fe190 12 hours ago
79 lines (59 sloc)  1.63 KB
    
<template>

    <v-container fill-height>
      <v-layout align-center>
        <v-flex>
          
        
        <!--search bar-->
        
        <v-text-field
            class="input is-medium is-rounded"
            v-model="searchQuery"
            outline
            dark= true
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
                  size="30"
                  color="info"
                  indeterminate
                ></v-progress-circular>
                <img v-else width="30" height="30" src="@/assets/SpyderzLogo.png" alt="">
              </v-fade-transition>
            </template>


            <template v-slot:append-outer>
              <v-btn depressed @click="clickMe">Search</v-btn>
            </template>


          </v-text-field>
        <!--end search bar-->

        </v-flex>
      </v-layout>
    </v-container> 
</template>
<script>
import axios from "axios";
import Vue from "vue"; 
const API_URL = 'http://localhost:58881';

  export default {
    data()  {
        return {
      searchQuery: null,
      userToken: "yes",
      Items: null,
    };  
    },
    methods: {
      clickMe () {
          axios.get(API_URL + "/api/search" ,{
          params:{
          searchQuery: this.searchQuery,
          userToken: this.userToken,
        } ,
        headers: {
          token: this.userToken
        }
        })
        .then(response => {
            this.Items = response.data;
            //console.log(this.Items[0][1][3].Value);
            this.$router.push({
              name: "ItemList",
              params: {
                Item : this.Items
            }
            })
        })
        .catch(err => {
            console.log(err)
        })
      }
    },
    watch: {
      Items: function() {
      return this.Items.filter(function(Item) {
        return item !== null;
      });
    }
    }
  }
</script>