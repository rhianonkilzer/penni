<template>
  <div id="app">
    <img src="./assets/penni.png" height="200" class="penni-logo">
    <router-view />
  </div>
</template>

<style>
  #app {
    font-family: 'Roboto', sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #000000d5;
  }

  .penni-logo {
    filter: brightness(240%);
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #000000;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>