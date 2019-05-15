<template>
  <div class="watchlist">

    <v-container>

      <v-toolbar-title>My Watchlist</v-toolbar-title>
      <br>

    <v-flex xs2 sm4 md8>

      <v-card flat v-for="item in items" :key="item.name">
        
        <v-layout row wrap :class="`pa-3 user`">

          <v-flex xs2 sm2 md6>
            <div class="caption grey--text">Item</div>
            <div>{{ item.name }}</div>
          </v-flex>

          <v-flex xs4 sm4 md2>
            <div class="caption grey--text">Price</div>
            <div>{{ item.price }}</div>
          </v-flex>

         
  
            <!--Make Delete method-->
            <v-btn fab dark small color="error">
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

export default {
  data() {
    return {
      items: [
        { name: 'Computer', price: '499.99'},
        { name: 'TV', price: '299.99'},
        { name: 'Shoes', price: '99.99'},
        { name: 'Sunglgasses', price: '39.99'},
      ]
    }
  }
}
</script>

