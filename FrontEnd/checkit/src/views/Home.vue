<template>
  <div class="home">
    <h1>Homepage</h1>
  </div>
</template>

<script>
  export default {
    name: 'home',
    props: ['token'],
    data() {
      return
    },
    methods: {
      login() {
        if(this.token !== undefined) {
          console.log("we've got the token mr president: " + this.token)
        }
      }
    },
    beforeMount() {
      this.login()
    }

  };

</script>