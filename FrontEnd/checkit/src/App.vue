<template>
  <v-app id="app">
    <div class="site">
      <NavBar />

      <div class="site-content">
        <router-view />
      </div>
      
      <Footer />
    </div>
  </v-app>
</template>

<script>
import NavBar from '@/components/NavBar'
import Footer from '@/components/Footer'
export default {
  name: 'App',
  components: {
      NavBar,
      Footer
  },
  data () {
    return {
    }
  }
}
</script>

<style lang="sass">
@import url('https://fonts.googleapis.com/css?family=Roboto');
#app
  font-family: Roboto;
  
.site
  display: flex;
  min-height: 100vh;
  flex-direction: column;
.site-content
  flex: 1;
</style>
