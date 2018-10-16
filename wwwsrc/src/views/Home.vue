<template>
  <div class="home">
    <div class="if-loggedin" v-if="user.id">
      <h1>Welcome, {{$store.state.user.username}}!</h1>
      <button class="logout-button" @click="logout">LOGOUT</button>
    </div>
    <div class="not-logged-in" v-if="!user.id">
      <router-link tag="button" class="login-button" id="button" to="login">Log In or Register</router-link>
    </div>
    <!-- <router-link to="/login">Login</router-link> -->
    <MyVaults />
    <Keeps />
  </div>
</template>

<script>
  import Keeps from '@/views/Keeps';
  import MyVaults from '@/views/MyVaults';

  export default {
    name: "home",
    mounted() {

    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      addKeep() {
        this.$store.dispatch("addKeep", this.keep);
        this.Keep = { name: "", description: "", img: img, isPrivate: isPrivate }
      },
      logout() {
        this.$store.dispatch("logout")
      },
      // goToVaults() {
      //   this.$store.dispatch("goToVaults")
      // }

    },
    mounted() {
      this.$store.dispatch("getAllKeeps", this.vaultId)
    },
    components: {
      Keeps,
      MyVaults
    }
  };
</script>
<style scoped>
  .logout-button {
    -moz-box-shadow: 0px 1px 0px 0px #ffffff;
    -webkit-box-shadow: 0px 1px 0px 0px #ffffff;
    box-shadow: 0px 1px 0px 0px #ffffff;
    background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #ffffff), color-stop(1, #f6f6f6));
    background: -moz-linear-gradient(top, #ffffff 5%, #f6f6f6 100%);
    background: -webkit-linear-gradient(top, #ffffff 5%, #f6f6f6 100%);
    background: -o-linear-gradient(top, #ffffff 5%, #f6f6f6 100%);
    background: -ms-linear-gradient(top, #ffffff 5%, #f6f6f6 100%);
    background: linear-gradient(to bottom, #ffffff 5%, #f6f6f6 100%);
    filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffff', endColorstr='#f6f6f6', GradientType=0);
    background-color: #ffffff;
    -moz-border-radius: 6px;
    -webkit-border-radius: 6px;
    border-radius: 6px;
    border: 1px solid #dcdcdc;
    display: inline-block;
    cursor: pointer;
    color: #666666;
    font-family: Arial;
    font-size: 16px;
    font-weight: bold;
    padding: 6px 24px;
    text-decoration: none;
    text-shadow: 0px 1px 0px #ffffff;
  }

  .logout-button:hover {
    background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #f6f6f6), color-stop(1, #ffffff));
    background: -moz-linear-gradient(top, #f6f6f6 5%, #ffffff 100%);
    background: -webkit-linear-gradient(top, #f6f6f6 5%, #ffffff 100%);
    background: -o-linear-gradient(top, #f6f6f6 5%, #ffffff 100%);
    background: -ms-linear-gradient(top, #f6f6f6 5%, #ffffff 100%);
    background: linear-gradient(to bottom, #f6f6f6 5%, #ffffff 100%);
    filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#f6f6f6', endColorstr='#ffffff', GradientType=0);
    background-color: #f6f6f6;
  }

  .logout-button:active {
    position: relative;
    top: 1px;
  }
</style>