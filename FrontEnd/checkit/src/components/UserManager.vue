<template>
  <div class="usermanager">

    <v-container class="my-4">

      <v-toolbar-title>User Manager</v-toolbar-title>


<!--This dialog box is what pops up when clicked edit or delete-->
<v-dialog v-model="newuserdialog" max-width="600px">

      <!--Button to open up form-->
       <template v-slot:activator="{on}">
          <v-btn @click="refreshForm" round color="primary" dark class="mb-2" v-on="on">New User</v-btn>
        </template>

        <v-card>
          <v-card-title>
            <span class="headline">New User</span>
          </v-card-title>

          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
          <!--ID Input Text-->
                <v-flex xs12 sm6 md4>
                  <v-text-field
                    v-model="userid"
                    label="UserID"
                    required
                  ></v-text-field>
                </v-flex>
            <!--Email Input Text-->
                <v-flex xs6 sm6 md4>
                  <v-text-field
                    v-model="email"
                    label="Email"
                    required
                  ></v-text-field>
                </v-flex>

                <!--Account Type Selector-->
                <v-select
                  :items="accounttype"
                  label="Account Type"
                ></v-select>


          <!--Telemetry Switch-->
              <v-switch
                v-model="telSwitch"
                color="primary"
                :label="`Telemetry: ${telSwitch.toString()}`"
                ></v-switch>

            <!--Status Switch-->
              <v-switch
                v-model="status"
                color="primary"
                :label="`Active: ${status.toString()}`"
                ></v-switch>

            <!--Feel free to add/delete text fields,switches, whatever is necessary-->


              </v-layout>
            </v-container>
          </v-card-text>
          <v-card-actions>
            

            <v-btn color="blue darken-1" flat click.native="dialog = false">Cancel</v-btn>
            
            <!--TODO: Make confirm method-->
            <v-btn color="blue darken-1" flat @click="confirm">Confirm</v-btn>
          
          </v-card-actions>
        </v-card>
      </v-dialog>
      <!--End dialog box-->
      


<!--USER MANAGER TABLE STARTS HERE-->

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
            
      <!--EDIT USER dialog box-->

    <v-dialog v-model="edituserdialog" max-width="600px">
      <!--Button to open up form-->
       <template v-slot:activator="{on}">
          <v-btn @click="refreshForm" small round color="primary" dark class="mb-2" v-on="on">Edit</v-btn>
        </template>

        <v-card>
          <v-card-title>
            <span class="headline">Edit User</span>
          </v-card-title>

          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>

          <!--ID Input Text-->
                <v-flex xs12 sm6 md4>
                  <v-text-field
                    v-model="userid"
                    label="UserID"
                    required
                  ></v-text-field>
                </v-flex>

            <!--Email Input Text-->
                <v-flex xs12 sm6 md4>
                  <v-text-field
                    v-model="email"
                    label="Email"
                    required
                  ></v-text-field>
                </v-flex>

                <!--Account Type Selector-->
                <v-select
                  :items="accounttype"
                  label="Account Type"
                ></v-select>


          <!--Telemetry Switch-->
              <v-switch
                v-model="telSwitch"
                color="primary"
                :label="`Telemetry: ${telSwitch.toString()}`"
                ></v-switch>

            <!--Status Switch-->
              <v-switch
                v-model="status"
                color="primary"
                :label="`Active: ${status.toString()}`"
                ></v-switch>

            <!--Feel free to add/delete text fields,switches, whatever is necessary-->


              </v-layout>
            </v-container>
          </v-card-text>
          <v-card-actions>
            

            <v-btn color="blue darken-1" flat click.native="dialog = false">Cancel</v-btn>
            
            <!--TODO: Make confirm method-->
            <v-btn color="blue darken-1" flat @click="confirm">Confirm</v-btn>
          
          </v-card-actions>
        </v-card>
      </v-dialog>
      <!--End edit dialog box-->


      <!--Delete Button-->
            <v-btn small round color="primary" @click="deleteUser">delete</v-btn>
          </v-flex>

        </v-layout>
        <v-divider></v-divider>
      </v-card>

    </v-container>
   
  </div>
</template>

<script>

const API_URL = 'Backend';

export default {
  data() {
    return {
      name: "usermanager",
      dialog: false,
      telSwitch: true,
      status: true,
      editedUser: -1,
      accounttype: ['System Admin', 'Admin', 'User'],
      users: [
        { uid: '1111', email: 'user111@gmail.com', dataCollection: 'true', accountType: 'Admin', status: 'active'},
        { uid: '1111', email: 'user111@gmail.com', dataCollection: 'true', accountType: 'Admin', status: 'inactive'},
        { uid: '1111', email: 'user111@gmail.com', dataCollection: 'true', accountType: 'Admin', status: 'active'},
        { uid: '1111', email: 'user111@gmail.com', dataCollection: 'true', accountType: 'User', status: 'active'},
      ]
    }
  },
methods:{
    refreshForm() {
      this.$refs.form.resetValidation();
      this.$refs.form.reset();
    },
    async deleteUser(  ) {
      if (confirm("Are you sure you want to delete this user?")) {
        await axios
          .delete(
            "API_URL" + UserID
          )
          .then(alert("User Successfully Deleted"));
      }
    },
    editUser( ) {
      alert("Clicked edit")
      
    },
    close() {
 this.close();
    },
computed: {
    formTitle() {
      return this.editedItem === -1 ? "New User" : "Edit User";
    }
  },
  watch: {
    dialog() {
        this.$refs.form.reset()
    }
}


  }
};
</script>



<style>
.user.active{
  border-left: 4px solid #3CD1C2;
}
.user.inactive{
  border-left: 4px solid tomato;
}
</style>