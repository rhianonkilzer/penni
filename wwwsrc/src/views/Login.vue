<template>


    <div class="login">
        <form v-if="loginForm" @submit.prevent="loginUser">
            <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <button type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">No account? Click to Register</p>
            <p v-else>Already have an account? click to Login</p>
        </div>
        <router-link tag="button" class="home-button" id="button" to="home">Dashboard</router-link>
        <!-- <router-link to="/home">Home</router-link> -->
    </div>
</template>

<script>
    export default {
        name: "login",
        mounted() {
            //checks for valid session
            this.$store.dispatch("authenticate");
        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            },

        }
    };
</script>
<style scoped>
    body {
        background-color: rgba(0, 0, 0, 0.712);
        color: white;
        text-shadow: 0px 2px 6px black;
    }
</style>