<template>
  <v-form>
    <v-container class="login">
      <v-layout align-center justify-center>
        <v-flex xs12 sm6 md3>
          <h1>Login to Checkit</h1>
          <v-text-field
            label="Username"
            outline
          ></v-text-field>
           <v-text-field
            label="Password"
            outline
          ></v-text-field>
          
          <v-btn outline>Log In</v-btn>
          <v-btn to="register" outline >Register</v-btn>
          <v-btn outline>Forgot My Password</v-btn>
        </v-flex>

      </v-layout>
    </v-container>
  </v-form>
</template>

<script>
    import axios from "axios"
  
    export default {
        name: 'login',
        data() {
            return {
                input: {
                    username: "",
                    password: ""
                }
            }
        },
        methods: {
            login() {
               axios.post('Backend',
               {
                    email: this.input.username,
                    password: this.input.password
               })
               .then(i => {this.input = i.data; alert("Login Succesful"); console.log("Login Succesful"); this.$router.push('/dashboard')
                })
               .catch(e => {console.log(e);
                    if(e.response.status === 404){
                        alert("User Not Found")
                    }
                    else if(e.response.status === 401){
                        alert("User is Disabled")
                    }
                    else if(e.response.status === 400){ 
                        alert("Invalid Password")
                    }
                    else{
                        alert("Bad Request or Conflict")
                    }
            })
        }
    }
}
</script>

<style>
#login {
  padding: 100px 0;
  text-align: center;
}
</style>