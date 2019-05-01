<template>
  <v-navigation-drawer
    class="blue lighten-3"
    dark
    permanent
    stateless
    value="true"
  >
    <v-list>
      <v-list-tile>
        <v-list-tile-action>
          <v-icon>dashboard</v-icon>
        </v-list-tile-action>
        <v-list-tile-title>Dashboard</v-list-tile-title>
      </v-list-tile>



      <v-list-group
        prepend-icon="account_circle"
        value="true"
      >
        <template v-slot:activator>
          <v-list-tile>
            <v-list-tile-title>User Management</v-list-tile-title>
          </v-list-tile>
        </template>

    <v-list-group
          sub-group
          no-action
        >
          <template v-slot:activator>
            <v-list-tile>
              <v-list-tile-title>CRUD Actions</v-list-tile-title>
            </v-list-tile>
          </template>
          <v-list-tile
            v-for="(crud, i) in cruds"
            :key="i"
            @click=""
          >
            <v-list-tile-title v-text="crud[0]"></v-list-tile-title>
            <v-list-tile-action>
              <v-icon v-text="crud[1]"></v-icon>
            </v-list-tile-action>
          </v-list-tile>
        </v-list-group>
      


        <v-list-group
          no-action
          sub-group
          value="true"
        >
          <template v-slot:activator>
            <v-list-tile>
              <v-list-tile-title>User Access Control</v-list-tile-title>
            </v-list-tile>
          </template>

          <v-list-tile
            v-for="(uac, i) in uacs"
            :key="i"
            @click=""
          >
            <v-list-tile-title v-text="uac[0]"></v-list-tile-title>
            <v-list-tile-action>
              <v-icon v-text="uac[1]"></v-icon>
            </v-list-tile-action>
          </v-list-tile>
        </v-list-group>

        </v-list-group>
    

    


      <v-list-group
        prepend-icon="folder_open"
        value="true"
      >
        <template v-slot:activator>
          <v-list-tile>
            <v-list-tile-title>Logs</v-list-tile-title>
          </v-list-tile>
        </template>
        <v-list-group
          no-action
          sub-group
          value="true"
        >
          <template v-slot:activator>
            <v-list-tile>
              <v-list-tile-title>Telemetry</v-list-tile-title>
            </v-list-tile>
          </template>

          <v-list-tile
            v-for="(log, i) in logs"
            :key="i"
            @click=""
          >
            <v-list-tile-title v-text="log[0]"></v-list-tile-title>
            <v-list-tile-action>
              <v-icon v-text="log[1]"></v-icon>
            </v-list-tile-action>
          </v-list-tile>
        </v-list-group>

        <v-list-group
          sub-group
          no-action
        >
          <template v-slot:activator>
            <v-list-tile>
              <v-list-tile-title>Error</v-list-tile-title>
            </v-list-tile>
          </template>
          <v-list-tile
            v-for="(log, i) in logs"
            :key="i"
            @click=""
          >
            <v-list-tile-title v-text="log[0]"></v-list-tile-title>
            <v-list-tile-action>
              <v-icon v-text="log[1]"></v-icon>
            </v-list-tile-action>
          </v-list-tile>
        </v-list-group>
      </v-list-group>
    </v-list>
</v-list>



  </v-navigation-drawer>
</template>



<script>
  export default {
    data: () => ({
      uacs: [
        ['Admins', 'account_circle'],
        ['Users', 'account_circle']
      ],
      cruds: [
        ['Create', 'add'],
        ['Read', 'insert_drive_file'],
        ['Update', 'update'],
        ['Delete', 'delete']
      ],
      logs: [
        ['Read', 'insert_drive_file'],
        ['Delete', 'delete']
      ]
    })
  }
</script>