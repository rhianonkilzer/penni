<template>
    <div class="vault">
        <h3>
            {{vault.name}}
        </h3>
        <p v-for="keep in keeps" :key="keep.id">

            {{keep.name}}
            <button @click="deleteVaultKeep(keep)">Remove</button>
        </p>


    </div>
</template>
<script>
    export default {
        name: "vault",
        data() {
            return {

            }
        },
        created() {
            // if (!this.$store.state.user._id) {
            //     this.$router.push({ name: "login" });
            // }

        },
        computed: {
            vault() {
                return this.$store.state.activeVault
            },
            keeps() {
                return this.$store.state.vaultKeeps
            }
        },
        mounted() {
            this.$store.dispatch("getVault", this.$route.params.vaultId)
            this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId)
        },
        methods: {
            deleteVaultKeep(keep) {
                let vaultKeep = {
                    keepId: keep.id,
                    vaultId: this.vault.id
                }
                this.$store.dispatch("deleteVaultKeep", vaultKeep)

            }
        }

    }


</script>
<style>

</style>