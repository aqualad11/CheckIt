<template>
  <v-form>
    <v-container class="playground">
      <v-layout align-center justify-center>
        <v-flex xs12 sm6 md3>

          <h1>Test a GetRequest with a Param</h1>
          <v-text-field
            v-model="getID"
            label="enter value"
            outline
          ></v-text-field>
          <v-btn color="success" v-on:click="getParam">Get</v-btn>

          <h1>Test Regular GetRequest</h1>
          <v-btn color="success" v-on:click="get">Get</v-btn>
          <h1>Test Password Validation</h1>
          <v-text-field
            name="id"
            id="id"
            v-model="postpw"
            type="id"
            label="password"
            outline
          ></v-text-field>
          
          <v-btn color="success" v-on:click="TestGet">Post</v-btn>
        </v-flex>

      </v-layout>
    </v-container>
  </v-form>
</template>


<script>  
import axios from "axios";
const API_URL = 'Backend';

export default {  
  data() {
    return {
      getID: null,
      postpw: null,
      postName: null,
      
    };
  },
  methods:{
    get(){
    axios.get(API_URL + "/api/user")
      .then(response => {
         console.log('successful get')
         console.log(response.data)
      })
      .catch(err => {
         console.log('error caught')
         //this.errors.push(err)
         
      })
    },
    getParam(){
    axios.get(API_URL + "/api/user/" + this.getID, {
      id: this.getID
    })
      .then(response => {
         console.log('successful get with param')
         console.log(response.data)
      })
      .catch(err => {console.log(err);
        if(err.response.status === 404){
            alert("User Not Found")
        }
        else if(err.response.status === 401){
            alert("User is Disabled")
        }
        else if(e.response.status === 400){ 
            alert("Invalid Password")
        }
        else{
            alert("Bad Request or Conflict")
        }
         
      })
    },
    TestGet () {
      axios.get(API_URL + "/api/user/test")
      .then( response => {
        console.log('Successful test! User ID = ')
        console.log(response.data)
      }).catch(err => {
        console.log("Unsuccessful test :(")
      })
    }
    /*
    CreatePost () {
      axios.post(API_URL + '/api/user/test/' {
        postedData:{
         pw: this.postpw,
        }
      })
        .then((response) => {
          console.log('Successful Post')
          console.log(response.data)


      })
      .catch(err => {console.log(err);
          if(err.response.status === 404){
              alert("User Not Found")
          }
          else if(err.response.status === 401){
              alert("User is Disabled")
          }
          else if(err.response.status === 400){ 
              alert("Invalid Password")
          }
          else{
              alert("Bad Request or Conflict")
          }
      })
  }*/
}
};

</script>
