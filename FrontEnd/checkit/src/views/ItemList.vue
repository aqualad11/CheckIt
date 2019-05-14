<template>
  <v-layout>
    <v-flex xs12 sm6 offset-sm3>
      <v-card>
        <v-img
          class="white--text"
          height="200px"
          src="@/assets/AmazonLogo.png"
        >
          
        
          <v-container fill-height fluid>
            <v-layout fill-height>
              <v-flex xs12 align-end flexbox>
                <span class="headline">Amazon.com</span>
              </v-flex>
            </v-layout>
          </v-container>
        </v-img>
        <v-card-title>
          <div>

            
            <span class="grey--text">Items</span><br>
            <span>Item 1 with price </span><br>
            <span>Item 2 with price</span>


          </div>
        </v-card-title>
        <v-card-actions>
          <v-btn flat color="blue">Add</v-btn>
          <v-btn flat color="orange">Explore</v-btn>
        </v-card-actions>
      </v-card>
    </v-flex>
  </v-layout>
</template>