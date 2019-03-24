<template>
  <v-toolbar app>
    <img src="@/assets/SpyderzLogo.png" alt="" width = 75 height = 65>
    <v-toolbar-title class="headline text-uppercase">
      <v-btn to="/" flat>CHECKIT</v-btn>
      <!--span>CHECKIT</span-->
    </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-btn to="/" flat>Home</v-btn>
    <v-btn to="hotdeals" flat>Hot Deals!</v-btn>
    <v-btn to="about" flat>About</v-btn>
    <v-btn to="login" flat>Login</v-btn>
    <v-btn to="register" flat>Register</v-btn>
    <v-btn to="playground" flat>Playground</v-btn>
  </v-toolbar>
</template>
<script>
export default {
  name: 'NavBar'
}
</script>