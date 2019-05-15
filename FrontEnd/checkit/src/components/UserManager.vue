<template>
  <div class="usermanager">

    <v-container class="my-4">

        <!--This dialog box is what pops up when clicked edit or delete-->
<v-dialog v-model="dialog" max-width="600px">


        <v-card>

          <v-card-title>
            <span class="headline">{{formTitle}}</span>
          </v-card-title>

          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>

                <v-flex xs12 sm6 md4>
                  <v-text-field
                    v-model="userid"
                    label="UserID"
                    required
                  ></v-text-field>
                </v-flex>

                <v-flex xs12 sm6 md4>
                  <v-text-field
                    v-model="email"
                    label="Email"
                    required
                  ></v-text-field>
                </v-flex>

            <!--Feel free to add more text fields, whatever is necessary-->








              </v-layout>
            </v-container>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="close, refreshForm">Cancel</v-btn>
            <v-btn color="blue darken-1" flat @click="confirm">Confirm</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <!--End dialog box-->



      <v-toolbar-title>User Manager</v-toolbar-title>

      
      <!-- TODO: MAKE newUser method-->
       <v-btn @click="newUser" small round color="primary" dark class="mb-2" v-on="on">New User</v-btn>

       <template v-slot:activator="{on}">
          <v-btn @click="refreshForm" color="primary" dark class="mb-2" v-on="on">New Production</v-btn>
        </template>

      <v-card flat v-for="user in users" :key="user.uid">
        
        <v-layout row wrap :class="`pa-3 user ${user.status}`">

          <v-flex xs2 sm2 md2>
            <div class="caption grey--text">User ID</div>
            <div>{{ user.uid }}</div>
          </v-flex>

          <v-flex xs4 sm4 md2>
            <div class="caption grey--text">Email</div>
            <div>{{ user.email }}</div>
          </v-flex>

          <v-flex xs2 sm2 md2>
            <div class="caption grey--text">Telemetry</div>
            <div>{{ user.dataCollection }}</div>
          </v-flex>

          <v-flex xs2 sm2 md2>
            <div class="caption grey--text">Account Type</div>
            <div>{{ user.accountType }}</div>
          </v-flex>

          <v-flex xs2 sm2 md2>
            <div class="caption grey--text">Status</div>
            <div>{{ user.status }}</div>
          </v-flex>

          <v-flex xs2 sm2 md1>
            <v-btn small round color="primary">edit</v-btn>
            <v-btn small round color="primary">delete</v-btn>
          </v-flex>

        </v-layout>
        <v-divider></v-divider>
      </v-card>

    </v-container>
   
  </div>
</template>

<script>
import { METHODS } from 'http';
export default {
  data() {
    return {
      users: [
        { uid: '1111', email: 'user111@gmail.com', dataCollection: 'true', accountType: 'Admin', status: 'active'},
        { uid: '1111', email: 'user111@gmail.com', dataCollection: 'true', accountType: 'Admin', status: 'inactive'},
        { uid: '1111', email: 'user111@gmail.com', dataCollection: 'true', accountType: 'Admin', status: 'active'},
        { uid: '1111', email: 'user111@gmail.com', dataCollection: 'true', accountType: 'User', status: 'active'},
      ]
    }
  }
}
</script>

<style>
.user.active{
  border-left: 4px solid #3CD1C2;
}
.user.inactive{
  border-left: 4px solid tomato;
}
</style>