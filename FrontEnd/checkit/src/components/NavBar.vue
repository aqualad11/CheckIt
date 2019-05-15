<template>
  <div>
    <!-- The entire navbar options and dropdown menu (navigation hamburger) -->
    <v-toolbar class="hidden-sm-and-down" style="padding: 0 2em; color: white; background: linear-gradient(to right, #9D8C0E, #000);">
      
      <!--Logo click-->
      <v-btn title size="14" color="white" flat big round to="/">Check It</v-btn>
      <v-spacer></v-spacer>

      <!-- Displays the links that route to other pages -->
      <v-toolbar-items v-for="(route, index) in pageRoutes" :key="index">
        <v-btn :to="route.link" flat>
          <span class="color-white">
            {{ route.title }}
          </span>
        </v-btn>
      </v-toolbar-items>
    </v-toolbar>

    <v-toolbar class="hidden-md-and-up" style="padding: 0 0em; color: white; background: linear-gradient(to right, #609D8C0E148D, #000);">
      <v-toolbar-title>CheckIt</v-toolbar-title>
      <v-spacer></v-spacer>

      <!-- When on a smaller screen, a navigation hamburger will show up -->
      <v-menu class="hidden-md-and-up" transition="slide-y-transition" bottom left>
        <!-- Shows the hamburger icon when on a small screen -->
        <template v-slot:activator="{ on }">
          <v-toolbar-side-icon v-on="on" right style="color: white;"></v-toolbar-side-icon>
        </template>
        <!-- Using the list of destinations, display and route to the page link -->
        <v-list v-for="(route, index) in pageRoutes" :key="index">
          <v-list-tile>
            <v-btn :to="route.link" flat block>
              <span class="color-black">
                {{ route.title }}
              </span>
            </v-btn>
          </v-list-tile>
        </v-list>
      </v-menu>
    </v-toolbar>
  </div>
</template>

<script>
export default {
  data: function() {
    return {
      pageRoutes: [
        { title: "Home", link: "/" },
        { title: "Account", link: "/admin" },
      ]
    };
  }
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css?family=Roboto");
.color-white {
  color: white;
}
.color-black {
  color: black;
}
</style>