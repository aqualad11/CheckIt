<template>
  <v-layout row>
    <v-flex xs12 sm6 offset-sm3>
      <v-card>
        <v-toolbar color="black" dark>
          <v-toolbar-side-icon></v-toolbar-side-icon>

          <v-toolbar-title>My Watchlist</v-toolbar-title>

          <v-spacer></v-spacer>


        </v-toolbar>

        <v-list>
          <v-list-group
            v-for="item in items"
            :key="item.title"
            v-model="item.active"
            :prepend-icon="item.action"
            no-action
          >

          
            <template v-slot:activator>
              
              <v-list-tile>
                
                <v-list-tile-content>
                  <v-list-tile-title>{{ item.title }}</v-list-tile-title>
                </v-list-tile-content>
              </v-list-tile>
            </template>

            <v-list-tile
              v-for="subItem in item.items"
              :key="subItem.title"
              
            >
              <v-list-tile-content>
                <v-list-tile-title>{{ subItem.title }}</v-list-tile-title>
              </v-list-tile-content>

              <!--Trigger price input box-->
          <v-flex xs5 sm4 md3>
            <v-text-field
               label="price"
                outline
                value="$"
            ></v-text-field>
           </v-flex>

        <!--Set button-->
           <v-btn small round color="primary" dark>Set</v-btn>

              <v-list-tile-action>
                <v-icon>{{ subItem.action }}</v-icon>
              </v-list-tile-action>
            </v-list-tile>
          </v-list-group>
        </v-list>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
  export default {
    data () {
      return {
        items: [
          {
            action: 'remove',
            title: 'Item 1',
            items: [
              { title: 'Trigger Price' }
            ]
          },
          {
            action: 'local_activity',
            title: 'Item 2',
            items: [
              { title: 'Trigger Price' }
            ]
          },
          {
            action: 'local_activity',
            title: 'Item 3',
            items: [
              { title: 'Trigger Price' }
            ]
          },
          {
            action: 'local_activity',
            title: 'Item 4',
            items: [
              { title: 'Trigger Price' }
            ]
          }

        ]
      }
    }
  }
</script>