<template>


  <v-navigation-drawer app v-model="drawer" :mini-variant.sync="mini" floating
        permanent
        stateless value="true" absolute style="height: auto; top: 81px; background-color: #fafafa;">
    <v-list>
      <v-list-tile>
        <v-list-tile-action>
        
          <v-btn icon @click.stop="miniMode">
            <v-icon>dashboard</v-icon>
          </v-btn>
        </v-list-tile-action>
        <v-list-tile-title>System Admin Dashboard</v-list-tile-title>
      </v-list-tile>



    <!--User Management Section-->
      <v-list-group sub-group no-action v-model="userManagementDropdownState">
        <template v-slot:activator>
          <v-list-tile>
            <v-list-tile-title>User Management</v-list-tile-title>
          </v-list-tile>
        </template>
                      <!--for later use, router :to="crudItem.route" -->
        <v-list-tile v-for="crudItem in cruds" :key="crudItem.title" @click="$emit(crudItem.route)">
          <v-list-tile-title v-text="crudItem.title"></v-list-tile-title>
            <v-list-tile-action>
              <v-icon v-text="crudItem.icon"></v-icon>
            </v-list-tile-action>
        </v-list-tile>
      </v-list-group>

      <!--Analytics-->
      
      <v-list-group sub-group no-action v-model="AnalyticsDropdownState">
        <template v-slot:activator>
          <v-list-tile>
            <v-list-tile-title>Analytics</v-list-tile-title>
          </v-list-tile>
        </template>

        <v-list-tile v-for="analyticItem in analytics" :key="analyticItem.title" @click="$emit(analyticItem.route)">
          <v-list-tile-title v-text="analyticItem.title"></v-list-tile-title>
            <v-list-tile-action>
              <v-icon v-text="analyticItem.icon"></v-icon>
            </v-list-tile-action>
        </v-list-tile>
      </v-list-group>
    </v-list>
    
  </v-navigation-drawer>

</template>

<script>
export default {
  data: () => ({
    drawer: true,
    cruds: [
        {title: 'CRUD', icon: 'person', route: 'usermanager'},
    ],
    analytics: [
        {title: 'UAD', icon: 'info', route: 'uad'},
    ],

    mini: false,
    userManagementDropdownState: true,
    AnalyticsDropdownState: true
  }),
  methods: {
    miniMode() {
      this.mini = !this.mini;
      if (!this.mini) {
        this.userManagementDropdownState = true;
        this.AnalyticsDropdownState = true;
      } else {
        this.userManagementDropdownState = false;
        this.AnalyticsDropdownState = false;
      }
    }
  }
};

</script>