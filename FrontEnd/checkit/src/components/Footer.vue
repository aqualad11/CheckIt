<template>
  <v-footer height="auto" lighten-1>
    <v-layout class="footer" justify-center row wrap>
      <v-btn v-for="(route, index) in linkRoute" :key="index" :to="route.link" color="white" flat>
        {{ route.title }}
      </v-btn>
      <v-flex class="footer" lighten-2 py-3 text-xs-center white--text xs12>
        &copy;2019 — <strong white--text>Spyderz-CheckIt</strong>
      </v-flex>
    </v-layout>
  </v-footer>
</template>

<script>
export default {
  data: function() {
    return {
      linkRoute: [
        { title: "Quick Start", link: "/usermanual" },
        { title: "FAQ", link: "/faq" },
        { title: "Terms of Service", link: "/terms" },
        { title: "Contact Us", link: "/contactus" }
      ]
    };
  }
};

</script>

<style lang="css" scoped>
@import url("https://fonts.googleapis.com/css?family=Roboto");
.footer {
  color: white;
  background: linear-gradient(to right, #9D8C0E, #000);
}
</style>