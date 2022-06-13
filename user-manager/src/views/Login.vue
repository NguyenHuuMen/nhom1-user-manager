<template>
  <div class="wrapper">
    <div class="section page-header header-filter" :style="headerStyle">
      <div class="container">
        <div class="md-layout">
          <div class="md-layout-item md-size-33 md-small-size-66 md-xsmall-size-100 md-medium-size-40 mx-auto">
            <login-card header-color="green">
              <h4 slot="title" class="card-title">Login</h4>
              <md-field class="md-form-group" slot="inputs">
                <md-icon>face</md-icon>
                <label>Username...</label>
                <md-input v-model="login.l_username"></md-input>
              </md-field>

              <md-field class="md-form-group" slot="inputs">
                <md-icon>lock_outline</md-icon>
                <label>Password...</label>
                <md-input v-model="login.l_password" type="password"></md-input>
              </md-field>
              <md-button slot="footer" class="md-simple md-success md-lg" @click="loginFunction()">
                Get Started
              </md-button>
            </login-card>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
import { LoginCard } from "@/components";
import router from "@/router";

import axios from 'axios';
import { Md5 } from "md5-typescript";

export default {
  components: {
    LoginCard,
  },
  bodyClass: "login-page",
  data() {
    return {
      login: {
        l_username: null,
        l_password: null,
      },
      error: null,
      success: false,
    };
  },

  methods: {
    loginFunction() {

      let test_user = this.login.l_username;
      let test_password = Md5.init(this.login.l_password);

      const url = "https://localhost:44381/api/User/login?userName=" + test_user + "%20&userPassword=" + test_password;
      this.success = false;
      this.error = null;

      try {
        const res = axios.get(url).then((res) => {
          if (res.status === 200) {
            console.log(url);
            this.success = true;

            if (!localStorage.hasOwnProperty("login"))
              localStorage.setItem("login", false);
            localStorage.setItem("login", true);
            localStorage.setItem("username", this.login.l_username);
            router.push('/');
          }
        })

      } catch (err) {
        this.error = err.message;
        console.log(this.error);
      }
    }
  },

  props: {
    header: {
      type: String,
      default: require("@/assets/img/profile_city.jpg")
    }
  },
  computed: {
    headerStyle() {
      return {
        backgroundImage: `url(${this.header})`
      };
    }
  }
};
</script>

<style lang="css">
</style>
