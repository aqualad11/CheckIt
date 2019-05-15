<template>
  <div class="watchlist">

    <v-container class="justify-center">


      <v-toolbar-title>My Account Information</v-toolbar-title>
      <br>

    <v-flex xs2 sm4 md4>

      <v-card flat v-for="user in users" :key="user.uid">
        
        <v-layout row wrap :class="`pa-3 user ${user.status}`">

          <v-flex xs2 sm2 md6>
            <div class="caption grey--text">Account ID</div>
            <div>{{ user.uid }}</div>
          </v-flex>

          <v-flex xs4 sm4 md2>
            <div class="caption grey--text">Email</div>
            <div>{{ user.email }}</div>
          </v-flex>

        

        </v-layout>
        <v-divider></v-divider>
      </v-card>
    </v-flex>
    <br>
          
          
          <v-flex xs2 sm2 md5>
            <!--Make Delete method-->
            <h3>Want to delete your account?</h3>
            <v-btn small round color="warning">Delete My Account</v-btn>
          </v-flex>

    </v-container>
   
  </div>
</template>

<script>

export default {
  data() {
    return {
      users: [
        { uid: '1244', email: 'user1@gmail.com'},
      ]
    }
  }
}
</script>

