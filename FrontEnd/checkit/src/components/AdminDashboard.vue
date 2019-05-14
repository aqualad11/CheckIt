<template>
  <v-navigation-drawer :mini-variant.sync="mini" stateless value="true" absolute floating style="height: auto; top: 81px; background-color: #fafafa;">
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

        <v-list-tile v-for="(crudItem, i) in cruds" :key="i" @click="$emit('usermanager')">
          <v-list-tile-title v-text="crudItem[0]"></v-list-tile-title>
            <v-list-tile-action>
              <v-icon v-text="crudItem[1]"></v-icon>
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

        <v-list-tile v-for="(analyticItem, i) in analytics" :key="i" :to="analyticItem[2]">
          <v-list-tile-title v-text="analyticItem[0]"></v-list-tile-title>
            <v-list-tile-action>
              <v-icon v-text="analyticItem[1]"></v-icon>
            </v-list-tile-action>
        </v-list-tile>
      </v-list-group>
    </v-list>



    
  </v-navigation-drawer>
</template>

<script>
export default {
  data: () => ({
    cruds: [
        ['Create', 'add', 'usermanager'],
        ['Read', 'insert_drive_file', 'readuser'],
        ['Update', 'update', 'updateuser'],
        ['Delete', 'delete', 'deleteuser']
    ],
    analytics: [
        ['UAD', 'info', '/uad'],
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