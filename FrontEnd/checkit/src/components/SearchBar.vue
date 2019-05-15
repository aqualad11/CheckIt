<template>

    <v-container fill-height>
      <v-layout align-center>
        <v-flex>
          
        
        <!--search bar-->
        
        <v-text-field
            class="input is-medium is-rounded"
            v-model="message"
            outline
            dark="true"
            clearable
            label="Search for your item..."
            type="text"
          >
            <template v-slot:prepend>
              <v-tooltip
                bottom
              >
                <template v-slot:activator="{ on }">
                  <v-icon v-on="on">mdi-help-circle-outline</v-icon>
                </template>
                I'm a tooltip
              </v-tooltip>
            </template>
            <template v-slot:append>
              <v-fade-transition leave-absolute>
                <v-progress-circular
                  v-if="loading"
                  size="30"
                  color="info"
                  indeterminate
                ></v-progress-circular>
                <img v-else width="30" height="30" src="@/assets/SpyderzLogo.png" alt="">
              </v-fade-transition>
            </template>


            <template v-slot:append-outer>
              <v-btn depressed @click="clickMe" small round>Search</v-btn>
            </template>


          </v-text-field>
        <!--end search bar-->

        </v-flex>
      </v-layout>
    </v-container>
  
  


  
</template>





<script>
  export default {
    data: () => ({
      loading: false
    }),

    methods: {
      clickMe () {
        this.loading = true
        setTimeout(() => {
          this.loading = false
        }, 2000)
      }
    }
  }
</script>