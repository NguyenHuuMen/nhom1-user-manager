<template>
  <div class="wrapper">
    <parallax class="page-header header-filter" :style="headerStyle">
      <div class="md-layout">
        <div class="md-layout-item">
          <div class="image-wrapper">
            <img :src="leaf4" alt="leaf4" class="leaf4" v-show="leafShow" />
            <img :src="leaf3" alt="leaf3" class="leaf3" v-show="leafShow" />
            <img :src="leaf2" alt="leaf2" class="leaf2" v-show="leafShow" />
            <img :src="leaf1" alt="leaf1" class="leaf1" v-show="leafShow" />
            <div class="brand">
              <h1>Vue Material Kit</h1>
              <h3>A Badass Vue.js UI Kit made with Material Design.</h3>
            </div>
          </div>
        </div>
      </div>
    </parallax>
    <div class="main main-raised">
      <div class="section section-basic">
        <div class="container">
          <div class="title">
            <form class="row g-3">
              <md-field>
                <label>username</label>
                <md-input v-model="form.f_user_name" type="text"></md-input>
              </md-field>
              <md-field>
                <label>password</label>
                <md-input v-model="form.f_password" type="password"></md-input>
              </md-field>
              <div class="col-auto">
                <md-button type="submit" class="md-raised md-primary" v-on:click="addUser()">ADD</md-button>

                <!-- <md-button type="submit" class="md-raised md-primary" v-on:click="findUser(form.f_user_name)">FIND
                </md-button> -->
              </div>
            </form>


            <md-table>
              <md-table-row>
                <md-table-head>Username</md-table-head>
                <md-table-head>Password</md-table-head>
                <md-table-head>Actions</md-table-head>
              </md-table-row>
              <md-table-row v-for="(value, index) in data" :key="index">

                <md-table-cell>{{ value.userName }}</md-table-cell>
                <md-table-cell>{{ value.userPassword }}</md-table-cell>
                <md-table-cell>
                  <svg @click="deleteUser(value.id, value.userName)" xmlns="http://www.w3.org/2000/svg" width="16"
                    height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                    <path
                      d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z" />
                  </svg>
                  <svg @click="editUser(value.id)" xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                    fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                    <path
                      d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                    <path fill-rule="evenodd"
                      d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                  </svg>

                </md-table-cell>
              </md-table-row>
            </md-table>



          </div>

        </div>
      </div>
    </div>
  </div>
</template>

<script>
//import BasicElements from "./components/BasicElementsSection";
import axios from 'axios'
import { Md5 } from "md5-typescript";

export default {
  components: {

  },
  name: "index",
  bodyClass: "index-page",
  props: {
    image: {
      type: String,
      default: require("@/assets/img/vue-mk-header.jpg")
    },
    leaf4: {
      type: String,
      default: require("@/assets/img/leaf4.png")
    },
    leaf3: {
      type: String,
      default: require("@/assets/img/leaf3.png")
    },
    leaf2: {
      type: String,
      default: require("@/assets/img/leaf2.png")
    },
    leaf1: {
      type: String,
      default: require("@/assets/img/leaf1.png")
    },
    signup: {
      type: String,
      default: require("@/assets/img/city.jpg")
    },
    landing: {
      type: String,
      default: require("@/assets/img/landing.jpg")
    },
    profile: {
      type: String,
      default: require("@/assets/img/profile.jpg")
    }
  },
  data() {
    return {
      userName: "",
      form: {
        f_user_name: null,
        f_password: null,

      },
      userPassword: "",
      leafShow: false,
      data: null,

    }
  },
  methods: {
    leafActive() {
      if (window.innerWidth < 768) {
        this.leafShow = false;
      } else {
        this.leafShow = true;
      }
    },


    addUser() {


      let md5_pass = Md5.init(this.form.f_password);
      axios.post("https://localhost:44381/api/User/User",
        { userName: this.form.f_user_name, userPassword: md5_pass }).then((res) => {
          if (res.data) {
            this.data = res.data;
          }
        })
        .catch(err => alert("This username is already exist."))
    },

    editUser(userId) {
      axios.put("https://localhost:44381/api/User",
        { id: userId, userName: this.form.f_user_name, userPassword: Md5.init(this.form.f_password) }).then((res) => {
          if (res.data) {
            this.data = res.data;
          }
          window.location.reload();
        })
    },

    deleteUser(userId, userName) {
      if (userName !== localStorage.username) {
        let API_URL = "https://localhost:44381/api/User/DeleteUser?id=" + userId;
        //   const url = `${API_URL}${userId}`;
        let text = "Do you want to delele this?";
        if (confirm(text) == true) {
          axios.delete(API_URL).then((res) => {

            window.location.reload();
          });
        } else {
          text = "You canceled!";
        }

      }
      else alert("You cannot delete yourself");

    },

    findUser: async function (username) {
      let API_URL = "https://localhost:44381/api/User/";
      await axios.get(API_URL, username).then((res) => {
        if (res.data) {
          this.data = res.data;
          console.log(this.data.length);
        }
      })
      console.log(this.data);
    },



  },
  computed: {
    headerStyle() {
      return {
        backgroundImage: `url(${this.image})`
      };
    },
    signupImage() {
      return {
        backgroundImage: `url(${this.signup})`
      };
    }
  },
  mounted() {
    this.leafActive();
    window.addEventListener("resize", this.leafActive);

    axios.get("https://localhost:44381/api/User/getUser").then((res) => {
      if (res.data) {
        this.data = res.data;

      }
    })

  },
  beforeDestroy() {
    window.removeEventListener("resize", this.leafActive);
  }
};
</script>


<style lang="scss">
.section-download {
  .md-button+.md-button {
    margin-left: 5px;
  }
}

@media all and (min-width: 991px) {
  .btn-container {
    display: flex;
  }
}

svg {
  margin-right: 30px;
  cursor: pointer;
}
</style>