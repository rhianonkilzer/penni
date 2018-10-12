<template>
    <div class="myvaults">
        <form @submit.prevent="createVault">
            <input type="text" placeholder="Name of Vault" v-model="newVault.name" required>
            <input type="text" placeholder="Description" v-model="newVault.description" required>
            <button type="submit">Create Vault</button>
        </form>
        <button @click="deleteVault(vault)">Delete Vault</button>
        <div class="vault" v-for="vault in vaults" :key="vault.id">
            <p>
                {{vault.name}}
                {{vault.description}}
            </p>
        </div>
    </div>
</template>


<script>
    export default {
        name: 'myvaults',
        data() {
            return {
                newVault: {

                }
            }
        },
        created() {
            //blocks users not logged in
            if (!this.$store.state.user.id) {
                this.$router.push({ name: "login" });
            }
            this.$store.dispatch("getAllVaults")
        },

        computed: {
            vaults() {
                return this.$store.state.vaults
            }
        },
        methods: {
            deleteVault(keep) {
                this.$store.dispatch("deleteVault", vault);
            },
            createVault() {
                this.$store.dispatch("createVault", this.newVault);
                this.newVault = { name: "", description: "" }
            },
        },
        components: {}
    }
</script>


<style scoped>

</style>