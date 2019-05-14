<template>
  <div class="UserManagerTable">
    <v-toolbar flat color="white">
      <v-toolbar-title>User Manager</v-toolbar-title>
      <v-divider class="mx-2" inset vertical></v-divider>
      <v-spacer></v-spacer>
      <v-dialog v-model="dialog" max-width="600px">
        <template v-slot:activator="{on}">

          <v-btn @click="refreshForm" small round color="primary" dark class="mb-2" v-on="on">New User</v-btn>
        </template>
        <v-card>

          <v-card-title>
            <span class="headline">{{formTitle}}</span>
          </v-card-title>

          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>

                <v-flex xs12 sm6 md4>
                  <v-text-field
                    v-model="userid"
                    label="UserID"
                    required
                  ></v-text-field>
                </v-flex>

                <v-flex xs12 sm6 md4>
                  <v-text-field
                    v-model="username"
                    label="Username"
                    required
                  ></v-text-field>
                </v-flex>

                <v-flex xs12 sm6 md4>
                  <v-text-field
                    v-model="editedProduction.directorFirstName"
                    label="Created"
                    required
                  ></v-text-field>
                </v-flex>


              </v-layout>
            </v-container>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="close, refreshForm">Cancel</v-btn>
            <v-btn color="blue darken-1" flat @click="confirm">Confirm</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-toolbar>

    <v-data-table :headers="headers" :items="productions" class="elevation-1">
      <template v-slot:items="props">

          <a @click="editProduction(props.item), refreshForm">
            <v-btn small round color="primary" dark alt="Edit">Edit</v-btn>
          </a>
        </td>
        <td>
          <a v-on:click="deleteProduction(props.item.ProductionID)">
            <v-btn small round color="primary" dark alt="Delete">Delete</v-btn>
          </a>
        </td>

      </template>
    </v-data-table>
  </div>
</template>



<script>
import axios from "axios";
export default {
  name: "UserManager",
  data() {
    return {
      productions: [],
      dialog: false,
      file: "",
      programID: 0,
      states: [
        "AL",

      ],
      editedItem: -1,
      editedProduction: {
        userID: "",
        theaterID: 1,
        directorFirstName: "",
        directorLastName: "",
        street: "",
        city: "",
        stateProvince: "",
        zipcode: "",
        country: "United States"
      },
      defaultProduction: {
        productionName: "",
        theaterID: 1,
        directorFirstName: "",
        directorLastName: "",
        street: "",
        city: "",
        stateProvince: "",
        zipcode: "",
        country: "United States"
      },
      headers: [
        {
          text: "UserID",
          align: "right",
          value: "UserID"
        },
        {
          text: "Username",
          align: "left",
          sortable: false,
          value: "Username"
        },
        {
          text: "Created",
          align: "right",
          value: "Created"
        },
        {
          text: "Edit",
          align: "right",
          sortable: false
        },
        {
          text: "Delete",
          align: "right",
          sortable: false
        },
      ]
    };
  },
  computed: {
    formTitle() {
      return this.editedItem === -1 ? "New User" : "Edit User";
    }
  },
  watched: {
    dialog(val) {
      val || this.close();
    }
  },
  async mounted() {
    var today = new Date();
    this.getProductions(today);
  },
  methods: {
    async deleteProduction(ProductionID) {
      if (confirm("Are you sure you want to delete?")) {
        await axios
          .delete(
            "https://api.broadwaybuilder.xyz/production/delete/" + ProductionID
          )
          .then(alert("User Successfully Deleted"));
      }
    },
    async uploadProgram(ProductionID) {
      let formData = new FormData();
      formData.append("file", this.file);
      await axios
        .put(
          "https://api.broadwaybuilder.xyz/production/" +
            ProductionID +
            "/uploadProgram",
          formData
        )
        .then(function() {
          console.log("Success!");
        })
        .catch(function() {
          console.log("Failure!");
        });
    },
    async getProductions(today) {
      await axios
        .get("https://api.broadwaybuilder.xyz/production/getProductions", {
          params: {
            previousDate: today,
            // theaterID: 2,
            pageSize: 1000
          }
        })
        .then(response => (this.productions = response.data));
    },
    async createProduction(createdProduction) {
      await axios
        .post(
          "https://api.broadwaybuilder.xyz/production/create",
          createdProduction
        )
        .then(function() {
          console.log("New Production Created!");
        })
        .catch(function() {
          console.log("Failure.");
        });
    },
    onFileChange() {
      this.file = this.$refs.file.files[0];
    },
    programIDSelect(id) {
      this.programID = id;
    },
    close() {
      this.dialog = false;
      setTimeout(() => {
        this.editedProduction = Object.assign({}, this.defaultProduction);
        this.editedIndex = -1;
      }, 300);
    },
    confirm() {
      if (this.editedIndex > -1) {
        Object.assign(
          this.productions[this.editedIndex],
          this.editedProduction
        );
      } else {
        this.productions.push(this.editedProduction);
      }
      this.close();
    },
    editProduction(item) {
      this.editedIndex = 0;
      this.editedProduction = Object.assign({}, item);
      this.dialog = true;
    },
    refreshForm() {
      this.$refs.form.resetValidation();
      this.$refs.form.reset();
    }
  }
};
</script>

<style lang="sass" scoped>
img
 width: 2em
 height: 2em
</style>