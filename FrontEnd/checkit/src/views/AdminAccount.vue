<template>
  <div id="admin-account">
    <v-container text-xs-center fluid>
      <v-layout row wrap>
        <v-flex xs3 md4>
          <AdminDashboard 
          @usermanager="viewUserManager = true; viewAnalytics = false;" 
          @uad="viewUserManager = false; viewAnalytics = true;"/>
        </v-flex>
        <v-flex xs9 md6>
          <UserManager v-if="viewUserManager" />
          <UAD v-if="viewAnalytics" />
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script>
import AdminDashboard from "@/components/AdminDashboard.vue";
import UserManager from "@/components/UserManager.vue";
import UAD from "@/views/UAD.vue";
export default {
  name: "AdminAccount",
  components: {
    AdminDashboard,
    UserManager,
    UAD
  },
  data() {
    return {
      viewUserManager: false,
      viewAnalytics: false,
    };
  },
  mounted() {},
  methods: {

    

  }
};
</script>

<style lang="sass">
a:hover
  font-weight: bold
UAD
  padding-top: 1em
</style>